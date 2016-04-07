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
    public partial class Edit : Form
    {
        Form opener;
        public Edit(Form parentForm)
        {
            InitializeComponent();
            opener = parentForm;
        }
        public string sname;
        public string classes;
        public string instructor;
        public string datescheduled;
        public string starttime;
        public string CBTPBT;

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Edit_Load(object sender, EventArgs e)
        {
            textBox1.Text = sname;
            textBox2.Text = classes;
            textBox3.Text = instructor;
            textBox4.Text = starttime;
            if (CBTPBT == "CBT")
                radioButton1.Checked = true;
            else if (CBTPBT == "PBT")
                radioButton2.Checked = true;
            else
                radioButton3.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
