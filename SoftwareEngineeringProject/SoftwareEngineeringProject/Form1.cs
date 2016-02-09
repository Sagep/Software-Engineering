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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.SelectedIndex = 0;

            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            radioButton1.Checked = true;

                if (comboBox1.SelectedIndex == 0)
                {
                    button1.Enabled = false;
                }
                if (comboBox2.SelectedIndex == 0)
                {
                    button1.Enabled = false;
                }
                if (comboBox3.SelectedIndex == 0)
                {
                    button1.Enabled = false;
                }
                else if (radioButton1.Checked)
                {

                    //Add column header
                    listView1.Columns.Add("Seats", 100);
                    listView1.Columns.Add("Date", 70);
                    listView1.Columns.Add("Time", 70);
                    listView1.Columns.Add("Room", 70);

                    //Add items in the listview
                    string[] arr = new string[4];
                    ListViewItem itm;


                    for (int i = 0; i < 100; i++)
                    {
                        //adding items so that they can be populated
                        arr[0] = "100";
                        arr[1] = "12/30/2016";
                        arr[2] = "12:00 PM";
                        arr[3] = "123";
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }
                }
                else if (radioButton2.Checked)
                {

                    //Add column header
                    listView1.Columns.Add("Delete", 100);
                    listView1.Columns.Add("Name", 70);
                    listView1.Columns.Add("Class", 70);
                    listView1.Columns.Add("Teacher", 70);
                    listView1.Columns.Add("Date", 100);
                    listView1.Columns.Add("Time", 70);
                    listView1.Columns.Add("Room", 70);
                    listView1.Columns.Add("Edit", 70);

                    //Add items in the listview
                    string[] arr = new string[4];
                    ListViewItem itm;


                    for (int i = 0; i < 100; i++)
                    {
                        //adding items so that they can be populated
                        arr[0] = "100";
                        arr[1] = "12/30/2016";
                        arr[2] = "12:00 PM";
                        arr[3] = "123";
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }

            }
        }
    }
}
