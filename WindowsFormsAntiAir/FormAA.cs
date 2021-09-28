﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAntiAir
{
	public partial class FormAA : Form
	{
		private IAntiAir AA;

		public FormAA()
		{
			InitializeComponent();
		}

		public void SetCar(IAntiAir AA)
		{
			this.AA = AA;
			Draw();
		}

		private void Draw()
		{
			Bitmap bmp = new Bitmap(pictureBoxAA.Width, pictureBoxAA.Height);
			Graphics gr = Graphics.FromImage(bmp);
			AA?.DrawTransport(gr);
			pictureBoxAA.Image = bmp;
		}

		private void buttonCreateArmoredCar_Click(object sender, EventArgs e)
		{
			Random rnd = new Random();
			AA = new ArmoredCar(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Black);
			AA.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxAA.Width, pictureBoxAA.Height);
			Draw();
		}

		private void buttonCreateAntiAir_Click(object sender, EventArgs e)
		{
			Random rnd = new Random();
			AA = new AntiAir(rnd.Next(100, 300), rnd.Next(1000, 2000), Color.Black, Color.Red, true, true);
			AA.SetPosition(rnd.Next(10, 100), rnd.Next(10, 100), pictureBoxAA.Width, pictureBoxAA.Height);
			Draw();
		}

		private void buttonMove_Click(object sender, EventArgs e)
		{
			string name = (sender as Button).Name;
			switch (name)
			{
				case "buttonUp":
					AA?.MoveTransport(Direction.Up);
					break;
				case "buttonDown":
					AA?.MoveTransport(Direction.Down);
					break;
				case "buttonLeft":
					AA?.MoveTransport(Direction.Left);
					break;
				case "buttonRight":
					AA?.MoveTransport(Direction.Right);
					break;
			}
			Draw();
		}
	}
}