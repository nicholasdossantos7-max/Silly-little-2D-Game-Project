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

        float buildingoffset;
        public bool invert = false;

        public void Setup(int offset) //it kinda looks like geomtry dash
        {
            
            buildingoffset = offset * 115;
            //front buildings\
            if (invert == false)
            {
                position = buildingoffset; // how far away the buildings are to make it so building are not so cluttered and you can actually fall off.
                size = Random.Vector2(50, 200, 400, 200); // for the front I wanted to make it more distinguishable from the back buildings.
                BuildingColor = new Color(80, 80, Random.Integer(150, 175)); //again just like the size.
            }
            else
            {
                //back buildings
                buildingoffset = offset * 100;
                position = buildingoffset;
                size = Random.Vector2(20, 230, -700, -200); //skinnier
                BuildingColor = new Color(80, 80, Random.Integer(80, 100));
            }
        }

        public void Update()
        {
            position = JohnWick.screenoffset + buildingoffset;


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
