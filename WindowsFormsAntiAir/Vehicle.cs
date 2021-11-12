using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsAntiAir
{
	public abstract class Vehicle : IAntiAir
	{
		protected float _startPosX;
		protected float _startPosY;
		protected int _pictureWidth;
		protected int _pictureHeight;
		public int MaxSpeed { protected set; get; }
		public float Weight { protected set; get; }
		public Color MainColor { protected set; get; }
		public void SetPosition(int x, int y, int width, int height)
		{
			_startPosX = x;
			_startPosY = y;
			_pictureHeight = height;
			_pictureWidth = width;
		}
		public void SetMainColor(Color color)
		{
			MainColor = color;
		}
		public abstract void DrawTransport(Graphics g);
		public abstract void MoveTransport(Direction direction);
	}
}
