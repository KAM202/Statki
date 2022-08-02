using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Windows;

namespace StatkiC
{
    public partial class AskBox : Form
    {
        public AskBox()
        {
            InitializeComponent();
        }

        public static DialogResult Show()
        {
            AskBox askBox = new AskBox();
            return askBox.ShowDialog();
        }


        private void missButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void destroyedButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        private void AskBox_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
