using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;

namespace MohawkGame2D
{
    public class JohnWick
{
        public Vector2 position;
        Vector2 velocity;
        Color JohnWickColor;

        bool coliding;

        public void Setup()
        {
            JohnWickColor = new Color(255, 0, 0);
            position = new Vector2(100, 100);
            Vector2 gravity = new Vector2(0, 6f); //trying to not make it seem like you are on the moon
        }
        public void Update()
        {
            Draw.SetFillColor(255, 0, 0);
            Draw.Rectangle(position.X, position.Y, 30, 65);
            Move();

            // pretty sure this does not go here, but I am trying to make it so the player can jump and fall, in a physical realistic way like Mario bros
            //Vector2 gravity = new Vector2(0, 0.5f);
            //velocity += gravity * Time.DeltaTime;
            //position += velocity;
        }

        public void Move()
        {
            Vector2 trymove = Vector2.Zero;
            if (Input.IsKeyboardKeyDown(KeyboardKey.Right))
            {
                position.X += 5;
                //trymove.X += 5;
            }
            if (Input.IsKeyboardKeyDown(KeyboardKey.Left))
            {
                position.X -= 5;
                //trymove.X -= 5;
            }
            //if (0 < coliding(x, 1 + y, City::City, i_map) && 1 == (Input.IsKeyboardKeyDown(KeyboardKey.Space))) // tried to make it so the player can only jump if he is standing on something
            if (Input.IsKeyboardKeyDown(KeyboardKey.Space))
            {
                //he can only seem to jump once, and then can never jump again, he also falls faster when falling and holding space.
                //for (int i = 0; i < 4.5; i++)
                {
                    trymove.Y -= 10;
                    // return; //he falls into the abyss.
                }
            }
            else
            {
                trymove.Y += 5; // change it to a minus for him to ascend...
                //velocity = Vector2.Zero;
            }
            if (Input.IsKeyboardKeyReleased(KeyboardKey.Space))
            {
                velocity = Vector2.Zero;
            }

            Vector2 gravity = new Vector2(0, 10f);
            velocity += gravity * Time.DeltaTime;
            position += velocity;

            bool coliding = false; //trying to create some collision so the player does not immediately snap to the top when hitting a wall.
            foreach (City c in Game.city)
            {
                if (position.Y + trymove.Y + 65 > c.size.Y)
                {
                    if (position.X + 30 + trymove.X > c.position && position.X + trymove.X < c.position + c.size.X)
                    {
                        position.Y = c.size.Y - 65; // keep this negative.
                        coliding = true;
                        // Guess I gotta do more like detect if the play is closer to the left, up, down, right to make sure it knows where to put the rectangle, it seems it is only registered to go up.
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
