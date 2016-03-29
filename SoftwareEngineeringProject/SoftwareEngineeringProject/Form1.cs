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
                button7.Visible = false;
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
                    arr[8] = q.Status.ToString();
                    arr[9] = q.Id.ToString();


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
                    arr[8] = q.Status.ToString();
                    arr[9] = q.Id.ToString();


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
                    arr[8] = q.Status.ToString();
                    arr[9] = q.Id.ToString();


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
                    arr[8] = q.Status.ToString();
                    arr[9] = q.Id.ToString();


                    itm = new ListViewItem(arr);
                    listView1.Items.Add(itm);
                    //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
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
                button1.Visible = false;
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
            listView1.Columns.Add("Name", 150);
            listView1.Columns.Add("Class", 70);
            listView1.Columns.Add("Instructor", 70);
            listView1.Columns.Add("Date", 100);
            listView1.Columns.Add("Time", 125);
            //subject to change
            listView1.Columns.Add("CBT-PBT-M", 70);
            listView1.Columns.Add("Reporter", 70);
            listView1.Columns.Add("Date Created", 100);
            listView1.Columns.Add("Status", 75);
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
                arr[8] = q.Status.ToString();
                arr[9] = q.Id.ToString();


                itm = new ListViewItem(arr);
                listView1.Items.Add(itm);
                //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
            }
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
                        TimeSpan ts = new TimeSpan(int.Parse(hour), int.Parse(minute), 0);
                        temp = temp.Date + ts;
                            System.Windows.Forms.MessageBox.Show(date + " " + temp.Hour + " for " + frm.time + " minutes");
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
        }

        //deleting Scheduled DB information.
        private void button6_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection breakfast =
            this.listView1.SelectedItems;
            string price ="";

            foreach (ListViewItem item in breakfast)
            {
                price += Double.Parse(item.SubItems[9].Text);
            }



            var query = from c in db.Saveds
                        where c.Id.ToString()==price.ToString()
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

        //remove users
        private void button4_Click(object sender, EventArgs e)
        {
            //delete selected
            ListView.SelectedListViewItemCollection breakfast =
            this.listView1.SelectedItems;
            string selecteduser = "";

            foreach (ListViewItem item in breakfast)
            {
                selecteduser += Double.Parse(item.SubItems[0].Text);
            }
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
}
