using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Session;

namespace Accounting
{
    public partial class PassChangeForm : Form
    {
        public PassChangeForm()
        {
            InitializeComponent();
        }

        EnterForm f = new EnterForm();
        public string password;

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == password && textBox2.Text == textBox3.Text && textBox2.Text != "")
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Неправильно введені дані");
            }
        }

        private void PassChangeForm_Load(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    }
}
