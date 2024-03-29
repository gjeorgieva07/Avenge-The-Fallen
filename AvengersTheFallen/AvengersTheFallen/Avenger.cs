﻿using AvengersTheFallen.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvengersTheFallen
{
    public class Avenger
    {
        public Point Location { get; set; }
        public string Name { get; set; }
        public Image Character { get; set; }
        public int width, height;
        public List<Weapon> shots { get; set; }
        public int Damage { get; set; }
        public int BossDamage { get; private set; }
		private Image heart;
		public bool Final = false;

		public Avenger(string name, Point position)
        {
            Name = name;
            width = 1000;
            height = 500;
			Location = position;
			Damage = 0;
            BossDamage = 0;
            shots = new List<Weapon>();
			heart = Resources.heart;
			heart = new Bitmap(heart, new Size(30, 30));
			if (Name == "IronMan")
            {
				Character = Resources.ironman;
			}
            else if (Name == "Thor")
            {
                Character = Resources.thor;
			}
            else if (Name == "Hulk")
            {
				Character = Resources.hulk;
			}
            else if (Name == "ScarletWitch")
            {
				Character = Resources.scarletwitch;
			}
            else if (Name == "CaptainAmerica")
            {
                Character = Resources.captainamerica;
			}
            else if (Name == "DrStrange")
            {
                Character = Resources.drstrange;
			}
			Character = new Bitmap(Character, new Size(60, 120));
		}

        public void Draw(Graphics g)
        {
            g.DrawImage(Character, new Point(Location.X, Location.Y));
            foreach (Weapon w in shots)
            {
                w.Draw(g);
			}
			int step = 5;
			if (Final == false)
			{
				for (int i = 0; i < 5 - Damage; i++)
				{
					g.DrawImage(heart, new Point(step, 0));
					step += 5 + heart.Width;
				}
			}
			else
			{
				for (int i = 0; i < 5 - BossDamage; i++)
				{
					g.DrawImage(heart, new Point(step, 0));
					step += 5 + heart.Width;
				}
			}
        }

        public void Move(string direction)
        {
            if (direction == "Left")
            {
                if (Location.X - 10 >= 0)
                {
                    Location = new Point(Location.X - 10, Location.Y);
                }

            }
            if (direction == "Right")
            {
                if (Location.X + 10 <= width - Character.Width)
                {
                    Location = new Point(Location.X + 10, Location.Y);
                }
            }
        }

        public void MoveShots()
        {
            foreach (Weapon w in shots)
            {
                w.Move();
            }
            for (int i = shots.Count - 1; i > -1; i--)
            {
                if (shots[i].Location.Y <= 0)
                {
                    shots.RemoveAt(i);
                }
            }
        }

        public void AddShot()
        {
            shots.Add(new Weapon(Name, new Point(Location.X, Location.Y - 20)));
        }

        public void AddShotHulk(Obstacle o)
        {
            if (o != null)
                shots.Add(new Weapon(Name, new Point(Location.X - o.image.Height / 2 + this.Character.Width / 2, Location.Y - 20), o));
        }

        public void TakeDamage()
        {
            Damage++;
        }

        public void TakeBossDamage()
        {
            BossDamage++;
        }
    }
}
