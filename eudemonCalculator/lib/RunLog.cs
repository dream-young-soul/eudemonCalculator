using System;
using System.IO;

namespace eudemonCalculator.lib
{
    internal class RunLog
    {
        /// <summary>
        /// 程序目录写入log
        /// </summary>
        internal static void WriteLog(string str)
        {

            if (File.Exists(DateTime.Today.ToString("yyyy-MM-dd") + ".log"))
            {
                var sw = new StreamWriter(DateTime.Today.ToString("yyyy-MM-dd") + ".log", true);
                sw.WriteLine("============================================================================");
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":");
                sw.WriteLine(str);
                sw.Close();

            }
            else
            {
                var sw2 = new StreamWriter(DateTime.Today.ToString("yyyy-MM-dd") + ".log", true);
                sw2.WriteLine("============================================================================");
                sw2.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":");
                sw2.WriteLine(str);
                sw2.Close();
            }


        }

    }
}
