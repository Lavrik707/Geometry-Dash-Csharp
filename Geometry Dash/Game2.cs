using GeometryDash;
using System;
using System.Windows.Forms;
using WMPLib;

namespace Geometry_Dash
{
    public partial class Game2 : Form
    {
        private Player player;
        private Timer gameTimer;
        private int levelWidth;
        private WindowsMediaPlayer musicPlayer;

        public Game2()
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

            this.KeyDown += Game2_KeyDown;
            player.moveSpeed = 10;
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

        private void Game2_KeyDown(object sender, KeyEventArgs e)
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
            Game2 newGame = new Game2();
            newGame.Show();
            this.Close();
        }

        private void CreateLevel()
        {
            levelWidth = 3000;


            Spike spike2 = new Spike(500, 320);
            this.Controls.Add(spike2);

           

            Block block1 = new Block(1000, 300, 50);
            this.Controls.Add(block1);

            Spike spike4 = new Spike(1100, 300);
            this.Controls.Add(spike4);

            Block block2 = new Block(1400, 250, 50);
            this.Controls.Add(block2);

            Spike spike5 = new Spike(1500, 220);
            this.Controls.Add(spike5);

            Block block3 = new Block(1700, 200, 50);
            this.Controls.Add(block3);

            Spike spike6 = new Spike(1800, 170);
            this.Controls.Add(spike6);

            Block block4 = new Block(2000, 300, 50);
            this.Controls.Add(block4);

            Spike spike7 = new Spike(2100, 320);
            this.Controls.Add(spike7);

            Spike spike8 = new Spike(2400, 320);
            this.Controls.Add(spike8);

            Block block5 = new Block(2700, 280, 50);
            this.Controls.Add(block5);

            PictureBox finish = new PictureBox();
            finish.Image = Geometry_Dash.Properties.Resources.finish;
            finish.SizeMode = PictureBoxSizeMode.StretchImage;
            finish.Width = 50;
            finish.Height = 50;
            finish.Left = 2900;
            finish.Top = 270;
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


        private void Game2_Load(object sender, EventArgs e)
        {
            this.Width = 820;
            PlayMusic();
        }

        private void Game2_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            if(player != null)
            {
                musicPlayer.controls.stop();
                musicPlayer.close();
            }
            base.OnFormClosed(e);
        }
    }
}
