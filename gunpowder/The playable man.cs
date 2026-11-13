using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace MohawkGame2D
{
    public class JohnWick
{
        Vector2 position;
        Color JohnWickColor;

        public void Setup()
        {
            JohnWickColor = new Color(255, 0, 0);
            position = new Vector2(100, 100);
        }
        public void Update()
        {
            Draw.SetFillColor(255, 0, 0);
            Draw.Rectangle(position.X, position.Y, 30, 65);
            Move();
        }

        public void Move()
        {
            Vector2 trymove = Vector2.Zero;
            if (Input.IsKeyboardKeyDown(KeyboardKey.Right))
            {
                trymove.X += 5;
            }
            if (Input.IsKeyboardKeyDown(KeyboardKey.Left))
            {
                trymove.X -= 5;
            }
            if (Input.IsKeyboardKeyDown(KeyboardKey.Space))
            {
                trymove.Y -= 5;
            }
            else
            {
                trymove.Y += 5; // Gravity
            }

            bool coliding = false;
            foreach (City c in Game.city)
            {
                if (position.Y + trymove.Y + 65 > c.size.Y)
                {
                    if (position.X + 30 + trymove.X > c.position && position.X + trymove.X < c.position + c.size.X)
                    {
                        position.Y = c.size.Y - 65; // go on the ground
                        coliding = true;
                    }
                }

            }
            if (!coliding)
            {
                position.X += trymove.X;
                position.Y += trymove.Y;
            }   
        }
    }

}
