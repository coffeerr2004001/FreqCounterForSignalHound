using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace freq_counter
{   
    class FrequencyDataFormatter
    {
        private UInt64 freq;
        private Double pwr;

        public UInt64 Freq
        {
            get
            {
                return freq;
            }
            set
            {
                if ((value >= 1e3) && (value <= 4e9))
                {
                    freq = value;
                }
            }
        }

        public Double Pwr
        {
            get
            {
                return pwr;
            }
            set
            {
                if ((value >= -80) && (value <= 30))
                {
                    pwr = value;
                }
            }
        }

        public String FreqStr 
        {
            get
            { 
                String DisplayString = null;

                String str = freq.ToString();

                for (int i = 0; i< 4; i++)
                {
                    if (str != null)
                    { 
                        if (str.Length > 3)
                        {
                            DisplayString = str.Substring(str.Length - 3, 3) + " " + DisplayString;
                            str = str.Substring(0, str.Length - 3);
                        }
                        else
                        {
                            DisplayString = str + " " + DisplayString;
                            str = null;
                        }
                    }
                }
                DisplayString = DisplayString + "  Hz";        
            
                return DisplayString;
            }
        }

        public String PwrStr
        {
            get
            { 
                String str;            
                str = string.Format("{0:f2}", pwr);
                str += "  dbm";
                return str;
            }
        }

        public override string ToString()
        {
            return "x";
        }

        public FrequencyDataFormatter (UInt64 _freq, Double _pwr)
        {
            Freq = _freq;
            Pwr = _pwr;
        }
        public FrequencyDataFormatter()
        {
            
        }
    }
}
