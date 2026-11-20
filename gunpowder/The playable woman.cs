using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MohawkGame2D
{
    public class HelenWick
{
        public Vector2 position; 
        Color HelenWickColor;

        public void Setup()
        {
            HelenWickColor = new Color(255, 0, 0);
            position = new Vector2(100, 100);
        }
        public void Update()
        {
            Draw.SetFillColor(0, 0, 255);
            Draw.Rectangle(position.X, position.Y, 30, 65);
            Move();
        }

        public void Move()
        {
            Vector2 trymove = Vector2.Zero;
            if (Input.IsKeyboardKeyDown(KeyboardKey.D))
            {
                position.X += 5;
                //trymove.X += 5;
            }
            if (Input.IsKeyboardKeyDown(KeyboardKey.A))
            {
                position.X -= 5;
                //trymove.X -= 5;
            }
            if (Input.IsKeyboardKeyDown(KeyboardKey.LeftShift))
            {
                trymove.Y -= 5;
            }
            else
            {
                trymove.Y += 5; // change it to a minus for him to ascend...
            }

            bool coliding = false; //trying to create some collision so the player does not immediately snap to the top when hitting a wall.
            foreach (City c in Game.city)
            {
                if (position.Y + trymove.Y + 65 > c.size.Y)
                {
                    if (position.X + 30 + trymove.X > c.position && position.X + trymove.X < c.position + c.size.X)
                    {
                        position.Y = c.size.Y - 65; // keep this positive.
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

