using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace Kabochi
{
    class Bullet: DrawableObject
    {
        public Brush bulletBrush;
        public Bullet (float x_m, float y_m, float scale_m)
        {
            drawable = true;
            movable = true;
            solid = true;
            delete = false;
            depth = 0;
            _angle = 180;
            _speed = 5.0f;
            CalculateVector();
            position = new System.Windows.Point(x_m, y_m);
            width = height = scale_m * 5;
            bulletBrush = Brushes.Yellow;
        }
        override public void Draw(BufferedGraphics grafx, float x, float y)
        {
            grafx.Graphics.FillEllipse(bulletBrush, x, y, width, height);

        }
        public override void CollisionWith(DrawableObject b)
        {
            //base.CollisionWith(b);
            if (b.GetType().Name == "Wall")
            {
                this.delete = true;
                //this.bulletBrush = System.Drawing.Brushes.Red;
            }
        }
        override public void Update(Core.GameLogic gameLogic)
        {
            if (position.Y > gameLogic.stageHeight)
                position.Y = 0;
            MoveVector();
            
        }
    }
}
