using System;

namespace Domain
{
    public class Person
    {
        int id;
        string fname;
        string sname;
        DateTime birthday;
        string pnumber;
        int salary;
        string passport;
        string post;
        string idnumber;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Fname
        {
            get
            {
                return fname;
            }

            set
            {
                fname = value;
            }
        }

        public string Sname
        {
            get
            {
                return sname;
            }

            set
            {
                sname = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
            }
        }

        public string Pnumber
        {
            get
            {
                return pnumber;
            }

            set
            {
                pnumber = value;
            }
        }

        public string Passport
        {
            get
            {
                return passport;
            }

            set
            {
                passport = value;
            }
        }

        public string Post
        {
            get
            {
                return post;
            }

            set
            {
                post = value;
            }
        }

        public string Idnumber
        {
            get
            {
                return idnumber;
            }

            set
            {
                idnumber = value;
            }
        }

        public int Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }

        public override string ToString()
        {
            return Fname + " " + Sname;
        }

    }
}
