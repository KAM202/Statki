using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StatkiC
{
    public partial class MainWindow : Form
    {
        private Game game;
        public Button[,] buttonArrayOpponent = new Button[Game.sizeBoard, Game.sizeBoard];
        public Button[,] buttonArrayPlayer = new Button[Game.sizeBoard, Game.sizeBoard];
        public MainWindow(int[,] playerBoard)
        {
            InitializeComponent();
            GetAllButtons();
            Game g = new Game(this, playerBoard);
            this.game = g;
            
        }

        public void UpdateInfo(String shipsLeft, String shots, String hits, String destroyed, String miss, String accuracy)
        {
            this.label49.Text = shipsLeft;
            this.label50.Text = shots;
            this.label51.Text = hits;
            this.label52.Text = destroyed;
            this.label53.Text = miss;
            this.label54.Text = accuracy + "%";

        }

        public void ShowBox(String text, String title = "Informacja")
        {
            MessageBox.Show(text, title);
        }

        private void buttonBoard_Click(object sender, EventArgs e)
        {
            if(game.boardOpponent.GetShipsCount() == (int)EShip.NONE)
            {
                ShowBox("Koniec gry! Wszystkie statki przeciwnika zostały zniszczone!");
                return;
            }   
            
            var btn = (Button)sender;
            var nameOfButton = btn.Name.ToString().Split("button");

            AskBox askBox = new AskBox();
            DialogResult dialogResult = askBox.ShowDialog();

            if (dialogResult == DialogResult.No)
            {
                game.boardOpponent.SetField((int)nameOfButton[1][0] - '0', (int)nameOfButton[1][1] - '0', EField.MISS);
            }
            if (dialogResult == DialogResult.Yes)
            {
                game.boardOpponent.SetField((int)nameOfButton[1][0] - '0', (int)nameOfButton[1][1] - '0', EField.SHIP);
            }
            if (dialogResult == DialogResult.Abort)
            {
                game.boardOpponent.SetField((int)nameOfButton[1][0] - '0', (int)nameOfButton[1][1] - '0', EField.SHIP_DESTROYED);
            }
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
        }

        private void GetAllButtons()
        {
            for (int i = 0; i < Game.sizeBoard; i++)
            {
                for (int j = 0; j < Game.sizeBoard; j++)
                {
                    Button tempButtonOpponent = (Button)this.Controls.Find("button" + i + j, true)[0];
                    Button tempButtonPlayer = (Button)this.Controls.Find("gracz" + i + j, true)[0];
                    buttonArrayOpponent[i, j] = tempButtonOpponent;
                    buttonArrayPlayer[i, j] = tempButtonPlayer;

                }
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
