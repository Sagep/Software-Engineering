using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//testing VS
namespace SoftwareEngineeringProject
{
    public partial class Form1 : Form
    {
        string[] arr = new string[10];
        bool search = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'scheduled3DataSet.User' table. You can move, or remove it, as needed.
            this.userTableAdapter.Fill(this.scheduled3DataSet.User);
            // TODO: This line of code loads data into the 'scheduled3DataSet.Saved' table. You can move, or remove it, as needed.
            this.savedTableAdapter.Fill(this.scheduled3DataSet.Saved);
            // TODO: This line of code loads data into the 'scheduled3DataSet.FinalsMontrose' table. You can move, or remove it, as needed.
            this.finalsMontroseTableAdapter.Fill(this.scheduled3DataSet.FinalsMontrose);
            // TODO: This line of code loads data into the 'scheduled3DataSet.FinalsMain' table. You can move, or remove it, as needed.
            this.finalsMainTableAdapter.Fill(this.scheduled3DataSet.FinalsMain);


            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string defaultUN = "SAGESPC\\Sage";
            defaultUN = defaultUN.Replace(@"\\", @"\");


            var query = from c in userTableAdapter.GetData()
                        select c;

            string available = "";
            available = available.Replace(@"\\", @"\");

            int i = 0;
            foreach (var d in query)
            {
                string temp = "";
                temp = "AD\\" + d.username;
                temp = temp.Replace(@"\\", @"\");

                if (userName == temp || userName == defaultUN)
                {
                    if (d.admin == "Y" || userName == defaultUN)
                        radioButton3.Visible = true;
                    else
                        radioButton3.Visible = false;
                }
                else
                {
                    if (query.Count() - 1 == i)
                    {
                        System.Windows.Forms.MessageBox.Show("Unauthorized user. Please contact your local administrator");
                        this.Close();
                    }
                }
                i++;
            }


            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dateTimePicker1.Value = DateTime.Today;
            comboBox1.SelectedIndex = 0;
            button3.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
            button8.Visible = false;


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
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;

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
            timer.Interval = (15 * 1000); // 15 secs
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        //DB refresh
        private void timer_Tick(object sender, EventArgs e)
        {
            int scrollbarstay = dataGridView1.FirstDisplayedScrollingRowIndex;
            int selectedindex = 0;
            if (dataGridView1.SelectedRows.Count > 0)
                selectedindex = dataGridView1.SelectedRows[0].Index;
            dataGridView1.Rows.Clear();

            if (radioButton1.Checked && comboBox1.SelectedIndex.ToString() == "1")
            {
                populatefinalsdates("CBT");
            }
            else if (radioButton1.Checked && comboBox1.SelectedIndex.ToString() == "2")
            {
                populatefinalsdates("PBT");
            }
            else if (radioButton1.Checked && comboBox1.SelectedIndex.ToString() == "3")
            {
                populatemontrosesdates();
            }

            if (radioButton3.Checked)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    foreach (var q in userTableAdapter.GetData())
                    {
                        arr[0] = q.Id.ToString();
                        arr[1] = q.name.ToString();
                        arr[2] = q.username.ToString();
                        arr[3] = q.dateadded.ToString();
                        arr[4] = q.admin.ToString();
                        dataGridView1.Rows.Add(arr);
                    }
                }
            }
            else if (radioButton2.Checked && search == false)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    foreach (var q in savedTableAdapter.GetData())
                    {
                        if (q.Status != "Canceled" && dateTimePicker1.Value.ToString("MM/dd/yyyy") == q.TestDate.ToString())
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
                            dataGridView1.Rows.Add(arr);
                        }
                    }
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    var query = from c in savedTableAdapter.GetData()
                                where c.CBT_PBT == "CBT"
                                select c;

                    foreach (var q in query)
                    {
                        if (q.Status != "Canceled" && dateTimePicker1.Value.ToString("MM/dd/yyyy") == q.TestDate.ToString())
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
                            dataGridView1.Rows.Add(arr);
                            //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                        }
                    }
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    var query = from c in savedTableAdapter.GetData()
                                where c.CBT_PBT == "PBT"
                                select c;

                    foreach (var q in query)
                    {
                        if (q.Status != "Canceled" && dateTimePicker1.Value.ToString("MM/dd/yyyy") == q.TestDate.ToString())
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
                            dataGridView1.Rows.Add(arr);
                            //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                        }
                    }
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    var query = from c in savedTableAdapter.GetData()
                                where c.CBT_PBT == "Montrose"
                                select c;

                    foreach (var q in query)
                    {
                        if (q.Status != "Canceled" && dateTimePicker1.Value.ToString("MM/dd/yyyy") == q.TestDate.ToString())
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
                            dataGridView1.Rows.Add(arr);
                            //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                        }
                    }
                }
            }
            else if (radioButton2.Checked && search == true)
            {
                dataGridView1.Rows.Clear();
                string searchinput = textBox1.Text;
                var query = from c in savedTableAdapter.GetData()
                            where c.StudentName == searchinput || c.Reporter == searchinput || c.Instructor == searchinput || c.Class == searchinput
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
                    dataGridView1.Rows.Add(arr);
                }
            }

            if (scrollbarstay != 0 || dataGridView1.Rows.Count > 0)
                dataGridView1.FirstDisplayedScrollingRowIndex = scrollbarstay;
            dataGridView1.Rows[selectedindex].Selected = true;
            dataGridView1.Update();
        }

        //drop down
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//First View
            if (comboBox1.SelectedIndex.ToString() != "0" && comboBox1.SelectedIndex.ToString() == "1" || comboBox1.SelectedIndex.ToString() == "2")
            {
                if (radioButton1.Checked)
                {
                    timer_Tick(sender, e);
                    dataGridView1.Rows[0].Selected = true;
                    dataGridView1.FirstDisplayedScrollingRowIndex = 0;
                }
            }
            if (comboBox1.SelectedIndex.ToString() == "0" && radioButton3.Checked)
            {
                timer_Tick(sender, e);
                button1.Visible = false;
                button3.Visible = true;
                button4.Visible = true;
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
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;

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
            else if ((comboBox1.SelectedIndex.ToString() == "1") && radioButton3.Checked)
            {
                checkBox8.Visible = false;
                checkBox8.Checked = false;
                dataGridView1.Visible = false;
                button1.Enabled = true;
                button1.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = false;
                button8.Visible = false;
                if (comboBox1.SelectedIndex.ToString() == "1")
                    Finalsdatesmain();
                else
                    Finalsdatesmontrose();
                dateTimePicker4.Visible = true;
                dateTimePicker5.Visible = true;
                dateTimePicker3.Visible = true;
                dateTimePicker2.Visible = true;

                dateTimePicker1.Visible = false;
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = true;
                label1.Visible = true;
                label2.Visible = true;
                label1.Enabled = true;
                label2.Enabled = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                datesscheduled();
                checkBox1.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = true;
                checkBox4.Visible = true;
                checkBox5.Visible = true;
                checkBox6.Visible = true;
                checkBox7.Visible = true;

                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                checkBox7.Enabled = true;

                checkBox8.Visible = false;
            }
            else if ((comboBox1.SelectedIndex.ToString() == "2") && radioButton3.Checked)
            {
                checkBox8.Visible = true;
                checkBox8.Checked = true;
                dataGridView1.Visible = false;
                button1.Enabled = true;
                button1.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = false;
                button8.Visible = false;
                if (comboBox1.SelectedIndex.ToString() == "1")
                    Finalsdatesmain();
                else
                    Finalsdatesmontrose();
                dateTimePicker4.Visible = true;
                dateTimePicker5.Visible = true;
                dateTimePicker3.Visible = true;
                dateTimePicker2.Visible = true;

                dateTimePicker1.Visible = false;
                dateTimePicker2.Enabled = false;
                dateTimePicker3.Enabled = false;
                label1.Visible = true;
                label2.Visible = true;
                label1.Enabled = false;
                label2.Enabled = false;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                datesscheduled();
                checkBox1.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
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
                dataGridView1.Visible = true;
                dateTimePicker1.Visible = true;
            }
            if (comboBox1.SelectedIndex.ToString() == "3" && comboBox1.SelectedIndex.ToString() != "0")
            {
                if (radioButton1.Checked)
                {
                    timer_Tick(sender, e);
                    dataGridView1.Rows[0].Selected = true;
                }
            }
            if (comboBox1.SelectedIndex.ToString() == "1" && radioButton2.Checked)
            {
                timer_Tick(sender, e);
                dataGridView1.Rows[0].Selected = true;
            }
            if (comboBox1.SelectedIndex.ToString() == "0" && radioButton2.Checked)
            {
                timer_Tick(sender, e);
                dataGridView1.Rows[0].Selected = true;
            }
            if (comboBox1.SelectedIndex.ToString() == "2" && radioButton2.Checked)
            {
                timer_Tick(sender, e);
                dataGridView1.Rows[0].Selected = true;
            }
            if (comboBox1.SelectedIndex.ToString() == "3" && radioButton2.Checked)
            {
                timer_Tick(sender, e);
                dataGridView1.Rows[0].Selected = true;
            }

        }

        //prints the information in the list
        private void populatefinalsdates(string cbtpbt)
        {
            int scrollbarstay = dataGridView1.FirstDisplayedScrollingRowIndex;
            int selectedindex = 0;
            if (dataGridView1.SelectedRows.Count > 0)
                selectedindex = dataGridView1.SelectedRows[0].Index;
            dataGridView1.Rows.Clear();

            var query = from c in finalsMainTableAdapter.GetData()
                        select c;
            int start = 0;
            int stop = 0;
            foreach (var c in query)
            {
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Sunday")
                {
                    if (c.Sunday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Sunday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Monday")
                {
                    if (c.Monday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Monday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Tuesday")
                {
                    if (c.Tuesday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Tuesday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Wednesday")
                {
                    if (c.Wednesday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Wednesday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Thursday")
                {
                    if (c.Thursday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Thursday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Friday")
                {
                    if (c.Friday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Friday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Saturday")
                {
                    if (c.Saturday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Saturday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
            }
            stop = stop - start;
            DateTime testing123 = new DateTime();


            //-----------------------------------------------------------------------------------------
            //----------This gets The tests and separates individual times(EXE startstop)--------------
            //-----------------------------------------------------------------------------------------
            int scheduledts = 0;
            int scheduledtst = 0;
            int gothroughs = 0;

            var querysaved =
                from c in savedTableAdapter.GetData()
                where c.TestDate.ToString() == dateTimePicker1.Value.ToString("MM/dd/yyy") && c.CBT_PBT == cbtpbt
                select c;

            int[] scheduledstart = new int[querysaved.Count()];
            int[] scheduledstop = new int[querysaved.Count()];
            int[] gothrough = new int[querysaved.Count()];

            int posss = 0;
            foreach (var time in querysaved)
            {
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Sunday")
                {
                    getschedule(time.TestTime, ref scheduledts, ref scheduledtst, ref  gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Monday")
                {
                    getschedule(time.TestTime, ref  scheduledts, ref scheduledtst, ref  gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Tuesday")
                {
                    getschedule(time.TestTime, ref scheduledts, ref scheduledtst, ref  gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Wednesday")
                {
                    getschedule(time.TestTime, ref scheduledts, ref scheduledtst, ref gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Thursday")
                {
                    getschedule(time.TestTime, ref scheduledts, ref  scheduledtst, ref  gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Friday")
                {
                    getschedule(time.TestTime, ref scheduledts, ref scheduledtst, ref gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Saturday")
                {
                    getschedule(time.TestTime, ref scheduledts, ref scheduledtst, ref gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                posss += 1;
            }
            //-----------------------------------------------------------------------------------------
            int seats = 25;
            int starttracker = start;
            if (stop != 0)
                for (int i = 0; i <= stop; i += 15)
                {
                    if (i == 0)
                    {
                        testing123 = testing123.AddMinutes(start);
                        foreach (var c in scheduledstart)
                        {
                            if (c == start)
                                seats -= 1;
                        }
                    }
                    else
                    {
                        start += 15;
                        int screech = 0;
                        int trydis = 0;
                        foreach (var c in scheduledstart)
                        {
                            trydis = c;
                            if (trydis == start)
                            {
                                seats -= 1;
                            }
                            else
                            {
                                while (trydis <= scheduledstop[screech])
                                {
                                    if (trydis == start)
                                        seats -= 1;
                                    if (trydis > start)
                                        break;
                                    trydis += 15;
                                }
                            }
                            screech += 1;
                        }
                        testing123 = testing123.AddMinutes(15);
                    }

                    arr[0] = "" + seats + "/25";
                    arr[1] = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                    arr[2] = testing123.ToString("hh:mm tt");
                    string seatsgraph = "";
                    for (int s = seats * 2; s > 0; s -= 2)
                        seatsgraph += '*';
                    arr[3] = seatsgraph;
                    dataGridView1.Rows.Add(arr);
                    seats = 25;

                }
            if (scrollbarstay != 0 || dataGridView1.Rows.Count > 0)
                dataGridView1.FirstDisplayedScrollingRowIndex = scrollbarstay;
            dataGridView1.Rows[selectedindex].Selected = true;
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void populatemontrosesdates()
        {
            int scrollbarstay = dataGridView1.FirstDisplayedScrollingRowIndex;
            int selectedindex = 0;
            if (dataGridView1.SelectedRows.Count > 0)
                selectedindex = dataGridView1.SelectedRows[0].Index;
            dataGridView1.Rows.Clear();

            var query = from c in allTimeMontroseTableAdapter.GetData()
                        select c;
            int start = 0;
            int stop = 0;
            foreach (var c in query)
            {
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Sunday")
                {
                    if (c.Sunday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Sunday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Monday")
                {
                    if (c.Monday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Monday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Tuesday")
                {
                    if (c.Tuesday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Tuesday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Wednesday")
                {
                    if (c.Wednesday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Wednesday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Thursday")
                {
                    if (c.Thursday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Thursday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Friday")
                {
                    if (c.Friday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Friday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Saturday")
                {
                    if (c.Saturday.ToString() != "OFF")//--------------
                    {
                        int go = 0;
                        int store = 0;
                        string temp = c.Saturday.ToString();//---------
                        string total = "";
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);
                    }
                }
            }
            stop = stop - start;
            DateTime testing123 = new DateTime();


            //-----------------------------------------------------------------------------------------
            //----------This gets The tests and separates individual times(EXE startstop)--------------
            //-----------------------------------------------------------------------------------------
            int scheduledts = 0;
            int scheduledtst = 0;
            int gothroughs = 0;

            var querysaved =
                from c in savedTableAdapter.GetData()
                where c.TestDate.ToString() == dateTimePicker1.Value.ToString("MM/dd/yyy") && c.CBT_PBT == "Montrose"
                select c;

            int[] scheduledstart = new int[querysaved.Count()];
            int[] scheduledstop = new int[querysaved.Count()];
            int[] gothrough = new int[querysaved.Count()];

            int posss = 0;
            foreach (var time in querysaved)
            {
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Sunday")
                {
                    getschedule(time.TestTime, ref scheduledts, ref scheduledtst, ref  gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Monday")
                {
                    getschedule(time.TestTime, ref  scheduledts, ref scheduledtst, ref  gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Tuesday")
                {
                    getschedule(time.TestTime, ref scheduledts, ref scheduledtst, ref  gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Wednesday")
                {
                    getschedule(time.TestTime, ref scheduledts, ref scheduledtst, ref gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Thursday")
                {
                    getschedule(time.TestTime, ref scheduledts, ref  scheduledtst, ref  gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Friday")
                {
                    getschedule(time.TestTime, ref scheduledts, ref scheduledtst, ref gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                if (dateTimePicker1.Value.DayOfWeek.ToString() == "Saturday")
                {
                    getschedule(time.TestTime, ref scheduledts, ref scheduledtst, ref gothroughs);
                    scheduledstart[posss] = scheduledts;
                    scheduledstop[posss] = scheduledtst;
                    gothrough[posss] = gothroughs;
                }
                posss += 1;
            }
            //-----------------------------------------------------------------------------------------
            int seats = 25;
            int starttracker = start; ;
            if (stop != 0)
                for (int i = 0; i <= stop; i += 15)
                {
                    if (i == 0)
                    {
                        testing123 = testing123.AddMinutes(start);
                        foreach (var c in scheduledstart)
                        {
                            if (c == start)
                                seats -= 1;
                        }
                    }
                    else
                    {
                        start += 15;
                        int screech = 0;
                        int trydis = 0;
                        foreach (var c in scheduledstart)
                        {
                            trydis = c;
                            if (trydis == start)
                            {
                                seats -= 1;
                            }
                            else
                            {
                                while (trydis <= scheduledstop[screech])
                                {
                                    if (trydis == start)
                                        seats -= 1;
                                    if (trydis > start)
                                        break;
                                    trydis += 15;
                                }
                            }
                            screech += 1;
                        }
                        testing123 = testing123.AddMinutes(15);
                    }

                    arr[0] = "" + seats + "/25";
                    arr[1] = dateTimePicker1.Value.ToString("MM/dd/yyyy");
                    arr[2] = testing123.ToString("hh:mm tt");
                    string seatsgraph = "";
                    for (int s = seats * 2; s > 0; s -= 2)
                        seatsgraph += '*';
                    arr[3] = seatsgraph;
                    dataGridView1.Rows.Add(arr);
                    seats = 25;

                }
            if (scrollbarstay != 0 || dataGridView1.Rows.Count > 0)
                dataGridView1.FirstDisplayedScrollingRowIndex = scrollbarstay;
            dataGridView1.Rows[selectedindex].Selected = true;
            dataGridView1.Update();
        }

        //admin schedulable dates load(alltime)
        private void datesscheduled()
        {
            if (comboBox1.SelectedIndex.ToString() == "1")
            {
                label5.Text = "CBT/PBT";
                checkBox8.Checked = true;
                var query = from c in finalsMainTableAdapter.GetData()
                            select c;
                string temp = "";
                int start = 0;
                int stop = 0;
                foreach (var q in query)
                {
                    if (q.Sunday == "OFF")
                    {
                        checkBox1.Checked = false;
                        label6.Text = "OFF";
                    }
                    else
                    {
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        checkBox1.Checked = true;
                        temp = q.Sunday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        label6.Text = temp;
                    }

                    if (q.Monday == "OFF")
                    {
                        checkBox6.Checked = false;
                        label7.Text = "OFF";
                    }
                    else
                    {
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        checkBox6.Checked = true;
                        /*Here*/
                        temp = q.Monday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        /*here*/
                        label7.Text = temp;

                    }

                    if (q.Tuesday == "OFF")
                    {
                        checkBox5.Checked = false;
                        label8.Text = "OFF";
                    }
                    else
                    {

                        checkBox5.Checked = true;
                        /*Here*/
                        temp = q.Tuesday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        /*here*/
                        label8.Text = temp;
                    }

                    if (q.Wednesday == "OFF")
                    {
                        checkBox7.Checked = false;
                        label9.Text = "OFF";
                    }
                    else
                    {
                        checkBox7.Checked = true;

                        /*Here*/
                        temp = q.Wednesday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        /*here*/
                        label9.Text = temp;
                    }

                    if (q.Thursday == "OFF")
                    {
                        checkBox4.Checked = false;
                        label10.Text = "OFF";
                    }
                    else
                    {
                        checkBox4.Checked = true;

                        /*Here*/
                        temp = q.Thursday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        /*here*/
                        label10.Text = temp;
                    }

                    if (q.Friday == "OFF")
                    {
                        checkBox3.Checked = false;
                        label11.Text = "OFF";
                    }
                    else
                    {
                        checkBox3.Checked = true;

                        /*Here*/
                        temp = q.Friday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        /*here*/
                        label11.Text = temp;
                    }

                    if (q.Saturday == "OFF")
                    {
                        checkBox2.Checked = false;
                        label12.Text = "OFF";
                    }
                    else
                    {
                        checkBox2.Checked = true;

                        /*Here*/
                        temp = q.Saturday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        /*here*/
                        label12.Text = temp;
                    }
                }
            }
            else
            {
                label5.Text = "Montrose";
                checkBox8.Checked = true;

                var query = from c in finalsMontroseTableAdapter.GetData()
                            select c;
                string temp = "";
                int start = 0;
                int stop = 0;
                foreach (var q in query)
                {
                    if (q.Sunday == "OFF")
                    {
                        checkBox1.Checked = false;
                        label6.Text = "OFF";
                    }
                    else
                    {
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        checkBox1.Checked = true;
                        temp = q.Sunday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        label6.Text = temp;
                    }

                    if (q.Monday == "OFF")
                    {
                        checkBox6.Checked = false;
                        label7.Text = "OFF";
                    }
                    else
                    {
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        checkBox6.Checked = true;
                        /*Here*/
                        temp = q.Monday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        /*here*/
                        label7.Text = temp;

                    }

                    if (q.Tuesday == "OFF")
                    {
                        checkBox5.Checked = false;
                        label8.Text = "OFF";
                    }
                    else
                    {

                        checkBox5.Checked = true;
                        /*Here*/
                        temp = q.Tuesday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        /*here*/
                        label8.Text = temp;
                    }

                    if (q.Wednesday == "OFF")
                    {
                        checkBox7.Checked = false;
                        label9.Text = "OFF";
                    }
                    else
                    {
                        checkBox7.Checked = true;

                        /*Here*/
                        temp = q.Wednesday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        /*here*/
                        label9.Text = temp;
                    }

                    if (q.Thursday == "OFF")
                    {
                        checkBox4.Checked = false;
                        label10.Text = "OFF";
                    }
                    else
                    {
                        checkBox4.Checked = true;

                        /*Here*/
                        temp = q.Thursday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        /*here*/
                        label10.Text = temp;
                    }

                    if (q.Friday == "OFF")
                    {
                        checkBox3.Checked = false;
                        label11.Text = "OFF";
                    }
                    else
                    {
                        checkBox3.Checked = true;

                        /*Here*/
                        temp = q.Friday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        /*here*/
                        label11.Text = temp;
                    }

                    if (q.Saturday == "OFF")
                    {
                        checkBox2.Checked = false;
                        label12.Text = "OFF";
                    }
                    else
                    {
                        checkBox2.Checked = true;

                        /*Here*/
                        temp = q.Saturday.ToString();
                        string total = "";
                        start = 0;
                        stop = 0;
                        int go = 0;
                        int store = 0;
                        DateTime starter = new DateTime();
                        DateTime stopper = new DateTime();
                        for (go = 0; go < temp.Length; go++)
                        {
                            if (temp[go] != '-')
                                total += temp[go];
                            else
                            {
                                store = go;
                                break;
                            }
                        }
                        start = int.Parse(total);

                        total = "";
                        for (go = store + 1; go < temp.Length; go++)
                        {
                            total += temp[go];
                        }
                        stop = int.Parse(total);

                        starter = starter.AddMinutes(start);
                        stopper = stopper.AddMinutes(stop);

                        temp = starter.ToString("hh:mm tt") + " - " + stopper.ToString("hh:mm tt");
                        /*here*/
                        label12.Text = temp;
                    }
                }
            }
        }

        /*get selected dates times and compair them to scheduled
         (Checkschedule gets the date selected (EXE tuesday)
         Getschedule gets the times converted to INT
         */

        private void getschedule(string daysscheduled, ref int starttestss, ref int stoptestss, ref int gothroughs)
        {
            string hh = "";
            string mm = "";
            string tt = "";
            string hh2 = "";
            string mm2 = "";
            string tt2 = "";
            int save = 0;
            int h = 0;
            int m = 0;
            int m2 = 0;
            for (int i = save; i < daysscheduled.Length; i++)
                if (daysscheduled[i] != ':')
                    hh += daysscheduled[i];
                else
                {
                    save = i + 1;
                    break;
                }
            for (int i = save; i < daysscheduled.Length; i++)
                if (daysscheduled[i] != ' ')
                    mm += daysscheduled[i];
                else
                {
                    save = i + 1;
                    break;
                }
            for (int i = save; i < daysscheduled.Length; i++)
                if (daysscheduled[i] != '-')
                    tt += daysscheduled[i];
                else
                {
                    save = i + 1;
                    break;
                }
            for (int i = save; i < daysscheduled.Length; i++)
                if (daysscheduled[i] != ':')
                    hh2 += daysscheduled[i];
                else
                {
                    save = i + 1;
                    break;
                }
            for (int i = save; i < daysscheduled.Length; i++)
                if (daysscheduled[i] != ' ')
                    mm2 += daysscheduled[i];
                else
                {
                    save = i + 1;
                    break;
                }
            for (int i = save; i < daysscheduled.Length; i++)
                tt2 += daysscheduled[i];

            h = int.Parse(hh);
            if (tt == "PM" && h != 12)
                h += 12;
            h *= 60;
            m = int.Parse(mm);
            m += h;

            h = 0;
            h = int.Parse(hh2);
            if (tt2 == "PM" && h != 12)
                h += 12;
            h *= 60;
            m2 = int.Parse(mm2);
            m2 += h;

            //TestStartAndStopTime
            int starttime = m;
            int stoptime = m2;
            //--------------------
            /*
                        save = 0;
                        hh = "";
                        hh2 = "";

                        string daytime = currentdate;

                        for (int i = 0; i < daytime.Length; i++)
                        {
                            if (daytime[i] != '-')
                                hh += daytime[i];
                            else
                            {
                                save = i + 1;
                                break;
                            }
                        }
                        for (int i = save; i < daytime.Length; i++)
                        {
                            hh2 += daytime[i];
                        }

                        //DayStartAndStopTime
                        int daystart = int.Parse(hh);
                        int dayend = int.Parse(hh2);
                        //----------------------
             */
            gothroughs = calculateseats(starttime, stoptime);
            starttestss = m;
            stoptestss = m2;
        }

        private int calculateseats(int teststart, int teststop)
        {
            int fifteenminuteintervals = 0;
            fifteenminuteintervals = (teststop - teststart) / 15;
            return fifteenminuteintervals;
        }

        //Add page
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                search = false;
            dataGridView1.Visible = true;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Select");
            comboBox1.Items.Add("Finals-CBT");
            comboBox1.Items.Add("Finals-PBT");
            comboBox1.Items.Add("Montrose");
            //Add column header
            this.Text = "MavPlanner - Add page";
            if (!comboBox1.Visible || !button1.Visible || button6.Visible)
            {
                dateTimePicker1.Visible = true;
                comboBox1.Visible = true;
                button1.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = false;
                button8.Visible = false;
                dateTimePicker4.Visible = false;
                dateTimePicker5.Visible = false;
            }
            comboBox1.SelectedIndex = 0;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("newColumnName", "Seats");
            dataGridView1.Columns.Add("newColumnName", "Date");
            dataGridView1.Columns.Add("newColumnName", "Time");
            dataGridView1.Columns.Add("newColumnName", "Seats");
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
            if (!comboBox1.Visible || !button1.Visible || !button6.Visible)
            {
                dateTimePicker1.Visible = true;
                dataGridView1.Visible = true;
                comboBox1.Visible = true;
                button1.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button6.Visible = true;
                button8.Visible = false;
                dateTimePicker4.Visible = false;
                dateTimePicker5.Visible = false;
            }
            comboBox1.SelectedIndex = 0;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("newColumnName", "Name");
            dataGridView1.Columns.Add("newColumnName", "Class");
            dataGridView1.Columns.Add("newColumnName", "Instructor");
            dataGridView1.Columns.Add("newColumnName", "Date");
            dataGridView1.Columns.Add("newColumnName", "Time");
            dataGridView1.Columns.Add("newColumnName", "CBT-PBT-M");
            dataGridView1.Columns.Add("newColumnName", "Reporter");
            dataGridView1.Columns.Add("newColumnName", "Date Created");
            dataGridView1.Columns.Add("newColumnName", "ID");

            var query = from c in savedTableAdapter.GetData()
                        select c;

            foreach (var q in query)
            {
                if (q.Status != "Canceled" && dateTimePicker1.Value.ToString("MM/dd/yyyy") == q.TestDate.ToString())
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
                    dataGridView1.Rows.Add(arr);
                    //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                }
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
            if (!button3.Visible || !button4.Visible || button6.Visible)
            {
                button3.Visible = true;
                button4.Visible = true;
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
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;

                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                checkBox7.Visible = false;
                checkBox8.Visible = false;
            }
            button1.Visible = false;
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf("Users");
            button8.Visible = true;
            if (comboBox1.SelectedIndex.ToString() == "0")
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("newColumnName", "ID");
                dataGridView1.Columns.Add("newColumnName", "Name:");
                dataGridView1.Columns.Add("newColumnName", "Username");
                dataGridView1.Columns.Add("newColumnName", "Date Added");
                dataGridView1.Columns.Add("newColumnName", "Admin");
                dataGridView1.Rows.Clear();
            }
            var query = from c in userTableAdapter.GetData()
                        select c;

            foreach (var q in query)
            {
                arr[0] = q.Id.ToString();
                arr[1] = q.name.ToString();
                arr[2] = q.username.ToString();
                arr[3] = q.dateadded.ToString();
                arr[4] = q.admin.ToString();
                dataGridView1.Rows.Add(arr);
            }
        }

        //Date Change
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string[] arr = new string[10];
            if (comboBox1.SelectedIndex.ToString() != "0" && comboBox1.SelectedIndex != 3 && comboBox1.SelectedIndex.ToString() == "1" || comboBox1.SelectedIndex.ToString() == "2")
            {
                if (!radioButton3.Checked)
                    dataGridView1.Rows.Clear();
                if (radioButton1.Checked)
                {
                    timer_Tick(sender, e);
                }
            }
            if (comboBox1.SelectedIndex.ToString() == "1" && radioButton2.Checked)
            {
                dataGridView1.Rows.Clear();
                var query = from c in savedTableAdapter.GetData()
                            where c.CBT_PBT == "CBT"
                            select c;

                foreach (var q in query)
                {
                    if (q.Status != "Canceled" && dateTimePicker1.Value.ToString("MM/dd/yyyy") == q.TestDate.ToString())
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
                        dataGridView1.Rows.Add(arr);
                    }
                    //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                }
            }
            if (comboBox1.SelectedIndex.ToString() == "0" && radioButton2.Checked)
            {
                dataGridView1.Rows.Clear();
                var query = from c in savedTableAdapter.GetData()
                            select c;

                foreach (var q in query)
                {
                    if (q.Status != "Canceled" && dateTimePicker1.Value.ToString("MM/dd/yyyy") == q.TestDate.ToString())
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
                        dataGridView1.Rows.Add(arr);
                        //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                    }
                }
            }
            if (comboBox1.SelectedIndex.ToString() == "2" && radioButton2.Checked)
            {
                dataGridView1.Rows.Clear();
                var query = from c in savedTableAdapter.GetData()
                            where c.CBT_PBT == "PBT"
                            select c;

                foreach (var q in query)
                {
                    if (q.Status != "Canceled" && dateTimePicker1.Value.ToString("MM/dd/yyyy") == q.TestDate.ToString())
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
                        dataGridView1.Rows.Add(arr);
                        //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                    }
                }
            }
            if (comboBox1.SelectedIndex.ToString() == "3" && radioButton2.Checked)
            {
                dataGridView1.Rows.Clear();
                var query = from c in savedTableAdapter.GetData()
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
                    dataGridView1.Rows.Add(arr);
                    //System.Windows.Forms.MessageBox.Show(q.CBT_PBT.ToString());
                }
            }
            if (comboBox1.SelectedIndex == 3)
            {
                if (!radioButton3.Checked)
                    dataGridView1.Rows.Clear();
                if (radioButton1.Checked)
                    timer_Tick(sender, e);
            }
        }

        //Add To DB-Update admin information
        private void button1_Click(object sender, EventArgs e)
        {
            //-----------------------Adding New Scheduled Date----------------------
            if (dateTimePicker1.Value < DateTime.Today && radioButton1.Checked)
            {
                System.Windows.Forms.MessageBox.Show("Please select Another day");
            }
            else if (!radioButton3.Checked)
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    Form2 frm = new Form2(this);

                    var result = frm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string date = "";
                        string timestart = "";

                        DateTime temp = new DateTime();
                        date = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                        timestart = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();

                        int inc = 0;
                        string hour = "";
                        string minute = "";
                        string ampm = "";

                        for (inc = 0; inc < timestart.Length; inc++)
                        {
                            if (timestart[inc] != ':')
                                hour += timestart[inc];
                            else
                                break;
                        }
                        for (inc += 1; inc < timestart.Length; inc++)
                        {
                            if (timestart[inc] != ' ')
                                minute += timestart[inc];
                            else
                                break;
                        }
                        for (inc += 1; inc < timestart.Length; inc++)
                        {
                            ampm += timestart[inc];
                        }

                        TimeSpan ts = new TimeSpan(int.Parse(hour), int.Parse(minute), 0);
                        temp = temp.Date + ts;
                        DateTime until = new DateTime();
                        if (ampm == "PM" && hour != "12")
                            temp = temp.AddHours(12);
                        until = temp;
                        until = until.AddMinutes(int.Parse(frm.time));

                        DateTime thisDay = DateTime.Now;
                        string cbtpbttest = "";

                        if (comboBox1.SelectedIndex == 1)
                            cbtpbttest = "CBT";
                        else if (comboBox1.SelectedIndex == 2)
                            cbtpbttest = "PBT";
                        else if (comboBox1.SelectedIndex == 3)
                            cbtpbttest = "Montrose";

                        int tempid = int.Parse(thisDay.ToString("MMddyyy"));
                        tempid += int.Parse(thisDay.ToString("hhmmss"));
                        string reporter1 = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                        int i = 0;
                        string reporter = "";
                        for ( i = 0; i < reporter1.Length; i++)
                        {
                            if(reporter1[i]=='\\')
                            {
                                break;
                            }
                        }
                        for (i+=1; i < reporter1.Length; i++)
                        {
                            reporter += reporter1[i];
                        }
                            savedTableAdapter.Insert(frm.first + " " + frm.last, frm.classs, frm.instructor, date, temp.ToString("hh:mm tt") + "-" + until.ToString("hh:mm tt"), cbtpbttest, reporter, thisDay.ToString("MM/dd/yyyy"), "ACTIVE");
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Please select a time frame.");
                }
            }
            //-----------------------Changing available Time-----------------------
            else if (radioButton3.Checked && comboBox1.SelectedIndex.ToString() == "1")
            {
                int hours2min = 0;
                hours2min = int.Parse(dateTimePicker4.Value.ToString("hh"));
                if (dateTimePicker4.Value.ToString("tt") == "PM" && hours2min != 12)
                {
                    hours2min += 12;
                }

                hours2min *= 60;
                hours2min += int.Parse(dateTimePicker4.Value.ToString("mm"));
                //---------------------------
                int starttimeofday = hours2min;
                //---------------------------

                hours2min = 0;
                hours2min = int.Parse(dateTimePicker5.Value.ToString("hh"));
                if (dateTimePicker5.Value.ToString("tt") == "PM" && hours2min != 12)
                {
                    hours2min += 12;
                }

                hours2min *= 60;
                hours2min += int.Parse(dateTimePicker5.Value.ToString("mm"));
                //---------------------------
                int endtimeofday = hours2min;
                //---------------------------

                int totalhoursofday = endtimeofday - starttimeofday;

                if (checkBox8.Checked && (totalhoursofday % 60 == 0 || totalhoursofday % 60 == 15 || totalhoursofday % 60 == 30 || totalhoursofday % 60 == 45))
                {
                    var query = from c in finalsMainTableAdapter.GetData()
                                select c;
                    DataRow newb;
                    newb = finalsMainTableAdapter.GetData().NewRow();
                    foreach (var c in query)
                    {
                        c.Dates = dateTimePicker2.Value.ToString("MM/dd/yyyy") +
    "-" + dateTimePicker3.Value.ToString("MM/dd/yyyy");

                        if (checkBox1.Checked)
                            c.Sunday = starttimeofday + "-" + endtimeofday;
                        else c.Sunday = "OFF";
                        if (checkBox6.Checked)
                            c.Monday = starttimeofday + "-" + endtimeofday;
                        else c.Monday = "OFF";
                        if (checkBox5.Checked)
                            c.Tuesday = starttimeofday + "-" + endtimeofday;
                        else c.Tuesday = "OFF";
                        if (checkBox7.Checked)
                            c.Wednesday = starttimeofday + "-" + endtimeofday;
                        else c.Wednesday = "OFF";
                        if (checkBox4.Checked)
                            c.Thursday = starttimeofday + "-" + endtimeofday;
                        else c.Thursday = "OFF";
                        if (checkBox3.Checked)
                            c.Friday = starttimeofday + "-" + endtimeofday;
                        else c.Friday = "OFF";
                        if (checkBox2.Checked)
                            c.Saturday = starttimeofday + "-" + endtimeofday;
                        else c.Saturday = "OFF";
                        newb = c;
                    }
                    finalsMainTableAdapter.Update(newb);
                    datesscheduled();
                    System.Windows.Forms.MessageBox.Show("Updated available Test times");
                }
                else if (checkBox8.Checked)
                {
                    System.Windows.Forms.MessageBox.Show("Error: Please select a time of day in intervals of 15 minutes.");
                }

            }
            //-----------------------Changing available Times-----------------------
            else if (radioButton3.Checked && comboBox1.SelectedIndex.ToString() == "2")
            {
                int hours2min = 0;
                hours2min = int.Parse(dateTimePicker4.Value.ToString("hh"));
                if (dateTimePicker4.Value.ToString("tt") == "PM" && hours2min != 12)
                {
                    hours2min += 12;
                }

                hours2min *= 60;
                hours2min += int.Parse(dateTimePicker4.Value.ToString("mm"));
                //---------------------------
                int starttimeofday = hours2min;
                //---------------------------

                hours2min = 0;
                hours2min = int.Parse(dateTimePicker5.Value.ToString("hh"));
                if (dateTimePicker5.Value.ToString("tt") == "PM" && hours2min != 12)
                {
                    hours2min += 12;
                }

                hours2min *= 60;
                hours2min += int.Parse(dateTimePicker5.Value.ToString("mm"));
                //---------------------------
                int endtimeofday = hours2min;
                //---------------------------

                int totalhoursofday = endtimeofday - starttimeofday;

                if (checkBox8.Checked && (totalhoursofday % 60 == 0 || totalhoursofday % 60 == 15 || totalhoursofday % 60 == 30 || totalhoursofday % 60 == 45))
                {
                    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------need to update this
                    var query = from c in allTimeMontroseTableAdapter.GetData()
                                select c;
                    DataRow newb;
                    newb = allTimeMontroseTableAdapter.GetData().NewRow();
                    foreach (var c in query)
                    {
                        //                        c.Dates = dateTimePicker2.Value.ToString("MM/dd/yyyy") +
                        //"-" + dateTimePicker3.Value.ToString("MM/dd/yyyy");
                        if (checkBox1.Checked)
                            c.Sunday = starttimeofday + "-" + endtimeofday;
                        else c.Sunday = "OFF";
                        if (checkBox6.Checked)
                            c.Monday = starttimeofday + "-" + endtimeofday;
                        else c.Monday = "OFF";
                        if (checkBox5.Checked)
                            c.Tuesday = starttimeofday + "-" + endtimeofday;
                        else c.Tuesday = "OFF";
                        if (checkBox7.Checked)
                            c.Wednesday = starttimeofday + "-" + endtimeofday;
                        else c.Wednesday = "OFF";
                        if (checkBox4.Checked)
                            c.Thursday = starttimeofday + "-" + endtimeofday;
                        else c.Thursday = "OFF";
                        if (checkBox3.Checked)
                            c.Friday = starttimeofday + "-" + endtimeofday;
                        else c.Friday = "OFF";
                        if (checkBox2.Checked)
                            c.Saturday = starttimeofday + "-" + endtimeofday;
                        else c.Saturday = "OFF";
                        newb = c;
                    }
                    allTimeMontroseTableAdapter.Update(newb);
                    datesscheduled();
                    System.Windows.Forms.MessageBox.Show("Updated available Test times");
                }
                if (!checkBox8.Checked && (totalhoursofday % 60 == 0 || totalhoursofday % 60 == 15 || totalhoursofday % 60 == 30 || totalhoursofday % 60 == 45))
                {
                    //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------need to update this
                    var query = from c in finalsMontroseTableAdapter.GetData()
                                select c;
                    DataRow newb;
                    newb = finalsMontroseTableAdapter.GetData().NewRow();
                    foreach (var c in query)
                    {
                        c.Dates = dateTimePicker2.Value.ToString("MM/dd/yyyy") +
"-" + dateTimePicker3.Value.ToString("MM/dd/yyyy");
                        if (checkBox1.Checked)
                            c.Sunday = starttimeofday + "-" + endtimeofday;
                        else c.Sunday = "OFF";
                        if (checkBox6.Checked)
                            c.Monday = starttimeofday + "-" + endtimeofday;
                        else c.Monday = "OFF";
                        if (checkBox5.Checked)
                            c.Tuesday = starttimeofday + "-" + endtimeofday;
                        else c.Tuesday = "OFF";
                        if (checkBox7.Checked)
                            c.Wednesday = starttimeofday + "-" + endtimeofday;
                        else c.Wednesday = "OFF";
                        if (checkBox4.Checked)
                            c.Thursday = starttimeofday + "-" + endtimeofday;
                        else c.Thursday = "OFF";
                        if (checkBox3.Checked)
                            c.Friday = starttimeofday + "-" + endtimeofday;
                        else c.Friday = "OFF";
                        if (checkBox2.Checked)
                            c.Saturday = starttimeofday + "-" + endtimeofday;
                        else c.Saturday = "OFF";
                        newb = c;
                    }
                    finalsMontroseTableAdapter.Update(newb);
                    datesscheduled();
                    System.Windows.Forms.MessageBox.Show("Updated available Test times");
                }
            }
        }

        //deleting Scheduled DB information.
        private void button6_Click(object sender, EventArgs e)
        {

            string price = "";
            string deleted = "";

            price += Double.Parse(dataGridView1.SelectedRows[0].Cells[8].Value.ToString());
            deleted += "ID: " + dataGridView1.SelectedRows[0].Cells[8].Value.ToString() + "\n\n" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + " " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + " " + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + "\n" +
                dataGridView1.SelectedRows[0].Cells[3].Value.ToString() + " " + dataGridView1.SelectedRows[0].Cells[4].Value.ToString() + " " + dataGridView1.SelectedRows[0].Cells[5].Value.ToString();

            var query = from c in savedTableAdapter.GetData()
                        where c.Id.ToString() == price.ToString()
                        select c;

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this?\n" + deleted, "Confirm", MessageBoxButtons.YesNo,
MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                foreach (var q in query)
                {
                    savedTableAdapter.Delete(q.Id);
                    dataGridView1.Rows.Clear();
                    if (q.Status != "Canceled" && dateTimePicker1.Value.ToString("MM/dd/yyyy") == q.TestDate.ToString())
                    {
                        q.Status = "Canceled";

                        arr[0] = q.StudentName.ToString();
                        arr[1] = q.Class.ToString();
                        arr[2] = q.Instructor.ToString();
                        arr[3] = q.TestDate.ToString();
                        arr[4] = q.TestTime.ToString();
                        arr[5] = q.CBT_PBT.ToString();
                        arr[6] = q.Reporter.ToString();
                        arr[7] = q.DateCreated.ToString();
                        arr[8] = q.Id.ToString();
                        dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add(arr);

                    }
                }
            }
        }

        //remove users
        private void button4_Click(object sender, EventArgs e)
        {
            //delete selected
            string selecteduser = "";
            string deleted = "";
            selecteduser += Double.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            deleted += "ID: " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "\n\nEmployee name: " + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "\nUsername: " + dataGridView1.SelectedRows[0].Cells[2].Value.ToString() + " Admin: " + dataGridView1.SelectedRows[0].Cells[4].Value.ToString();

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this?\n" + deleted, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                var query = from c in userTableAdapter.GetData()
                            where c.Id.ToString() == selecteduser.ToString()
                            select c;
                foreach (var q in query)
                {
                    userTableAdapter.Delete(q.Id);
                }
                dataGridView1.Rows.Clear();

                //refresh page
                query = from c in userTableAdapter.GetData()
                        select c;
                foreach (var q in query)
                {
                    arr[0] = q.Id.ToString();
                    arr[1] = q.name.ToString();
                    arr[2] = q.username.ToString();
                    arr[3] = q.dateadded.ToString();
                    arr[4] = q.admin.ToString();
                    dataGridView1.Rows.Add(arr);
                }
            }
        }

        //search function
        private void button2_Click(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            search = true;
            dataGridView1.Rows.Clear();
            string searchinput = textBox1.Text;
            var query = from c in savedTableAdapter.GetData()
                        where c.StudentName == searchinput || c.Reporter == searchinput || c.Instructor == searchinput || c.Class == searchinput
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
                dataGridView1.Rows.Add(arr);
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
                userTableAdapter.Insert(frm.username, adminft, thisDay.ToString("MM/dd/yyyy"), frm.employee);
            }
        }

        //Convert Date into Date time.
        private void d2dt(string datescheduled, DateTimePicker dtp)
        {
            string m = "", d = "", y = "";
            int stored = 0;
            for (int i = 0; i < datescheduled.Length; i++)
            {
                if (datescheduled[i] != '/')
                    m += datescheduled[i];
                else
                {
                    stored = i + 1;
                    break;
                }
            }
            for (int i = stored; i < datescheduled.Length; i++)
            {
                if (datescheduled[i] != '/')
                    d += datescheduled[i];
                else
                {
                    stored = i + 1;
                    break;
                }
            }
            for (int i = stored; i < datescheduled.Length; i++)
            {
                y += datescheduled[i];
            }
            DateTime datescheduleds = new DateTime(int.Parse(y), int.Parse(m), int.Parse(d));
            dtp.Value = datescheduleds;
        }

        //Convert DB FinalTest into two dates
        private void Finalsdatesmain()
        {
            string firsttestdate = "", secondtestdate = "";
            var query = from c in finalsMainTableAdapter.GetData()
                        select c;
            foreach (var c in query)
            {
                int track = 0;
                for (int i = 0; i < c.Dates.Length; i++)
                {
                    if (c.Dates[i] != '-')
                        firsttestdate += c.Dates[i];
                    else
                    {
                        track = i + 1;
                        break;
                    }
                }
                for (int i = track; i < c.Dates.Length; i++)
                {
                    secondtestdate += c.Dates[i];
                }
            }
            d2dt(firsttestdate, dateTimePicker2);
            d2dt(secondtestdate, dateTimePicker3);
        }

        private void Finalsdatesmontrose()
        {
            string firsttestdate = "", secondtestdate = "";
            var query = from c in finalsMontroseTableAdapter.GetData()
                        select c;
            foreach (var c in query)
            {
                int track = 0;
                for (int i = 0; i < c.Dates.Length; i++)
                {
                    if (c.Dates[i] != '-')
                        firsttestdate += c.Dates[i];
                    else
                    {
                        track = i + 1;
                        break;
                    }
                }
                for (int i = track; i < c.Dates.Length; i++)
                {
                    secondtestdate += c.Dates[i];
                }
            }
            d2dt(firsttestdate, dateTimePicker2);
            d2dt(secondtestdate, dateTimePicker3);
        }

        //Admin page check if "All Time"
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked && comboBox1.SelectedIndex.ToString() == "2")
            {
                label1.Enabled = false;
                label2.Enabled = false;
                dateTimePicker2.Enabled = false;
                dateTimePicker3.Enabled = false;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                checkBox5.Enabled = true;
                checkBox6.Enabled = true;
                checkBox7.Enabled = true;
                label6.Enabled = true;
                label7.Enabled = true;
                label8.Enabled = true;
                label9.Enabled = true;
                label10.Enabled = true;
                label11.Enabled = true;
                label12.Enabled = true;
                datesscheduled();
            }
            else
            {
                label1.Enabled = true;
                label2.Enabled = true;
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = true;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                checkBox5.Enabled = false;
                checkBox6.Enabled = false;
                checkBox7.Enabled = false;

                label6.Enabled = false;
                label7.Enabled = false;
                label8.Enabled = false;
                label9.Enabled = false;
                label10.Enabled = false;
                label11.Enabled = false;
                label12.Enabled = false;

                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;

                if (comboBox1.SelectedIndex.ToString() == "2")
                {
                    var query = from c in finalsMontroseTableAdapter.GetData()
                                select c;
                    string starttime = "";
                    string stoptime = "";
                    foreach (var c in query)
                    {
                        int stop = 0;
                        for (int j = 0; j < 2; j++)
                            for (int i = stop; i < c.Monday.Length; i++)
                            {
                                if (c.Monday[i] != '-' && j < 1)
                                    starttime += c.Monday[i];
                                else if (j == 1)
                                    stoptime += c.Monday[i];
                                else
                                {
                                    stop = i + 1;
                                    break;
                                }
                            }
                    }
                    DateTime finalsst = new DateTime(1992, 1, 30, 0, 0, 0);
                    finalsst = finalsst.AddMinutes(int.Parse(starttime));

                    dateTimePicker4.Value = finalsst;

                    finalsst = finalsst.AddMinutes(int.Parse(stoptime) - int.Parse(starttime));

                    dateTimePicker5.Value = finalsst;
                }
                if (comboBox1.SelectedIndex.ToString() == "1")
                {
                    var query = from c in finalsMainTableAdapter.GetData()
                                select c;
                    string starttime = "";
                    string stoptime = "";
                    foreach (var c in query)
                    {
                        int stop = 0;
                        for (int j = 0; j < 2; j++)
                            for (int i = stop; i < c.Monday.Length; i++)
                            {
                                if (c.Monday[i] != '-' && j < 1)
                                    starttime += c.Monday[i];
                                else if (j == 1)
                                    stoptime += c.Monday[i];
                                else
                                {
                                    stop = i + 1;
                                    break;
                                }
                            }
                    }
                    DateTime finalsst = new DateTime(1992, 1, 30, 0, 0, 0);
                    finalsst = finalsst.AddMinutes(int.Parse(starttime));

                    dateTimePicker4.Value = finalsst;

                    finalsst = finalsst.AddMinutes(int.Parse(stoptime) - int.Parse(starttime));

                    dateTimePicker5.Value = finalsst;
                }
            }
        }
    }
}
