using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gamesnake
{
    public partial class Form1 : Form
    {
        int score = 0;
        Random randFood = new Random();
        Food food;
        Graphics paper;
        Snake snake = new Snake();
        Boolean left = false, right = false, up = false, down = false;


        public Form1()
        {
            InitializeComponent();
            food = new Food(randFood);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            food.drawFood(paper);
            snake.drawSnake(paper);
            
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        if (e.KeyData == Keys.Space)
            {
                timer1.Enabled = true;
                left = false; right = false; up = false; down = false;
                
            }
            if(e.KeyData==Keys.Up && down ==false)
            {
                up = true;
                down = false;
                left = false;
                right = false;
            }
            if (e.KeyData == Keys.Down && up == false)
            {
                up = false;
                down = true;
                left = false;
                right = false;
            }
            if (e.KeyData == Keys.Left && right == false)
            {
                up = false;
                down = false;
                left = true;
                right = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                up = false;
                down = false;
                left = false;
                right = true;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (down == true) { snake.moveDown(); }
            if (up == true) { snake.moveUp(); }
            if (left == true) { snake.moveLeft(); }
            if (right == true) { snake.moveRight(); }
            for (int i = 0; i < snake.SnakeREC.Length; i++)
            {
                if (snake.SnakeREC[i].IntersectsWith(food.foodRec))
                {
                    score += 10;
                    snake.growSnake();
                    food.foodLocation(randFood);
                }
            }
            collison();
            this.Invalidate();

        }
        public void collison()
        {
            for(int i=1;i<snake.SnakeREC.Length;i++)
            {
                if(snake.SnakeREC[0].IntersectsWith(snake.SnakeREC[i]))
                {
                    Restart();
                }
            }
            if (snake.SnakeREC[0].Y < 0 || snake.SnakeREC[0].Y > 250) 
            {
                Restart();
            }
            if (snake.SnakeREC[0].X < 0 || snake.SnakeREC[0].X > 280)
            {
                Restart();
            }
        }
        void Restart()
        {
            timer1.Enabled = false;
            score = 0;
            MessageBox.Show($"you die !!{score.ToString()}");
            snake = new Snake();
        }
    }
}
