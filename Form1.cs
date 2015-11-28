using System;
using System.Threading;
using System.Windows.Forms;

namespace freq_counter
{
    public partial class Form1 : Form
    {
     
        SADevice SaDev = new SADevice();
        TestStatus test_status = new TestStatus();

        private void set_default_value ()
        {
            tb_freq.Text = " ---- ";
            tb_pwr.Text = " ---- ";           
        }

        public Form1()
        {
            InitializeComponent();
            set_default_value();
        }        

        private void btn_reference_Click(object sender, EventArgs e)
        {

            if (test_status.ReferenceSource == TestStatus.ReferenceSource_t.Internal)
            {
                test_status.ReferenceSource = TestStatus.ReferenceSource_t.External;
                //btn_reference.Text = "External ref";
            }
            else
            {
                test_status.ReferenceSource = TestStatus.ReferenceSource_t.Internal;
                
            }
            btn_reference.Text = test_status.GetText(test_status.ReferenceSource);
                      

            test_status.MeasureRange = TestStatus.MeaRange_t.mr_full;            
            AddLog("Reference source changed.\r\n");
        }


        private delegate void BtnRefSrcEventHandler(String Message);
        private void ButtonReferenceSourceText(String Message)
        {
            if (this.btn_reference.InvokeRequired)
            {
                BtnRefSrcEventHandler evt = new BtnRefSrcEventHandler(ButtonReferenceSourceText);
                this.Invoke(evt, new object[] { Message });
            }
            else
            {
                if (Message == null)
                {
                    this.btn_reference.Text = "----";
                }
                else
                {
                    this.btn_reference.Text = Message;
                }
            }
        }

        private void bt_range_Click(object sender, EventArgs e)
        {
            if (test_status.FreqRange == TestStatus.FreqRange_t.r_1m_1g)
            {
                test_status.FreqRange = TestStatus.FreqRange_t.r_1g_2g;
            }
            else if (test_status.FreqRange == TestStatus.FreqRange_t.r_1g_2g)
            {
                test_status.FreqRange = TestStatus.FreqRange_t.r_2g_3g;                
            }
            else if (test_status.FreqRange == TestStatus.FreqRange_t.r_2g_3g)
            {
                test_status.FreqRange = TestStatus.FreqRange_t.r_3g_4g;                
            }
            else if (test_status.FreqRange == TestStatus.FreqRange_t.r_3g_4g)
            {
                test_status.FreqRange = TestStatus.FreqRange_t.r_1k_100M;                
            }
            else if (test_status.FreqRange == TestStatus.FreqRange_t.r_1k_100M)
            {
                test_status.FreqRange = TestStatus.FreqRange_t.r_1m_1g;                
            }
            else
            {

            }

            btn_range.Text = test_status.GetText(test_status.FreqRange);

            test_status.MeasureRange = TestStatus.MeaRange_t.mr_full;
            //test_status.FoundPeak = false;
            AddLog("Test range changed.\r\n");

        }
        


        private void Form1_Load(object sender, EventArgs e)
        {
            AddLog("Program start\r\n");
            Thread test = new Thread(TestLoop);
            test.Start();
        }

        private delegate void AddlogEventHandler (String Message);
        private void AddLog (String Message)
        {           
            if (this.rtb_log.InvokeRequired)
            {
                AddlogEventHandler evt = new AddlogEventHandler(AddLog);                
                this.Invoke(evt, new object[] { Message });
            }
            else
            {
                if (Message == null)
                {
                    this.rtb_log.AppendText("Device not connected.");
                }
                else
                { 
                    this.rtb_log.AppendText(":" + Message);                    
                }
            }
        }

        private delegate void FreqTextEventHandler(String Message);
        private void FreqText(String Message)
        {
            if (this.tb_freq.InvokeRequired)
            {
                FreqTextEventHandler evt = new FreqTextEventHandler(FreqText);
                this.Invoke(evt, new object[] { Message });
            }
            else
            {
                if (Message == null)
                {
                    this.tb_freq.Text = " ---- ";
                }
                else
                {
                    this.tb_freq.Text = Message;
                }
            }
        }

        private delegate void PwrTextEventHandler(String Message);
        private void PwrText(String Message)
        {
            if (this.tb_pwr.InvokeRequired)
            {
                PwrTextEventHandler evt = new PwrTextEventHandler(PwrText);
                this.Invoke(evt, new object[] { Message });
            }
            else
            {
                if (Message == null)
                {
                    this.tb_pwr.Text = " ---- ";
                }
                else
                {
                    this.tb_pwr.Text = Message;
                }
            }
        }

        
        private delegate void StatusTextEventHandler(String Message);
        public void StatusText(String Message)
        {
            if (this.lb_status.InvokeRequired)
            {
                StatusTextEventHandler evt = new StatusTextEventHandler(StatusText);
                this.Invoke(evt, new object[] { Message });
            }
            else
            {
                if (Message == null)
                {
                    this.lb_status.Text = " ";
                }
                else
                {
                    this.lb_status.Text = Message;
                }
            }
        }

        public void TestLoop()
        {
            //public bool SaGetPeakFreq(out double peak_freq, out float peak_pwr, double begin_freq, double end_freq, double rbw)
            Double PeakFreq = new Double();
            float peak_pwr = new float();

            SaDev.CloseDevice();
            SaDev.OpenDevice();
            AddLog("Opened sa device.\r\n");

            while (true)
            {                
                Thread.Sleep(10);
                if (test_status.MeasureRange == TestStatus.MeaRange_t.mr_full)
                {
                    test_status.FoundPeak = false;

                    if (test_status.ReferenceSource == TestStatus.ReferenceSource_t.External)
                    {
                        if (SaDev.ExternalReferenceSource())
                        {
                            AddLog("Switch to external reference done.\r\n");
                        }
                        else
                        {
                            AddLog("External reference error.\r\n");
                            test_status.ReferenceSource = TestStatus.ReferenceSource_t.Internal;
                            ButtonReferenceSourceText(test_status.GetText(test_status.ReferenceSource));

                        }
                    }

                    StatusText("1/3");
                    AddLog("Full range scan, may take about 10 secends.\r\n");

                    SaDev.SaGetPeakFreq( out PeakFreq, out peak_pwr, test_status);
                    if (peak_pwr < -40)
                    {
                        AddLog("Not found a signal over -40dbm.\r\n");
                    }
                    else
                    { 
                        FrequencyDataFormatter DataFormat = new FrequencyDataFormatter((ulong)PeakFreq, peak_pwr);
                        FreqText(DataFormat.FreqStr);
                        PwrText(DataFormat.PwrStr);
                        test_status.MeasureRange = TestStatus.MeaRange_t.mr_1m;
                        test_status.CenterFrequency = PeakFreq;                    
                        test_status.FoundPeak = true;
                        AddLog("Found peak in full range.\r\n");                        
                    }
                    Thread.Sleep(100);
                }

                if (test_status.MeasureRange == TestStatus.MeaRange_t.mr_1m)
                {
                    StatusText("2/3");                    
                    SaDev.SaGetPeakFreq(out PeakFreq, out peak_pwr, test_status);
                    if (peak_pwr < -40)
                    {
                        test_status.MeasureRange = TestStatus.MeaRange_t.mr_full;
                        //test_status.FoundPeak = false;
                        AddLog("Miss peak in 1MHz range.\r\n");
                    }
                    else
                    {
                        FrequencyDataFormatter DataFormat = new FrequencyDataFormatter((ulong)PeakFreq, peak_pwr);
                        FreqText(DataFormat.FreqStr);
                        PwrText(DataFormat.PwrStr);
                        test_status.MeasureRange = TestStatus.MeaRange_t.mr_1k;
                        test_status.CenterFrequency = PeakFreq;
                        //test_status.FoundPeak = true;
                        AddLog("Found peak in 1MHz range.\r\n");
                    }

                }

                while (test_status.MeasureRange == TestStatus.MeaRange_t.mr_1k)
                {
                    StatusText("3/3");                    
                    SaDev.SaGetPeakFreq(out PeakFreq, out peak_pwr, test_status);

                    if (peak_pwr < -40)
                    {
                        test_status.MeasureRange = TestStatus.MeaRange_t.mr_1m;
                        //test_status.FoundPeak = false;
                        AddLog("Miss peak in 1KHz range.\r\n");
                    }
                    else
                    { 
                        FrequencyDataFormatter DataFormat = new FrequencyDataFormatter((ulong)PeakFreq, peak_pwr);             
                        FreqText(DataFormat.FreqStr);
                        PwrText(DataFormat.PwrStr);
                        test_status.CenterFrequency = PeakFreq;
                        //test_status.FoundPeak = true;
                        AddLog("Found peak in 1KHz range.\r\n");
                    }
                }
            }

        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            SaDev.CloseDevice();
            System.Environment.Exit(0);
        }

    }
}
