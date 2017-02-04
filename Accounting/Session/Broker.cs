using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Domain;
using System.Data;

namespace Session
{
    public class Broker
    {
        OleDbConnection connection;
        OleDbCommand command;

        private void ConnectTo()
        {
            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\DataBase.accdb;Jet OLEDB:Database Password=12345");
            command = connection.CreateCommand();
        }

        public Broker()
        {
            ConnectTo();
        }

        public void Insert(Person p)
        {
            try
            {
                command.Parameters.AddWithValue("@fname", p.Fname);
                command.Parameters.AddWithValue("@sname", p.Sname);
                command.Parameters.AddWithValue("@birthday", p.Birthday);
                command.Parameters.AddWithValue("@pnumber", p.Pnumber);
                command.Parameters.AddWithValue("@passport", p.Passport);
                command.Parameters.AddWithValue("@post", p.Post);
                command.Parameters.AddWithValue("@idnumber", p.Idnumber);
                command.Parameters.AddWithValue("@salary", p.Salary);
                command.CommandText = "INSERT INTO [Table] ([FName], [SName], [Birthday], [PNumber], [Passport], [Post], [IDNumber], [Salary]) VALUES(@fname, @sname, @birthday, @pnumber, @passport, @post, @idnumber, @salary)";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public DataTable ShowTable(string table)
        {
            string sql = "SELECT * FROM [" + table + "]";
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            connection.Open();
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable scores = new DataTable();
            da.Fill(scores);
            connection.Close();
            return scores;
        }

        public DataTable ShowTable(string table, int id)
        {
            string sql = "SELECT * FROM [" + table + "] WHERE TableID= " + id.ToString();
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            connection.Open();
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable scores = new DataTable();
            da.Fill(scores);
            connection.Close();
            return scores;
        }

        public DataTable ShowTable(string table, string post)
        {
            string sql = "SELECT * FROM [Table] WHERE Post= '" + post + "'";
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            connection.Open();
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable scores = new DataTable();
            da.Fill(scores);
            connection.Close();
            return scores;
        }

        public DataTable ShowTable(string table, string sign, int value)
        {
            string sql = "SELECT * FROM [Table] WHERE Salary " + sign + " " + value;
            OleDbCommand cmd = new OleDbCommand(sql, connection);
            connection.Open();
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable scores = new DataTable();
            da.Fill(scores);
            connection.Close();
            return scores;
        }

        public void Delete(Person p, string table)
        {
            try
            {
                command.Parameters.AddWithValue("@id", p.Id);
                command.CommandText = "DELETE FROM [" + table + "] WHERE ID= @id";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void Update(Person p, Person newPerson)
        {
            try
            {
                command.Parameters.AddWithValue("@fname", newPerson.Fname);
                command.Parameters.AddWithValue("@sname", newPerson.Sname);
                command.Parameters.AddWithValue("@birthday", newPerson.Birthday);
                command.Parameters.AddWithValue("@pnumber", newPerson.Pnumber);
                command.Parameters.AddWithValue("@passport", newPerson.Passport);
                command.Parameters.AddWithValue("@post", newPerson.Post);
                command.Parameters.AddWithValue("@idnumber", newPerson.Idnumber);
                command.Parameters.AddWithValue("@salary", newPerson.Salary);
                command.Parameters.AddWithValue("@id", p.Id);
                command.CommandText = "UPDATE [Table] SET [FName] = @fname, [SName] = @sname, [Birthday] = @birthday, [PNumber] = @pnumber, [Passport] = @passport, [Post] = @post, [IDNumber] = @idnumber, [Salary] = @salary WHERE [ID] = @id";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void InsertPost(Person p)
        {
            try
            {
                command.Parameters.AddWithValue("@fname", p.Fname);
                command.CommandText = "INSERT INTO [Post] ([Post]) VALUES(@fname)";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public List<Person> FillComboBox()
        {
            List<Person> postlist = new List<Person>();
            try
            {
                command.CommandText = "SELECT * FROM [Post]";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Person p = new Person();
                    p.Id = Convert.ToInt32(reader["ID"].ToString());
                    p.Fname = reader["Post"].ToString();
                    postlist.Add(p);
                }
                return postlist;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public List<Person> FillReportComboBox()
        {
            List<Person> personlist = new List<Person>();
            try
            {
                command.CommandText = "SELECT * FROM [Table]";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Person p = new Person();
                    p.Id = Convert.ToInt32(reader["ID"].ToString());
                    p.Fname = reader["FName"].ToString();
                    p.Sname = reader["SName"].ToString();
                    p.Post = reader["Post"].ToString();
                    personlist.Add(p);
                }
                return personlist;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void SettingsUpdate(Settings set, Settings oldSet)
        {
            try
            {
                command.Parameters.AddWithValue("@emax", set.Esvmax);
                command.Parameters.AddWithValue("@eperc", set.Esvperc);
                command.Parameters.AddWithValue("@lmin", set.Livingmin);
                command.Parameters.AddWithValue("@lperc1", set.Livingperc1);
                command.Parameters.AddWithValue("@lperc2", set.Livingperc2);
                command.Parameters.AddWithValue("@armyrepc", set.Armyperc);
                command.Parameters.AddWithValue("@emaxold", oldSet.Esvmax);
                command.CommandText = "UPDATE [Settings] SET [ESVMax] = @emax, [ESVPercent] = @eperc, [LivingMin] = @lmin, [LivingPercent1] = @lperc1, [LivingPercent2] = @lperc2, [ArmyPercent] = @armyrepc WHERE [ESVMax] = @emaxold";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public Settings SettingsShow()
        {
            try
            {
                command.CommandText = "SELECT * FROM [Settings]";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                Settings set = new Settings();
                while (reader.Read())
                {
                    set.Esvmax = Convert.ToInt32(reader["ESVMax"].ToString());
                    set.Esvperc = Convert.ToDouble(reader["ESVPercent"].ToString());
                    set.Livingmin = Convert.ToInt32(reader["LivingMin"].ToString());
                    set.Livingperc1 = Convert.ToDouble(reader["LivingPercent1"].ToString());
                    set.Livingperc2 = Convert.ToDouble(reader["LivingPercent2"].ToString());
                    set.Armyperc = Convert.ToDouble(reader["ArmyPercent"].ToString());
                }
                return set;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void InsertSalary(Salary sal)
        {
            try
            {
                command.Parameters.AddWithValue("@tableid", sal.Tableid);
                command.Parameters.AddWithValue("@fname", sal.Fname);
                command.Parameters.AddWithValue("@sname", sal.Sname);
                command.Parameters.AddWithValue("@days", sal.Days);
                command.Parameters.AddWithValue("@tdays", sal.Tdays);
                command.Parameters.AddWithValue("@month", sal.Month);
                command.Parameters.AddWithValue("@year", sal.Year);
                command.Parameters.AddWithValue("@pay", sal.Pay);
                command.Parameters.AddWithValue("@esv", sal.Esv);
                command.Parameters.AddWithValue("@pdfo", sal.Pdfo);
                command.Parameters.AddWithValue("@army", sal.Army);
                command.CommandText = "INSERT INTO [Salary] ([TableID], [FName], [SName], [Days], [TDays], [SalaryMonth], [SalaryYear], [Pay], [ESV], [PDFO], [Army]) VALUES(@tableid, @fname, @sname, @days, @tdays, @month, @year, @pay, @esv, @pdfo, @army)";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public bool EnterProgram(string login, string password)
        {
            try
            {
                command.CommandText = "SELECT * FROM [Users] WHERE Login = '" + login + "' AND Password = '" + password + "'";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read()) return true;
                else return false;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public bool EnterProgram(string login)
        {
            try
            {
                command.CommandText = "SELECT * FROM [Users] WHERE Login = '" + login + "'";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read()) return false;
                else return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void UpdatePass(string login, string newPassword)
        {
            try
            {
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@pass", newPassword);
                command.CommandText = "UPDATE [Users] SET [Password] = @pass WHERE [Login] = @login";
                command.CommandType = CommandType.Text;
                connection.Open();

                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void InsertAdmin(string login, string password)
        {
            try
            {
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@pass", password);
                command.CommandText = "INSERT INTO [Users] ([Login], [Password]) VALUES(@login, @pass)";
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public bool EnterSalary(int id, string month, int year)
        {
            try
            {
                command.CommandText = "SELECT * FROM [Salary]";
                command.CommandType = CommandType.Text;
                connection.Open();

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["TableID"].ToString() == id.ToString() && reader["SalaryMonth"].ToString() == month && reader["SalaryYear"].ToString() == year.ToString())
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }


    }
}
