using System;
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
	public partial class FormBase : Form
	{
		private readonly Base<ArmoredCar> militaryBase;

		public FormBase()
		{
			InitializeComponent();
			militaryBase = new Base<ArmoredCar>(pictureBoxBase.Width, pictureBoxBase.Height);
			Draw();
		}

		private void Draw()
		{
			Bitmap bmp = new Bitmap(pictureBoxBase.Width, pictureBoxBase.Height);
			Graphics gr = Graphics.FromImage(bmp);
			militaryBase.Draw(gr);
			pictureBoxBase.Image = bmp;
		}

		private void buttonSetArmoredCar_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			if(dialog.ShowDialog() == DialogResult.OK)
			{
				var armoredCar = new ArmoredCar(100, 1000, dialog.Color);
				if(militaryBase + armoredCar >= 0)
				{
					Draw();
				}
				else
				{
					MessageBox.Show("База переполнена");
				}
			}
		}

		private void buttonSetAA_Click(object sender, EventArgs e)
		{
			ColorDialog dialog = new ColorDialog();
			if(dialog.ShowDialog() == DialogResult.OK)
			{
				ColorDialog dialogDop = new ColorDialog();
				if(dialogDop.ShowDialog() == DialogResult.OK)
				{
					var aa = new AntiAir(100, 1000, dialog.Color, dialogDop.Color, true, true);
					if(militaryBase + aa >= 0)
					{
						Draw();
					}
					else
					{
						MessageBox.Show("Парковка переполнена");
					}
				}
			}
		}

		private void bittonTake_Click(object sender, EventArgs e)
		{
			if(maskedTextBox.Text != "")
			{
				var car = militaryBase - Convert.ToInt32(maskedTextBox.Text);
				if(car != null)
				{
					FormAA form = new FormAA();
					form.SetCar(car);
					form.ShowDialog();
				}
				Draw();
			}
		}
	}
}
