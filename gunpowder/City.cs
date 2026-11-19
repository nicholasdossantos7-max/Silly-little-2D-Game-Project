using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MohawkGame2D
{
    public class City
{
        public float position;
        public Vector2 size; //finally using vectors
        Color BuildingColor;

        public bool invert = false;

        public void Setup(int offset) //it kinda looks like geomtry dash
        {
            //front buildings\
            if (invert == false)
            {
                position = offset * 115; // how far away the buildings are to make it so building are not so cluttered and you can actually fall off.
                size = Random.Vector2(50, 200, 400, 200); // for the front I wanted to make it more distinguishable from the back buildings.
                BuildingColor = new Color(80, 80, Random.Integer(150, 175)); //again just like the size.
            }
            else
            {
                //back buildings
                position = offset * 100;
                size = Random.Vector2(20, 230, -700, -200); //skinnier
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
