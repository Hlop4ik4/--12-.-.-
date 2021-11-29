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
    public partial class FormAAConfig : Form
    {
        ArmoredCar antiAir = null;
        private event Action<ArmoredCar> eventAddCar;
        public FormAAConfig()
        {
            InitializeComponent();

            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
            panelRed.MouseDown += panelColor_MouseDown;
            panelYelow.MouseDown += panelColor_MouseDown;
            panelBlack.MouseDown += panelColor_MouseDown;
            panelBlue.MouseDown += panelColor_MouseDown;
            panelGreen.MouseDown += panelColor_MouseDown;
            panelGrey.MouseDown += panelColor_MouseDown;
            panelOrange.MouseDown += panelColor_MouseDown;
            panelWhite.MouseDown += panelColor_MouseDown;
        }

        private void DrawCar()
        {
            if(antiAir != null)
            {
                Bitmap bmp = new Bitmap(pictureBoxAA.Width, pictureBoxAA.Height);
                Graphics gr = Graphics.FromImage(bmp);
                antiAir.SetPosition(5, 5, pictureBoxAA.Width, pictureBoxAA.Height);
                antiAir.DrawTransport(gr);
                pictureBoxAA.Image = bmp;
            }
        }

        private void panelColor_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as Control).DoDragDrop((sender as Control).BackColor, DragDropEffects.Copy | DragDropEffects.Move);
        }

        public void AddEvent(Action<Vehicle> ev)
        {
            eventAddCar += ev;
        }
        private void labelArmoredCar_MouseDown(object sender, MouseEventArgs e)
        {
            labelArmoredCar.DoDragDrop(labelArmoredCar.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void labelAA_MouseDown(object sender, MouseEventArgs e)
        {
            labelAA.DoDragDrop(labelAA.Text, DragDropEffects.Move | DragDropEffects.Copy);
        }

        private void panelAA_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void panelAA_DragDrop(object sender, DragEventArgs e)
        {
            switch (e.Data.GetData(DataFormats.Text).ToString())
            {
                case "Обычная бронемашина":
                    antiAir = new ArmoredCar(Convert.ToInt32(numericUpDownSpeed.Value), Convert.ToInt32(numericUpDownWeight.Value), Color.White);
                    break;
                case "ЗСУ":
                    antiAir = new AntiAir(Convert.ToInt32(numericUpDownSpeed.Value), Convert.ToInt32(numericUpDownWeight.Value), Color.White, Color.Black, checkBoxStar.Checked, checkBoxGun.Checked);
                    break;
            }
            DrawCar();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            eventAddCar?.Invoke(antiAir);
            Close();
        }

        private void labelMainColor_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void labelMainColor_DragDrop(object sender, DragEventArgs e)
        {
            if(antiAir != null)
            {
                antiAir.SetMainColor((Color)e.Data.GetData(typeof(Color)));
                DrawCar();
            }
        }

        private void labelDopColor_DragDrop(object sender, DragEventArgs e)
        {
            if(antiAir != null)
            {
                if(antiAir is AntiAir)
                {
                    (antiAir as AntiAir).SetDopColor((Color)e.Data.GetData(typeof(Color)));
                    DrawCar();
                }
            }
        }
	}
}
