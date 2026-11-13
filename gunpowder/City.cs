using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MohawkGame2D
{
    public class City
{
        public float position;
        public Vector2 size;
        Color BuildingColor;

        public bool invert = false;

        public void Setup(int offset)
        {
            //front buildings\
            if (invert == false)
            {
                position = offset * 115; //Random.Integer(Window.Width);
                size = Random.Vector2(50, 200, 400, 200);
                BuildingColor = new Color(80, 80, Random.Integer(150, 175));
            }
            else
            {
                //back buildings
                position = offset * 100;
                size = Random.Vector2(20, 230, -700, -200);
                BuildingColor = new Color(80, 80, Random.Integer(80, 100));
            }
        }

        public void Update()
        {
            //building 1
            Draw.SetFillColor(BuildingColor);
            Draw.Rectangle(position, size.Y, size.X, Window.Height);
            if (invert)
            {
                Draw.SetFillColor(BuildingColor);
                Draw.Rectangle(position, -size.Y, size.X, 0);
            }
        }
    }
}
