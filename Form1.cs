using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PlitkaCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string GetCurrentDir()
        {
            string fname = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString();
            fname = fname.Replace("file:///", "");
            fname = fname.Replace("/", @"\");
            fname = fname.Substring(0, fname.LastIndexOf(@"\") + 1);
            return fname;
        }

        public void CalcTiles(Zones.TPolygon BoxRect, SizeF TileSize, double Gap)
        {
            Hashtable ht = new Hashtable();            

            double tmpH = BoxRect.Height + TileSize.Height * 2;
            double tmpW = BoxRect.Width + TileSize.Width * 2;
            
            List<Zones.TPolygon> TotalTiles = new List<Zones.TPolygon>();

            if (Angle45.Checked)
            {
                double step_xy = Math.Sqrt(Math.Pow((double)TileSize.Width + Gap, 2.0) + Math.Pow((double)TileSize.Height + Gap, 2.0));

                double y = 0;// TileSize.Height;
                while (y < tmpH)
                {
                    double x = 0;// TileSize.Width;
                    while (x < tmpW)
                    {
                        Zones.TPolygon pl;
                        pl = GetPlitka45(new PointF((float)x, (float)y), TileSize);
                        if (Zones.PolygonInPolygon(pl, BoxRect)) TotalTiles.Add(pl);
                        pl = GetPlitka45(new PointF(
                            (float)(x - step_xy / 2.0),
                            (float)(y + step_xy / 2.0)), TileSize);
                        if (Zones.PolygonInPolygon(pl, BoxRect)) TotalTiles.Add(pl);
                        x += TileSize.Width * (double)Math.Sqrt(2) + Gap;
                    };
                    y += TileSize.Width * (double)Math.Sqrt(2) + Gap;
                };
            };

            if (Angle90.Checked)
            {
                double y = 0;// TileSize.Height;
                while (y < tmpH)
                {
                    double x = 0;// TileSize.Width;
                    while (x < tmpW)
                    {
                        Zones.TPolygon pl = GetPlitka90(new PointF((float)x, (float)y), TileSize);
                        if (Zones.PolygonInPolygon(pl, BoxRect)) TotalTiles.Add(pl);
                        x += TileSize.Width + Gap;
                    };
                    y += TileSize.Height + Gap;
                };
            };

            Bitmap b = null;            
            Graphics g = null;
            if (!NoDraw.Checked)
            {
                b = new Bitmap((int)(BoxRect.Width + TileSize.Width * 2), (int)(BoxRect.Height + TileSize.Height * 2));
                g = Graphics.FromImage(b);
            };

            int count_Black = 0;
            int count_Red = 0;
            int count_Green = 0;
            AreasCount ac_red = new AreasCount();
            AreasCount ac_green = new AreasCount();
            double DefaultTileArea = (new Zones.TPolygon(new Zones.TPoint(0, 0), TileSize)).Area;
            int tCo = 0;
            foreach (Zones.TPolygon CurrentTile in TotalTiles)
            {
                CurrentTile.Title = tCo++;
                Pen pen = new Pen(new SolidBrush(Color.Gray));
                if (!NoDraw.Checked) CurrentTile.Draw(g, pen, (int)TileSize.Width, (int)TileSize.Height);
                Zones.TPolygon poly = CalcOutOfBoundsPoly(CurrentTile, BoxRect);
                if (poly != null)// выходит за границы                
                {
                    if (poly.Area <= (DefaultTileArea / 2.0)) // меньше половины плитки
                    {
                        ac_green[poly.Area]++;
                        count_Green++;
                        pen = new Pen(new SolidBrush(Color.Green));
                        poly.Title = CurrentTile.Title;
                        if (!NoDraw.Checked) poly.Draw(g, pen, (int)TileSize.Width, (int)TileSize.Height);
                    }
                    else if (poly.Area >= (DefaultTileArea * 0.85)) // Плитка полностью входит площадь
                    {
                        count_Black++;
                        pen = new Pen(new SolidBrush(Color.Black));
                        if (!NoDraw.Checked) CurrentTile.Draw(g, pen, (int)TileSize.Width, (int)TileSize.Height);
                    }
                    else // больше половины плитки
                    {
                        ac_red[poly.Area]++;
                        count_Red++;
                        pen = new Pen(new SolidBrush(Color.Red));
                        if (!NoDraw.Checked) CurrentTile.Draw(g, pen, (int)TileSize.Width, (int)TileSize.Height);
                    };
                };                                  
            };

            SolidBrush br = new SolidBrush(Color.FromArgb(80, Color.Navy));
            if (!NoDraw.Checked)
            {
                BoxRect.Draw(g, new Pen(new SolidBrush(Color.FromArgb(255, Color.Black))), (int)TileSize.Width, (int)TileSize.Height);
                pictureBox1.Image = b;
                pictureBox1.Image.Save(GetCurrentDir() + @"\Calced.bmp");
            };            

            textBox9.Text = "Черных: " + count_Black.ToString()+"\r\n";
            textBox9.Text += "   " + DefaultTileArea.ToString() + ": " + count_Black.ToString() + "\r\n";
            textBox9.Text += "Красных: " + count_Red.ToString() + "\r\n";
            foreach (double d in ac_red.Areas) textBox9.Text += "   " + d.ToString() + ": " + ac_red[d].ToString() + "\r\n";
            textBox9.Text += "Зеленых: " + count_Green.ToString() + "\r\n";
            foreach (double d in ac_green.Areas) textBox9.Text += "   " + d.ToString() + ": " + ac_green[d].ToString() + "\r\n";
        }
        
        private Zones.TPolygon GetPlitka90(PointF StartX, SizeF Plitka)
        {
            double x2 = StartX.X + Plitka.Width;
            double y2 = StartX.Y + Plitka.Height;

            Zones.TPolygon plb = new Zones.TPolygon(4);
            plb[0] = new Zones.TPoint(StartX.X, StartX.Y);
            plb[1] = new Zones.TPoint(x2, StartX.Y);
            plb[2] = new Zones.TPoint(x2, y2);
            plb[3] = new Zones.TPoint(StartX.X, y2);

            return plb;
        }

        private Zones.TPolygon GetPlitka45(PointF StartPoint, SizeF Plitka)
        {
            double r2 = Math.Sqrt(2);

            double x1 = StartPoint.X;
            double x2 = (double)(StartPoint.X + Plitka.Width * r2 / 2.0);
            double x3 = (double)(StartPoint.X + Plitka.Width * r2);
            double y1 = StartPoint.Y;
            double y2 = (double)(StartPoint.Y - Plitka.Height * r2 / 2.0);
            double y4 = (double)(StartPoint.Y + Plitka.Height * r2 / 2.0);

            Zones.TPolygon plb = new Zones.TPolygon(4);
            plb[0] = new Zones.TPoint(x1, y1);
            plb[1] = new Zones.TPoint(x2, y2);
            plb[2] = new Zones.TPoint(x3, y1);
            plb[3] = new Zones.TPoint(x2, y4);

            return plb;
        }

        private Zones.TPolygon CalcOutOfBoundsPoly(Zones.TPolygon Tile, Zones.TPolygon BoxRect)
        {
            List<List<ClipperLib.IntPoint>> subj = new List<List<ClipperLib.IntPoint>>();
            subj.Add(new List<ClipperLib.IntPoint>());
            for (int i = 0; i < Tile.Dots.Length; i++)
                subj[0].Add(new ClipperLib.IntPoint((long)Tile[i].X, (long)Tile[i].Y));
            
            List<List<ClipperLib.IntPoint>> clip = new List<List<ClipperLib.IntPoint>>();
            clip.Add(new List<ClipperLib.IntPoint>(4));
            for (int i = 0; i < BoxRect.Dots.Length; i++)
                clip[0].Add(new ClipperLib.IntPoint((long)BoxRect[i].X, (long)BoxRect[i].Y));

            List<ClipperLib.ExPolygon> solution = new List<ClipperLib.ExPolygon>();

            ClipperLib.Clipper c = new ClipperLib.Clipper();
            c.AddPolygons(clip, ClipperLib.PolyType.ptSubject);
            c.AddPolygons(subj, ClipperLib.PolyType.ptClip);

            bool res = (c.Execute(ClipperLib.ClipType.ctIntersection, solution, ClipperLib.PolyFillType.pftEvenOdd, ClipperLib.PolyFillType.pftEvenOdd));
            if (res)
                if (solution.Count > 0)
                {
                    Zones.TPolygon poly = new Zones.TPolygon((ushort)solution[0].outer.Count);
                    for (int i = 0; i < poly.Dots.Length; i++) poly[i] = new Zones.TPoint((double)solution[0].outer[i].X, (double)solution[0].outer[i].Y);
                    return poly;
                };

            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SizeF Tile = new SizeF((float)Convert.ToDouble(textBox4.Text), (float)Convert.ToDouble(textBox3.Text));            
            double Gap = Convert.ToInt32(textBox5.Text);
            CalcTiles(FormPoly, Tile, Gap);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите файл с полигоном";
            ofd.DefaultExt = ".txt";
            ofd.Filter = "Текстовые файлы (*.txt)|*.txt|Все типы файлов (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileStream fs = new System.IO.FileStream(ofd.FileName, System.IO.FileMode.Open);
                System.IO.StreamReader sr = new System.IO.StreamReader(fs);
                List<Zones.TPoint> pts = new List<Zones.TPoint>();
                while (!sr.EndOfStream)
                {
                    string ln = sr.ReadLine();
                    string[] lns = ln.Split(new string[] { ";" }, StringSplitOptions.None);
                    pts.Add(new Zones.TPoint(Convert.ToDouble(lns[0]), Convert.ToDouble(lns[1])));
                };
                sr.Close();
                fs.Close();

                FormPoly = new Zones.TPolygon();
                FormPoly.Dots = pts.ToArray();
            };
            ofd.Dispose();
        }

        Zones.TPolygon FormPoly = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            FormPoly = new Zones.TPolygon();
            FormPoly.Dots = new Zones.TPoint[4];
            FormPoly[0] = new Zones.TPoint(0, 0);
            FormPoly[1] = new Zones.TPoint(170, 0);
            FormPoly[2] = new Zones.TPoint(170, 170);
            FormPoly[3] = new Zones.TPoint(0, 170);
        }       
    }

    public class AreasCount
    {
        private Hashtable ht = new Hashtable();
        public double[] Areas
        {
            get
            {
                List<double> d = new List<double>();
                foreach (double dv in ht.Keys) d.Add(dv);
                return d.ToArray();
            }
        }
        public int Count
        {
            get { return ht.Keys.Count; }
        }
        public int this[double area]
        {
            get
            {
                foreach (double dv in ht.Keys)
                    if (area == dv) return (int)ht[dv];
                return 0;
            }
            set
            {
                ht[area] = value;
            }
        }

    }
}