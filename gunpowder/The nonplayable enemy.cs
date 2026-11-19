using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Numerics;
using System.Text;

namespace MohawkGame2D
{
    public class Gorg // the nonplayable enemy.
    {
        public Vector2 position;
        Vector2 velocity;
        Color GorgColor;
        public void Setup()
        {
            GorgColor = new Color(255, 0, 0);
            position = new Vector2(100, 100);
            velocity = Vector2.Zero;
        }
        public void Update()
        {
            Draw.SetFillColor(204, 255, 0);
            Draw.Rectangle(position.X, position.Y, 30, 65);
            Move();
        }
        //public void Move()
//        {
//            Vector2 trymove = Vector2.Zero;
//            if (johnwick.position.X += 5)
//            {
//                position.X += 5;
//                //trymove.X += 5;
//            }
//            else if (johnwick.position.X -= 5)
//            {
//                position.X -= 5;
//                //trymove.X -= 5;
//            }
//        }
//    }
//}

