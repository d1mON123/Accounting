using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting
{
    public partial class EditForm : Form
    {
        public EditForm()
        {
            InitializeComponent();
        }

        private void PNumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void PNTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void IdNTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void SalaryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void OKButton_Click_1(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                MessageBox.Show("Не введене ім'я", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (SNameTextBox.Text == "")
            {
                MessageBox.Show("Не введене прізвище", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PNumberTextBox.Text == "")
            {
                MessageBox.Show("Не введений номер телефону", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (PSTextBox.Text == "" || PNTextBox.Text == "")
            {
                MessageBox.Show("Не введена серія і номер паспорту", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не вибрана посада", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (IdNTextBox.Text == "")
            {
                MessageBox.Show("Не введений ідентифікаційний номер", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (SalaryTextBox.Text == "")
            {
                MessageBox.Show("Не введений оклад", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else DialogResult = DialogResult.OK;
        }
    }
}
