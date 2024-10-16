using System.Windows.Forms;

namespace GeometryDash
{
    public class Player : PictureBox
    {
        private int gravity = 2;
        private int jumpVelocity;
        private int maxJumpVelocity = -15;
        public int moveSpeed { get; set; } = 5;
        private int groundLevel;
        private bool isJumping = false;
        private bool isFalling = true;

        public Player()
        {
            this.Image = Geometry_Dash.Properties.Resources.sr262166bf0c6aws3;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.Width = 50;
            this.Height = 50;

            groundLevel = 300;
            this.Top = groundLevel;
        }

        public void Jump()
        {
            if (!isJumping && !isFalling)
            {
                isJumping = true;
                jumpVelocity = maxJumpVelocity;
            }
        }

        public void UpdatePhysics()
        {
            if (isJumping)
            {
                this.Top += jumpVelocity;
                jumpVelocity += gravity;

                if (jumpVelocity >= 0)
                {
                    isJumping = false;
                    isFalling = true;
                }
            }
            else if (isFalling)
            {
                this.Top += gravity;

                if (this.Top >= groundLevel)
                {
                    this.Top = groundLevel;
                    isFalling = false;
                }
            }
        }

        public void CheckCollisionWithBlock(Block block)
        {
            bool isOnBlockHorizontally = this.Left < block.Left + block.Width && this.Left + this.Width > block.Left;
            bool isOnBlockVertically = this.Bottom >= block.Top && this.Top < block.Top;

            if (isOnBlockHorizontally && isOnBlockVertically && isFalling)
            {
                this.Top = block.Top - this.Height;
                isFalling = false;
            }
        }
    }
}
