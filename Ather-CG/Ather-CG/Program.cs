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
            DefaultGame.Start();
        }
    }

    class Game
    {
        public void Start()
        {
            MainMenu();
        }

        public static void MainMenu()
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
            CreateButton("Test ", 200, 50, -250, 600);

            Controls.ButtonClicked += Events.BC;
            GraphicsWindow.MouseDown += Events.MD;
        }

        public static void GameBackgroud()
        {
            GraphicsWindow.Clear();
            GraphicsWindow.Height = 800;GraphicsWindow.Width = 1280;
            GraphicsWindow.BackgroundColor = "Gray";
            CreateButton("Main Menu", 200, 50, 50, 40);
            GraphicsWindow.DrawLine(300, 0, 300, GraphicsWindow.Height);
            GraphicsWindow.DrawLine(300, 600, GraphicsWindow.Width, 600);

        }

        public static void CreateButton(string Caption, int Width, int Height, int XCord, int YCord)
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
                //Console.WriteLine("Button: {0} Caption: {1}", LastClickedButton, Controls.GetButtonCaption(LastClickedButton));
                string Caption = Controls.GetButtonCaption(LastClickedButton);
                switch (Caption)
                {
                    case "Play":
                        GameBackgroud();
                        break;
                    case "Options":
                        break;
                    case "Place_Holder":
                        break;
                    case "Main Menu":
                        MainMenu();
                        break;
                    default:
                        GraphicsWindow.ShowMessage("This button has not yet been implemented.", "Error");
                        break;
                }
            }

            public static void MouseDown(int X, int Y)
            {

            }
        }
    }
}