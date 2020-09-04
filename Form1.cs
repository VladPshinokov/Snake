using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Snake
{
    public partial class Form1 : Form
    {
        
        //Создание объектов: змеи и еды

        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        private int maxXPos;
        private int maxYPos;

        //Счетчик первого запуска

        private static bool firstStart;

        public Form1()
        {
            InitializeComponent();

            //Задание первоначальных параметров игры

            new Settings();
            firstStart = true;

            maxXPos = pbSnakeWindow.Size.Width / Settings.Width;
            maxYPos = pbSnakeWindow.Size.Height / Settings.Height;

            //Установка таймера, определяющего движение змеи (через вызов функции UpdateScreen(), обновляющей ее положение в окне) 

            gameTimer.Interval = 1000 / Settings.Speed;
            gameTimer.Tick += UpdateScreen;

            //Запуск игры

            StartGame();

        }

        //-----------------------------------------------------------------------------------------------

        private void StartGame()
        {
            //Для случая повторного начала игры (т.е. мы не попадаем в конструктор) задаем также настройки игры по умолчанию

            if (!firstStart)
            {
                new Settings();

                maxXPos = pbSnakeWindow.Size.Width / Settings.Width;
                maxYPos = pbSnakeWindow.Size.Height / Settings.Height;
            }
            firstStart = false;

            Input.clearHashtable();

            // Запускаем таймер

            gameTimer.Start();

            //Создание змеи

            Snake.Clear(); //для случая повторного начала игры освобождаем список, представляющий змею
            Circle headSnake = new Circle();
            headSnake.X = 10;
            headSnake.Y = 5;
            Snake.Add(headSnake);

            lblScore.Text = Settings.Score.ToString();
            GenerateFood();

        }

        //-----------------------------------------------------------------------------------------------

        // Рандомное размещение еды в окне

        // Реализация через проверку условия

        private void GenerateFood()
        {
            Random random = new Random();
            bool bFind;

            do
            {
                bFind = false;

                food.X = random.Next(0, maxXPos);
                food.Y = random.Next(0, maxYPos);

                for (int i = 0; i < Snake.Count; i++)
                {
                    if (food.X == Snake[i].X && food.Y == Snake[i].Y)
                    {
                        bFind = true;
                    }
                }
            }
            while (bFind);
        }

        // Реализация через рекурсию

        //private void GenerateFood()
        //{
        //    Random random = new Random();

        //    food.X = random.Next(0, maxXPos);
        //    food.Y = random.Next(0, maxYPos);

        //    for (int i = 0; i < Snake.Count; i++)
        //    {
        //        if (food.X == Snake[i].X && food.Y == Snake[i].Y)
        //        {
        //            food.X = random.Next(0, maxXPos);
        //            food.Y = random.Next(0, maxYPos);
        //            RecursionCountCoordinate(ref random, i);
        //        }
        //    }

        //}

        //private void RecursionCountCoordinate(ref Random random, int index)
        //{ 
        //    for (int i = 0; i < index; i++)
        //    {
        //        if (food.X == Snake[i].X && food.Y == Snake[i].Y)
        //        {
        //            food.X = random.Next(0, maxXPos);
        //            food.Y = random.Next(0, maxYPos);
        //            RecursionCountCoordinate(ref random, i);
        //        }
        //    }
        //}

  
        //-----------------------------------------------------------------------------------------------

        private void UpdateScreen(object sender, EventArgs e)
        {
            {
                if (Input.keyPressed(Keys.Left) && Settings.direction != Direction.Right)
                    Settings.direction = Direction.Left;
                else if (Input.keyPressed(Keys.Right) && Settings.direction != Direction.Left)
                    Settings.direction = Direction.Right;
                else if (Input.keyPressed(Keys.Up) && Settings.direction != Direction.Down)
                    Settings.direction = Direction.Up;
                else if (Input.keyPressed(Keys.Down) && Settings.direction != Direction.Up)
                    Settings.direction = Direction.Down;

                // Определяем какая нажата клавиша (куда дальше двигаться змее) и вызываем метод, двигающий змею

                MovePlayer();
            }

            pbSnakeWindow.Invalidate();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //-----------------------------------------------------------------------------------------------

        private void pbSnakeWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            if (!Settings.GameOver)
            {

                foreach(var obj in Snake)
                {
                    canvas.FillEllipse(Brushes.Green,
                        new Rectangle(obj.X * Settings.Width,
                                      obj.Y * Settings.Height,
                                      Settings.Width, Settings.Height));
                }

                canvas.FillEllipse(Brushes.Red,
                        new Rectangle(food.X * Settings.Width,
                                      food.Y * Settings.Height,
                                      Settings.Width, Settings.Height));

            }
            else
            {
                // Останавливаем таймер (чтобы прекратить обновление экрана), выводим сообщение и запускаем заново игру

                gameTimer.Stop();

                string gameOver = "Game over!\nYour final score is " + Settings.Score + "\nDo you want to start a new game?";
                
                if (MessageBox.Show(gameOver, null, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    StartGame();
                else 
                    MessageBox.Show("There was funny moments, thanks for gaming");
            }
        }

        //-----------------------------------------------------------------------------------------------

        private void MovePlayer()
        {
            // Цикл организовываем с конца змеи, сначала двигаем все тело, затем двигаем голову
            // и определяем, нет ли столкновения с границами, телом или едой

            for (int i = (Snake.Count - 1); i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[0].X++;
                            break;
                        case Direction.Left:
                            Snake[0].X--;
                            break;
                        case Direction.Up:
                            Snake[0].Y--;
                            break;
                        case Direction.Down:
                            Snake[0].Y++;
                            break;
                    }

                    //Столкновние с границами

                    if (Snake[0].X < 0 || Snake[0].X >= maxXPos ||
                        Snake[0].Y < 0 || Snake[0].Y >= maxYPos)
                        Die();

                    //Столкновение головы с телом

                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[0].X == Snake[j].X && Snake[0].Y == Snake[j].Y)
                            Die();
                    }

                    //Столкновение с едой

                    if (Snake[0].X == food.X && Snake[0].Y == food.Y)
                        Eat();

                }
                else
                {
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Input.changeState(e.KeyCode, false);
        }

        private void Die()
        {
            Settings.GameOver = true;
        }

        //-----------------------------------------------------------------------------------------------

        private void Eat()
        {
            // Создаем новый объект с координатами последнего элемента змейки, добавляем его в список Snake, при этом по факту отрисовка
            // нового добалвенного элемента (его отображение на игровом поле) будет выполнена с задержкой на интервал таймера, т.к. необходимо
            // сдвинуть змейку заново на один ход, чтобы увидеть добавленный элемент
            
            Circle food = new Circle();
            food.X = Snake[Snake.Count - 1].X;
            food.Y = Snake[Snake.Count - 1].Y;

            Snake.Add(food);

            // Увеличиваем счет, изменяем значение метки на форме

            Settings.Score += Settings.Points;
            lblScore.Text = Settings.Score.ToString();

            // Усложнение игры через увеличение скорости и уменьшение масштаба

            if (Settings.Score == 500)
            {
                Settings.Width = 30;
                Settings.Height = 30;

                Settings.Speed = 16;

                maxXPos = pbSnakeWindow.Size.Width / Settings.Width; // заново вычисляем эти значения для метода GenerateFood
                maxYPos = pbSnakeWindow.Size.Height / Settings.Height;
            }
            else if (Settings.Score == 1000)
            {
                Settings.Width = 20;
                Settings.Height = 20;

                Settings.Speed = 25;

                maxXPos = pbSnakeWindow.Size.Width / Settings.Width;  // заново вычисляем эти значения для метода GenerateFood
                maxYPos = pbSnakeWindow.Size.Height / Settings.Height;
            }
            else if (Settings.Score == 1500)
            {
                Settings.Speed = 100;
            }

            // Создаем новый объект еды

            GenerateFood();

        }

        
    }
}
