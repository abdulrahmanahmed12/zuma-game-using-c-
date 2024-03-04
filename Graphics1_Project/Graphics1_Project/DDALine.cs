using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Lec_1_DDA
{
    public class DDALine
    {
        public int xs;
        public int ys;
        public int xe;
        public int ye;
        public bool flagstop = false;
        public DDALine(int xst,int yst,int xend,int yend)
        {
            xs = xst;
            ys = yst;
            xe = xend;
            ye = yend;
        }
        public void DrawmyLine(Graphics g)
        {
            float dx = xe - xs;
            float dy = ye - ys;
            float m = dy / dx;
            float cx = xs;
            float cy = ys;
            int speed = 15;
            while (true)
            {
                g.FillEllipse(Brushes.Black, cx, cy, 3, 3);
                if (Math.Abs(dx) > Math.Abs(dy))
                {
                    if (xs < xe)
                    {
                        cx += speed;
                        cy += m * speed;
                        if (cx >= xe)
                            break;
                    }
                    else
                    {
                        cx -= speed;
                        cy -= m * speed;
                        if (cx <= xe)
                            break;
                    }

                }
                else
                {
                    if (ys < ye)
                    {
                        cy += speed;
                        cx += (1 / m) * speed;
                        if (cy >= ye)
                            break;
                    }
                    else
                    {
                        cy -= speed;
                        cx -= (1 / m) * speed;
                        if (cy <= ye)
                            break;
                    }

                }
            }
        }
        public PointF getnextpoint(float cx, float cy)
        {
            float dx = xe - xs;
            float dy = ye - ys;
            float m = dy / dx;
            int speed = 50;
            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if (xs < xe)
                {
                    cx += speed;
                    cy += m * speed;
                    if (cx >= xe)
                    {
                        //if (flagd == 1)
                        //    flagd = 0;
                        //else
                        //    flagd = 1;
                        flagstop = true;
                    }
                }
                else
                {
                    cx -= speed;
                    cy -= m * speed;
                    if (cx <= xe)
                    {
                        flagstop = true;
                    }
                }

            }
            else
            {
                if (ys < ye)
                {
                    cy += speed;
                    cx += (1 / m) * speed;
                    if (cy >= ye)
                    {
                        flagstop = true;
                    }
                }
                else
                {
                    cy -= speed;
                    cx -= (1 / m) * speed;
                    if (cy <= ye)
                    {
                        flagstop = true;
                    }
                }

            }
            PointF pnn = new PointF(cx, cy);
            return pnn;
        }
    }
}

