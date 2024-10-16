using GeometryDash;
using System;
using System.Windows.Forms;
using WMPLib;

namespace Geometry_Dash
{
    public partial class Game1 : Form
    {
        private Player player;
        private Timer gameTimer;
        private int levelWidth;
        private WindowsMediaPlayer musicPlayer;
        

        public Game1()
        {
            InitializeComponent();

            player = new Player();
            player.Left = 100;
            player.Top = 300;
            this.Controls.Add(player);


            CreateLevel();

            gameTimer = new Timer();
            gameTimer.Interval = 20; // частота кадра
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            this.KeyDown += Game1_KeyDown;
            player.moveSpeed = 7;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            player.UpdatePhysics();


            foreach (Control control in this.Controls)
            {
                if (control is Block block)
                {
                    player.CheckCollisionWithBlock(block);
                }

                if (control is PictureBox && control != player)
                {
                    control.Left -= player.moveSpeed;
                }
            }

            foreach (Control control in this.Controls)
            {
                if (control is Spike spike && player.Bounds.IntersectsWith(spike.Bounds))
                {
                    RestartGame();
                    break;
                }
            }
        }

        private void Game1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                player.Jump();
            }
        }

        private void RestartGame()
        {
            gameTimer.Stop();

            this.Controls.Clear();
            Game1 newGame = new Game1();
            newGame.Show();
            this.Close();
        }

        private void CreateLevel()
        {
            
                levelWidth = 4000;

                

                Spike spike2 = new Spike(300, 320);
                this.Controls.Add(spike2);

                

                Spike spike4 = new Spike(800, 320);
                this.Controls.Add(spike4);

                Block block1 = new Block(1000, 300, 50);
                this.Controls.Add(block1);

                Spike spike5 = new Spike(1100, 300);
                this.Controls.Add(spike5);

                Block block2 = new Block(1400, 250, 50);
                this.Controls.Add(block2);

                Spike spike6 = new Spike(1500, 220);
                this.Controls.Add(spike6);

                Block block3 = new Block(1700, 200, 50);
                this.Controls.Add(block3);

                Spike spike7 = new Spike(1800, 170);
                this.Controls.Add(spike7);

                Block block4 = new Block(2000, 300, 50);
                this.Controls.Add(block4);

                Spike spike8 = new Spike(2100, 320);
                this.Controls.Add(spike8);

                Spike spike9 = new Spike(2400, 320);
                this.Controls.Add(spike9);

                Block block5 = new Block(2700, 280, 50);
                this.Controls.Add(block5);

                Spike spike10 = new Spike(2900, 240);
                this.Controls.Add(spike10);

                Block block6 = new Block(3100, 200, 50);
                this.Controls.Add(block6);

                Spike spike11 = new Spike(3200, 160);
                this.Controls.Add(spike11);

                Block block7 = new Block(3400, 120, 50);
                this.Controls.Add(block7);
            


            PictureBox finish = new PictureBox();
            finish.Image = Geometry_Dash.Properties.Resources.finish;
            finish.SizeMode = PictureBoxSizeMode.StretchImage;
            finish.Width = 50;
            finish.Height = 50;
            finish.Left = 3900;
            finish.Top = 110;
            this.Controls.Add(finish);
        }

        private void PlayMusic()
        {
            try
            {
                musicPlayer = new WindowsMediaPlayer();
                musicPlayer.URL = @"C:\Users\Vaio\source\repos\Geometry Dash\Geometry Dash\Properties\stereo-madness.mp3";
                musicPlayer.controls.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось воспроизвести музыку: " + ex.Message);
            }
        }


        private void Game1_Load(object sender, EventArgs e)
        {
            this.Width = 820;
            PlayMusic();
        }

        private void Game1_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            if (player != null)
            {
                musicPlayer.controls.stop();
                musicPlayer.close();
            }
            base.OnFormClosed(e);
        }
    }
}
