using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsAntiAir
{
	public class ArmoredCar : Vehicle
	{
		protected readonly int AAWidth = 280;
		protected readonly int AAHeight = 100;
		protected readonly char separator = ';';

		public ArmoredCar(string info)
		{
			string[] strs = info.Split(separator);
			if(strs.Length == 3)
			{
				MaxSpeed = Convert.ToInt32(strs[0]);
				Weight = Convert.ToInt32(strs[1]);
				MainColor = Color.FromName(strs[2]);
			}
		}

		public ArmoredCar(int maxSpeed, float weight, Color mainColor)
		{
			MaxSpeed = maxSpeed;
			Weight = weight;
			MainColor = mainColor;
		}

		protected ArmoredCar(int maxSpeed, float weight, Color mainColor, int AAWidth, int AAHeight)
		{
			MaxSpeed = maxSpeed;
			Weight = weight;
			MainColor = mainColor;
			this.AAWidth = AAWidth;
			this.AAHeight = AAHeight;
		}

		public override void MoveTransport(Direction direction)
		{
			float step = MaxSpeed * 100 / Weight;
			switch (direction)
			{
				case Direction.Right:
					if (_startPosX + step < _pictureWidth - AAWidth)
					{
						_startPosX += step;
					}
					break;
				case Direction.Left:
					if (_startPosX - step > 0)
					{
						_startPosX -= step;
					}
					break;
				case Direction.Up:
					if (_startPosY - step > 0)
					{
						_startPosY -= step;
					}
					break;
				case Direction.Down:
					if (_startPosY + step < _pictureHeight - AAHeight)
					{
						_startPosY += step;
					}
					break;
			}
		}

		public override void DrawTransport(Graphics g)
		{
			Pen pen = new Pen(Color.Black);
			g.DrawArc(pen, _startPosX, _startPosY + 62, 50, 50, 90, 180);
			g.DrawArc(pen, _startPosX + 230, _startPosY + 62, 50, 50, 270, 180);
			g.DrawLine(pen, _startPosX + 25, _startPosY + 112, _startPosX + 255, _startPosY + 112);
			g.DrawEllipse(pen, _startPosX + 5, _startPosY + 64, 45, 45);
			g.DrawEllipse(pen, _startPosX + 231, _startPosY + 64, 45, 45);
			g.DrawEllipse(pen, _startPosX + 60, _startPosY + 82, 30, 30);
			g.DrawEllipse(pen, _startPosX + 100, _startPosY + 82, 30, 30);
			g.DrawEllipse(pen, _startPosX + 140, _startPosY + 82, 30, 30);
			g.DrawEllipse(pen, _startPosX + 180, _startPosY + 82, 30, 30);
			Brush br = new SolidBrush(MainColor);
			g.FillRectangle(br, _startPosX + 80, _startPosY + 17, 100, 40);
			g.FillRectangle(br, _startPosX + 10, _startPosY + 47, 260, 22);
			g.FillEllipse(br, _startPosX + 130, _startPosY + 57, 20, 20);
			g.FillEllipse(br, _startPosX + 90, _startPosY + 57, 20, 20);
			g.FillEllipse(br, _startPosX + 170, _startPosY + 57, 20, 20);
		}

		public override string ToString()
		{
			return $"{MaxSpeed}{separator}{Weight}{separator}{MainColor}";
		}
	}
}
