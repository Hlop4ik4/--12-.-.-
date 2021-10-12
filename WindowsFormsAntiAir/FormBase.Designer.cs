
namespace WindowsFormsAntiAir
{
	partial class FormBase
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBoxBase = new System.Windows.Forms.PictureBox();
			this.buttonSetArmoredCar = new System.Windows.Forms.Button();
			this.buttonSetAA = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonTake = new System.Windows.Forms.Button();
			this.maskedTextBox = new System.Windows.Forms.MaskedTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.listBoxBase = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonAddBase = new System.Windows.Forms.Button();
			this.buttonDelBase = new System.Windows.Forms.Button();
			this.textBoxNewLevelName = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBase)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBoxBase
			// 
			this.pictureBoxBase.Dock = System.Windows.Forms.DockStyle.Left;
			this.pictureBoxBase.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxBase.Name = "pictureBoxBase";
			this.pictureBoxBase.Size = new System.Drawing.Size(755, 461);
			this.pictureBoxBase.TabIndex = 0;
			this.pictureBoxBase.TabStop = false;
			// 
			// buttonSetArmoredCar
			// 
			this.buttonSetArmoredCar.Location = new System.Drawing.Point(761, 251);
			this.buttonSetArmoredCar.Name = "buttonSetArmoredCar";
			this.buttonSetArmoredCar.Size = new System.Drawing.Size(111, 51);
			this.buttonSetArmoredCar.TabIndex = 1;
			this.buttonSetArmoredCar.Text = "Припарковать бронемашину";
			this.buttonSetArmoredCar.UseVisualStyleBackColor = true;
			this.buttonSetArmoredCar.Click += new System.EventHandler(this.buttonSetArmoredCar_Click);
			// 
			// buttonSetAA
			// 
			this.buttonSetAA.Location = new System.Drawing.Point(761, 308);
			this.buttonSetAA.Name = "buttonSetAA";
			this.buttonSetAA.Size = new System.Drawing.Size(111, 35);
			this.buttonSetAA.TabIndex = 1;
			this.buttonSetAA.Text = "Припарковать ЗСУ";
			this.buttonSetAA.UseVisualStyleBackColor = true;
			this.buttonSetAA.Click += new System.EventHandler(this.buttonSetAA_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonTake);
			this.groupBox1.Controls.Add(this.maskedTextBox);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(761, 349);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(111, 100);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Забрать технику";
			// 
			// buttonTake
			// 
			this.buttonTake.Location = new System.Drawing.Point(16, 50);
			this.buttonTake.Name = "buttonTake";
			this.buttonTake.Size = new System.Drawing.Size(75, 23);
			this.buttonTake.TabIndex = 2;
			this.buttonTake.Text = "Забрать";
			this.buttonTake.UseVisualStyleBackColor = true;
			this.buttonTake.Click += new System.EventHandler(this.buttonTake_Click);
			// 
			// maskedTextBox
			// 
			this.maskedTextBox.Location = new System.Drawing.Point(54, 24);
			this.maskedTextBox.Name = "maskedTextBox";
			this.maskedTextBox.Size = new System.Drawing.Size(37, 20);
			this.maskedTextBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Место:";
			// 
			// listBoxBase
			// 
			this.listBoxBase.FormattingEnabled = true;
			this.listBoxBase.Location = new System.Drawing.Point(761, 91);
			this.listBoxBase.Name = "listBoxBase";
			this.listBoxBase.Size = new System.Drawing.Size(120, 95);
			this.listBoxBase.TabIndex = 3;
			this.listBoxBase.SelectedIndexChanged += new System.EventHandler(this.listBoxBase_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(783, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Уровни базы: ";
			// 
			// buttonAddBase
			// 
			this.buttonAddBase.Location = new System.Drawing.Point(761, 51);
			this.buttonAddBase.Name = "buttonAddBase";
			this.buttonAddBase.Size = new System.Drawing.Size(120, 34);
			this.buttonAddBase.TabIndex = 6;
			this.buttonAddBase.Text = "Добавить уровень базы";
			this.buttonAddBase.UseVisualStyleBackColor = true;
			this.buttonAddBase.Click += new System.EventHandler(this.buttonAddBase_Click);
			// 
			// buttonDelBase
			// 
			this.buttonDelBase.Location = new System.Drawing.Point(761, 192);
			this.buttonDelBase.Name = "buttonDelBase";
			this.buttonDelBase.Size = new System.Drawing.Size(120, 34);
			this.buttonDelBase.TabIndex = 6;
			this.buttonDelBase.Text = "Удалить уровень базы";
			this.buttonDelBase.UseVisualStyleBackColor = true;
			this.buttonDelBase.Click += new System.EventHandler(this.buttonDelBase_Click);
			// 
			// textBoxNewLevelName
			// 
			this.textBoxNewLevelName.Location = new System.Drawing.Point(763, 25);
			this.textBoxNewLevelName.Name = "textBoxNewLevelName";
			this.textBoxNewLevelName.Size = new System.Drawing.Size(118, 20);
			this.textBoxNewLevelName.TabIndex = 7;
			// 
			// FormBase
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 461);
			this.Controls.Add(this.textBoxNewLevelName);
			this.Controls.Add(this.buttonDelBase);
			this.Controls.Add(this.buttonAddBase);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.listBoxBase);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.buttonSetAA);
			this.Controls.Add(this.buttonSetArmoredCar);
			this.Controls.Add(this.pictureBoxBase);
			this.Name = "FormBase";
			this.Text = "Военная база";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxBase)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBoxBase;
		private System.Windows.Forms.Button buttonSetArmoredCar;
		private System.Windows.Forms.Button buttonSetAA;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button buttonTake;
		private System.Windows.Forms.MaskedTextBox maskedTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listBoxBase;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonAddBase;
		private System.Windows.Forms.Button buttonDelBase;
		private System.Windows.Forms.TextBox textBoxNewLevelName;
	}
}