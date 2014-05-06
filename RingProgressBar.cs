using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WaitDialogDemo
{
    public partial class RingProgressBar : UserControl
    {
        int ringWidth = 30;
        int ringMargin = 5;
        int speed = 3;
        Rectangle clipRectangle;
        Polygon outCircle;
        Polygon innerCircle;

        public RingProgressBar()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            int W = ClientRectangle.Width;
            int H = ClientRectangle.Height;
            
            clipRectangle = new Rectangle(0, 0, W, 0);

            int side = Math.Min(W , H) - 2*ringMargin;
            int x =  (W -  side) / 2;
            int y =  (H -  side) / 2;
            int pointNum = 50;
            outCircle = new Polygon(x, y, side,side, pointNum);

            x += ringWidth;
            y += ringWidth;
            side -= 2*ringWidth;
            innerCircle = new Polygon(x, y, side,side, pointNum);
        }


        public void Start()
        {
            timer1.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            
            Region regionRing = new Region(outCircle.Path);
            //形成圆环
            regionRing.Xor(innerCircle.Path);
            //截取部分圆环
            regionRing.Intersect(clipRectangle);
            e.Graphics.FillRegion(Brushes.Red, regionRing);
            //画处边框
            using (Pen p = new Pen(Brushes.Black))
            {
                e.Graphics.DrawPath(p, outCircle.Path);
                e.Graphics.DrawPath(p, innerCircle.Path);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //更新高度
            clipRectangle.Height += speed;
            if (clipRectangle.Height > Height || clipRectangle.Height < 0)
            {
                speed = -speed;
            }
            this.Invalidate();
        }
    }
}
