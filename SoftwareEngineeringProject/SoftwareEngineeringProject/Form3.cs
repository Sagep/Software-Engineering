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
    public partial class Form3 : Form
    {
        Form opener;

        public Form3(Form parentForm)
        {
            InitializeComponent();
            opener = parentForm;
        }
        public string employee;
        public string username;
        public bool admin;
        private void button1_Click(object sender, EventArgs e)
        {
            employee = textBox1.Text;
            username = textBox2.Text;
            if (checkBox1.Checked)
                admin = true;
            if (employee != "" || username != "")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("ERROR: Please type in the required information");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            employee = "";
            username = "";
            admin = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
