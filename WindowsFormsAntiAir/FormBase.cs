using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace WindowsFormsAntiAir
{
	public partial class FormBase : Form
	{
		private readonly BaseCollection baseCollection;
		private readonly Logger logger;

		public FormBase()
		{
			InitializeComponent();
			baseCollection = new BaseCollection(pictureBoxBase.Width, pictureBoxBase.Height);
			Draw();
			logger = LogManager.GetCurrentClassLogger();
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

			logger.Info($"Добавили парковку {textBoxNewLevelName.Text}");
			baseCollection.AddBase(textBoxNewLevelName.Text);
			ReloadLevels();
		}

		private void buttonDelBase_Click(object sender, EventArgs e)
		{
			if(listBoxBase.SelectedIndex > -1)
			{
				if(MessageBox.Show($"Удалить базу {listBoxBase.SelectedItem.ToString()}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					logger.Info($"Удалили парковку {listBoxBase.SelectedItem.ToString()}");
					baseCollection.DelBase(textBoxNewLevelName.Text);
					ReloadLevels();
				}
			}
		}

		private void buttonTake_Click(object sender, EventArgs e)
		{
			if(listBoxBase.SelectedIndex > -1 && maskedTextBox.Text != "")
			{
				try
				{
					var car = baseCollection[listBoxBase.SelectedItem.ToString()] - Convert.ToInt32(maskedTextBox.Text);
					if (car != null)
					{
						FormAA form = new FormAA();
						form.SetCar(car);
						form.ShowDialog();
						logger.Info($"Изъят транспорт {car} с места {maskedTextBox.Text}");
					}
					Draw();
				}
				catch (BaseNotFoundException ex)
				{
					logger.Warn($"Транспорт по месту {maskedTextBox.Text} не найден");
					MessageBox.Show(ex.Message, "Не найдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch (Exception ex)
				{
					logger.Warn("Произошла неизвестная ошибка");
					MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void listBoxBase_SelectedIndexChanged(object sendet, EventArgs e)
		{
			logger.Info($"Перешли на парковку {listBoxBase.SelectedItem.ToString()}");
			Draw();
		}

		private void buttonAddTransport_Click(object sender, EventArgs e)
		{
			var formAAConfig = new FormAAConfig();
			formAAConfig.AddEvent(AddTransport);
			formAAConfig.Show();
		}

		private void AddTransport(Vehicle car)
		{
			if(car != null && listBoxBase.SelectedIndex > -1)
			{
				try
				{
					if (baseCollection[listBoxBase.SelectedItem.ToString()] + car > -1)
					{
						Draw();
						logger.Info($"Добавлен транспорт {car}");
					}
					else
					{
						MessageBox.Show("Транспорт не удалось поставить");
					}
				}
				catch(BaseOverflowException ex)
				{
					logger.Warn("Произошло переполнение базы");
					MessageBox.Show(ex.Message, "Переполнение", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch(Exception ex)
				{
					logger.Warn("Произошла неизвестная ошибка");
					MessageBox.Show(ex.Message, "Неизвестная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					baseCollection.SaveData(saveFileDialog.FileName);
					MessageBox.Show("Сохранение прошло успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
					logger.Info("Сохранено в файл " + saveFileDialog.FileName);
				}
				catch(Exception ex)
				{
					logger.Warn("Произошла неизвестная ошибка");
					MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					baseCollection.LoadData(openFileDialog.FileName);
					MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
					logger.Info("Загружено из файла " + openFileDialog.FileName);
					ReloadLevels();
					Draw();
				}
				catch (BaseOccupiedPlaceException ex)
				{
					MessageBox.Show(ex.Message, "Занятое место", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				catch(Exception ex)
				{
					logger.Warn("Произошла неизвестная ошибка");
					MessageBox.Show(ex.Message, "Неизвестная ошибка при загрузке", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void buttonSort_Click(object sender, EventArgs e)
		{
			if(listBoxBase.SelectedIndex > -1)
			{
				baseCollection[listBoxBase.SelectedItem.ToString()].Sort();
				Draw();
				logger.Info("Сортировка уровней");
			}
		}
	}
}
