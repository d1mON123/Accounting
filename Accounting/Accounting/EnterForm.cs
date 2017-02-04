using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Session;

namespace Accounting
{
    public partial class EnterForm : Form
    {
        public EnterForm()
        {
            InitializeComponent();
        }

        Broker b = new Broker();
        public string login;
        public string password;

        private void button1_Click(object sender, EventArgs e)
        {
            login = textBox1.Text;
            password = textBox2.Text;
            if (b.EnterProgram(login, password))
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Неправильний логін або пароль");
            }
        }
    }
}
