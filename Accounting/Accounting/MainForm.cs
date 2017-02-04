using System;
using System.Windows.Forms;
using Session;
using Domain;


namespace Accounting
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        bool Access = true;
        Broker b = new Broker();
        EditForm f = new EditForm();
        PostForm f1 = new PostForm();
        PayForm f2 = new PayForm();
        PayResForm f3 = new PayResForm();
        SettingsForm f4 = new SettingsForm();
        MainReportForm f5 = new MainReportForm();
        SalaryReportForm f6 = new SalaryReportForm();
        PersonReportForm f7 = new PersonReportForm();
        PostFilterForm f8 = new PostFilterForm();
        EnterForm f9 = new EnterForm();
        PassChangeForm f10 = new PassChangeForm();
        RegAdminForm f11 = new RegAdminForm();
        SalaryFiltForm f12 = new SalaryFiltForm();

        private void Form1_Load(object sender, EventArgs e)
        {
            if (f9.ShowDialog() != DialogResult.OK)
            {
                Access = false;
                Application.Exit();
            } else Access = true;
            виУвійшлиЯкToolStripMenuItem.Text = "Ви увійшли як: " + f9.login;
            DataUpdate();

        }

        void DataUpdate()
        {
            dataGridView1.DataSource = b.ShowTable("Table");
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Ім'я";
            dataGridView1.Columns[2].HeaderText = "Прізвище";
            dataGridView1.Columns[3].HeaderText = "Дата народження";
            dataGridView1.Columns[4].HeaderText = "Номер телефону";
            dataGridView1.Columns[5].HeaderText = "Серія і номер паспорту";
            dataGridView1.Columns[6].HeaderText = "Посада";
            dataGridView1.Columns[7].HeaderText = "Ідент. номер";
            dataGridView1.Columns[7].Width = 110;
            dataGridView1.Columns[8].HeaderText = "Оклад";
            dataGridView1.Update();
        }

        private void додатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.NameTextBox.Clear();
            f.SNameTextBox.Clear();
            f.PNumberTextBox.Clear();
            f.PSTextBox.Clear();
            f.PNTextBox.Clear();
            f.comboBox1.DataSource = b.FillComboBox();
            f.comboBox1.SelectedIndex = -1;
            f.IdNTextBox.Clear();
            f.SalaryTextBox.Clear();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Person p = new Person();
                p.Fname = f.NameTextBox.Text;
                p.Sname = f.SNameTextBox.Text;
                p.Birthday = Convert.ToDateTime(f.DataPicker.Value.ToShortDateString());
                p.Pnumber = f.PNumberTextBox.Text;
                p.Passport = f.PSTextBox.Text + f.PNTextBox.Text;
                p.Post = f.comboBox1.Text;
                p.Idnumber = f.IdNTextBox.Text;
                p.Salary = Convert.ToInt32(f.SalaryTextBox.Text);
                b.Insert(p);
                DataUpdate();
            }
        }

        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            int a = Convert.ToInt32(dataGridView1.CurrentRow.Index);
            p.Id = Convert.ToInt32(dataGridView1.Rows[a].Cells[0].Value);
            if (MessageBox.Show("Ви дійсно бажаєте видалити інформацію про " + Convert.ToString(dataGridView1.Rows[a].Cells[1].Value) + " " + Convert.ToString(dataGridView1.Rows[a].Cells[2].Value) + "?", "Видалення", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                b.Delete(p, "Table");
                DataUpdate();
            }
        }

        private void редагуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person p = new Person();
            Person newPerson = new Person();
            int a = Convert.ToInt32(dataGridView1.CurrentRow.Index);
            p.Id = Convert.ToInt32(dataGridView1.Rows[a].Cells[0].Value);
            p.Fname = Convert.ToString(dataGridView1.Rows[a].Cells[1].Value);
            p.Sname = Convert.ToString(dataGridView1.Rows[a].Cells[2].Value);
            p.Birthday = Convert.ToDateTime(Convert.ToString(dataGridView1.Rows[a].Cells[3].Value));
            p.Pnumber = Convert.ToString(dataGridView1.Rows[a].Cells[4].Value);
            p.Passport = Convert.ToString(dataGridView1.Rows[a].Cells[5].Value);
            p.Post = Convert.ToString(dataGridView1.Rows[a].Cells[6].Value);
            p.Idnumber = Convert.ToString(dataGridView1.Rows[a].Cells[7].Value);
            p.Salary = Convert.ToInt32(dataGridView1.Rows[a].Cells[8].Value);
            f.NameTextBox.Text = p.Fname;
            f.SNameTextBox.Text = p.Sname;
            f.DataPicker.Value = p.Birthday;
            f.PNumberTextBox.Text = p.Pnumber;
            f.PSTextBox.Text = p.Passport.Substring(0, 2);
            f.PNTextBox.Text = p.Passport.Substring(2, 6);
            f.comboBox1.DataSource = b.FillComboBox();
            f.comboBox1.SelectedIndex = -1;
            f.IdNTextBox.Text = p.Idnumber;
            f.SalaryTextBox.Text = p.Salary.ToString();
            if (f.ShowDialog() == DialogResult.OK)
            {
                newPerson.Id = p.Id;
                newPerson.Fname = f.NameTextBox.Text;
                newPerson.Sname = f.SNameTextBox.Text;
                newPerson.Birthday = Convert.ToDateTime(f.DataPicker.Value.ToShortDateString());
                newPerson.Pnumber = f.PNumberTextBox.Text;
                newPerson.Passport = f.PSTextBox.Text + f.PNTextBox.Text;
                newPerson.Post = f.comboBox1.Text;
                newPerson.Idnumber = f.IdNTextBox.Text;
                newPerson.Salary = Convert.ToInt32(f.SalaryTextBox.Text);
                b.Update(p, newPerson);
                DataUpdate();
            }
        }

        private void посадиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f1.ShowDialog();
        }

        private void розрахуватиЗарплатуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salary sal = new Salary();
            int a = Convert.ToInt32(dataGridView1.CurrentRow.Index);
            sal.Tableid = Convert.ToInt32(dataGridView1.Rows[a].Cells[0].Value);
            sal.Fname = dataGridView1.Rows[a].Cells[1].Value.ToString();
            sal.Sname = dataGridView1.Rows[a].Cells[2].Value.ToString();
            int money = Convert.ToInt32(dataGridView1.Rows[a].Cells[8].Value.ToString());
            f2.label1.Text = sal.Fname + " " + sal.Sname;
            if (f2.ShowDialog() == DialogResult.OK)
            {
                sal.Days = Convert.ToInt32(f2.comboBox1.Text);
                sal.Tdays = Convert.ToInt32(f2.comboBox2.Text);
                sal.Month = f2.comboBox3.Text;
                sal.Year = Convert.ToInt32(f2.comboBox4.Text);
                if (b.EnterSalary(sal.Tableid, sal.Month, sal.Year))
                {
                    Settings set = new Settings();
                    set = b.SettingsShow();
                    sal.Pay = (Convert.ToDouble(sal.Days) / Convert.ToDouble(sal.Tdays)) * money;
                    if (sal.Pay > (set.Livingmin * 10))
                    {
                        sal.Esv = (set.Esvmax / 100) * set.Esvperc;
                    }
                    else
                    {
                        sal.Esv = (sal.Pay / 100) * set.Esvperc;
                    }
                    double ost = sal.Pay - sal.Esv;
                    if (ost > (set.Livingmin * 10))
                    {
                        sal.Pdfo = (((set.Livingmin * 10) / 100) * set.Livingperc1) + (((ost - (set.Livingmin * 10)) / 100) * set.Livingperc2);
                    }
                    else
                    {
                        sal.Pdfo = (ost / 100) * set.Livingperc1;
                    }
                    sal.Army = (sal.Pay / 100) * set.Armyperc;
                    b.InsertSalary(sal);
                    f2.comboBox1.SelectedIndex = -1;
                    f2.comboBox2.SelectedIndex = -1;
                    f2.comboBox3.SelectedIndex = -1;
                    f2.comboBox4.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Заробітня плата цього працівника за вказаний період вже була розрахована раніше");
                    f2.ShowDialog();
                }
            }
            else
            {
                f2.comboBox1.SelectedIndex = -1;
                f2.comboBox2.SelectedIndex = -1;
                f2.comboBox3.SelectedIndex = -1;
                f2.comboBox4.SelectedIndex = -1;
            }
        }

        private void налаштуванняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set = b.SettingsShow();
            f4.textBox1.Text = set.Esvmax.ToString();
            f4.textBox2.Text = set.Esvperc.ToString();
            f4.textBox3.Text = set.Livingmin.ToString();
            f4.textBox4.Text = set.Livingperc1.ToString();
            f4.textBox5.Text = set.Livingperc2.ToString();
            f4.textBox6.Text = set.Armyperc.ToString();
            if(f4.ShowDialog() == DialogResult.OK)
            {
                Settings newSet = new Settings();
                newSet.Esvmax = Convert.ToInt32(f4.textBox1.Text);
                newSet.Esvperc = Convert.ToDouble(f4.textBox2.Text);
                newSet.Livingmin = Convert.ToInt32(f4.textBox3.Text);
                newSet.Livingperc1 = Convert.ToDouble(f4.textBox4.Text);
                newSet.Livingperc2 = Convert.ToDouble(f4.textBox5.Text);
                newSet.Armyperc = Convert.ToDouble(f4.textBox6.Text);
                b.SettingsUpdate(newSet, set);
            }
        }

        private void обраногоРобітникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(dataGridView1.CurrentRow.Index);
            int id = Convert.ToInt32(dataGridView1.Rows[a].Cells[0].Value);
            f3.dataGridView1.DataSource = b.ShowTable("Salary", id);
            f3.ShowDialog();
        }

        private void весьСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f3.dataGridView1.DataSource = b.ShowTable("Salary");
            f3.ShowDialog();
        }

        private void списокПрацівниківToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f5.TableTableAdapter.Fill(f5.DataSet.Table);
            f5.ShowDialog();
        }

        private void весьСписокToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            f6.SalaryTableAdapter.Fill(f6.DataSet.Salary);
            f6.ShowDialog();
        }

        private void обраногоПрацівникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f7.comboBox1.DataSource = b.FillReportComboBox();
            if (f7.ShowDialog() == DialogResult.OK)
            {
                Person p = new Person();
                p = f7.comboBox1.Items[f7.comboBox1.SelectedIndex] as Person;
                f6.SalaryTableAdapter.FillBy(f6.DataSet.Salary, p.Id);
                f6.ShowDialog();
            }
        }

        private void весьСписокToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            весьСписокToolStripMenuItem2.Checked = true;
            заОкладомToolStripMenuItem.Checked = false;
            заПосадоюToolStripMenuItem.Checked = false;
            toolStripStatusLabel1.Text = "Фільтрування: весь список";
            DataUpdate();
        }

        private void заПосадоюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f8.comboBox1.DataSource = b.FillComboBox();
            if (f8.ShowDialog() == DialogResult.OK)
            {
                string post = f8.comboBox1.Text;
                post.Remove(post.Length - 1);
                dataGridView1.DataSource = b.ShowTable("Table", post);
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Ім'я";
                dataGridView1.Columns[2].HeaderText = "Прізвище";
                dataGridView1.Columns[3].HeaderText = "Дата народження";
                dataGridView1.Columns[4].HeaderText = "Номер телефону";
                dataGridView1.Columns[5].HeaderText = "Серія і номер паспорту";
                dataGridView1.Columns[6].HeaderText = "Посада";
                dataGridView1.Columns[7].HeaderText = "Ідент. номер";
                dataGridView1.Columns[7].Width = 110;
                dataGridView1.Columns[8].HeaderText = "Оклад";
                dataGridView1.Update();
                весьСписокToolStripMenuItem2.Checked = false;
                заОкладомToolStripMenuItem.Checked = false;
                заПосадоюToolStripMenuItem.Checked = true;
                toolStripStatusLabel1.Text = "Фільтрування: за посадою (" + post + ")";
            }
        }

        private void заОкладомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f12.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = b.ShowTable("Table", f12.comboBox1.Text, Convert.ToInt32(f12.textBox1.Text));
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Ім'я";
                dataGridView1.Columns[2].HeaderText = "Прізвище";
                dataGridView1.Columns[3].HeaderText = "Дата народження";
                dataGridView1.Columns[4].HeaderText = "Номер телефону";
                dataGridView1.Columns[5].HeaderText = "Серія і номер паспорту";
                dataGridView1.Columns[6].HeaderText = "Посада";
                dataGridView1.Columns[7].HeaderText = "Ідент. номер";
                dataGridView1.Columns[7].Width = 110;
                dataGridView1.Columns[8].HeaderText = "Оклад";
                dataGridView1.Update();
                весьСписокToolStripMenuItem2.Checked = false;
                заОкладомToolStripMenuItem.Checked = true;
                заПосадоюToolStripMenuItem.Checked = false;
                toolStripStatusLabel1.Text = "Фільтрування: за окладом (" + f12.comboBox1.Text + f12.textBox1.Text + ")";
            }
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void змінитиПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f10.password = f9.password;
            string s = f9.login;
            if (f10.ShowDialog() == DialogResult.OK)
            {
                string s1 = f10.textBox2.Text;
                b.UpdatePass(s1, s);
                f9.password = s1;
            }
        }

        private void зареєструватиНовогоАдміністратораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f11.ShowDialog() == DialogResult.OK)
            {
                b.InsertAdmin(f11.textBox1.Text, f11.textBox2.Text);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Access != false)
            {
                if (MessageBox.Show("Ви дійсно бажаєте вийти?", "Вихід", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}