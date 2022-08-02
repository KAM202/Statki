using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StatkiC
{
    public partial class StartWindow : Form
    {
        private BoardPlayer boardPlayer;
        public Button[,] buttonArray = new Button[10,10];
        public StartWindow()
        {
            BoardPlayer boardPlayer = new BoardPlayer(this);
            this.boardPlayer = boardPlayer;
            InitializeComponent();
            GetAllButtons();
        }

        public void ShowBox(String text, String title = "Informacja")
        {
            MessageBox.Show(text, title);
        }

        private void GetAllButtons()
        {
            for(int i = 0; i < Game.sizeBoard; i++)
            {
                for(int j = 0; j < Game.sizeBoard; j++)
                {
                    Button tempButton = (Button)this.Controls.Find("button" + i + j, true)[0];
                    buttonArray[i, j] = tempButton;
                    
                }
            }
        }

       private void buttonBoard_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var nameOfButton = btn.Name.ToString().Split("button");

            boardPlayer.SetField((int)nameOfButton[1][0] - '0', (int)nameOfButton[1][1] - '0'); 
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if(boardPlayer.GetShipsCount() == (int)EShip.NONE)
            {
                this.Hide();
                MainWindow w = new MainWindow(boardPlayer.GetBoard());
                w.ShowDialog();
            }
            else
            {
                ShowBox("Nie ustawiono jeszcze wszystkich statków!\n Do ustawienia zostało jeszcze " + boardPlayer.GetShipsCount() + " statków!");
            }
             
            
        }
        public void UpdateShipsCount(String text)
        {
            label25.Text = text;
        }
        public void UpdateShipSize(String text)
        {
            label24.Text = text + "x1";
        }

        private void StartWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
