using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace StatkiC
{
    class BoardOpponent: Board
    {
        private MainWindow mainWindow;

        private int shots;
        private int hits;
        private int destroyed;
        private int miss;
        private double accuracy;

        public BoardOpponent(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            this.size = Game.sizeBoard;
            this.shots = 0;
            this.shipCounts = Game.shipCount;
            this.hits = 0;
            this.destroyed = 0;
            this.miss = 0;
            this.accuracy = 0;
            FillBoard();
            mainWindow.UpdateInfo(shipCounts.ToString(), shots.ToString(), hits.ToString(), destroyed.ToString(), miss.ToString(), accuracy.ToString());
        }

        public void SetField(int x, int y, EField eField)
        {
            if (eField == EField.MISS || eField == EField.SHIP)
            {
                board[x, y] = (int)eField;
                mainWindow.buttonArrayOpponent[x, y].Text = (eField == EField.MISS) ? "X" : "O";
                mainWindow.buttonArrayOpponent[x, y].BackColor = (eField == EField.MISS) ? Color.DarkGray : Color.Red;
                mainWindow.buttonArrayOpponent[x, y].ForeColor = Color.White;
                mainWindow.buttonArrayOpponent[x, y].Enabled = false;
                _ = (eField == EField.SHIP) ? hits++ : miss++;
            }
            else if (eField == EField.SHIP_DESTROYED)
            {
                FillShip(x, y);
                destroyed++;
                shipCounts--;
                
            }
            shots++;
            accuracy = Math.Truncate(((double)hits + (double)destroyed) / (double)shots * (double)100);
            mainWindow.UpdateInfo(shipCounts.ToString(), shots.ToString(), hits.ToString(), destroyed.ToString(), miss.ToString(), accuracy.ToString());

            if (shipCounts == (int)EShip.NONE) mainWindow.ShowBox("Koniec gry! Wszystkie statki przeciwnika zostały zniszczone!");
        }

        public void FillShip(int x, int y)
        {
            List<Field> fields = new List<Field>();
            fields.Add(new Field(x, y));

            for(int a = x - 1; a >= 0; a--)
            {
                if (board[a, y] == (int)EField.SHIP) fields.Add(new Field(a, y));
                else
                    break;
            }
            for(int a = x + 1; a <= Game.sizeBoard - 1; a++)
            {
                if (board[a, y] == (int)EField.SHIP) fields.Add(new Field(a, y));
                else
                    break;
            }

            for (int a = y - 1; a >= 0; a--)
            {
                if (board[x, a] == (int)EField.SHIP) fields.Add(new Field(x, a));
                else
                    break;
            }

            for (int a = y + 1; a <= Game.sizeBoard - 1; a++)
            {
                if (board[x, a] == (int)EField.SHIP) fields.Add(new Field(x, a));
                else
                    break;
            }

            foreach(Field field in fields)
            {
                board[field.getX(), field.getY()] = (int)EField.SHIP_DESTROYED;
                mainWindow.buttonArrayOpponent[field.getX(), field.getY()].Text = "#";
                mainWindow.buttonArrayOpponent[field.getX(), field.getY()].BackColor = Color.DarkOliveGreen;
                mainWindow.buttonArrayOpponent[field.getX(), field.getY()].ForeColor = Color.White;
                mainWindow.buttonArrayOpponent[field.getX(), field.getY()].Enabled = false;
            }
        }
    }
}
