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

        public void Setup()
        {
            Window.SetTitle("Gunpowder");
            Window.SetSize(800, 600);

            for (int i = 0; i < city.Length; i++)
            {
               // city[i] = new City(); // Opening the game with this just causes my computer to slow down HEAVILY
                city[i] = new City();
                city[i].Setup(i); //
            }

            for (int i = 0; i < ytic.Length; i++)
            {
                ytic[i] = new City();
                ytic[i].invert = true;
                ytic[i].Setup(i);
            }
            johnwick.Setup();
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
            
            johnwick.Update();
        }
    }

}
