    using System;
    using System.Windows.Forms;

    namespace GeometryDash
    {
        public class Spike : PictureBox
        {
            private Timer moveTimer;
            private int moveSpeed = 5;

            public Spike(int left, int top)
            {
                Initialize(left, top);
            }

            private void Initialize(int left, int top)
            {
                this.Image = Geometry_Dash.Properties.Resources.spike;
                this.SizeMode = PictureBoxSizeMode.Zoom;
                this.BackColor = System.Drawing.Color.Transparent;
                this.Width = 40;
                this.Height = 40;
                this.Left = left;
                this.Top = top;

                moveTimer = new Timer();
                moveTimer.Interval = 20;
                moveTimer.Tick += MoveTimer_Tick;
            }

            private void MoveTimer_Tick(object sender, EventArgs e)
            {
                this.Left -= moveSpeed;
            }

            public void StartMoving()
            {
                moveTimer.Start();
            }

            public void StopMoving()
            {
                moveTimer.Stop();
            }
        }
    }
