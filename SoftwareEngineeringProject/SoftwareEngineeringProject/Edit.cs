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
            if (dateTimePicker1.Value < DateTime.Today)
            {
                System.Windows.Forms.MessageBox.Show("Please select Another day");
            }
            else
            {
                sname = textBox1.Text;
                classes = textBox2.Text;
                instructor = textBox3.Text;
                starttime = textBox4.Text;
                datescheduled = dateTimePicker1.Value.ToString("MM/dd/yyyy");


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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

            string m="", d="", y="";
            int stored = 0;

            //this is getting datetime to work. 
            for(int i=0; i<datescheduled.Length; i++)
            {
                if (datescheduled[i] != '/')
                    m += datescheduled[i];
                else
                {
                    stored = i+1;
                    break; 
                }
            }
            for (int i = stored; i < datescheduled.Length; i++)
            {
                if (datescheduled[i] != '/')
                    d += datescheduled[i];
                else
                {
                    stored = i + 1;
                    break;
                }
            }
            for (int i = stored; i < datescheduled.Length; i++)
            {
                    y += datescheduled[i];
            }
            DateTime datescheduleds = new DateTime(int.Parse(y), int.Parse(m), int.Parse(d));
            dateTimePicker1.Value = datescheduleds;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
