using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //uncomment this information before release. 

            string dblocations = "";
            dblocations = System.IO.File.ReadAllText(@"DBlocation.txt");
            dblocations = dblocations.Replace(@"\\", @"\");
            AppDomain.CurrentDomain.SetData("DataDirectory", "" + dblocations); 


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
