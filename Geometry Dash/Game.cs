using GeometryDash;
using System;
using System.Windows.Forms;
using WMPLib;

namespace Geometry_Dash
{
    public partial class Game : Form
    {
        private Player player;
        private Timer gameTimer;
        private int levelWidth;
        private WindowsMediaPlayer musicPlayer;

        public Game()
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

            this.KeyDown += Game_KeyDown;
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

        private void Game_KeyDown(object sender, KeyEventArgs e)
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
            Game newGame = new Game();
            newGame.Show();
            this.Close();
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (player != null)
            {
                musicPlayer.controls.stop();
                musicPlayer.close();
            }
            base.OnFormClosed(e);
        }

        private void CreateLevel()
        {
            levelWidth = 2500;  

            // Добавляем шипы
            Spike spike1 = new Spike(200, 320);
            this.Controls.Add(spike1);

            Spike spike2 = new Spike(400, 320);
            this.Controls.Add(spike2);

            Spike spike4 = new Spike(710, 320);
            this.Controls.Add(spike4);

            Spike spike3 = new Spike(750, 320);
            this.Controls.Add(spike3);

            Spike spike5 = new Spike(790, 320);
            this.Controls.Add(spike5);

            Block block2 = new Block(650, 300, 50);
            this.Controls.Add(block2);

            Block block3 = new Block(720, 255, 50);
            this.Controls.Add(block3);

            Spike spike6 = new Spike(1000, 320);
            this.Controls.Add(spike6);

            //Spike spike7 = new Spike(1200, 320);
            //this.Controls.Add(spike7);

            Block block4 = new Block(1300, 270, 50);
            this.Controls.Add(block4);

            Block block5 = new Block(1350, 220, 50);
            this.Controls.Add(block5);

            Block block6 = new Block(1450, 180, 50);
            this.Controls.Add(block6);

            Spike spike8 = new Spike(1500, 320);
            this.Controls.Add(spike8);

            Block block7 = new Block(1600, 300, 50);
            this.Controls.Add(block7);

            Block block8 = new Block(1650, 250, 50);
            this.Controls.Add(block8);

            Block block9 = new Block(1700, 200, 50);
            this.Controls.Add(block9);

            Spike spike9 = new Spike(1800, 320);
            this.Controls.Add(spike9);

            Spike spike10 = new Spike(1850, 320);
            this.Controls.Add(spike10);

           
            Block finishBlock = new Block(1950, 300, 100);
            this.Controls.Add(finishBlock);

            PictureBox finish = new PictureBox();
            finish.Image = Geometry_Dash.Properties.Resources.finish;
            finish.SizeMode = PictureBoxSizeMode.StretchImage;
            finish.Width = 50;
            finish.Height = 50;
            finish.Left = 2050;
            finish.Top = 250;
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


        private void Game_Load(object sender, EventArgs e)
        {
            this.Width = 820;
            PlayMusic();
        }
    }
}
