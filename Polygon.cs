using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitDialogDemo
{
    public class Polygon
    {
        int mPointNum = 3; //顶点数大于30时，接近于圆形或椭圆
        Rectangle mBounds;

        GraphicsPath mPath;

        /// <summary>
        /// 初使化一个多连形
        /// </summary>
        public Polygon(int x, int y, int width, int height, int pointNum)
            : this(new Rectangle(x, y, width, height), pointNum)
        { }

        public Polygon(Rectangle bounds, int pointNum)
        {
            mPointNum = pointNum;
            mBounds = bounds;
            InitPath();
        }

        private void InitPath()
        {
            Point[] points = new Point[mPointNum];
            double angle = 0;
            double delta = Math.PI * 2 / mPointNum;
            int a = Width / 2;
            int b = Height /2;
            for (int i = 0; i < mPointNum; i++)
            {
                Point p = new Point();
                p.X = (int)(a * Math.Cos(angle) + Width/2 + X);
                p.Y = (int)(b * Math.Sin(angle) + Height/2 + Y);
                angle += delta;
                points[i] = p;
            }
            mPath = new GraphicsPath();
            mPath.AddPolygon(points);
        }

        public int PointNum
        {
            get { return mPointNum; }
            set
            {
                mPointNum = value;
                InitPath();
            }
        }

        public GraphicsPath Path
        {
            get { return mPath; }
        }

        public int X
        {
            get { return mBounds.X; }
        }

        public int Y
        {
            get { return mBounds.Y; }
        }

        public int Width
        {
            get { return mBounds.Width; }
        }

        public int Height
        {
            get { return mBounds.Height; }
        }


    }
}
