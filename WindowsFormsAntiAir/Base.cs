using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace WindowsFormsAntiAir
{
	public class Base<T> : IEnumerator<T>, IEnumerable<T>
		where T : class, IAntiAir
	{
		private readonly List<T> _places;
		private readonly int _maxCount;
		private readonly int pictureWidth;
		private readonly int pictureHeight;
		private readonly int _placeSizeWidth = 290;
		private readonly int _placeSizeHeight = 130;
		private int _currentIndex;
		public T Current => _places[_currentIndex];
		object IEnumerator.Current => _places[_currentIndex];

		public Base(int picWidth, int picHeight)
		{
			int width = picWidth / _placeSizeWidth;
			int height = picHeight / _placeSizeHeight;
			_maxCount = width * height;
			pictureWidth = picWidth;
			pictureHeight = picHeight;
			_places = new List<T>();
			_currentIndex = -1;
		}

		public static int operator +(Base<T> p, T car)
		{
			if (p._places.Count >= p._maxCount)
			{
				throw new BaseOverflowException();
			}
			if (p._places.Contains(car))
			{
				throw new BaseAlreadyHaveException();
			}
			p._places.Add(car);
			return p._places.IndexOf(car);
		}

		public static T operator -(Base<T> p, int index)
		{
			if (index < p._places.Count && index >= 0)
			{
				T transport = p._places[index];
				p._places.RemoveAt(index);
				return transport;
			}
			else
			{
				throw new BaseNotFoundException(index);
			}
		}

		public void Draw(Graphics g)
		{
			DrawMarking(g);
			int startPosX = 0;
			int startPosY = 14;
			int horizontalPlacesCount = 0;
			for(int i = 0; i < _places.Count; i++)
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

		public T GetNext(int index)
		{
			if(index < 0 || index >= _places.Count)
			{
				return null;
			}

			return _places[index];
		}

		public void Sort() => _places.Sort((IComparer<T>)new CarComparer());

		public void Dispose() { }

		public bool MoveNext()
		{
			if(_currentIndex < _places.Count - 1)
			{
				_currentIndex++;
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Reset()
		{
			_currentIndex = -1;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return this;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this;
		}
	}
}
