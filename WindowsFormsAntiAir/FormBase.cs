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
		private readonly BaseCollection baseCollection;

		public FormBase()
		{
			InitializeComponent();
			baseCollection = new BaseCollection(pictureBoxBase.Width, pictureBoxBase.Height);
			Draw();
		}

		private void ReloadLevels()
		{
			int index = listBoxBase.SelectedIndex;

			listBoxBase.Items.Clear();
			for(int i = 0; i < baseCollection.Keys.Count; i++)
			{
				listBoxBase.Items.Add(baseCollection.Keys[i]);
			}

			if(listBoxBase.Items.Count > 0 && (index == -1) || index >= listBoxBase.Items.Count)
			{
				listBoxBase.SelectedIndex = 0;
			}
			else if(listBoxBase.Items.Count > 0 && index > -1 && index < listBoxBase.Items.Count)
			{
				listBoxBase.SelectedIndex = index;
			}
		}

		private void Draw()
		{
			if (listBoxBase.SelectedIndex > -1)
			{
				Bitmap bmp = new Bitmap(pictureBoxBase.Width, pictureBoxBase.Height);
				Graphics gr = Graphics.FromImage(bmp);
				baseCollection[listBoxBase.SelectedItem.ToString()].Draw(gr);
				pictureBoxBase.Image = bmp;
			}
		}

		private void buttonAddBase_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBoxNewLevelName.Text))
			{
				MessageBox.Show("Введите название базы", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			baseCollection.AddBase(textBoxNewLevelName.Text);
			ReloadLevels();
		}

		private void buttonDelBase_Click(object sender, EventArgs e)
		{
			if(listBoxBase.SelectedIndex > -1)
			{
				if(MessageBox.Show($"Удалить базу {listBoxBase.SelectedItem.ToString()}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					baseCollection.DelBase(textBoxNewLevelName.Text);
					ReloadLevels();
				}
			}
		}

		private void buttonSetArmoredCar_Click(object sender, EventArgs e)
		{
			if (listBoxBase.SelectedIndex > -1)
			{
				ColorDialog dialog = new ColorDialog();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					var armoredCar = new ArmoredCar(100, 1000, dialog.Color);
					if (baseCollection[listBoxBase.SelectedItem.ToString()] + armoredCar >= 0)
					{
						Draw();
					}
					else
					{
						MessageBox.Show("База переполнена");
					}
				}
			}
		}

		private void buttonSetAA_Click(object sender, EventArgs e)
		{
			if (listBoxBase.SelectedIndex > -1)
			{
				ColorDialog dialog = new ColorDialog();
				if (dialog.ShowDialog() == DialogResult.OK)
				{
					ColorDialog dialogDop = new ColorDialog();
					if (dialogDop.ShowDialog() == DialogResult.OK)
					{
						var aa = new AntiAir(100, 1000, dialog.Color, dialogDop.Color, true, true);
						if (baseCollection[listBoxBase.SelectedItem.ToString()] + aa >= 0)
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
		}

		private void buttonTake_Click(object sender, EventArgs e)
		{
			if(listBoxBase.SelectedIndex > -1 && maskedTextBox.Text != "")
			{
				var car = baseCollection[listBoxBase.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBox.Text);
				if(car != null)
				{
					FormAA form = new FormAA();
					form.SetCar(car);
					form.ShowDialog();
				}
				Draw();
			}
		}

		private void listBoxBase_SelectedIndexChanged(object sendet, EventArgs e)
		{
			Draw();
		}
	}
}
