using System;

namespace Domain
{
    public class Salary
    {
        int id;
        int tableid;
        string fname;
        string sname;
        int days;
        int tdays;
        string month;
        int year;
        double pay;
        double esv;
        double pdfo;
        double army;
        double salaryres;

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

        public int Tableid
        {
            get
            {
                return tableid;
            }

            set
            {
                tableid = value;
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

        public int Days
        {
            get
            {
                return days;
            }

            set
            {
                days = value;
            }
        }

        public int Tdays
        {
            get
            {
                return tdays;
            }

            set
            {
                tdays = value;
            }
        }

        public double Pay
        {
            get
            {
                return pay;
            }

            set
            {
                pay = value;
            }
        }

        public double Esv
        {
            get
            {
                return esv;
            }

            set
            {
                esv = value;
            }
        }

        public double Pdfo
        {
            get
            {
                return pdfo;
            }

            set
            {
                pdfo = value;
            }
        }

        public double Army
        {
            get
            {
                return army;
            }

            set
            {
                army = value;
            }
        }

        public double Salaryres
        {
            get
            {
                return salaryres;
            }

            set
            {
                salaryres = value;
            }
        }

        public string Month
        {
            get
            {
                return month;
            }

            set
            {
                month = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }

            set
            {
                year = value;
            }
        }
    }
}
