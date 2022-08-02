
namespace StatkiC
{
    partial class AskBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AskBox));
            this.label1 = new System.Windows.Forms.Label();
            this.missButton = new System.Windows.Forms.Button();
            this.hitButton = new System.Windows.Forms.Button();
            this.destroyedButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Określ jaki był wynik dla wybranego pola.";
            // 
            // missButton
            // 
            this.missButton.Location = new System.Drawing.Point(13, 47);
            this.missButton.Name = "missButton";
            this.missButton.Size = new System.Drawing.Size(87, 23);
            this.missButton.TabIndex = 1;
            this.missButton.Text = "Pudło 😥";
            this.missButton.UseVisualStyleBackColor = true;
            this.missButton.Click += new System.EventHandler(this.missButton_Click);
            // 
            // hitButton
            // 
            this.hitButton.Location = new System.Drawing.Point(106, 47);
            this.hitButton.Name = "hitButton";
            this.hitButton.Size = new System.Drawing.Size(87, 23);
            this.hitButton.TabIndex = 2;
            this.hitButton.Text = "Trafiony 🤩";
            this.hitButton.UseVisualStyleBackColor = true;
            this.hitButton.Click += new System.EventHandler(this.hitButton_Click);
            // 
            // destroyedButton
            // 
            this.destroyedButton.Location = new System.Drawing.Point(199, 47);
            this.destroyedButton.Name = "destroyedButton";
            this.destroyedButton.Size = new System.Drawing.Size(87, 23);
            this.destroyedButton.TabIndex = 3;
            this.destroyedButton.Text = "Zatopiony 😎";
            this.destroyedButton.UseVisualStyleBackColor = true;
            this.destroyedButton.Click += new System.EventHandler(this.destroyedButton_Click);
            // 
            // AskBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 82);
            this.Controls.Add(this.destroyedButton);
            this.Controls.Add(this.hitButton);
            this.Controls.Add(this.missButton);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(318, 121);
            this.MinimumSize = new System.Drawing.Size(318, 121);
            this.Name = "AskBox";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asystent do gry w statki";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AskBox_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button missButton;
        private System.Windows.Forms.Button hitButton;
        private System.Windows.Forms.Button destroyedButton;
    }
}