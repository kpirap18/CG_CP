﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    class Shadow
    {
        public Shadow(Point3D cen, Point3D p, House h, double y)
        {
            int count_ray = 0;
            _sh = new PointF[8][];

            for (int i = 0; i < 4; i++)
            {
                var pol = new PointF[4];
                var point3 = new Point3D(h.S[i].P[0].X,
                                         h.S[i].P[0].Y,
                                         h.S[i].P[0].Z);
                Transform.TurnY(cen, point3, y);
                Transform.TurnX(cen, point3, -15);

                pol[0] = point3.PointF;
                point3 = new Point3D(h.S[i].P[1].X,
                                     h.S[i].P[1].Y,
                                     h.S[i].P[1].Z);

                Transform.TurnY(cen, point3, y);
                Transform.TurnX(cen, point3, -15);

                pol[1] = point3.PointF;
                for (int j = 2; j < 4; j++)
                {
                    var per = new Point3D();
                    count_ray++;
                    var ray = new Ray(new Point3D(h.S[i].P[j].X - p.X,
                                                  h.S[i].P[j].Y - p.Y,
                                                  h.S[i].P[j].Z - p.Z),
                                                  new Point3D(p.X, p.Y, p.Z));
                    double t = (ray.Beg.Y + 500) / (ray.Vec.Y);

                    per.X = (float)(ray.Beg.X + ray.Vec.X * t);
                    per.Y = 500;
                    per.Z = (float)(ray.Beg.Z + ray.Vec.Z * t);

                    Transform.TurnY(cen, per, y);
                    Transform.TurnX(cen, per, -15);

                    pol[j] = per.PointF;
                }
                _sh[i] = pol;
            }

            for (int i = 4; i < 8; i++)
            {
                var pol = new PointF[4];
                var point3 = new Point3D(h.S[i - 4].P[0].X,
                                         h.S[i - 4].P[0].Y,
                                         h.S[i - 4].P[0].Z);
                Transform.TurnY(cen, point3, y);
                Transform.TurnX(cen, point3, -15);

                pol[0] = point3.PointF;
                point3 = new Point3D(h.S[i - 4].P[1].X,
                                     h.S[i - 4].P[1].Y,
                                     h.S[i - 4].P[1].Z);

                Transform.TurnY(cen, point3, y);
                Transform.TurnX(cen, point3, -15);

                pol[1] = point3.PointF;
                for (int j = 2; j < 4; j++)
                {
                    var per = new Point3D();
                    count_ray++;
                    var ray = new Ray(new Point3D(h.S[i - 4].P[j].X - p.X,
                                                  h.S[i].P[j].Y - p.Y,
                                                  h.S[i - 4].P[j].Z - p.Z),
                                                  new Point3D(p.X, p.Y, p.Z));
                    double t = (ray.Beg.Y + 500) / (ray.Vec.Y);

                    per.X = (float)(ray.Beg.X + ray.Vec.X * t);
                    per.Y = 500;
                    per.Z = (float)(ray.Beg.Z + ray.Vec.Z * t);

                    Transform.TurnY(cen, per, y);
                    Transform.TurnX(cen, per, -15);

                    pol[j] = per.PointF;
                }
                _sh[i] = pol;
            }
        }

        public void DrawShadow(Graphics g)
        {
            Brush b = new SolidBrush(Color.Black);

            for (int i = 0; i < 8; i++)
            {
                g.FillPolygon(b, _sh[i]);
            }
        }

        private readonly PointF[][] _sh;
    }
}
