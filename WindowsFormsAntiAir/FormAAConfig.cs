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
        Vehicle antiAir = null;
        private event CarDelegate eventAddCar;
        public FormAAConfig()
        {
            InitializeComponent();

            buttonCancel.Click += (object sender, EventArgs e) => { Close(); };
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

        public void AddEvent(CarDelegate ev)
        {
            if(eventAddCar == null)
            {
                eventAddCar = new CarDelegate(ev);
            }
            else
            {
                eventAddCar += ev;
            }
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
                    antiAir = new ArmoredCar(100, 500, Color.White);
                    break;
                case "ЗСУ":
                    antiAir = new AntiAir(100, 500, Color.White, Color.Black, true, true);
                    break;
            }
            DrawCar();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            eventAddCar?.Invoke(antiAir);
            Close();
        }
    }
}
