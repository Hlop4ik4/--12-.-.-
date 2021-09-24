using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsAntiAir
{
	class AntiAir
	{
		private float _startPosX;
		private float _startPosY;
		private int _pictureWidth;
		private int _pictureHeight;
		private readonly int AAWidth = 280;
		private readonly int AAHeight = 117;
		public int MaxSpeed { private set; get; }
		public float Weight { private set; get; }
		public Color MainColor { private set; get; }
		public Color DopColor { private set; get; }
		public bool StarEmblem { private set; get; }
		public bool Gun { private set; get; }

		public void Init(int maxSpeed, float weight, Color mainColor, Color dopColor,
bool starEmblem, bool gun)
		{
			MaxSpeed = maxSpeed;
			Weight = weight;
			MainColor = mainColor;
			DopColor = dopColor;
			StarEmblem = starEmblem;
			Gun = gun;
		}

		public void SetPosition(int x, int y, int width, int height)
		{
			_startPosX = x;
			_startPosY = y;
			_pictureHeight = height;
			_pictureWidth = width;
		}

		public void MoveTransport(Direction direction)
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

		public void DrawAA(Graphics g)
		{
			if (Gun)
			{
				Brush brDop = new SolidBrush(DopColor);
				g.FillEllipse(brDop, _startPosX + 90, _startPosY - 3, 80, 60);
				Pen DopPen = new Pen(DopColor);
				g.DrawLine(DopPen, _startPosX + 130, _startPosY + 17, _startPosX + 70, _startPosY - 3);
			}
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
	}
}
