using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;
using LitDev;

namespace Ather_CG
{
    static class UI
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
        public void MainMenu()
        {
            GraphicsWindow.Show();
            GraphicsWindow.Clear();
            GraphicsWindow.Height = 800;
            GraphicsWindow.Width = 700;
            GraphicsWindow.CanResize = false;
            GraphicsWindow.BackgroundColor = "silver";
        }
    }
}
