using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaitDialogDemo
{
    public partial class Form1 : Form
    {
        private Polygon polygon;
        public Form1()
        {
            InitializeComponent();

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            polygon = new Polygon(30, 30, 200,200, 3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WaitDialog dialog = new WaitDialog();
            dialog.Show();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Pen p = new Pen(Brushes.Black))
            {
                //画边界
                e.Graphics.DrawEllipse(p, polygon.X, polygon.Y, polygon.Width, polygon.Height);
                //画圆
                e.Graphics.DrawPath(p, polygon.Path);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            //改变顶点数目
            polygon.PointNum = trackBar1.Value;
            Invalidate();
            
        }
    }
}
