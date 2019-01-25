namespace Chess
{
    partial class frmGameFinished
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
            this.JugarDenuevo = new System.Windows.Forms.Button();
            this.Salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // JugarDenuevo
            // 
            this.JugarDenuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.JugarDenuevo.Location = new System.Drawing.Point(12, 26);
            this.JugarDenuevo.Name = "PlayAgain";
            this.JugarDenuevo.Size = new System.Drawing.Size(375, 42);
            this.JugarDenuevo.TabIndex = 1;
            this.JugarDenuevo.Text = "Play Again";
            this.JugarDenuevo.UseVisualStyleBackColor = true;
            this.JugarDenuevo.Click += new System.EventHandler(this.PlayAgain_Click);
            // 
            // Salir
            // 
            this.Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salir.Location = new System.Drawing.Point(12, 97);
            this.Salir.Name = "Exit";
            this.Salir.Size = new System.Drawing.Size(375, 42);
            this.Salir.TabIndex = 2;
            this.Salir.Text = "Exit";
            this.Salir.UseVisualStyleBackColor = true;
            this.Salir.Click += new System.EventHandler(this.Exit_Click);
            // 
            // frmGameFinished
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 157);
            this.Controls.Add(this.Salir);
            this.Controls.Add(this.JugarDenuevo);
            this.Name = "frmGameFinished";
            this.Text = "Game finished";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button JugarDenuevo;
        private System.Windows.Forms.Button Salir;
    }
}