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
    public partial class Information : Form
    {
        Form opener;
        public Information(Form parentForm)
        {
            InitializeComponent();
            opener = parentForm;
        }
        public string first;
        public string last;
        public string classs;
        public string instructor;

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            first = textBox1.Text;
            last = textBox2.Text;
            classs = textBox3.Text;
            instructor = textBox4.Text;
            if (first != "" || last != "" || classs != "" || instructor != "")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("ERROR: Please type in the required information");
            }
        }

        private void Information_Load(object sender, EventArgs e)
        {
            first = "";
            last = "";
            classs = "";
            instructor = "";
        }
    }
}
