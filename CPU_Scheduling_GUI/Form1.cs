using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPU_Scheduling_GUI
{
    unsafe public struct process
    {
        public int pID;
        public int priority;           // the priority of the process
        public int arrivalTime;     // the start time of the process
        public int burstTime;       // time for the process to finish
        public int completionTime;
        public int turnArroundTime;
        public int waitingTime;
        public int started;
        public int end;
        public int on_time;
    };

    public partial class Form1 : Form
    {

        public static bool preemptive;
        public static int P_pID;	// number of process entered by the user
        public static int[] burstTime;
        public static int quantumTime;
        public static string process_type;

        public static LinkedList<process> queue = new LinkedList<process>();
        public static List<process> output = new List<process>();

        public static LinkedList<process> list = new LinkedList<process>();
        public static LinkedListNode<process> index = null;
        //create an empty list of type process
        public static List<process> processes = new List<process>();
        public static List<process> queue_fcfs = new List<process>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Clear_Val()
        {
            output.Clear();
            processes.Clear();
            preemptive = false;
            queue.Clear();
            list.Clear();
            queue_fcfs.Clear();
            flowLayoutPanel1.Controls.Clear();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            process_type = "FCFS";
            //textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            //label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            checkBox1.Visible = false;

            checkBox1.Checked = false;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            Clear_Val();

        }



        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            process_type = "SJF";
            //textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            //label3.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            checkBox1.Visible = true;

            checkBox1.Checked = false;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            Clear_Val();
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            process_type = "PRIORITY";
            //textBox3.Visible = false;
            textBox4.Visible = true;
            textBox5.Visible = false;
            //label3.Visible = false;
            label4.Visible = true;
            label6.Visible = false;
            checkBox1.Visible = true;

            checkBox1.Checked = false;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            Clear_Val();
        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            process_type = "RR";
            //textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = true;
            //label3.Visible = false;
            label4.Visible = false;
            label6.Visible = true;
            checkBox1.Visible = false;

            checkBox1.Checked = false;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            Clear_Val();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Clear_Val();

            P_pID = int.Parse(textBox1.Text);
            preemptive = checkBox1.Checked;
            string[] A = textBox2.Text.Split(' ');
            string[] B = textBox3.Text.Split(' ');
            string[] P= { };
            if (process_type == "PRIORITY")
                P = textBox4.Text.Split(' ');
            else if(process_type == "RR")
                quantumTime = int.Parse(textBox5.Text);
            process p = new process();
            for(int i = 0; i < P_pID; i++)
            {
                p.pID = i + 1;
                p.arrivalTime = int.Parse(A[i]);
                p.burstTime = int.Parse(B[i]);
                if (process_type == "PRIORITY")
                    p.priority = int.Parse(P[i]);
                p.end = 0;
                p.started = 0;
                p.on_time = 1;
                processes.Add(p);
            }
            processes.Sort((x, y) => x.arrivalTime - y.arrivalTime);

            switch (process_type)
            {
                case "FCFS":
                    FCFS();
                    break;
                case "PRIORITY":
                case "SJF":
                    priority_sjf();
                    break;
                case "RR":
                    Round_R();
                    break;
            }
            foreach(process l in output)
            {
                Label tempLabel_RR = new Label();
                tempLabel_RR.Enabled = true;
                tempLabel_RR.BorderStyle = BorderStyle.FixedSingle;
                tempLabel_RR.Font = new Font("Arial", 10, FontStyle.Bold);
                tempLabel_RR.Text = "P" + l.pID;
                if (process_type == "FCFS")
                    tempLabel_RR.Width = 35 + l.burstTime * 10;
                else
                    tempLabel_RR.Width = 35 + l.on_time * 10;
                flowLayoutPanel1.Controls.Add(tempLabel_RR);
            }




        }

        static void FCFS()
        {
            int start = processes[0].arrivalTime;
            int total = 0;
            int c = 0;
            float averageWaitingTime = 0;
            foreach (process i in processes)
            {
                total += i.burstTime;
                arrange(i, start, total, c);
                c++;
            }
            processes.Clear();
            foreach (process k in queue)
            {
                averageWaitingTime += k.waitingTime / P_pID;
            }
        }

        //Time calculations and store the final processes' queue in a new list and linked list
        static void arrange(process task, int start, int total, int i)
        {
            task.completionTime = total - start;
            task.turnArroundTime = task.completionTime - task.arrivalTime;
            task.waitingTime = task.turnArroundTime - task.burstTime;
            output.Add(task);
        }

        static void pl(process p)
        {
            LinkedListNode<process> i;
            if (list.Count == 0)
            {
                list.AddLast(p);
            }
            else if (p.arrivalTime < list.First.Value.arrivalTime)
            {
                list.AddFirst(p);
            }
            else if (p.arrivalTime >= list.Last.Value.arrivalTime)
            {
                list.AddLast(p);
            }
            else
            {
                i = list.Last;
                while (i.Value.arrivalTime > p.arrivalTime)
                {
                    i = i.Previous;
                }
                list.AddAfter(i, p);
            }
        }
        static void priority_sjf()
        {
            process p = new process();
            int d;		// detect the current timing of the process
            float waiting = 0;


            // var k = list.First;
            var k = processes[0];
            d = k.arrivalTime;

            RQ(k);

            processes.RemoveAt(0);
            if (processes.Count != 0)
            {
                k = processes[0];
            }
            else
            {
                k.end = 1;
            }
            float turnAroundTime = 0;

            while (queue.Count != 0 || processes.Count != 0)
            {
                if (k.end != 1 && k.arrivalTime == d)
                {
                    RQ(k);
                    processes.RemoveAt(0);
                    if (processes.Count == 0)
                    {
                        k.end = 1;
                    }
                    else
                    {
                        k = processes[0];
                    }
                }

                else
                {
                    //Console.Write(queue.First.Value.pID + " ");
                    p = queue.First.Value;
                    queue.RemoveFirst();

                    p.started++;
                    d++;

                    if (p.started == p.burstTime)
                    {
                        turnAroundTime = (d - p.arrivalTime);
                        waiting = waiting + (turnAroundTime - p.burstTime) / P_pID;
                    }
                    else
                    {
                        queue.AddFirst(p);
                    }

                    if (output.Count != 0 && output[output.Count - 1].pID == p.pID)
                    {
                        process m = output[output.Count - 1];
                        m.on_time++;
                        output.RemoveAt(output.Count - 1);
                        output.Add(m);
                    }
                    else
                    {
                        output.Add(p);
                    }
                }
            }
        }

        static void RQ(process p)
        {
            if (process_type == "SJF")
            {
                if (queue.Count == 0)
                {
                    queue.AddFirst(p);
                }
                else if (queue.Count == 1)
                {
                    if ((preemptive || queue.First.Value.started == 0) && p.burstTime < queue.First.Value.burstTime)
                    {
                        queue.AddFirst(p);
                    }
                    else
                        queue.AddLast(p);
                }
                else if (p.burstTime > queue.Last.Value.burstTime)
                {
                    queue.AddLast(p);
                }
                else
                {
                    LinkedListNode<process> i = preemptive ? queue.First : queue.First.Next;
                    while (i.Value.burstTime <= p.burstTime)
                    {
                        i = i.Next;
                    }
                    queue.AddBefore(i, p);
                }
            }
            else if (process_type == "PRIORITY")
            {
                if (queue.Count == 0)
                {
                    queue.AddFirst(p);
                }
                else if (queue.Count == 1)
                {
                    if ((preemptive || queue.First.Value.started == 0) && p.priority < queue.First.Value.priority)
                    {
                        queue.AddFirst(p);
                    }
                    else
                        queue.AddLast(p);
                }
                else if (p.priority > queue.Last.Value.priority)
                {
                    queue.AddLast(p);
                }
                else
                {
                    LinkedListNode<process> i = preemptive ? queue.First : queue.First.Next;
                    while (i.Value.priority <= p.priority)
                    {
                        i = i.Next;
                    }
                    queue.AddBefore(i, p);
                }
            }

        }
        static void Round_R()
        {
            process p = new process();
            int d;		// detect the current timing of the process
            float waiting = 0;

            var k = processes[0];
            d = k.arrivalTime;
            queue.AddFirst(k);

            processes.RemoveAt(0);
            if (processes.Count != 0)
            {
                k = processes[0];
            }
            else
            {
                k.end = 1;
            }
            float turnAroundTime = 0;
            var temp = queue.First;
            bool detectProcessRemoval = false;

            bool smallerProcess = false;
            while (queue.Count != 0 || processes.Count != 0)
            {
                if ((k.end != 1 && k.arrivalTime <= d) && d != 0)
                {
                    if (detectProcessRemoval)
                    {
                        queue.AddLast(k);
                        processes.RemoveAt(0);
                        if (processes.Count == 0)
                        {
                            k.end = 1;
                        }
                        else
                        {
                            k = processes[0];
                        }
                        detectProcessRemoval = false;
                        while (k.end != 1 && k.arrivalTime <= d)
                        {
                            queue.AddLast(k);
                            if (processes.Count == 0)
                            {
                                k.end = 1;
                            }
                            else
                            {
                                k = processes[0];
                            }
                            processes.RemoveAt(0);
                        }
                    }
                    else
                    {
                        temp = queue.Last;
                        queue.AddBefore(temp, k);
                        if (processes.Count == 0)
                        {
                            k.end = 1;
                        }
                        else
                        {
                            k = processes[0];
                        }
                        list.RemoveFirst();
                    }
                }
                else
                {


                    smallerProcess = false;
                    p = queue.First.Value;

                    if (p.burstTime > quantumTime)
                    {
                        p.burstTime -= quantumTime;
                        queue.RemoveFirst();
                        queue.AddLast(p);
                    }
                    else
                    {
                        smallerProcess = true;
                        d += p.burstTime;
                        p.burstTime = 0;
                        turnAroundTime = (d - p.arrivalTime);
                        waiting = waiting + (turnAroundTime - burstTime[queue.First.Value.pID - 1]) / (P_pID);
                        queue.RemoveFirst();
                        detectProcessRemoval = true;
                    }
                    if (!smallerProcess)
                    {
                        d += quantumTime;
                    }
                    if (output.Count != 0 && output[output.Count - 1].pID == queue.First.Value.pID)
                    {
                        process m = output[output.Count - 1];
                        m.on_time++;
                        output.RemoveAt(output.Count - 1);
                        output.Add(m);
                    }
                    else
                    {
                        output.Add(queue.First.Value);
                    }


                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
