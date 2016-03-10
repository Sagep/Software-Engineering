using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareEngineeringProject
{
    public partial class Form2 : Form
    {
        Form opener;

        public Form2(Form parentForm)
        {
            InitializeComponent();
            opener = parentForm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.ShowUpDown = true;
            dateTimePicker4.CustomFormat = "hh:mm tt";
            dateTimePicker5.Format = DateTimePickerFormat.Custom;
            dateTimePicker5.ShowUpDown = true;
            dateTimePicker5.CustomFormat = "hh:mm tt";

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Information frm = new Information(this);
            frm.Show();
            this.Close();
        }
    }
}
