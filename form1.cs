using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_rotations
{
    public partial class Form1 : Form
    {
        class Vector
        {
            public int x;
            public int y;
            public int z;

            public double Mag { get { return Math.Sqrt((x * x) + (y * y) + (z * z)); } }

            public Vector(int X, int Y, int Z)
            {
                x = X;
                y = Y;
                z = Z;
            }

            public static Vector operator +(Vector a, Vector b)
            {
                return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
            }

            public static Vector operator -(Vector a, Vector b)
            {
                return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
            }

            public static Vector operator *(Vector a, int number)
            {
                return new Vector(a.x * number, a.y * number, a.z * number);
            }

            public static Vector operator -(Vector a)
            {
                return new Vector(-a.x, -a.y, -a.z);
            }

            public static float operator *(Vector a, Vector b) // dot multiplication of two vectors (returns scalar)
            {
                return a.x * b.x + a.y * b.y + a.z * b.z;

            }

            public static Vector operator %(Vector A, Vector B)
            {
                return new Vector(A.y * B.z - A.z * B.y, A.z * B.x - A.x * B.z, A.x * B.y - A.y * B.x);
            }

            public override string ToString()
            {
                return $"<{x}, {y}, {z}>";
            }
        }
        Pen brush = new Pen(Color.Black);
        Color FavColor = Color.Coral;
        public static Graphics gmain;
        Vector camera;
        private void Form1_Load(object sender, EventArgs e)
        {
            gmain = panel1.CreateGraphics();
            //x.Maximum = panel1.Width;
            //y.Maximum = panel1.Height;
            x.Value = panel1.Width / 2;
            y.Value = panel1.Height / 2;
            camera = new Vector((int)x.Value, (int)y.Value, 1);
        }

        private void DrawLine(Vector p, Vector p2)
        {
            float F = p.z - camera.z;
            float F2 = p2.z - camera.z;
            float x1 = ((p.x - camera.x) * (F / p.z)) + camera.x + panel1.Width / 2;
            float y1 = ((p.y - camera.y) * (F / p.z)) + camera.y + panel1.Height / 2;
            float x2 = ((p2.x - camera.x) * (F2 / p2.z)) + camera.x + panel1.Width / 2;
            float y2 = ((p2.y - camera.y) * (F2 / p2.z)) + camera.y + panel1.Height / 2;
            gmain.DrawLine(brush, x1, y1, x2, y2);
        }
        private void DoTheThing()
        {
            camera = new Vector((int)x.Value, (int)y.Value, (int)z.Value);
            gmain.Clear(FavColor);
            List<Vector> pts = new List<Vector>();
            pts.Add(new Vector(-10, -10, 10));
            pts.Add(new Vector(-10, 10, 10));
            pts.Add(new Vector(10, -10, 10));
            pts.Add(new Vector(10, 10, 10));
            pts.Add(new Vector(-10, -10, 5));
            pts.Add(new Vector(-10, 10, 5));
            pts.Add(new Vector(10, -10, 5));
            pts.Add(new Vector(10, 10, 5));
            DrawLine(pts[0], pts[1]);
            DrawLine(pts[0], pts[2]);
            DrawLine(pts[0], pts[4]);
            DrawLine(pts[1], pts[3]);
            DrawLine(pts[1], pts[5]);
            DrawLine(pts[3], pts[2]);
            DrawLine(pts[3], pts[7]);
            DrawLine(pts[2], pts[6]);
            DrawLine(pts[5], pts[7]);
            DrawLine(pts[5], pts[4]);
            DrawLine(pts[4], pts[6]);
            DrawLine(pts[6], pts[7]);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            DoTheThing();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void X_ValueChanged(object sender, EventArgs e)
        {
            DoTheThing();
        }

        private void Y_ValueChanged(object sender, EventArgs e)
        {
            DoTheThing();
        }

        private void Z_ValueChanged(object sender, EventArgs e)
        {
            DoTheThing();
        }
    }
}
