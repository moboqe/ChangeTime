using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DateChanger
{
    class Program
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime([In] ref SYSTEMTIME st);

        public static void Main(string[] args)
        {
            DateTime tmp = DateTime.UtcNow;
            Console.WriteLine(tmp);
            SYSTEMTIME st = new SYSTEMTIME();
            st.wYear = Convert.ToInt16(DateTime.UtcNow.Year);
            st.wMonth = Convert.ToInt16(1);
            st.wDay = Convert.ToInt16(DateTime.UtcNow.Day);
            st.wHour = Convert.ToInt16(DateTime.UtcNow.Hour);
            st.wMinute = Convert.ToInt16(DateTime.UtcNow.Minute);
            st.wSecond = Convert.ToInt16(DateTime.UtcNow.Second);
            st.wMilliseconds = Convert.ToInt16(DateTime.UtcNow.Millisecond);
            SetSystemTime(ref st);

            // Process.Start("");
            st.wYear = Convert.ToInt16(tmp.Year);
            st.wMonth = Convert.ToInt16(tmp.Month);
            st.wDay = Convert.ToInt16(tmp.Day);
            st.wHour = Convert.ToInt16(tmp.Hour);
            st.wMinute = Convert.ToInt16(tmp.Minute);
            st.wSecond = Convert.ToInt16(tmp.Second);
            st.wMilliseconds = Convert.ToInt16(tmp.Millisecond);
            SetSystemTime(ref st);
            Console.ReadKey();
        }
    }
}