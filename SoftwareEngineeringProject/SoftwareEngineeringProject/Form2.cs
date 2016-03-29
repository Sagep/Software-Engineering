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

        private void Form2_Load(object sender, EventArgs e)
        {
            time = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            time = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            Information frm = new Information(this);
            frm.ShowDialog();

            this.Close();
        }
    }
}
