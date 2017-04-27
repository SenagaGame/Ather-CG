using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;
using LitDev;

namespace Ather_CG
{
    static class Default
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Game DefaultGame = new Game();
            DefaultGame.MainMenu();
        }
    }

    class Game
    {
        List<string> Buttons = new List<string>();
        public void MainMenu()
        {
            GraphicsWindow.Show();
            GraphicsWindow.Clear();
            GraphicsWindow.Height = 800;
            GraphicsWindow.Width = 700;
            GraphicsWindow.CanResize = false;
            GraphicsWindow.BackgroundColor = "silver";
            CreateButton("Play", 200, 50, 250, 400);
            CreateButton("Options", 200, 50, 250, 500);
            CreateButton("Place_Holder", 200, 50, 250, 600);

            Controls.ButtonClicked += Events.BC;
            GraphicsWindow.MouseDown += Events.MD;
        }

        void CreateButton(string Caption, int Width, int Height, int XCord, int YCord)
        {
            if (string.IsNullOrWhiteSpace(Caption))
            {
                throw new ArgumentNullException();
            }
            if (Width < 0 || Height < 0 || XCord < 0 || YCord < 0 || YCord > Desktop.Height || XCord > Desktop.Width)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            string Button = Controls.AddButton(Caption, XCord, YCord);
            Controls.SetSize(Button, Width, Height);
            Buttons.Add(Button);
        }

        class Events
        {
            public async static void MD()
            {
                await Task.Run(() => { Handler.MouseDown(GraphicsWindow.MouseX, GraphicsWindow.MouseY); });
            }
            public async static void BC()
            {
                await Task.Run(() => { Handler.Buttons(Controls.LastClickedButton); });
            }
        }

        class Handler
        {
            public static void Buttons(string LastClickedButton)
            {

            }
            public static void MouseDown(int X, int Y)
            {

            }
        }
    }
}
