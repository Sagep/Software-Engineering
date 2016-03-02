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
        string[] arr = new string[10];
        ListViewItem itm;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            comboBox1.SelectedIndex = 0;

            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

            radioButton1.Checked = true;

                if (comboBox1.SelectedIndex == 0)
                {
                    button1.Enabled = false;
                }
                else if (radioButton1.Checked)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        //adding items so that they can be populated
                        arr[0] = "";
                        arr[1] = "";
                        arr[2] = "";
                        arr[3] = "";
                        arr[4] = "";
                        arr[5] = "";
                        arr[6] = "";
                        arr[7] = "";
                        arr[8] = "";
                        arr[9] = "";
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }
                }
                else if (radioButton2.Checked)
                {
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
        {//First View
            listView1.Items.Clear();

            string[] arr = new string[10];
            ListViewItem itm;

            if (comboBox1.SelectedIndex.ToString() != "0" && comboBox1.SelectedIndex.ToString() == "1" || comboBox1.SelectedIndex.ToString() == "2")
            {
                int j = 8;
                int k = 660;
                string AP = "";
                if (radioButton1.Checked)
                for (int i = 0; i <=k; i+=30)
                {
                    //adding items so that they can be populated
                    //this needs to be updated so that it will add stuff from DB
                    arr[0] = ""+25;
                    arr[1] = "" + dateTimePicker1.Value.ToString("MM/dd/yyyy");
                    if (i == 60)
                    {
                        j += 1;
                        i -= 60;
                        k -= 60;
                    }
                    if (j > 12)
                    {
                        j -= 12;
                    }
                    if(j<8||j==12)
                        AP = " PM";
                    else
                        AP = " AM";
                    if (i == 0)
                    {
                        arr[2] = j + ":00"+AP;
                    }
                    else
                        arr[2] = j+":"+i+AP;
                    
                    arr[3] = "123";
                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                }
            }
            if (comboBox1.SelectedIndex.ToString() != "0" && comboBox1.SelectedIndex.ToString() == "2")
            {
                if (radioButton1.Checked)
                { }
            }
            if (comboBox1.SelectedIndex.ToString() == "3" && comboBox1.SelectedIndex.ToString() != "0")
            {
                int j = 0;
                if (radioButton1.Checked) 
                        //adding items so that they can be populated
                        //this needs to be updated so that it will add stuff from DB
                        dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
                        arr[0] = "" + 18;
                        arr[1] = "" + dateTimePicker1.Value.ToString("MM/dd/yyyy");
                        arr[2] = "12:00 PM - 2:00 PM";
                        arr[3] = "Montrose";
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Add column header
            if (!comboBox1.Visible || !button1.Visible||button5.Visible||button6.Visible)
            {
                comboBox1.Visible = true;
                button1.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
            }
            comboBox1.SelectedIndex = 0;
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Seats", 100);
            listView1.Columns.Add("Date", 70);
            listView1.Columns.Add("Time", 70);
            listView1.Columns.Add("Room", 70);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (!comboBox1.Visible||!button1.Visible||!button5.Visible||!button6.Visible)
            {
                comboBox1.Visible = true;
                button1.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = true;
                button6.Visible = true;
            }
            comboBox1.SelectedIndex = 0;
            listView1.Columns.Clear();
            listView1.Items.Clear();
            //Add column header
            listView1.Columns.Add("Name", 70);
            listView1.Columns.Add("Class", 70);
            listView1.Columns.Add("Teacher", 70);
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("Time", 70);
            listView1.Columns.Add("Room", 70);
            listView1.Columns.Add("Reporter", 70);
            listView1.Columns.Add("Date Created", 100);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Visible = false;
            if (!button3.Visible || !button4.Visible || button5.Visible || button6.Visible)
            {
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = false;
                button6.Visible = false;
            }
            listView1.Columns.Clear();
            button1.Visible = false;

            listView1.Columns.Add("Name:", 70);
            listView1.Columns.Add("Username:", 70);
            listView1.Columns.Add("Date Added", 70);
            listView1.Columns.Add("Admin", 70);
            listView1.Items.Clear();
                    for (int i = 0; i < 10; i++)
                    {
                        //adding items so that they can be populated
                        //this needs to be updated so that it will add stuff from DB
                        arr[0] = "Porter, Sage";
                        arr[1] = "sporter";
                        arr[2] = "02/22/201" + i;
                        arr[3] = "Y";

                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {//Date Change
            listView1.Items.Clear();

            string[] arr = new string[10];
            ListViewItem itm;

            if (comboBox1.SelectedIndex.ToString() != "0" && comboBox1.SelectedIndex.ToString() == "1" || comboBox1.SelectedIndex.ToString() == "2")
            {
                int j = 8;
                int k = 660;
                string AP = "";
                if (radioButton1.Checked)
                    for (int i = 0; i <= k; i += 30)
                    {
                        //adding items so that they can be populated
                        //this needs to be updated so that it will add stuff from DB
                        arr[0] = "" + 25;
                        arr[1] = "" + dateTimePicker1.Value.ToString("MM/dd/yyyy");
                        if (i == 60)
                        {
                            j += 1;
                            i -= 60;
                            k -= 60;
                        }
                        if (j > 12)
                        {
                            j -= 12;
                        }
                        if (j < 8 || j == 12)
                            AP = " PM";
                        else
                            AP = " AM";
                        if (i == 0)
                        {
                            arr[2] = j + ":00" + AP;
                        }
                        else
                            arr[2] = j + ":" + i + AP;

                        arr[3] = "123";
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }
            }
            if (comboBox1.SelectedIndex.ToString() == "3" && comboBox1.SelectedIndex.ToString() != "0")
            {//Montrose
                if (radioButton1.Checked)
                        //adding items so that they can be populated
                        //this needs to be updated so that it will add stuff from DB
                        dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
                        arr[0] = "" + 18;
                        arr[1] = "" + dateTimePicker1.Value.ToString("MM/dd/yyyy");
                        arr[2] = "12:00 PM - 2:00 PM";
                        arr[3] = "Montrose";
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
            }

        }
    }
}
