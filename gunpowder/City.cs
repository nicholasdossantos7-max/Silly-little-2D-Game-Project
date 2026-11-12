using System;
using System.Collections.Generic;
using System.Text;

namespace MohawkGame2D
{
    public class City
{
        float x;
        float y;
        Color BuildingColor;
        float radius;

        public void Setup()
        {
            x = Random.Integer(Window.Width);
            y = Random.Integer(Window.Height);
            radius = 50;
            BuildingColor = new Color(62, 107, 158);
        }

        public void Update()
        {
            //building 1
            Draw.SetFillColor(BuildingColor);
            Draw.Rectangle(x, y, 255, 300);
            //DrawBuilding();
        }
    }
}
