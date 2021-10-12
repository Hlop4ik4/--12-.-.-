using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsAntiAir
{
	public class Base<T> where T : class, IAntiAir
	{
		private readonly T[] _places;
		private readonly int pictureWidth;
		private readonly int pictureHeight;
		private readonly int _placeSizeWidth = 290;
		private readonly int _placeSizeHeight = 130;

		public Base(int picWidth, int picHeight)
		{
			int width = picWidth / _placeSizeWidth;
			int height = picHeight / _placeSizeHeight;
			_places = new T[width * height];
			pictureWidth = picWidth;
			pictureHeight = picHeight;
		}

		public static int operator +(Base<T> p, T car)
		{
			for(int i = 0; i < p._places.Length; i++)
			{
				if(p._places[i] == null)
				{
					p._places[i] = car;
					return i;
				}
			}
			return -1;
		}

		public static T operator -(Base<T> p, int index)
		{
			if (index < p._places.Length)
			{
				T transport = p._places[index];
				p._places[index] = null;
				return transport;
			}
			else
			{
				return null;
			}
		}

		public void Draw(Graphics g)
		{
			DrawMarking(g);
			int startPosX = 0;
			int startPosY = 14;
			int horizontalPlacesCount = 0;
			for(int i = 0; i < _places.Length; i++)
			{
				if (horizontalPlacesCount > (pictureWidth / _placeSizeWidth) - 1)
				{
					horizontalPlacesCount = 0;
					startPosY += 130;
					startPosX = 0;
				}
				_places[i]?.SetPosition(startPosX, startPosY, pictureWidth, pictureHeight);
				_places[i]?.DrawTransport(g);
				startPosX += 290;
				horizontalPlacesCount++;
			}
		}

		private void DrawMarking(Graphics g)
		{
			Pen pen = new Pen(Color.Black, 3);
			for(int i = 0; i < pictureWidth / _placeSizeWidth; i++)
			{
				for(int j = 0; j < pictureHeight / _placeSizeHeight + 1; j++)
				{
					g.DrawLine(pen, i * _placeSizeWidth, j * _placeSizeHeight, i * _placeSizeWidth + _placeSizeWidth / 2, j * _placeSizeHeight);
				}
				g.DrawLine(pen, i * _placeSizeWidth, 0, i * _placeSizeWidth, (pictureHeight / _placeSizeHeight) * _placeSizeHeight);
			}
		}
	}
}
