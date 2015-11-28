using System;


namespace freq_counter
{
    class TestStatus
    {
        public enum FreqRange_t
        {
            r_1k_100M,
            r_1m_1g,
            r_1g_2g,
            r_2g_3g,
            r_3g_4g,         
        };

        public enum MeaRange_t
        {
            mr_full,
            mr_1m,
            mr_1k
        };

        public enum ReferenceSource_t
        {
            Internal,
            External
        };
        public String GetText(FreqRange_t invalue)
        {
            if (invalue == FreqRange_t.r_1k_100M)
            {
                return "1KHz-100MHz";
            }
            else if (invalue == FreqRange_t.r_1m_1g)
            {
                return "1MHz - 1GHz";
            }
            else if (invalue == FreqRange_t.r_1g_2g)
            {
                return "1GHz - 2GHz";
            }
            else if (invalue == FreqRange_t.r_2g_3g)
            {
                return "2GHz - 3GHz";
            }
            else if (invalue == FreqRange_t.r_3g_4g)
            {
                return "3GHz - 4GHz";
            }

            return null;
        }
        public String GetText(ReferenceSource_t invalue)
        {
            if (invalue == ReferenceSource_t.External)
            {
                return "External ref";
            }
            else
            {
                return "Internal ref";
            }
        }

        private bool found_peak;
        private bool adjust_range;

        private MeaRange_t measure_range;
        private FreqRange_t freq_range;
        private ReferenceSource_t ref_source;

        private double begin_frequency;
        private double end_frequency;
        private double center_frequency;
        private double rbw;
        
        public MeaRange_t MeasureRange
        {
            get
            {
                return measure_range;
            }
            set
            {
                measure_range = value;
            }
        }
        public FreqRange_t FreqRange
        {
            get
            {
                return freq_range;
            }
            set
            {
                freq_range = value;
            }
        }
        public ReferenceSource_t ReferenceSource
        {
            get
            {
                return ref_source;
            }
            set
            {
                ref_source = value;
            }
        }
        public double CenterFrequency
        {
            get
            {
                return center_frequency;
            }
            set
            {
                center_frequency = value;
            }
        }
        public double Span
        {
            get
            {
                if (MeasureRange == MeaRange_t.mr_1k)
                {
                    return 1e3;
                }
                else if (MeasureRange == MeaRange_t.mr_1m)
                {
                    return 1e6;
                }
                else
                {
                    return 1e9;
                }

            }
        }
        public double BeginFreq
        {
            get
            {
                if (found_peak == true)
                {
                    begin_frequency = CenterFrequency - Span / 2;
                }
                else if (freq_range == FreqRange_t.r_1k_100M)
                {
                    begin_frequency = 1e3 - 1e2;
                }
                else if (freq_range == FreqRange_t.r_1m_1g)
                {
                    begin_frequency = 1e6 - 1e3;
                }
                else if (freq_range == FreqRange_t.r_1g_2g)
                {
                    begin_frequency = 1e9 - 1e6;
                }
                else if (freq_range == FreqRange_t.r_2g_3g)
                {
                    begin_frequency = 2e9 - 1e6;
                }
                else if (freq_range == FreqRange_t.r_3g_4g)
                {
                    begin_frequency = 3e9 - 1e6;
                }
                
                return begin_frequency;
            }
        }
        public double EndFreq
        {
            get
            {
                if (found_peak == true)
                {
                    end_frequency = CenterFrequency + Span / 2;
                }
                else if (freq_range == FreqRange_t.r_1k_100M)
                {
                    end_frequency = 100e6 + 1e3;
                }
                else if (freq_range == FreqRange_t.r_1m_1g)
                {
                    end_frequency = 1e9 + 1e6;
                }
                else if (freq_range == FreqRange_t.r_1g_2g)
                {
                    end_frequency = 2e9 + 1e6;
                }
                else if (freq_range == FreqRange_t.r_2g_3g)
                {
                    end_frequency = 3e9 + 1e6;
                }
                else if (freq_range == FreqRange_t.r_3g_4g)
                {
                    end_frequency = 4e9 + 1e6;
                }

                return end_frequency;

            }
        }
        public double Rbw
        {
            get
            {
                if (measure_range == MeaRange_t.mr_full)
                {
                    rbw = 250e3;
                }
                else if (measure_range == MeaRange_t.mr_1m)
                {
                    rbw = 1e3;
                }
                else
                {
                    rbw = 10;
                }
                return rbw;
            }

        }

        public bool FoundPeak
        {
            set
            {
                found_peak = value;
            }
        }

        public bool AdjustRange
        {
            set
            {
                adjust_range = value;
            }
        }

        public TestStatus()
        {
            FreqRange = TestStatus.FreqRange_t.r_1m_1g;
            ReferenceSource = TestStatus.ReferenceSource_t.Internal;
            MeasureRange = TestStatus.MeaRange_t.mr_full;
            found_peak = false;
        }      

    }
}
