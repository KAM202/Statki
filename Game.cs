using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StatkiC
{
    class Game
    {
        public MainWindow mainWindow;
        public static int sizeBoard = 10;
        public BoardOpponent boardOpponent;
        public static List<ShipInfo> shipList = new List<ShipInfo>
        {
            new ShipInfo(4,1),
            new ShipInfo(3,2),
            new ShipInfo(2,3),
            new ShipInfo(1,4)
        };
        public static int shipCount;
        int[,] playerBoard;

        public Game(MainWindow mainWindow, int[,] playerBoard)
        {
            this.mainWindow = mainWindow;
            this.playerBoard = playerBoard;
            this.boardOpponent = new BoardOpponent(mainWindow);
            SetPlayerShips();
        }

        private void SetPlayerShips()
        {
            for(int i = 0; i < sizeBoard; i++)
            {
                for(int j = 0; j < sizeBoard; j++)
                {
                    mainWindow.buttonArrayPlayer[i, j].Text = (playerBoard[i, j] != 0) ? playerBoard[i, j].ToString() : "";
                    mainWindow.buttonArrayPlayer[i, j].Enabled = (playerBoard[i, j] != 0) ? true : false;
                    mainWindow.buttonArrayPlayer[i, j].BackColor = (playerBoard[i, j] != 0) ? Color.DeepPink : Color.White;
                    mainWindow.buttonArrayPlayer[i, j].ForeColor = (playerBoard[i, j] != 0) ? Color.White : Color.Black;
                }
            }
        }
    }
}
