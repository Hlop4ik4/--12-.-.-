﻿using System;
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
		private readonly int _placeSizeWidth = 280;
		private readonly int _placeSizeHeight = 117;

		public Base(int picWidth, int picHeight)
		{
			int width = picWidth / _placeSizeWidth;
			int height = picHeight / _placeSizeHeight;
			_places = new T[width * height];
			pictureWidth = picWidth;
			pictureHeight = picHeight;
		}

		public static bool operator +(Base<T> p, T car)
		{
			for(int i = 0; i < p._places.Length; i++)
			{
				if(p._places[i] == null)
				{
					p._places[i] = car;
					return true;
				}
			}
			return false;
		}

		public static T operator -(Base<T> p, int index)
		{
			T transport = p._places[index];
			p._places[index] = null;
			return transport;
		}

		public void Draw(Graphics g)
		{
			DrawMarking(g);
			int startPosX = 0;
			int startPosY = 0;
			for(int i = 0; i < _places.Length; i++)
			{
				_places[i].SetPosition(startPosX, startPosY, pictureWidth, pictureHeight);
				_places[i]?.DrawTransport(g);
				startPosY += 117;
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