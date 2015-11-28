using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace freq_counter
{    
    class SADevice
    {
        private volatile bool scan_enable;
        private int device_id = -1;
        private String device_name = null;
        private saStatus status;

        public bool ScanEnable
        {
            get
            {
                return scan_enable;
            }
            set
            {
                scan_enable = value;
            }
        }

        public int DeviceId
        {
            get
            {
                return device_id;
            }            
        }

        public void ScanDecive()
        {
            while (ScanEnable)
            {
                if (status != saStatus.saNoError)
                {
                    CloseDevice();
                    OpenDevice();
                }
                else if ((device_id == -1) || (device_name == null))
                {
                    OpenDevice();
                }
                else
                {
                    
                }

                Thread.Sleep(1000);
            }
        }

        public String DeviceName
        {
            get
            {
                return sa_api.saGetDeviceName(device_id).ToString() + "@" + sa_api.saGetSerialString(device_id);
                //return device_name;
            }
            set
            {
                device_name = value;
            }
        }
        
        //public delegate void AddLogEventHandler(String Message);
        
        public bool OpenDevice ()
        {             
            status = sa_api.saOpenDevice(ref device_id);
            if (status != saStatus.saNoError)
            {
                device_name = null;
                device_id = -1;
                return false;
            }

            device_name = DeviceName;            
            //Form1.AddlogEventHandler("xx");
            //sa_api.saCloseDevice(device_id);
            return true;            
        }
        
        public bool CloseDevice()
        {
            if ( device_name != null)
            {
                sa_api.saCloseDevice(device_id);
                device_name = null;
                device_id = -1;
                return true;
            }
            else
            {
                
            }

            device_name = null;
            device_id = -1;

            return false;
        }

        public bool SaGetPeakFreq(out double peak_freq, out float peak_pwr, TestStatus test_state)
        {
            return SaGetPeakFreq(out peak_freq, out peak_pwr, test_state.BeginFreq, test_state.EndFreq, test_state.Rbw);
        }

        public bool SaGetPeakFreq (out double peak_freq, out float peak_pwr, double begin_freq, double end_freq, double rbw)
        {            
            double vbw = rbw;
            double span = end_freq - begin_freq;
            double center_freq = begin_freq + span / 2;

            //saStatus status = saStatus.saNoError;
            sa_api.saConfigCenterSpan(device_id, center_freq, span);

            //detector and scale.
            sa_api.saConfigAcquisition(device_id, sa_api.SA_MIN_AND_MAX, sa_api.SA_LOG_SCALE);            
            sa_api.saConfigLevel(device_id, 0);
            sa_api.saConfigSweepCoupling(device_id, rbw, vbw, true);

            // Initialize the device with the configuration just set
            saStatus status = (sa_api.saInitiate(device_id, sa_api.SA_SWEEPING, 0));
            if (status != saStatus.saNoError) //saStatus 
            {
                // Handle unable to initialize
                //Console.WriteLine("Sa device initial error.\r\n");
                peak_freq = 0;
                peak_pwr = 0;
                return false;
            }
            
            // Get sweep characteristics

            int[] sweepLen = new int[1];
            double[] startFreq = new double[1];
            double[] binSize = new double[1];
            sa_api.saQuerySweepInfo(device_id, sweepLen, startFreq, binSize);

            //Console.WriteLine("total point count = " + sweepLen[0].ToString());
            //Console.WriteLine("startfreq = " + startFreq[0]);
            //Console.WriteLine("binsize = " + binSize[0]);            

            double res_freq = span / (sweepLen[0] - 1);
            //Console.WriteLine("res freq = " + res_freq.ToString());

            // Allocate memory for the sweep
            float[] min = new float[sweepLen[0]];
            float[] max = new float[sweepLen[0]];

            // Get one sweep
            sa_api.saGetSweep_32f(device_id, min, max);
            //sa_api.saCloseDevice(device_id);

            peak_pwr = min.Max();
            int index = Array.IndexOf<float>(min, peak_pwr);

            peak_freq = index * res_freq + startFreq[0];

            //Console.WriteLine("Find peakpower {0}dbm at {1}, freq= {2}", max_value, index, peak_freq);
                       
            //sa_api.saAbort(device_id);
            return true; 

        }


        public bool ExternalReferenceSource ()
        {
            if (saStatus.saNoError != sa_api.saEnableExternalReference(device_id))
            { 
                return false;
            }
            else
            {
                return true;
            }
        }



    }
}

/*

        
*/
