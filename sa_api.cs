using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/**
*   Most of the contents in this page was copied from bb csharp project 
*   because signalhound doesn't release a csharp project for sa spectrum analyzer,
*   so most of the unused api may NOT declared right, and need to be checked when using.
*/

namespace freq_counter
{
    public enum saDeviceType
    {
        saDeviceTypeNone = 0,
        saDeviceTypeSA44 = 1,
        saDeviceTypeSA44B = 2,
        saDeviceTypeSA124A = 3,
        saDeviceTypeSA124B = 4
    };

    public enum saStatus
    {
        saUnknownErr = -666,

        // Setting specific error codes
        saFrequencyRangeErr = -99,
        saInvalidDetectorErr = -95,
        saInvalidScaleErr = -94,
        saBandwidthErr = -91,
        saExternalReferenceNotFound = -89,

        // Device-specific errors
        saOvenColdErr = -20,

        // Data errors
        saInternetErr = -12,
        saUSBCommErr = -11,

        // General configuration errors
        saTrackingGeneratorNotFound = -10,
        saDeviceNotIdleErr = -9,
        saDeviceNotFoundErr = -8,
        saInvalidModeErr = -7,
        saNotConfiguredErr = -6,
        saTooManyDevicesErr = -5,
        saInvalidParameterErr = -4,
        saDeviceNotOpenErr = -3,
        saInvalidDeviceErr = -2,
        saNullPtrErr = -1,

        // No Error
        saNoError = 0,

        // Warnings
        saNoCorrections = 1,
        saCompressionWarning = 2,
        saParameterClamped = 3,
        saBandwidthClamped = 4,
    };

    class sa_api
    {
        // saGetDeviceType : type

        public static int SA_DEVICE_NONE = 0x0;
        public static int SA_DEVICE_SA44 = 0x1;
        public static int SA_DEVICE_SA44B = 0x2;
        public static int SA_DEVICE_SA124A = 0x3;
        public static int SA_DEVICE_SA124B = 0x4;        


        // saConfigureLevel : atten
        public static double SA_AUTO_ATTEN = -1.0;
        // saConfigureGain : gain
        public static int SA_AUTO_GAIN = -1;
        // saConfigAcquisition : detector
        public static uint SA_MIN_AND_MAX = 0x0;
        public static uint SA_AVERAGE = 0x1;

        // saConfigAcquisition : scale
        public static uint SA_LOG_SCALE = 0x0;
        public static uint SA_LIN_SCALE = 0x1;
        public static uint SA_LOG_FULL_SCALE = 0x2;
        public static uint SA_LIN_FULL_SCALE = 0x3;

        // saConfigureSweepCoupling : rbwType
        public static uint SA_NATIVE_RBW = 0x0;
        public static uint SA_NON_NATIVE_RBW = 0x1;
        // saConfigureSweepCoupling : rejection
        public static uint SA_NO_SPUR_REJECT = 0x0;
        public static uint SA_SPUR_REJECT = 0x1;
        // saConfigureWindow : window
        public static uint SA_NUTALL = 0x0;
        public static uint SA_BLACKMAN = 0x1;
        public static uint SA_HAMMING = 0x2;
        public static uint SA_FLAT_TOP = 0x3;
        // saConfigureProcUnits : units
        public static uint SA_LOG = 0x0;
        public static uint SA_VOLTAGE = 0x1;
        public static uint SA_POWER = 0x2;
        public static uint SA_SAMPLE = 0x3;
        
        // saConfigureIQ : downsampleFactor
        public static int SA_MIN_DECIMATION = 1; // 2 ^ 0
        public static int SA_MAX_DECIMATION = 128; // 2 ^ 7


        // saInitiate : mode
        public static int SA_IDLE = -1;
        public static uint SA_SWEEPING = 0x0;
        public static uint SA_REAL_TIME = 0x1;
        public static uint SA_IQ = 0x2;
        public static uint SA_AUDIO = 0x3;
        public static uint SA_TG_SWEEP = 0x4;


        // saInitiate : flag
        public static uint SA_STREAM_IQ = 0x0;
        public static uint SA_STREAM_IF = 0x1;
        // saConfigureIO : port1
        public static uint SA_PORT1_AC_COUPLED = 0x00;
        public static uint SA_PORT1_DC_COUPLED = 0x04;
        public static uint SA_PORT1_INT_REF_OUT = 0x00;
        public static uint SA_PORT1_EXT_REF_IN = 0x08;
        public static uint SA_PORT1_OUT_AC_LOAD = 0x10;
        public static uint SA_PORT1_OUT_LOGIC_LOW = 0x14;
        public static uint SA_PORT1_OUT_LOGIC_HIGH = 0x1C;
        // saConfigureIO : port2
        public static uint SA_PORT2_OUT_LOGIC_LOW = 0x00;
        public static uint SA_PORT2_OUT_LOGIC_HIGH = 0x20;
        public static uint SA_PORT2_IN_TRIGGER_RISING_EDGE = 0x40;
        public static uint SA_PORT2_IN_TRIGGER_FALLING_EDGE = 0x60;

        //sa ok
        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saOpenDevice(ref int device);

        //sa ok
        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saCloseDevice(int device);

        //sa ok
        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saEnableExternalReference(int device);
        
        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saConfigAcquisition(int device,
            uint detector, uint scale);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saConfigCenterSpan(int device,
            double center, double span);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saConfigLevel(int device,
            double ref_level);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saConfigGain(int device, int gain);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saConfigSweepCoupling(int device,
            double rbw, double vbw, bool rejection);

        //saStatus saQuerySweepInfo(int device, int* sweepLength, double* startFreq, double * binSize);
        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saQuerySweepInfo(int device,
            [Out, MarshalAs(UnmanagedType.LPArray)] int[] sweepLength,
            [Out, MarshalAs(UnmanagedType.LPArray)] double[] startFreq,
            [Out, MarshalAs(UnmanagedType.LPArray)] double[] binSize);

        //saStatus saGetSweep_32f(int device, float* min, float* max);
        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saGetSweep_32f(int device,
            [Out, MarshalAs(UnmanagedType.LPArray)] float[] min,
            [Out, MarshalAs(UnmanagedType.LPArray)] float[] max);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saConfigWindow(int device, uint window);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saConfigProcUnits(int device, uint units);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saConfigIO(int device,
            uint port1, uint port2);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saConfigDemod(int device,
            int mod_type, double freq, float if_bandwidth, float low_pass_freq,
            float high_pass_freq, float fm_deemphasis);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saConfigIQ(int device,
            int downsampleFactor, double bandwidth);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saInitiate(int device,
            uint mode, uint flag);

        [DllImport("sa_api", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saFetchTrace_32f(int device,
            int arraySize, float[] min, float[] max);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saFetchTrace(int device,
            int array_size, double[] min, double[] max);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saFetchAudio(int device, ref float audio);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saFetchRaw(int device,
            float[] buffer, int[] triggers);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saQueryTraceInfo(int device,
            ref uint trace_len, ref double bin_size, ref double start);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saQueryStreamInfo(int device,
            ref int return_len, ref double bandwidth, ref int samples_per_sec);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saQueryTimestamp(int device,
            ref uint seconds, ref uint nanoseconds);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saAbort(int device);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saPreset(int device);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saSelfCal(int device);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saSyncCPUtoGPS(int com_port, int baud_rate);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saGetDeviceType(int device, ref int type);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saGetSerialNumber(int device, ref uint serial_number);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saGetFirmwareVersion(int device, ref int version);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saGetFirmwareString(int device, [Out, MarshalAs(UnmanagedType.LPArray)] char[] firmware_str);

        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern saStatus saGetDeviceDiagnostics(int device,
            ref float temperature, ref float usbVoltage, ref float usbCurrent);

        //saEnableExternalReference

        public static string saGetDeviceName(int device)
        {
            int device_type = -1;
            saGetDeviceType(device, ref device_type);

            if (device_type == SA_DEVICE_NONE)
            { 
                return "None";
            }
            else if (device_type == SA_DEVICE_SA44)
            {
                return "SA44";
            }
            else if (device_type == SA_DEVICE_SA44B)
            {
                return "SA44B";
            }
            else if (device_type == SA_DEVICE_SA124A)
            {
                return "SA124A";
            }
            else if (device_type == SA_DEVICE_SA124B)
            {
                return "SA124B";
            }

            return "Unknown device";
        }

        public static string saGetSerialString(int device)
        {
            uint serial_number = 0;
            if (saGetSerialNumber(device, ref serial_number) == saStatus.saNoError)
                return serial_number.ToString();

            return "";
        }

        public static string saGetAPIString()
        {
            IntPtr str_ptr = saGetAPIVersion();
            return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(str_ptr);
        }

        public static string saGetStatusString(saStatus status)
        {
            IntPtr str_ptr = saGetErrorString(status);
            return System.Runtime.InteropServices.Marshal.PtrToStringAnsi(str_ptr);
        }

        // Call get_string variants above instead
        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr saGetAPIVersion();
        [DllImport("sa_api.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr saGetErrorString(saStatus status);
    }
}
