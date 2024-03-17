using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_17_OOP_Danylko
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double side1) &&
                double.TryParse(textBox2.Text, out double side2) &&
                double.TryParse(textBox3.Text, out double angle))
            {
                if (side1 <= 0 || side2 <= 0 || angle <= 0 || angle >= 180)
                {
                    MessageBox.Show("Помилка: Сторони трикутника та кут повинні бути додатні та менше за 180 градусів.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Перевірка чи кут дорівнює 90 градусів
                if (angle == 90)
                {
                    RightTriangle rightTriangle = new RightTriangle(side1, side2);
                    label1.Text = "Тип трикутника: Прямокутний";
                    label2.Text = $"Периметр: {rightTriangle.Perimeter():F2}";
                    label3.Text = $"Площа: {rightTriangle.Area():F2}";
                }
                else if (side1 == side2 && angle != 60)
                {
                    IsoscelesTriangle isoscelesTriangle = new IsoscelesTriangle(side1, side2, angle);
                    label1.Text = "Тип трикутника: Рівнобедрений";
                    label2.Text = $"Периметр: {isoscelesTriangle.Perimeter():F2}";
                    label3.Text = $"Площа: {isoscelesTriangle.Area():F2}";
                }
                else if (side1 == side2 && angle == 60) // перевіряємо, чи всі сторони однакові
                {
                    EquilateralTriangle equilateralTriangle = new EquilateralTriangle(side1);
                    label1.Text = "Тип трикутника: Рівносторонній";
                    label2.Text = $"Периметр: {equilateralTriangle.Perimeter():F2}";
                    label3.Text = $"Площа: {equilateralTriangle.Area():F2}";
                }
                else
                {
                    ArbitraryTriangle arbitraryTriangle = new ArbitraryTriangle(side1, side2, angle);
                    label1.Text = "Тип трикутника: Довільний";
                    label2.Text = $"Периметр: {arbitraryTriangle.Perimeter():F2}";
                    label3.Text = $"Площа: {arbitraryTriangle.Area():F2}";
                }
            }
            else
            {
                MessageBox.Show("Помилка: Некоректні дані", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
