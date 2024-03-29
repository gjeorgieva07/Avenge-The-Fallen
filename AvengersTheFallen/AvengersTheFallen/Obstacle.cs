﻿using AvengersTheFallen.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersTheFallen
{
    public class Obstacle
    {
        public Point Location { get; set; }
        public Image image;
        string level;
        enum Hulk
        {
            car,
            bus,
            motorcycle
        }
        public Obstacle(Point p, string level)
        {
            Location = p;
            this.level = level;
            if (level == "Hulk")
            {
                int k = Form1.r.Next(0, Enum.GetNames(typeof(Hulk)).Length);
                Hulk e = (Hulk)k;
                if (Hulk.car == e)
                    image = new Bitmap(Resources.car, new Size(50, 100));
                if (Hulk.bus == e)
                    image = new Bitmap(Resources.bus, new Size(50, 150));
                if (Hulk.motorcycle == e)
                    image = new Bitmap(Resources.motorcycle, new Size(30, 60));
            }
            if (level == "IronMan")
            {
                int k = Form1.r.Next(1, 3);
                if(k == 1)
                {
                    image = new Bitmap(Resources.IronManObstacle1, new Size(56, 46));
                }
                else
                {
                    image = new Bitmap(Resources.IronManObstacle2, new Size(82, 94));
                }
            }
            if (level == "Thor")
            {
                int k = Form1.r.Next(1, 3);
                if (k == 1)
                {
                    image = new Bitmap(Resources.ThorObstacle1, new Size(113, 45));
                }
                else
                {
                    image = new Bitmap(Resources.ThorObstacle2, new Size(40, 123));
                }
            }
            if (level == "CaptainAmerica")
            {
                int k = Form1.r.Next(1, 4);
                if (k == 1)
                {
                    image = new Bitmap(Resources.CaptainAmericaObstacle1, new Size(97, 110));
                }
                else if (k == 2)
                {
                    image = new Bitmap(Resources.CaptainAmericaObstacle2, new Size(122, 60));
                }
                else
                {
                    image = new Bitmap(Resources.CaptainAmericaObstacle3, new Size(118, 105));
                }
            }
            if (level == "ScarletWitch")
			{
				int k = Form1.r.Next(1, 3);
				if (k == 1)
				{
					image = new Bitmap(Resources.car, new Size(50,100));
				}
				else
				{
					image = new Bitmap(Resources.bus, new Size(50,150));
				}
			}
			if (level == "DrStrange")
			{
				int k = Form1.r.Next(1, 4);
				if (k == 1)
				{
					image = new Bitmap(Resources.drstrangeObstacle1, new Size(100, 50));
				}
				else if (k == 2)
				{
					image = new Bitmap(Resources.drstrangeObstacle2, new Size(100, 50));
				}
				else
				{
					image = new Bitmap(Resources.drstrangeObstacle3, new Size(70, 50));
				}
			}

		}

        public void Draw(Graphics g)
        {
            g.DrawImage(image, Location.X, Location.Y, image.Width, image.Height);
        }
    }
}
