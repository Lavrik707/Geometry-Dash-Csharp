﻿namespace Geometry_Dash
{
    partial class Game2
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
            this.SuspendLayout();
            // 
            // Game2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Geometry_Dash.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1382, 453);
            this.Name = "Game2";
            this.Text = "Geometry Dash";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game2_FormClosed_1);
            this.Load += new System.EventHandler(this.Game2_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}