using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Geometry_Dash
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    Game game = new Game();
                    this.Hide();
                    game.ShowDialog();
                    this.Show();
                    break;
                case 1:
                    Game1 game1 = new Game1();
                    this.Hide();
                    game1.ShowDialog();
                    this.Show();
                    break;
                case 2:
                    Game2 game2 = new Game2();
                    this.Hide();
                    game2.ShowDialog();
                    this.Show();
                    break;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}
