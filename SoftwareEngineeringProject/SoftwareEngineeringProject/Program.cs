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
            string dblocations = "";

            dblocations = System.IO.File.ReadAllText(@"DBlocation.txt");
            dblocations = dblocations.Replace(@"\\", @"\");
            //System.Windows.Forms.MessageBox.Show(dblocations);
            //dblocations = "C:\\Users\\Sage\\Documents\\GitHub\\Software-Engineering\\SoftwareEngineeringProject\\SoftwareEngineeringProject\\obj\\Debug";
            //System.Windows.Forms.MessageBox.Show(dblocations);

            AppDomain.CurrentDomain.SetData("DataDirectory", ""+dblocations); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
