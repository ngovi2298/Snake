using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace gamesnake
{
    class Snake
    {
        private Rectangle[] snakeREC;
        public Rectangle[] SnakeREC
        {
            get
            {
                return snakeREC;
            }
        }
        
        
        private SolidBrush brush;
        private int x, y, width, height;
        // craete snake
        public Snake()
        {
            snakeREC = new Rectangle[3];
            brush = new SolidBrush(Color.Black);
            x = 20;y = 0;width = 10;height = 10;
            for(int i=0;i<snakeREC.Length;i++)
            {
                snakeREC[i] = new Rectangle(x, y, width, height);
                x -= 10;
            }
        }
        public void drawSnake(Graphics paper)
        {
            foreach(Rectangle rec in snakeREC)
            {
                paper.FillEllipse(brush, rec);
            }
        }
        //Snake move
        public void drawSnakeRun()
        {
            for(int i=snakeREC.Length-1;i>0;i--)
            {
                snakeREC[i] = snakeREC[i - 1];
            }
        }
        public void moveDown()
        {
            drawSnakeRun();
            snakeREC[0].Y += 1;
        }
        public void moveUp()
        {
            drawSnakeRun();
            snakeREC[0].Y -= 1;
        }
        public void moveRight()
        {
            drawSnakeRun();
            snakeREC[0].X += 1;
        }
        public void moveLeft()
        {
            drawSnakeRun();
            snakeREC[0].X -= 1;
        }
        public void growSnake()
        {
            List<Rectangle> rec = snakeREC.ToList();
            rec.Add(new Rectangle(snakeREC[snakeREC.Length - 1].X, snakeREC[snakeREC.Length - 1].Y, width, height));
            snakeREC = rec.ToArray();
        }
    }
}
