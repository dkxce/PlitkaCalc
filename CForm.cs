using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace PlitkaCalc
{
    public partial class CForm : Form
    {
        public CForm()
        {
            InitializeComponent();
        }        

        public void CalcTiles(Zones.TPolygon BoxRect, SizeF TileSize, double Gap)
        {
            Hashtable ht = new Hashtable();            

            double tmpH = BoxRect.Height + TileSize.Height * 2;
            double tmpW = BoxRect.Width + TileSize.Width * 2;
            
            List<Zones.TPolygon> TotalTiles = new List<Zones.TPolygon>();

            if (Angle45.Checked)
            {
                double step_xy = (TileSize.Width + Gap) * Math.Sqrt(2);

                double y = 0;
                while (y < tmpH)
                {
                    double x = 0;
                    while (x < tmpW)
                    {
                        Zones.TPolygon pl;
                        pl = GetPlitka45(new PointF((float)x, (float)y), TileSize);
                        if (Zones.PolygonInPolygon(pl, BoxRect)) TotalTiles.Add(pl);
                        pl = GetPlitka45(new PointF(
                            (float)(x - step_xy / 2.0),
                            (float)(y + step_xy / 2.0)), TileSize);
                        if (Zones.PolygonInPolygon(pl, BoxRect)) TotalTiles.Add(pl);
                        x += step_xy;
                    };
                    y += step_xy;
                };
            };

            if (Angle90.Checked)
            {
                double y = 0;// wallPlan.Gap;
                while (y < tmpH)
                {
                    double x = 0;//wallPlan.Gap;
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
            int scaleSize = 1;
            if (TileSize.Width >= 100)
            {
                if (gOneTwo.Checked) scaleSize = 2;
                if (gOneThree.Checked) scaleSize = 3;
                if (gOneFour.Checked) scaleSize = 4;
                if (gOneFive.Checked) scaleSize = 5;
                if (gOneTen.Checked) scaleSize = 10;
            };
            if (makeImage.Checked)
            {                
                b = new Bitmap((int)((BoxRect.Width + TileSize.Width * 2) / scaleSize), (int)((BoxRect.Height + TileSize.Height * 2)/scaleSize));
                g = Graphics.FromImage(b);

                Zones.TPolygon pBox = new Zones.TPolygon(new Zones.TPoint(0 - TileSize.Width, 0 - +TileSize.Height), new SizeF((float)(BoxRect.Width + TileSize.Width * 2), (float)(BoxRect.Height + TileSize.Height * 2)));
                g.FillRectangle(new SolidBrush(Color.FromArgb(50,Color.Silver)),new Rectangle(0,0,b.Width,b.Height));
                PointF[] pts = new PointF[BoxRect.Dots.Length];
                for (int i = 0; i < pts.Length; i++) pts[i] = new PointF((float)((BoxRect.Dots[i].X + TileSize.Width)/ scaleSize), (float)((BoxRect.Dots[i].Y + TileSize.Height)/ scaleSize));
                g.FillPolygon(new SolidBrush(Color.White), pts);
            };

            Area1Storage ac_black = new Area1Storage();
            Area1Storage ac_red = new Area1Storage();
            Area1Storage ac_green = new Area1Storage();
            double DefaultTileArea = (new Zones.TPolygon(new Zones.TPoint(0, 0), TileSize)).Area;
            int tCo = 0;
            foreach (Zones.TPolygon CurrentTile in TotalTiles)
            {
                TileIdentity tid = new TileIdentity(new Pen(new SolidBrush(Color.Gray)), ++tCo);
                CurrentTile.ID = tid;
                if (makeImage.Checked)                    
                        CurrentTile.Draw(g, tid.pen, (int)TileSize.Width, (int)TileSize.Height, scaleSize);
                Zones.TPolygon poly = CalcOutOfBoundsPoly(CurrentTile, BoxRect, ClipperLib.ClipType.ctIntersection)[0];
                if (poly != null)// выходит за границы                
                {
                    if (poly.Area <= (DefaultTileArea / 2.0)) // меньше половины плитки
                    {
                        ac_green.Add(poly.Area,((TileIdentity)CurrentTile.ID).ID);
                        tid.pen = new Pen(new SolidBrush(Color.Green));
                    }
                    else if (poly.Area >= (DefaultTileArea * 0.85)) // Плитка полностью входит площадь
                    {
                        ac_black.Add(DefaultTileArea, ((TileIdentity)CurrentTile.ID).ID);
                        tid.pen = new Pen(new SolidBrush(Color.Black));
                    }
                    else // больше половины плитки
                    {
                        ac_red.Add(poly.Area, ((TileIdentity)CurrentTile.ID).ID);
                        tid.pen = new Pen(new SolidBrush(Color.Red));
                    };
                };                                  
            };

            LoadWallPlan();            
            
            StatusList.Text += "\r\n";            
            StatusList.Text += "Черных: " + ac_black.TilesCount.ToString() + "\r\n";
            foreach (double d in ac_black.Areas) StatusList.Text += "   " + d.ToString() + ": " + ac_black.Get(d).Length.ToString() + "\r\n";
            StatusList.Text += "Красных: " + ac_red.TilesCount.ToString() + "\r\n";
            foreach (double d in ac_red.Areas) StatusList.Text += "   " + d.ToString() + ": " + ac_red.Get(d).Length.ToString() + "\r\n";
            StatusList.Text += "Зеленых: " + ac_green.TilesCount.ToString() + "\r\n";
            foreach (double d in ac_green.Areas) StatusList.Text += "   " + d.ToString() + ": " + ac_green.Get(d).Length.ToString() + "\r\n";
            StatusList.Text += "------------\r\nВсего: " + TotalTiles.Count.ToString() + "\r\n\r\n";

            // CALC MERGE
            Area1Storage ac_all = new Area1Storage();
            foreach (double d in ac_red.Areas) ac_all.Add(d,ac_red.Get(d));
            foreach (double d in ac_green.Areas) ac_all.Add(d,ac_green.Get(d));
                        
            Area2AreaStorage a2c = new Area2AreaStorage();
            while (ac_all.Areas.Length > 0)
            {
                double val1 = ac_all.Areas[0];
                double val2 = 0;

                int tile1 = ac_all.Get(val1)[0];
                int tile2 = 0;

                double max1 = val1 + val2;                
                ac_all.Remove(val1,tile1);
                for (int i = 0; i < ac_all.Areas.Length; i++)
                {
                    double tmp_max = val1 + ac_all.Areas[i];
                    if ((tmp_max > max1) && (tmp_max < DefaultTileArea))
                    {
                        max1 = tmp_max;
                        val2 = ac_all.Areas[i];
                    };
                };
                if (val2 > 0)
                {
                    tile2 = ac_all.Get(val2)[0];
                    ac_all.Remove(val2, tile2);
                };
                a2c.Add(val1, val2,tile1,tile2);
            };

            if (makeImage.Checked)
            {
                if(drawWalls.Checked)
                    BoxRect.Draw(g, new Pen(new SolidBrush(Color.FromArgb(150, Color.Navy)), 1), (int)TileSize.Width, (int)TileSize.Height, scaleSize);                

                int btc = 0;
                foreach (double d in ac_black.Areas)
                    foreach (int id in ac_black.Get(d))
                        foreach (Zones.TPolygon CurrentTile in TotalTiles)
                            if (((TileIdentity)CurrentTile.ID).ID == id)
                            {
                                CurrentTile.Title = (++btc).ToString();
                                if (tileEnum.Checked) 
                                    CurrentTile.DrawTitle(g, ((TileIdentity)CurrentTile.ID).pen, (int)TileSize.Width, (int)TileSize.Height, scaleSize, wallPlan.Angle);
                            };

                foreach (Area2AreaStorage.TileTwinStorage a12 in a2c.Areas)
                    foreach (int[] ids in a12.TileTwins)
                    {
                        btc++;
                        foreach (Zones.TPolygon CurrentTile in TotalTiles)
                            if ((((TileIdentity)CurrentTile.ID).ID == ids[0]) || (((TileIdentity)CurrentTile.ID).ID == ids[1]))
                            {
                                CurrentTile.Title = btc.ToString();
                                CurrentTile.Fill(g, new Pen(new SolidBrush(Color.FromArgb(25,(((TileIdentity)CurrentTile.ID).pen.Color)))), (int)TileSize.Width, (int)TileSize.Height, scaleSize);
                                if (tileEnum.Checked) 
                                    CurrentTile.DrawTitle(g, ((TileIdentity)CurrentTile.ID).pen, (int)TileSize.Width, (int)TileSize.Height, scaleSize, wallPlan.Angle);
                            };
                    };
                pictureBox1.Image = b;
            };

            int ttl = 0;
            foreach (Area2AreaStorage.TileTwinStorage a12 in a2c.Areas) ttl += a12.TileTwins.Count;
            StatusList.Text += "\r\n";
            StatusList.Text += "С компоновкой: " + ac_black.TilesCount.ToString() + " + " + ttl.ToString() + " = " + (ac_black.TilesCount + ttl).ToString() + "\r\n";
            foreach (double d in ac_black.Areas) StatusList.Text += "   " + d.ToString() + ": " + ac_black.Get(d).Length.ToString() + "\r\n";
            foreach (Area2AreaStorage.TileTwinStorage a12 in a2c.Areas)
                StatusList.Text += "   " + a12.area1.ToString() + "+" + a12.area2.ToString() + ": " + a12.TileTwins.Count.ToString() + "\r\n";
            
            // SQUARE
            StatusList.Text += "\r\n";
            StatusList.Text += "Площадь контура: " + BoxRect.Area.ToString() + " мм2\r\n";
            Zones.TPolygon tilp = new Zones.TPolygon(new Zones.TPoint(0, 0), new SizeF((float)(wallPlan.TileWidth + Gap), (float)(wallPlan.TileHeight + Gap)));
            StatusList.Text += "Площадь плитки: " + tilp.Area.ToString() + " мм2\r\n";
            int tilesSquare = (int)Math.Truncate(BoxRect.Area / tilp.Area+1);
            StatusList.Text += "Плиток по площади: " + tilesSquare.ToString() + "\r\n";
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
            double x2 = (double)(StartPoint.X + Plitka.Width / r2);
            double x3 = (double)(StartPoint.X + Plitka.Width / r2 * 2);
            double y1 = StartPoint.Y;
            double y2 = (double)(StartPoint.Y - Plitka.Height / r2);
            double y4 = (double)(StartPoint.Y + Plitka.Height / r2);

            Zones.TPolygon plb = new Zones.TPolygon(4);
            plb[0] = new Zones.TPoint(x1, y1);
            plb[1] = new Zones.TPoint(x2, y2);
            plb[2] = new Zones.TPoint(x3, y1);
            plb[3] = new Zones.TPoint(x2, y4);

            return plb;
        }

        private Zones.TPolygon[] CalcOutOfBoundsPoly(Zones.TPolygon Tile, Zones.TPolygon BoxRect, ClipperLib.ClipType clipType)
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

            bool res = (c.Execute(clipType, solution)); // , ClipperLib.PolyFillType.pftEvenOdd, ClipperLib.PolyFillType.pftEvenOdd
            if (res)
                if (solution.Count > 0)
                {
                    List<Zones.TPolygon> pols = new List<Zones.TPolygon>();
                    for (int s = 0; s < solution.Count; s++)
                    {
                        Zones.TPolygon poly = new Zones.TPolygon((ushort)solution[s].outer.Count);
                        for (int i = 0; i < poly.Dots.Length; i++) poly[i] = new Zones.TPoint((double)solution[s].outer[i].X, (double)solution[s].outer[i].Y);
                        pols.Add(poly);
                    };
                    return pols.ToArray();
                };

            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        WallsPlan wallPlan = new WallsPlan();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadWallPlan();
        }

        public void LoadWallPlan()
        {
            makeImage.Checked = wallPlan.Plot;
            Angle90.Checked = wallPlan.Angle != 45;
            Angle45.Checked = !Angle90.Checked;

            if (wallPlan.Angle == 45) wallPlan.TileHeight = wallPlan.TileWidth;

            Text = "Расчет плитки ["+wallPlan.caption+"]";

            pictureBox1.Image = null;
            StatusList.Clear();
            StatusList.Text += "Загружен профиль\r\n";
            StatusList.Text += wallPlan.caption+"\r\n\r\n";
            StatusList.Text += "Углов: " + wallPlan.points.Length.ToString() + "\r\n";
            StatusList.Text += "Размер плитки: " + wallPlan.TileWidth.ToString()+" x "+ wallPlan.TileHeight.ToString() + " мм\r\n";
            StatusList.Text += "Межплиточный отступ: " + wallPlan.Gap.ToString() + " мм\r\n";
            StatusList.Text += "Угол укладки: " + wallPlan.Angle.ToString() + "°\r\n";
            StatusList.Text += "Чертеж: " + (wallPlan.Plot ? "да" : "нет") + " \r\n";

        }

        public void LoadWallPlan(string fileName)
        {
            wallPlan = WallsPlan.Load(fileName);
            //wallPlan.caption = System.IO.Path.GetFileName(fileName);
            LoadWallPlan();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void новыйПрофильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wallPlan = new WallsPlan();
            LoadWallPlan();
        }

        private void загрузитьПрофильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите файл с полигоном";
            ofd.DefaultExt = ".wplan";
            ofd.Filter = "Walls Plan (*.wplan)|*.wplan|Все типы файлов (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK) LoadWallPlan(ofd.FileName);
            ofd.Dispose();
        }

        private void Execute_Click(object sender, EventArgs e)
        {
            if (wallPlan.points.Length < 3) return;

            List<Zones.TPoint> pts = new List<Zones.TPoint>();
            for (int i = 0; i < wallPlan.points.Length; i++)
                pts.Add(new Zones.TPoint(wallPlan.points[i].X, wallPlan.points[i].Y));

            Zones.TPolygon WallsPolygon = new Zones.TPolygon();
            WallsPolygon.Dots = pts.ToArray();

            SizeF Tile = new SizeF((float)wallPlan.TileWidth, (float)wallPlan.TileHeight);
            CalcTiles(WallsPolygon, Tile, wallPlan.Gap);
        }

        private void makeImage_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            wallPlan.Plot = !wallPlan.Plot;
            LoadWallPlan();
        }

        private void Angle45_Click(object sender, EventArgs e)
        {
            wallPlan.Angle = (wallPlan.Angle != 90 ? 90 : 45);
            LoadWallPlan();
        }

        private void сохранитьПрофильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Выберите файл с полигоном";
            sfd.DefaultExt = ".wplan";
            sfd.Filter = "Walls Plan (*.wplan)|*.wplan|Все типы файлов (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                wallPlan.caption = System.IO.Path.GetFileName(sfd.FileName);
                WallsPlan.Save(sfd.FileName, wallPlan);
            };
            sfd.Dispose();
            LoadWallPlan();
        }

        private void размерыПлиткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TForm tf = new TForm();
            tf.tWi.Text = wallPlan.TileWidth.ToString();
            tf.tLe.Text = wallPlan.TileHeight.ToString();
            tf.tGa.Text = wallPlan.Gap.ToString();
            if (wallPlan.Angle == 45) tf.tLe.Enabled = false;
            if (tf.ShowDialog() == DialogResult.OK)
            {
                wallPlan.TileWidth = Convert.ToDouble(tf.tWi.Text);
                wallPlan.TileHeight = Convert.ToDouble(tf.tLe.Text);
                wallPlan.Gap = Convert.ToDouble(tf.tGa.Text);
                LoadWallPlan();
            };
            tf.Dispose();
        }

        private void сохранитьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Введите имя файла";
            sfd.DefaultExt = ".bmp";
            sfd.Filter = "Bitmap файлы (*.bmp)|*.bmp|Все типы файлов (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(sfd.FileName);
            };
            sfd.Dispose();
        }

        private void узлыПериметраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NForm nf = new NForm();
            nf.textBox1.Text = "";
            for (int i = 0; i < wallPlan.points.Length; i++) nf.textBox1.Text += wallPlan.points[i].X.ToString() + ";\t" + wallPlan.points[i].Y.ToString() + "\r\n";
            if (nf.ShowDialog() == DialogResult.OK)
            {
                List<Zones.TPoint> pts = new List<Zones.TPoint>();
                string[] lns = nf.textBox1.Text.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string ln in lns)
                {
                    string[] xy = ln.Split(new string[] { ";", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                    pts.Add(new Zones.TPoint(Convert.ToDouble(xy[0].Trim()), Convert.ToDouble(xy[1].Trim())));
                };
                wallPlan.points = pts.ToArray();
                LoadWallPlan();
            };
            nf.Dispose();
        }
        

        public static string GetCurrentDir()
        {
            string fname = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase.ToString();
            fname = fname.Replace("file:///", "");
            fname = fname.Replace("/", @"\");
            fname = fname.Substring(0, fname.LastIndexOf(@"\") + 1);
            return fname;
        }

        private void tileEnum_Click(object sender, EventArgs e)
        {
            tileEnum.Checked = !tileEnum.Checked;
        }

        private void drawWalls_Click(object sender, EventArgs e)
        {
            drawWalls.Checked = !drawWalls.Checked;
        }

        private void gOneTwo_Click(object sender, EventArgs e)
        {
            gOneOne.Checked = false;
            gOneTwo.Checked = true;
            gOneFive.Checked = false;
            gOneTen.Checked = false;
            gOneThree.Checked = false;
            gOneFour.Checked = false;
        }

        private void gOneFive_Click(object sender, EventArgs e)
        {
            gOneOne.Checked = false;
            gOneTwo.Checked = false;
            gOneFive.Checked = true;
            gOneTen.Checked = false;
            gOneThree.Checked = false;
            gOneFour.Checked = false;
        }

        private void gOneTen_Click(object sender, EventArgs e)
        {
            gOneOne.Checked = false;
            gOneTwo.Checked = false;
            gOneFive.Checked = false;
            gOneTen.Checked = true;
            gOneThree.Checked = false;
            gOneFour.Checked = false;
        }

        private void gOneThree_Click(object sender, EventArgs e)
        {
            gOneOne.Checked = false;
            gOneTwo.Checked = false;
            gOneFive.Checked = false;
            gOneTen.Checked = false;
            gOneThree.Checked = true;
            gOneFour.Checked = false;
        }

        private void gOneFour_Click(object sender, EventArgs e)
        {
            gOneOne.Checked = false;
            gOneTwo.Checked = false;
            gOneFive.Checked = false;
            gOneTen.Checked = false;
            gOneThree.Checked = false;
            gOneFour.Checked = true;
        }

        private void gOneOne_Click(object sender, EventArgs e)
        {
            gOneOne.Checked = true;
            gOneTwo.Checked = false;
            gOneFive.Checked = false;
            gOneTen.Checked = false;
            gOneThree.Checked = false;
            gOneFour.Checked = false;
        }
    }

    /// <summary>
    ///     wplan file format
    /// </summary>
    public class WallsPlan: XmlSaved<WallsPlan>
    {
        public string caption = "Безымянный";
        [XmlArrayItem("xy")]
        public Zones.TPoint[] points = new Zones.TPoint[0];
        public double TileHeight = 30;
        public double TileWidth = 30;
        public double Gap = 2;
        public int Angle = 90;
        public bool Plot = true;

    }

    public class Area1Storage
    {
        private class TilesStorage
        {
            private List<int> _tiles = new List<int>();
            
            public int TilesCount { get { return _tiles.Count; }}
            public void AddTile(int ID)
            {
                _tiles.Remove(ID);
                _tiles.Add(ID);
            }
            public void AddTiles(int[] IDs)
            {
                for (int i = 0; i < IDs.Length; i++)
                    AddTile(IDs[i]);
            }
            public void RemoveTile(int ID)
            {
                _tiles.Remove(ID);
            }
            public int[] Tiles
            {
                get { return _tiles.ToArray(); }
            }
        }

        private Hashtable _areas = new Hashtable();
        
        public double[] Areas
        {
            get
            {
                List<double> areas = new List<double>();
                foreach (double val in _areas.Keys) areas.Add(val);
                areas.Sort();
                areas.Reverse();
                return areas.ToArray();
            }
        }
        public int AreasCount
        {
            get { return _areas.Keys.Count; }
        }
        public int TilesCount
        {
            get
            {
                int ttl = 0;
                foreach (double dv in _areas.Keys)
                    ttl += ((TilesStorage)_areas[dv]).TilesCount;
                return ttl;
            }
        }
        public void Add(double area, int ID)
        {
            TilesStorage na = null;
            foreach (double dv in _areas.Keys)
                if (area == dv) na = (TilesStorage)_areas[dv];

            if (na == null)
            {
                na = new TilesStorage();
                _areas.Add(area, na);
            };
            na.AddTile(ID);
        }
        public void Add(double area, int[] IDs)
        {
            TilesStorage na = null;
            foreach (double dv in _areas.Keys)
                if (area == dv) na = (TilesStorage)_areas[dv];

            if (na == null)
            {
                na = new TilesStorage();
                _areas.Add(area, na);
            };
            na.AddTiles(IDs);
        }
        public int[] Get(double area)
        {
            TilesStorage tileStore = new TilesStorage();
            foreach (double dv in _areas.Keys)
                if (area == dv) tileStore = (TilesStorage)_areas[dv];
            return tileStore.Tiles;
        }
        public void Remove(double area, int ID)
        {
            List<double> d = new List<double>();
            foreach (double dv in _areas.Keys) d.Add(dv);            
            for (int i = d.Count - 1; i >= 0; i--)
            {
                double dv = d[i];
                if (area == dv)
                {
                    TilesStorage na = (TilesStorage)_areas[dv];
                    na.RemoveTile(ID);
                    if (na.TilesCount == 0) _areas.Remove(dv);
                };
            };
        }
    }

    public class Area2AreaStorage
    {
        public class TileTwinStorage
        {
            public double area1;
            public double area2;
            public List<int[]> TileTwins = new List<int[]>();

            public bool AreaExists(double d)
            {
                return ((area1 == d) || (area2 == d));
            }

            public bool TileExists(int ID)
            {
                foreach (int[] tileIDs in TileTwins)
                    if (tileIDs != null)
                        foreach (int id in tileIDs)
                            if (id == ID) return true;
                return false;
            }
        }

        public class TileTwinComparer : IComparer<TileTwinStorage>
        {
            public int Compare(TileTwinStorage objA, TileTwinStorage objB)
            {
                return objA.area1.CompareTo(objB.area1);
            }
        }

        private List<TileTwinStorage> _tileTwinAreas = new List<TileTwinStorage>();

        public TileTwinStorage[] Areas
        {
            get { return _tileTwinAreas.ToArray(); }
        }
        public int AreasCount
        {
            get { return _tileTwinAreas.Count; }
        }
        public int TilesCount
        {
            get
            {
                int ttl = 0;
                foreach (TileTwinStorage dv in _tileTwinAreas) ttl += dv.TileTwins.Count;
                return ttl;
            }
        }

        public void Add(double a1, double a2, int id1, int id2)
        {
            TileTwinStorage a12 = null;
            foreach (TileTwinStorage dv in _tileTwinAreas)
                    if ((dv.AreaExists(a1) && dv.AreaExists(a2)))
                        a12 = dv;
                if (a12 == null)
                {
                    a12 = new TileTwinStorage();
                    a12.area1 = a1;
                    a12.area2 = a2;
                    _tileTwinAreas.Add(a12);
                };
            if (a12.TileExists(id1)) return;
            if (a12.TileExists(id2)) return;
            a12.TileTwins.Add(new int[] { id1, id2 });
        }

        public TileTwinStorage Get(double a1, double a2)
        {
            foreach (TileTwinStorage dv in _tileTwinAreas)
                if ((dv.AreaExists(a1) && dv.AreaExists(a2)))
                    return dv;
            return null;
        }
    }

    public class TileIdentity
    {
        public Pen pen;
        public int ID;
        public TileIdentity(Pen pen, int ID)
        {
            this.pen = pen;
            this.ID = ID;
        }
    }
}