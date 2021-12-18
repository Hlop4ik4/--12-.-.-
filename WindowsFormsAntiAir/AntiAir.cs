using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsAntiAir
{
	public class AntiAir : ArmoredCar, IEquatable<AntiAir>
	{
		public Color DopColor { private set; get; }
		public bool StarEmblem { private set; get; }
		public bool Gun { private set; get; }

		public AntiAir(int maxSpeed, float weight, Color mainColor, Color dopColor, bool starEmblem, bool gun) : base(maxSpeed, weight, mainColor, 280, 117)
		{
			DopColor = dopColor;
			StarEmblem = starEmblem;
			Gun = gun;
		}

		public AntiAir(string info) : base(info)
		{
			string[] strs = info.Split(separator);
			if(strs.Length == 6)
			{
				MaxSpeed = Convert.ToInt32(strs[0]);
				Weight = Convert.ToInt32(strs[1]);
				MainColor = Color.FromName(strs[2]);
				DopColor = Color.FromName(strs[3]);
				StarEmblem = Convert.ToBoolean(strs[4]);
				Gun = Convert.ToBoolean(strs[5]);
			}
		}

		public override void DrawTransport(Graphics g)
		{
			if (Gun)
			{
				Brush brDop = new SolidBrush(DopColor);
				g.FillEllipse(brDop, _startPosX + 90, _startPosY - 3, 80, 60);
				Pen DopPen = new Pen(DopColor);
				g.DrawLine(DopPen, _startPosX + 130, _startPosY + 17, _startPosX + 70, _startPosY - 3);
			}
			base.DrawTransport(g);
			if (StarEmblem)
			{
				Brush brDop = new SolidBrush(DopColor);
				PointF p1 = new PointF(_startPosX + 100, _startPosY + 37);
				PointF p2 = new PointF(_startPosX + 111, _startPosY + 37);
				PointF p3 = new PointF(_startPosX + 115, _startPosY + 27);
				PointF p4 = new PointF(_startPosX + 119, _startPosY + 37);
				PointF p5 = new PointF(_startPosX + 130, _startPosY + 37);
				PointF p6 = new PointF(_startPosX + 121, _startPosY + 43.4f);
				PointF p7 = new PointF(_startPosX + 124, _startPosY + 53);
				PointF p8 = new PointF(_startPosX + 115, _startPosY + 47.5f);
				PointF p9 = new PointF(_startPosX + 106, _startPosY + 53);
				PointF p10 = new PointF(_startPosX + 109, _startPosY + 43.4f);
				PointF[] arr = { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10 };
				g.FillPolygon(brDop, arr);
			}
		}

		public void SetDopColor(Color color)
		{
			DopColor = color;
		}

		public override string ToString()
		{
			return $"{base.ToString()}{separator}{DopColor.Name}{separator}{StarEmblem}{separator}{Gun}";
		}

		public bool Equals(AntiAir other)
		{
			if(other == null)
			{
				return false;
			}
			if(GetType().Name != other.GetType().Name)
			{
				return false;
			}
			if(MaxSpeed != other.MaxSpeed)
			{
				return false;
			}
			if(Weight != other.Weight)
			{
				return false;
			}
			if(MainColor != other.MainColor)
			{
				return false;
			}
			if(DopColor != other.DopColor)
			{
				return false;
			}
			if(StarEmblem != other.StarEmblem)
			{
				return false;
			}
			if(Gun != other.Gun)
			{
				return false;
			}
			return true;
		}

		public override bool Equals(object obj)
		{
			if(obj == null)
			{
				return false;
			}
			if(!(obj is AntiAir carObj))
			{
				return false;
			}
			else
			{
				return Equals(carObj);
			}
		}
	}
}
