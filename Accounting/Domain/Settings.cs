using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Settings
    {
        int esvmax;
        double esvperc;
        int livingmin;
        double livingperc1;
        double livingperc2;
        double armyperc;

        public int Esvmax
        {
            get
            {
                return esvmax;
            }

            set
            {
                esvmax = value;
            }
        }

        public double Esvperc
        {
            get
            {
                return esvperc;
            }

            set
            {
                esvperc = value;
            }
        }

        public int Livingmin
        {
            get
            {
                return livingmin;
            }

            set
            {
                livingmin = value;
            }
        }

        public double Livingperc1
        {
            get
            {
                return livingperc1;
            }

            set
            {
                livingperc1 = value;
            }
        }

        public double Livingperc2
        {
            get
            {
                return livingperc2;
            }

            set
            {
                livingperc2 = value;
            }
        }

        public double Armyperc
        {
            get
            {
                return armyperc;
            }

            set
            {
                armyperc = value;
            }
        }
    }
}
