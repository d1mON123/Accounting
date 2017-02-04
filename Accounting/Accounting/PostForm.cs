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
using Domain;

namespace Accounting
{
    public partial class PostForm : Form
    {
        public PostForm()
        {
            InitializeComponent();
        }

        Broker b = new Broker();

        private void button1_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            p.Fname = textBox1.Text;
            if (textBox1.Text != "")
            {
                b.InsertPost(p);
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Не введена посада");
            }
            DataUpdate();
        }

        void DataUpdate()
        {
            dataGridView1.DataSource = b.ShowTable("Post");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Посада";
            dataGridView1.Columns[1].Width = 180;
            dataGridView1.Update();
        }

        private void PostForm_Load(object sender, EventArgs e)
        {
            DataUpdate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            try
            {
                int a = Convert.ToInt32(dataGridView1.CurrentRow.Index);
                p.Id = Convert.ToInt32(dataGridView1.Rows[a].Cells[0].Value);
                if (MessageBox.Show("Ви дійсно бажаєте видалити посаду " + Convert.ToString(dataGridView1.Rows[a].Cells[1].Value) + "?", "Видалення", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    b.Delete(p, "Post");
                    DataUpdate();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не обраний елемент або база пуста");
            }
            
        }
    }
}
