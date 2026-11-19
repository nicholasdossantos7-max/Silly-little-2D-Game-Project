// Include the namespaces (code libraries) you need below.
using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
/*
    Game Project rubric Requirements (because I only got a 24/54 on the interactive toy, so clearly I'm really bad at this):
Create at least two(2) array of a class type you defined with a minimum of four (4) elements each. 

Gameplay motion is controlled using the Vector2 type AND makes uses of Vector2 concepts such as direction (normalized vector) and magnitude (length or speed). 

The game uses at least one method of collision detection for gameplay purposes. Collision detection and resolution are functional (has few to no bugs).

Process work includes annotated sketches (drawings) using the pixel-paper grid provided which demonstrates thorough graphics exploration or planning. 

Commit messages created through git client (not GitHub uploads) such as Visual Studio are well formatted, and describe commit contents clearly. Messages use the imperative tense. 

2+ distinct uses of conditional statements.

2+ uses of For Loops.

4+ distinct uses of functions.

3+ classes defined

The project is exceptionally well formatted, following most/all best practices and language conventions.
*/
// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        /// 
        public static City[] city = new City[10];
        City[] ytic = new City[10];
        JohnWick johnwick = new JohnWick();
        HelenWick helenwick = new HelenWick();

        Gorg gorg = new Gorg();

        public void Setup()
        {
            Window.SetTitle("Gunpowder");
            Window.SetSize(1000, 600);

            for (int i = 0; i < city.Length; i++)
            {
               // city[i] = new City(); // Opening the game with this just causes my computer to slow down HEAVILY
                city[i] = new City();
                city[i].Setup(i); // after a while I got it working
            }

            for (int i = 0; i < ytic.Length; i++)
            {
                ytic[i] = new City();
                ytic[i].invert = true;
                ytic[i].Setup(i);
            }
            johnwick.Setup();
            //helenwick.Setup(); //probably won't work for numerous reasons
            gorg.Setup();
            
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        
        bool showtext = true;
        public void Update()
        {
            Window.ClearBackground(200,235,255);
            Text.Draw("Gunpowder", 340, 150);

            for (int i = 0; i < ytic.Length; i++)
            {
                ytic[i].Update();
            }

            for (int i = 0; i < city.Length; i++)
            {
                city[i].Update();
            }

            //for the mouse // not sure if this even goes here but idk, I'm trying to make the cool thing

                {
                Draw.SetFillColor(0, 0, 0, 0);
                Draw.SetLineSize(5);
                Draw.Line(Input.GetMouseX(), Input.GetMouseY(), 30 + Input.GetMouseX(), Input.GetMouseY());// I created a wrecking ball dude what?
                Draw.Line(Input.GetMouseX(), Input.GetMouseY(), -30 + Input.GetMouseX(), Input.GetMouseY());
                Draw.Line(Input.GetMouseX(), Input.GetMouseY(), Input.GetMouseX(), -30 + Input.GetMouseY());
                Draw.Line(Input.GetMouseX(), Input.GetMouseY(), Input.GetMouseX(), 30 + Input.GetMouseY());
                Draw.Circle(Input.GetMouseX(), Input.GetMouseY(), 30); // it's meant to be like a aim cursor thing you find in shooting games.
                Draw.SetLineSize(1);
            }

            //That Super Mario Camera Movement
            //float CameraX = 0; // God forbid I know how to do anything on this program.
            //float screenwidth = Window.Width;
            //float middlethreshold = screenwidth * 0.5f;

            //Hidden Debug menu
            bool showtext = false;
            if (Input.IsKeyboardKeyDown(KeyboardKey.F1))
            {
                showtext = !showtext;
            }

            if (showtext)
            {
                Text.Draw("Debug Information", 10, 10);
                Text.Draw("Mouse Position: " + Input.GetMouseX() + ", " + Input.GetMouseY(), 10, 30);
                Text.Draw("Window Size: " + Window.Width + ", " + Window.Height, 10, 55);
                Text.Draw("John Wick Position: " + johnwick.position.X + ", " + johnwick.position.Y, 10, 80);
                Text.Draw("Helen Wick Position: " + helenwick.position.X + ", " + helenwick.position.Y, 10, 110);
                //Text.Draw("Enemy count: " + city.Length, 10, 130); //This doesn't work even if there were enemies
                Text.Draw("Enemy position: " + gorg.position.X + ", " + gorg.position.Y, 10, 155);
                //Text.Draw("FPS: " + Time.FPS, 10, 70);
            }
            else
            {
                showtext = false;
            }

            johnwick.Update();
            helenwick.Update();
            gorg.Update(); // I don't know if this will work, but I'm trying to make it so the enemy be seen on the screen.
        }
    }

}
