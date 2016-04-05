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
        public string time;
        public string first;
        public string last;
        public string classs;
        public string instructor;
        public bool canceled;

        private void Form2_Load(object sender, EventArgs e)
        {
            time = "";
            first = "";
            last = "";
            classs = "";
            instructor = "";
            canceled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            time = textBox1.Text;
            try
            {
                if (int.Parse(time) <= 29)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Please type in an amount greater than or equal to 30 minutes");
                }
                else
                {
                    this.Close();
                    this.DialogResult = DialogResult.OK;
                    Information information = new Information(this);
                    var student=information.ShowDialog();
                    if (student == DialogResult.OK)
                    {
                        first=information.first;
                        last = information.last;
                        classs = information.classs;
                        instructor = information.instructor;
                    }
                    else
                    {
                        canceled = true;
                    }
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Error: Please type in a number");
            }
        }
    }
}
