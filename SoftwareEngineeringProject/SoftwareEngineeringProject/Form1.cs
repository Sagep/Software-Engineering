using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;


namespace SoftwareEngineeringProject
{
    public partial class Form1 : Form
    {
        string[] arr = new string[10];
        bool search = false;
        ListViewItem itm;
        public Form1()
        {
            InitializeComponent();
        }
        DatabaseQuerieDataContext db = new DatabaseQuerieDataContext();

        //start page
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
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
            label2.Visible = false; 
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;

            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            checkBox5.Visible = false;
            checkBox6.Visible = false;
            checkBox7.Visible = false; 
            checkBox8.Visible = false;

            radioButton1.Checked = true;

            //timer function (refresh rate)
            Timer timer = new Timer();
            timer.Interval = (5 * 1000); // 10 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        //DB refresh
        private void timer_Tick(object sender, EventArgs e) 
        {
            int index=-1;
            string id = "";
            if (index != -2 && listView1.SelectedIndices.Count>0)
            {
                index = listView1.SelectedIndices[0];
                id = listView1.SelectedItems[0].Text;
            }


            //refresh users
            if (radioButton3.Checked)
            {
                listView1.Items.Clear();
                if (comboBox1.SelectedIndex == 0)
                {
                    var query = from c in db.Users
                                select c;

                    foreach (var q in query)
                    {
                        arr[0] = q.Id.ToString();
                        arr[1] = q.name.ToString();
                        arr[2] = q.username.ToString();
                        arr[3] = q.dateadded.ToString();
                        arr[4] = q.admin.ToString();
                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }
                }
            }
            else if (radioButton2.Checked && search == false)
            {
                listView1.Items.Clear();
                if (comboBox1.SelectedIndex == 0)
                {
                    var query = from c in db.Saveds
                                select c;
                    foreach (var q in query)
                    {
                        arr[0] = q.StudentName.ToString();
                        arr[1] = q.Class.ToString();
                        arr[2] = q.Instructor.ToString();
                        arr[3] = q.TestDate.ToString();
                        arr[4] = q.TestTime.ToString();
                        arr[5] = q.CBT_PBT.ToString();
                        arr[6] = q.Reporter.ToString();
                        arr[7] = q.DateCreated.ToString();
                        arr[8] = q.Id.ToString();


                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                    }
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    var query = from c in db.Saveds
                                where c.CBT_PBT == "CBT"
                                select c;

                    foreach (var q in query)
                    {
                        arr[0] = q.StudentName.ToString();
                        arr[1] = q.Class.ToString();
                        arr[2] = q.Instructor.ToString();
                        arr[3] = q.TestDate.ToString();
                        arr[4] = q.TestTime.ToString();
                        arr[5] = q.CBT_PBT.ToString();
                        arr[6] = q.Reporter.ToString();
                        arr[7] = q.DateCreated.ToString();
                        arr[8] = q.Id.ToString();


                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                        //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                    }
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    var query = from c in db.Saveds
                                where c.CBT_PBT == "PBT"
                                select c;

                    foreach (var q in query)
                    {
                        arr[0] = q.StudentName.ToString();
                        arr[1] = q.Class.ToString();
                        arr[2] = q.Instructor.ToString();
                        arr[3] = q.TestDate.ToString();
                        arr[4] = q.TestTime.ToString();
                        arr[5] = q.CBT_PBT.ToString();
                        arr[6] = q.Reporter.ToString();
                        arr[7] = q.DateCreated.ToString();
                        arr[8] = q.Id.ToString();


                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                        //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                    }
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    var query = from c in db.Saveds
                                where c.CBT_PBT == "Montrose"
                                select c;

                    foreach (var q in query)
                    {
                        arr[0] = q.StudentName.ToString();
                        arr[1] = q.Class.ToString();
                        arr[2] = q.Instructor.ToString();
                        arr[3] = q.TestDate.ToString();
                        arr[4] = q.TestTime.ToString();
                        arr[5] = q.CBT_PBT.ToString();
                        arr[6] = q.Reporter.ToString();
                        arr[7] = q.DateCreated.ToString();
                        arr[8] = q.Id.ToString();


                        itm = new ListViewItem(arr);
                        listView1.Items.Add(itm);
                        //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                    }
                }
            }
            else if (radioButton2.Checked && search == true)
            {
                listView1.Items.Clear();
                string searchinput=textBox1.Text;
                var query = from c in db.Saveds
                            where c.StudentName==searchinput || c.Reporter==searchinput || c.Instructor==searchinput || c.Class==searchinput
                                select c;

                foreach (var q in query)
                {
                    arr[0] = q.StudentName.ToString();
                    arr[1] = q.Class.ToString();
                    arr[2] = q.Instructor.ToString();
                    arr[3] = q.TestDate.ToString();
                    arr[4] = q.TestTime.ToString();
                    arr[5] = q.CBT_PBT.ToString();
                    arr[6] = q.Reporter.ToString();
                    arr[7] = q.DateCreated.ToString();
                    arr[8] = q.Id.ToString();


                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                }

            }
            if (index != -1 && listView1.Items.Count > index)
                listView1.Items[index].Selected = true;
        }

        //drop down
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//First View
            listView1.Items.Clear();
            search = false;
            string[] arr = new string[10];
            ListViewItem itm;

            if (comboBox1.SelectedIndex.ToString() != "0" && comboBox1.SelectedIndex.ToString() == "1" || comboBox1.SelectedIndex.ToString() == "2")
            {
                int j = 8;
                int k = 660;
                string AP = "";
                if (radioButton1.Checked)
                for (int i=30; i<=k; i+=15)
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
                var query = from c in db.Users
                            select c;

                foreach (var q in query)
                {
                    arr[0] = q.Id.ToString();
                    arr[1] = q.name.ToString();
                    arr[2] = q.username.ToString();
                    arr[3] = q.dateadded.ToString();
                    arr[4] = q.admin.ToString();
                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                }

                button1.Visible = false;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = false;
                button6.Visible = false;
                button8.Visible = true;
                dateTimePicker4.Visible = false;
                dateTimePicker5.Visible = false;

                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;
                label1.Visible = false;
                label2.Visible = false; 
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;

                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                checkBox7.Visible = false; 
                checkBox8.Visible = false;

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
                label5.Visible = true;
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
                checkBox8.Visible = true;
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
            if(comboBox1.SelectedIndex.ToString()=="1" && radioButton2.Checked)
            {
                var query = from c in db.Saveds
                            where c.CBT_PBT=="CBT"
                            select c;

                foreach (var q in query)
                {
                    arr[0] = q.StudentName.ToString();
                    arr[1] = q.Class.ToString();
                    arr[2] = q.Instructor.ToString();
                    arr[3] = q.TestDate.ToString();
                    arr[4] = q.TestTime.ToString();
                    arr[5] = q.CBT_PBT.ToString();
                    arr[6] = q.Reporter.ToString();
                    arr[7] = q.DateCreated.ToString();
                    arr[8] = q.Id.ToString();


                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                    //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                }
            }
            if (comboBox1.SelectedIndex.ToString() == "0" && radioButton2.Checked)
            {
                var query = from c in db.Saveds
                            select c;

                foreach (var q in query)
                {
                    arr[0] = q.StudentName.ToString();
                    arr[1] = q.Class.ToString();
                    arr[2] = q.Instructor.ToString();
                    arr[3] = q.TestDate.ToString();
                    arr[4] = q.TestTime.ToString();
                    arr[5] = q.CBT_PBT.ToString();
                    arr[6] = q.Reporter.ToString();
                    arr[7] = q.DateCreated.ToString();
                    arr[8] = q.Id.ToString();


                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                    //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                }
            }
            if (comboBox1.SelectedIndex.ToString() == "2" && radioButton2.Checked)
            {
                var query = from c in db.Saveds
                            where c.CBT_PBT == "PBT"
                            select c;

                foreach (var q in query)
                {
                    arr[0] = q.StudentName.ToString();
                    arr[1] = q.Class.ToString();
                    arr[2] = q.Instructor.ToString();
                    arr[3] = q.TestDate.ToString();
                    arr[4] = q.TestTime.ToString();
                    arr[5] = q.CBT_PBT.ToString();
                    arr[6] = q.Reporter.ToString();
                    arr[7] = q.DateCreated.ToString();
                    arr[8] = q.Id.ToString();


                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                    //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                }
            }
            if (comboBox1.SelectedIndex.ToString() == "3" && radioButton2.Checked)
            {
                var query = from c in db.Saveds
                            where c.CBT_PBT == "Montrose"
                            select c;

                foreach (var q in query)
                {
                    arr[0] = q.StudentName.ToString();
                    arr[1] = q.Class.ToString();
                    arr[2] = q.Instructor.ToString();
                    arr[3] = q.TestDate.ToString();
                    arr[4] = q.TestTime.ToString();
                    arr[5] = q.CBT_PBT.ToString();
                    arr[6] = q.Reporter.ToString();
                    arr[7] = q.DateCreated.ToString();
                    arr[8] = q.Id.ToString();


                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                    //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                }
            }

        }
      
        //Add page
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            search = false;
            listView1.Visible = true;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Select");
            comboBox1.Items.Add("Finals-CBT");
            comboBox1.Items.Add("Finals-PBT");
            comboBox1.Items.Add("Montrose");
            //Add column header
            this.Text = "MavPlanner - Add page";
            if (!comboBox1.Visible || !button1.Visible||button5.Visible||button6.Visible)
            {
                dateTimePicker1.Visible = true;
                comboBox1.Visible = true;
                button1.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
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
            this.Text = "MavPlanner - Edit-View Page";
            if (!comboBox1.Visible||!button1.Visible||!button5.Visible||!button6.Visible)
            {
                dateTimePicker1.Visible = true;
                listView1.Visible = true;
                comboBox1.Visible = true;
                button1.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = true;
                button6.Visible = true;
                button8.Visible = false;
                dateTimePicker4.Visible = false;
                dateTimePicker5.Visible = false;
            }
            comboBox1.SelectedIndex = 0;
            listView1.Columns.Clear();
            listView1.Items.Clear();
            //Add column header
            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("Class", 70);
            listView1.Columns.Add("Instructor", 70);
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("Time", 125);
            //subject to change
            listView1.Columns.Add("CBT-PBT-M", 70);
            listView1.Columns.Add("Reporter", 70);
            listView1.Columns.Add("Date Created", 100);
            listView1.Columns.Add("ID", 75);

            var query = from c in db.Saveds
                        select c;

            foreach (var q in query)
            {
                arr[0] = q.StudentName.ToString();
                arr[1] = q.Class.ToString();
                arr[2] = q.Instructor.ToString();
                arr[3] = q.TestDate.ToString();
                arr[4] = q.TestTime.ToString();
                arr[5] = q.CBT_PBT.ToString();
                arr[6] = q.Reporter.ToString();
                arr[7] = q.DateCreated.ToString();
                arr[8] = q.Id.ToString();


                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
                //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
            }
        }
       
        //admin page
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            search = false;
            comboBox1.Items.Clear();

            comboBox1.Items.Add("Users");
            comboBox1.Items.Add("Finals");
            comboBox1.Items.Add("Montrose");
            this.Text = "MavPlanner - Admin Page";
            if (!button3.Visible || !button4.Visible || button5.Visible || button6.Visible)
            {
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = false;
                button6.Visible = false;
                dateTimePicker4.Visible = false;
                dateTimePicker5.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;
                label1.Visible = false;
                label2.Visible = false; 
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;

                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                checkBox7.Visible = false; 
                checkBox8.Visible = false;
            }
            listView1.Columns.Clear();
            button1.Visible = false;
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("Users");
            button8.Visible = true;
            if (comboBox1.SelectedIndex.ToString() == "0")
            {
                listView1.Columns.Add("ID", 50);
                listView1.Columns.Add("Name:", 150);
                listView1.Columns.Add("Username:", 70);
                listView1.Columns.Add("Date Added", 100);
                listView1.Columns.Add("Admin", 50);
                listView1.Items.Clear();
            }
            var query = from c in db.Users
                        select c;

            foreach (var q in query)
            {
                arr[0] = q.Id.ToString();
                arr[1] = q.name.ToString();
                arr[2] = q.username.ToString();
                arr[3] = q.dateadded.ToString();
                arr[4] = q.admin.ToString();
                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
        }
        
        //Date Change
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string[] arr = new string[10];
            ListViewItem itm;
            if (comboBox1.SelectedIndex.ToString() != "0" && comboBox1.SelectedIndex!=3 && comboBox1.SelectedIndex.ToString() == "1" || comboBox1.SelectedIndex.ToString() == "2")
            {
                if (!radioButton3.Checked)
                    listView1.Items.Clear();
                int j = 8;
                int k = 660;
                string AP = "";
                if (radioButton1.Checked)
                    for (int i = 30; i <= k; i += 15)
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
            if(comboBox1.SelectedIndex==3)
            {
                if (!radioButton3.Checked)
                    listView1.Items.Clear();
                int j = 0;
                if (radioButton1.Checked)
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

        //Add To DB
        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Today && radioButton1.Checked)
            {
                System.Windows.Forms.MessageBox.Show("Please select Another day");
            }
            else if(!radioButton3.Checked)
            {
                if (listView1.SelectedItems.Count>0)
                {
                    Form2 frm = new Form2(this);

                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        ListView.SelectedListViewItemCollection selectedtimestart =this.listView1.SelectedItems;
                        string date = "";
                        string timestart = "";

                        DateTime temp=new DateTime();

                        foreach (ListViewItem item in selectedtimestart)
                        {
                            //temp.TimeOfDay = item.SubItems[1].Text;
                            date += item.SubItems[1].Text;
                            timestart += item.SubItems[2].Text;
                        }
                        int inc = 0;
                        string hour="";
                        string minute="";
                        string ampm = "";

                        for (inc = 0; inc < timestart.Length; inc++ )
                        {
                            if (timestart[inc] != ':')
                                hour += timestart[inc];
                            else
                                break;
                        }
                        for (inc += 1; inc < timestart.Length; inc++ )
                        {
                            if (timestart[inc] != ' ')
                                minute += timestart[inc];
                            else
                                break;
                        }
                        for (inc +=1; inc < timestart.Length; inc++)
                        {
                            ampm+=timestart[inc];
                        }

                        TimeSpan ts = new TimeSpan(int.Parse(hour), int.Parse(minute), 0);
                        temp = temp.Date + ts;
                        DateTime until = new DateTime();
                        if (ampm == "PM" && hour!="12")
                            temp=temp.AddHours(12);
                        until = temp;
                        until = until.AddMinutes(int.Parse(frm.time));

                        DateTime thisDay = DateTime.Now;
                        string cbtpbttest="";

                        if (comboBox1.SelectedIndex == 1)
                            cbtpbttest = "CBT";
                        else if (comboBox1.SelectedIndex == 2)
                            cbtpbttest = "PBT";
                        else if (comboBox1.SelectedIndex == 3)
                            cbtpbttest = "Montrose";

                        int tempid = int.Parse(thisDay.ToString("MMddyyy"));
                        tempid+=int.Parse(thisDay.ToString("hhmmss"));

                        Saved rowadd = new Saved()
                        {
                            StudentName=frm.first+" "+frm.last,
                            Class=frm.classs,
                            Instructor=frm.instructor,
                            TestDate=date,
                            Reporter="Test",
                            DateCreated=thisDay.ToString("MM/dd/yyyy"),
                            CBT_PBT=cbtpbttest,
                            TestTime=temp.ToString("hh:mm tt")+"-"+until.ToString("hh:mm tt"),
                            Id=tempid
                        };
                        db.Saveds.InsertOnSubmit(rowadd);
                        try
                        {
                            db.SubmitChanges();
                            System.Windows.Forms.MessageBox.Show("Successfully Added Scheduled Test");
                        }
                        catch
                        {
                            System.Windows.Forms.MessageBox.Show("Sorry, there seems to be an issue. Please contact your local administrator. Error:DB add");
                        }

                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Please select a time frame.");
                }
            }
        }

        //edit DB information
        private void button5_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection breakfast = this.listView1.SelectedItems;
            string price = "";
            string deleted = "";

            Edit frm = new Edit(this);

            foreach (ListViewItem item in breakfast)
            {
                price += Double.Parse(item.SubItems[8].Text);
                frm.sname = item.SubItems[0].Text;
                frm.classes = item.SubItems[1].Text;
                frm.instructor = item.SubItems[2].Text;
                frm.datescheduled = item.SubItems[3].Text;
                frm.starttime = item.SubItems[4].Text;
                frm.CBTPBT = item.SubItems[5].Text;
            }

            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {

                var query = from c in db.Saveds
                            where c.Id.ToString() == price.ToString()
                            select c;

                foreach (var q in query)
                {
                    db.Saveds.DeleteOnSubmit(q);
                    db.SubmitChanges();
                }

                listView1.Items.Clear();
                if (comboBox1.SelectedIndex.ToString() == "0")
                    comboBox1.SelectedIndex = 1;
                comboBox1.SelectedIndex = 0;
            }
        }

        //deleting Scheduled DB information.
        private void button6_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection breakfast = this.listView1.SelectedItems;
            string price ="";
            string deleted = "";

            foreach (ListViewItem item in breakfast)
            {
                price += Double.Parse(item.SubItems[8].Text);
                deleted +="ID: "+ item.SubItems[8].Text+"\n\n"+item.SubItems[0].Text + " " + item.SubItems[1].Text + " " + item.SubItems[2].Text + "\n" + item.SubItems[3].Text + " " + item.SubItems[4].Text + " " + item.SubItems[5].Text;
            }

            var query = from c in db.Saveds
                        where c.Id.ToString()==price.ToString()
                        select c;

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this?\n"+deleted, "Confirm", MessageBoxButtons.YesNo,
MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                foreach (var q in query)
                {
                    db.Saveds.DeleteOnSubmit(q);
                    db.SubmitChanges();
                }

                listView1.Items.Clear();

                if (comboBox1.SelectedIndex.ToString() == "0")
                    comboBox1.SelectedIndex = 1;
                comboBox1.SelectedIndex = 0;
            }
        }

        //remove users
        private void button4_Click(object sender, EventArgs e)
        {
            //delete selected
            ListView.SelectedListViewItemCollection breakfast =
            this.listView1.SelectedItems;
            string selecteduser = "";
            string deleted = "";

            foreach (ListViewItem item in breakfast)
            {
                selecteduser += Double.Parse(item.SubItems[0].Text);
                deleted += "ID: " + item.SubItems[0].Text + "\n\nEmployee name: " + item.SubItems[1].Text + "\nUsername: " + item.SubItems[2].Text+" Admin: "+item.SubItems[4].Text;
            }
                        DialogResult dr = MessageBox.Show("Are you sure you want to delete this?\n"+deleted, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            var query = from c in db.Users
                                        where c.Id.ToString() == selecteduser.ToString()
                                        select c;
                            foreach (var q in query)
                            {
                                db.Users.DeleteOnSubmit(q);
                                db.SubmitChanges();
                            }
                            listView1.Items.Clear();


                            //refresh page
                            query = from c in db.Users
                                    select c;
                            foreach (var q in query)
                            {
                                arr[0] = q.Id.ToString();
                                arr[1] = q.name.ToString();
                                arr[2] = q.username.ToString();
                                arr[3] = q.dateadded.ToString();
                                arr[4] = q.admin.ToString();
                                itm = new ListViewItem(arr);
                                listView1.Items.Add(itm);
                            }
                        }
        }

        //search function
        private void button2_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            search = true;
            listView1.Items.Clear();
            string searchinput=textBox1.Text;
            var query = from c in db.Saveds
                        where c.StudentName==searchinput || c.Reporter==searchinput || c.Instructor==searchinput || c.Class==searchinput
                            select c;

            foreach (var q in query)
            {
                arr[0] = q.StudentName.ToString();
                arr[1] = q.Class.ToString();
                arr[2] = q.Instructor.ToString();
                arr[3] = q.TestDate.ToString();
                arr[4] = q.TestTime.ToString();
                arr[5] = q.CBT_PBT.ToString();
                arr[6] = q.Reporter.ToString();
                arr[7] = q.DateCreated.ToString();
                arr[8] = q.Id.ToString();


                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
            }
        }

        //add User
        private void button3_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3(this);

            var result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                string adminft = "F";
                if (frm.admin)
                    adminft = "T";
                DateTime thisDay = DateTime.Now;
                int tempid = int.Parse(thisDay.ToString("MMddyyy"));
                tempid += int.Parse(thisDay.ToString("hhmmss"));

                User addemp = new User()
                {
                    username=frm.username,
                    name=frm.employee,
                    dateadded = thisDay.ToString("MM/dd/yyyy"),
                    Id=tempid,
                    admin=adminft
                };

                db.Users.InsertOnSubmit(addemp);
                try
                {
                    db.SubmitChanges();
                    System.Windows.Forms.MessageBox.Show("User Added:\nUsername: " + frm.username + "\nEmployee name: " + frm.employee + "\nAdmin: " + adminft);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Sorry, there seems to be an issue. Please contact your local administrator. Error:DB add");
                }
                 
            }
        }
    }
}
