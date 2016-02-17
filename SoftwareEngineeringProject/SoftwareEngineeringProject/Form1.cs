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
                    //Add items in the listview
                    string[] arr = new string[4];
                    ListViewItem itm;


                    for (int i = 0; i < 100; i++)
                    {
                        //adding items so that they can be populated
                        arr[0] = "";
                        arr[1] = "";
                        arr[2] = "";
                        arr[3] = "";
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }
                }
                else if (radioButton2.Checked)
                {

                    //Add items in the listview
                    string[] arr = new string[4];
                    ListViewItem itm;


                    for (int i = 0; i < 100; i++)
                    {
                        //adding items so that they can be populated
                        arr[0] = "";
                        arr[1] = "";
                        arr[2] = "";
                        arr[3] = "";
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            string[] arr = new string[10];
            ListViewItem itm;

            if(comboBox1.SelectedIndex.ToString()!="0")
                if(radioButton1.Checked)
            for (int i = 0; i < 31; i++)
            {
                //adding items so that they can be populated
                //this needs to be updated so that it will add stuff from DB
                arr[0] = comboBox1.SelectedIndex.ToString()+i;
                arr[1] = "12/"+(i+1)+"/2016";
                arr[2] = "12:00 PM";
                arr[3] = "123";
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
                else if(radioButton2.Checked)
                    for (int i = 0; i < 31; i++)
                    {
                        //adding items so that they can be populated
                        //this needs to be updated so that it will add stuff from DB
                        arr[0] = comboBox1.SelectedIndex.ToString() + i;
                        arr[1] = "12/" + (i + 1) + "/2016";
                        arr[2] = "12:00 PM";
                        arr[3] = "123";
                        arr[4] = "125";
                        arr[5] = "123";
                        arr[6] = "125";
                        arr[7] = "123";
                        arr[8] = "125";
                        arr[9] = "123";

                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Add column header
            comboBox1.SelectedIndex = 0;
            listView1.Columns.Clear();
            listView1.Columns.Add("Seats", 100);
            listView1.Columns.Add("Date", 70);
            listView1.Columns.Add("Time", 70);
            listView1.Columns.Add("Room", 70);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            listView1.Columns.Clear();
            //Add column header
            listView1.Columns.Add("Delete", 70);
            listView1.Columns.Add("Name", 70);
            listView1.Columns.Add("Class", 70);
            listView1.Columns.Add("Teacher", 70);
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("Time", 70);
            listView1.Columns.Add("Room", 70);
            listView1.Columns.Add("Edit", 70);
            listView1.Columns.Add("Reporter", 70);
            listView1.Columns.Add("Date Created", 100);
        }
    }
}
