using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


//petry net visulisation

namespace Petry_net
{
    public partial class mainForm : Form
    {
        private Graphics g;
        Brush mainBrush = new SolidBrush(Color.Aqua);
        Brush blackBrush = new SolidBrush(Color.Black);
        Pen mainPen = new Pen(Color.Aqua, 4);
        Pen arrowPen = new Pen(Color.Aqua,4);
        Brush fillBrush = new SolidBrush(Color.Aqua);
        private Bitmap bmp;
        public mainForm()
        {
            InitializeComponent();
            bmp = new Bitmap(paper.Width, paper.Height);
            g = Graphics.FromImage(bmp);
           
            g.DrawEllipse(mainPen, 50, 50, 50, 50);
            g.DrawEllipse(mainPen, 50, 150, 50, 50);
            g.DrawEllipse(mainPen, 350, 50, 50, 50);
            g.DrawEllipse(mainPen, 350, 150, 50, 50);
            g.FillRectangle(mainBrush,215,10,20,60);
            g.FillRectangle(mainBrush,215,100,20,60);
            g.FillRectangle(mainBrush,215,190,20,60);
            arrowPen.CustomEndCap = new AdjustableArrowCap(3,3);
            g.DrawLine(arrowPen,110,60,195,45);
            g.DrawLine(arrowPen,110,160,195,60);
            g.DrawLine(arrowPen,195,130,110,80);
            g.DrawLine(arrowPen,195,210,110,170);
            g.DrawLine(arrowPen,245,45,330,65);
            g.DrawLine(arrowPen,330,75,245,115);
            g.DrawLine(arrowPen, 330, 185, 245, 225);
            g.DrawLine(arrowPen,245,135,335,160);
           
            paper.Image = bmp;

            Task petryTask = new Task(petryWork);
            petryTask.Start();

        }

        void drawIn(int n,Brush b)
        {
            if (n % 4 == 0)
            {
                g.FillEllipse(b,70,70,10,10);
            }
            else if (n % 4 == 1)
            {
                g.FillEllipse(b, 350+20, 50+20, 10, 10);
            }
            else if (n % 4 == 2)
            {
                g.FillEllipse(b, 350 + 20, 150 + 20, 10, 10);
               
            } 
            else 
            {
                g.FillEllipse(b, 50 + 20, 150 + 20, 10, 10);
            }

            paper.Image = bmp;
        }

        void petryWork()
        {
            Thread.Sleep(1000);
            drawIn(0, mainBrush);
            Thread.Sleep(1000);
            drawIn(0, blackBrush);
            drawIn(1, mainBrush);
            Thread.Sleep(1000);
            drawIn(1, blackBrush);
            drawIn(0, mainBrush);
            drawIn(2, mainBrush);
            Thread.Sleep(1000);
            drawIn(0, blackBrush);
            drawIn(2, blackBrush);
            drawIn(1, mainBrush);
            drawIn(3, mainBrush);
            Thread.Sleep(900);
            drawIn(0, blackBrush);
            drawIn(1, blackBrush);
            drawIn(2, blackBrush);
            drawIn(3, blackBrush);
            Thread.Sleep(100);
            drawIn(3, blackBrush);
            drawIn(1,mainBrush);
            drawIn(0,mainBrush);
            drawIn(2,mainBrush);
            Thread.Sleep(900);
            drawIn(3,mainBrush);
            while (true)
            {
                drawIn(0, mainBrush);
                drawIn(1, mainBrush);
                drawIn(2, mainBrush);
                drawIn(3, mainBrush);
                Thread.Sleep(900);
                drawIn(0, blackBrush);
                drawIn(1, blackBrush);
                drawIn(2, blackBrush);
                drawIn(3, blackBrush);
                Thread.Sleep(100);
            }
        }
    }
}
