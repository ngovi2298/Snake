using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace gamesnake
{
    class Food
    {
        private int x, y, witht, height;
        private SolidBrush brush;
        public Rectangle foodRec;
        public Food(Random randFood)
        {
            x = randFood.Next(0, 25) * 10;
            y = randFood.Next(0, 25) * 10;
            brush = new SolidBrush(Color.Black);
            witht = 10;
            height = 10;
            foodRec = new Rectangle(x, y, witht, height);

        }
        public void foodLocation(Random randFood)
        {
            x = randFood.Next(0, 25) * 10;
            y = randFood.Next(0, 25) * 10;
        }
       public void drawFood(Graphics paper)
        {
            foodRec.X = x;
            foodRec.Y = y;
            paper.FillEllipse(brush, foodRec);
        }
    }
}
