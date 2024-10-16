using System.Windows.Forms;

namespace GeometryDash
{
    public class Block : PictureBox
    {
        public Block(int left, int top, int width = 100)
        {
            Initialize(left, top, width);
        }

        private void Initialize(int left, int top, int width)
        {
            this.Image = Geometry_Dash.Properties.Resources.photo_2024_08_18_23_06_04;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Width = width;
            this.Height = 40; 
            this.Left = left;
            this.Top = top;
        }

    }
}
