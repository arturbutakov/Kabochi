using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace Kabochi
{
    class Wall: DrawableObject
    {

        public Brush wallBrush;
        public  Wall(float x_m, float y_m, float scale_m)
        {
            drawable = true;
            solid = true;
            movable = true;
            collidable = true;
            delete = false;
            position = new System.Windows.Point(x_m, y_m);
            width = height = scale_m * 32;
            wallBrush = Brushes.Green;

        }
        public override void Draw(BufferedGraphics grafx, float x, float y)
        {
            grafx.Graphics.FillRectangle(this.wallBrush, x, y, width, height);
        }
        public override void CollisionWith(DrawableObject b)
        {
            //base.CollisionWith(b);
            if (b.GetType().Name == "Bullet")
            {
                this.delete = true;
                //this.bulletBrush = System.Drawing.Brushes.Red;
            }
        }
    }
}
