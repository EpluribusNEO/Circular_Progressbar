using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Circular_Progressbar.Code
{
    public partial class CircularProgressBar : UserControl
    {
        private int progress;
        private Color _arc;
        private Color _center;

        public CircularProgressBar()
        {

            progress = 0;

            _arc = Color.FromArgb(255, 120, 158, 250); // 250, 120, 158
            _center = Color.White;

            InitializeComponent();
        }

        private void CircularProgressBar_Paint(object sender, PaintEventArgs e)
        {
            /* Арка (Кусок Пирога) */
            e.Graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.RotateTransform(-90);
            Pen pen = new Pen(_arc);
            Rectangle rect = new Rectangle(0 - this.Width / 2+10, 0 - this.Height / 2+10, this.Width-20, this.Height-20);
            e.Graphics.DrawPie(pen, rect, 0, (int)(this.progress * 3.6));
            e.Graphics.FillPie(new SolidBrush(_arc), rect, 0, (int)(this.progress * 3.6));
            /* /Арка (Кусок Пирога) */

            /* Центральная заливка */
            pen = new Pen(_center);
            rect = new Rectangle(0 - this.Width / 2 + 25, 0 - this.Height / 2 + 25, this.Width - 50, this.Height - 50);
            e.Graphics.DrawPie(pen, rect, 0, 360);
            e.Graphics.FillPie(new SolidBrush(_center), rect, 0, 360);
            /* /Центральная заливка */

            /* Текст */
            String str = String.Format("{0}%", this.progress);
            StringFormat strFrmt = new StringFormat();
            strFrmt.LineAlignment = StringAlignment.Center;
            strFrmt.Alignment = StringAlignment.Center;
            e.Graphics.RotateTransform(90);
            e.Graphics.DrawString(str, new Font("Arial", 22), new SolidBrush(_arc), rect, strFrmt);
            /* /Текст */
        }

        public void UpdateProgress(int progress)
        {
            this.progress = progress;
            this.Invalidate();
        }
    }
}
