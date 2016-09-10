using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        class Bowl
        {
            public int x;
            public int y;
            public int x1;
            public int y1;

            public Bowl(int x, int y,int x1,int y1)
            {
                this.x = x;
                this.y = y;
                this.x1 = x1;
                this.y1 = y1;
            }

            public void Ido()
            {
                System.Random r = new System.Random(System.Environment.TickCount);

                x = x + x1;
                y = y + y1;

                if (x > 500)
                {
                    x = x - x1;
                    x1 = System.Math.Sign(x1) * (-1) * (r.Next(50) + 10);
                }

                if (x < 0)
                {
                    x = x - x1;
                    x1 = System.Math.Sign(x1) * (-1) * (r.Next(50) + 10);
                }

                if (y > 500)
                {
                    y = y - y1;
                    y1 = System.Math.Sign(y1) * (-1) * (r.Next(50) + 10);
                }

                if (y < 0)
                {
                    y = y - y1;
                    y1 = System.Math.Sign(y1) * (-1) * (r.Next(50) + 10);
                }
            }
        }

        Bowl bowl1 = new Bowl(100,200,10,10);
        Bowl bowl2 = new Bowl(50,250,5,5);
        Bowl bowl3 = new Bowl(200, 100, 20, 20);
        Bowl bowl4 = new Bowl(300, 200, -10, -10);
        Bowl bowl5 = new Bowl(400, 300, -30, 20);

        private void timer1_Tick(object sender, EventArgs e)
        {
            bowl1.Ido();
            bowl2.Ido();
            bowl3.Ido();
            bowl4.Ido();
            bowl5.Ido();

            //ImageオブジェクトのGraphicsオブジェクトを作成する
            Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics g = Graphics.FromImage(canvas);

            //先に描いた四角に内接する楕円を黒で描く
            g.DrawRectangle(Pens.Red, 0, 0, 499, 499);
            g.DrawEllipse(Pens.Black, bowl1.x, bowl1.y, 10, 10);
            g.DrawEllipse(Pens.Black, bowl2.x, bowl2.y, 10, 10);
            g.DrawEllipse(Pens.Black, bowl3.x, bowl3.y, 10, 10);
            g.DrawEllipse(Pens.Black, bowl4.x, bowl4.y, 10, 10);
            g.DrawEllipse(Pens.Black, bowl5.x, bowl5.y, 10, 10);

            //リソースを解放する
            g.Dispose();

            //PictureBox1に表示する
            pictureBox1.Image = canvas;

        }
    }
}
