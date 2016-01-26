using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class save
    {
        static string[] result = new string[2];
        static public void save_info(string s)
        {
            result[0] = s;
        }

        internal static void save_question(string totalResult)
        {
            result[1] = totalResult;
        }

        static public void saveToFile()
        {
            File.AppendAllText(@"G:\res.txt", result[0] + result[1] + Environment.NewLine);
        }
    }
}
