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

        //start page
        private void Form1_Load(object sender, EventArgs e)
        {


            comboBox1.SelectedIndex = 0;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;
            button8.Visible = false;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;


            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.ShowUpDown = true;
            dateTimePicker4.CustomFormat = "hh:mm tt";
            dateTimePicker5.Format = DateTimePickerFormat.Custom;
            dateTimePicker5.ShowUpDown = true;
            dateTimePicker5.CustomFormat = "hh:mm tt";

            dateTimePicker4.Visible = false;
            dateTimePicker5.Visible = false;
            dateTimePicker2.Visible = false;
            dateTimePicker3.Visible = false;
            label1.Visible = false;
            label2.Visible =false; 
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible=false;

            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox5.Visible = false;
            checkBox6.Visible = false;
            checkBox7.Visible = false;

            radioButton1.Checked = true;
        }
        //drop down
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
                for (int i = 30; i <=k; i+=15)
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
            if (comboBox1.SelectedIndex.ToString() == "0" && radioButton3.Checked)
            {
                listView1.Visible = true;
                listView1.Items.Clear();
                for (int i = 0; i < 10; i++)
                {
                    //adding items so that they can be populated
                    //this needs to be updated so that it will add stuff from DB
                    arr[0] = "Porter, Sage";
                    arr[1] = "sporter";
                    arr[2] = DateTime.Now.ToString();
                    arr[3] = "Y";

                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                }

                button1.Visible = false;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = true;
                button8.Visible = false;
                dateTimePicker4.Visible = false;
                dateTimePicker5.Visible = false;

                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;
                label1.Visible = false;
                label2.Visible =false; 
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible=false;

                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                checkBox7.Visible = false;

            }
            else if (comboBox1.SelectedIndex.ToString() == "0")
            {
                button1.Enabled = false;
            }
            else if ((comboBox1.SelectedIndex.ToString() == "1" || comboBox1.SelectedIndex.ToString() == "2") && radioButton3.Checked)
            {
                listView1.Visible = false;
                button1.Enabled = true;
                button1.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                dateTimePicker4.Visible = true;
                dateTimePicker5.Visible = true;

                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;
                label1.Visible = true;
                label2.Visible = true; 
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible=true;
                if (comboBox1.SelectedIndex.ToString() == "1")
                    label5.Text = "CBT/PBT";
                else
                    label5.Text = "Montrose";

                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
                checkBox6.Visible = true;
                checkBox7.Visible = true;
            }
            else
            {
                button1.Enabled = true;
                listView1.Visible = true;
                dateTimePicker1.Visible = true;
            }
            if (comboBox1.SelectedIndex.ToString() == "3" && comboBox1.SelectedIndex.ToString() != "0")
            {
                int j = 0;
                if (radioButton1.Checked)
                    //adding items so that they can be populated
                    //this needs to be updated so that it will add stuff from DB
                    for (j = 0; j < 30; j++)
                    {
                        arr[0] = "" + 18;
                        arr[1] = "" + dateTimePicker1.Value.AddDays(j).ToString("MM/dd/yyyy");
                        arr[2] = "12:00 PM - 2:00 PM";
                        arr[3] = "Montrose";
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }
            }

        }
        //Add page
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listView1.Visible = true;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Select");
            comboBox1.Items.Add("Finals-CBT");
            comboBox1.Items.Add("Finals-PBT");
            comboBox1.Items.Add("Montrose");
            //Add column header
            if (!comboBox1.Visible || !button1.Visible||button5.Visible||button6.Visible)
            {
                dateTimePicker1.Visible = true;
                comboBox1.Visible = true;
                button1.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = false;
                dateTimePicker4.Visible = false;
                dateTimePicker5.Visible = false;
            }
            comboBox1.SelectedIndex = 0;
            listView1.Columns.Clear();
            listView1.Items.Clear();
            listView1.Columns.Add("Seats", 100);
            listView1.Columns.Add("Date", 70);
            listView1.Columns.Add("Time", 70);
        }
        //Edit-View Page
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Select");
            comboBox1.Items.Add("Finals-CBT");
            comboBox1.Items.Add("Finals-PBT");
            comboBox1.Items.Add("Montrose");
            if (!comboBox1.Visible||!button1.Visible||!button5.Visible||!button6.Visible)
            {
                dateTimePicker1.Visible = true;
                listView1.Visible = true;
                comboBox1.Visible = true;
                button1.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = true;
                button6.Visible = true;
                button7.Visible = true;
                button8.Visible = false;
                dateTimePicker4.Visible = false;
                dateTimePicker5.Visible = false;
            }
            comboBox1.SelectedIndex = 0;
            listView1.Columns.Clear();
            listView1.Items.Clear();
            //Add column header
            listView1.Columns.Add("Name", 70);
            listView1.Columns.Add("Class", 70);
            listView1.Columns.Add("Instructor", 70);
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("Time", 70);
            //subject to change
            listView1.Columns.Add("CBT-PBT-Montrose", 125);
            listView1.Columns.Add("Reporter", 70);
            listView1.Columns.Add("Date Created", 100);
            listView1.Columns.Add("Status", 100);
        }
        //admin page
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            comboBox1.Items.Add("Users");
            comboBox1.Items.Add("Finals");
            comboBox1.Items.Add("Montrose");
            if (!button3.Visible || !button4.Visible || button5.Visible || button6.Visible)
            {
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
                button8.Visible = true;
                dateTimePicker4.Visible = false;
                dateTimePicker5.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;
                label1.Visible = false;
                label2.Visible =false; 
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible=false;

                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                checkBox7.Visible = false;
            }
            listView1.Columns.Clear();
            button1.Visible = false;
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("Users");

            if (comboBox1.SelectedIndex.ToString() == "0")
            { 
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
                    arr[2] = DateTime.Now.ToString();
                    arr[3] = "Y";

                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                }
            }
        }
        //Date Change
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if(!radioButton3.Checked)
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Today && (radioButton1.Checked || radioButton3.Checked))
            {
                System.Windows.Forms.MessageBox.Show("Please select another date.");
            }
            else
            {
                Form2 frm = new Form2(this);
                frm.Show();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }
    }
}
