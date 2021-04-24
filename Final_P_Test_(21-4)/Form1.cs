using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_P_Test__21_4_
{
    struct process
    {
        public int pID;
        public int priority;           // the priority of the process
        public float arrivalTime;     // the start time of the process
        public float burstTime;       // time for the process to finish
        public float completionTime;
        public float turnArroundTime;
        public float waitingTime;
        public float started;
        public int end;
        public float on_time;
        public Color labcolor;
    };


    public partial class CPU_Scheduler : Form
    {
        #region variables

        static LinkedList<process> queue = new LinkedList<process>();
        static List<process> output = new List<process>();

        static LinkedList<process> list = new LinkedList<process>();
        //create an empty list of type process
        static List<process> processes = new List<process>();
        static List<process> queue_fcfs = new List<process>();

        static int number_processes;	// number of process entered by the user
        static float[] burstTime;
        static int quantumTime;
        static string process_type;
        static bool preemptive = false;
        static float averageWaitingTime = 0;

        float[] arrival_time_int;
        float[] duration_int = { 0 };
        int[] priority_int = { 0 };
        static Random rnd = new Random();
        #endregion


        #region CPU Schedule Logic Part

        // FCFS
        static void FCFS()
        {
            float total = 0;
            int c = 0;
            if (processes[0].arrivalTime > 0)
            {
                total += processes[0].arrivalTime;
            }
            foreach (process i in processes)
            {
                
                total += i.burstTime;
                if (c != 0 && i.arrivalTime > output[c - 1].completionTime)
                {
                    total += i.arrivalTime - output[c - 1].completionTime;
                }
                arrange(i, total);
                c++;
            }
            processes.Clear();
            foreach (process k in output)
            {
                averageWaitingTime += k.waitingTime / (float)number_processes;
            }
        }

        static void arrange(process task, float total)
        {
            task.on_time = task.burstTime;
            task.completionTime = total - 0;
            task.turnArroundTime = task.completionTime - task.arrivalTime;
            task.waitingTime = task.turnArroundTime - task.burstTime;
            output.Add(task);
        }

        // Priority & SJF
        static void priority_sjf()
        {
            process p = new process();
            float d;      // detect the current timing of the process

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
            averageWaitingTime = 0;

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
                else if (queue.Count == 0)
                {
                    d = k.arrivalTime;
                }

                else
                {
                    //Console.Write(queue.First.Value.pID + " ");
                    p = queue.First.Value;
                    
                    queue.RemoveFirst();
                    //p.started++;
                    //d++;
                    
                    //d = k.arrivalTime;
                    if(k.end !=1 &&(k.arrivalTime - d) < (p.burstTime - p.started))
                    {
                        p.started += (k.arrivalTime - d);
                        p.on_time = (k.arrivalTime - d);
                        d = k.arrivalTime;
                    }
                    else
                    {
                        float ll = p.burstTime - p.started;
                        p.started += ll;
                        p.on_time = ll;
                        d += ll;
                    }
                    
                    if (p.started == p.burstTime)
                    {
                        turnAroundTime = (d - p.arrivalTime);
                        averageWaitingTime = averageWaitingTime + (turnAroundTime - p.burstTime) / (float)number_processes;
                    }
                    else
                    {
                        queue.AddFirst(p);
                    }

                    if (output.Count != 0 && output[output.Count - 1].pID == p.pID)
                    {
                        process m = output[output.Count - 1];
                        m.on_time+= p.on_time;
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
            if (process_type == "SJF (Preemptive)" || process_type == "SJF (Non Preemptive)")
            {
                if (queue.Count == 0)
                {
                    queue.AddFirst(p);
                }
                else if (queue.Count == 1)
                {
                    if ((preemptive || queue.First.Value.started == 0) && p.burstTime < (queue.First.Value.burstTime - queue.First.Value.started))
                    {
                        queue.AddFirst(p);
                    }
                    else
                        queue.AddLast(p);
                }
                else if (p.burstTime >= (queue.Last.Value.burstTime - queue.Last.Value.started))
                {
                    queue.AddLast(p);
                }
                else
                {
                    LinkedListNode<process> i = preemptive ? queue.First : queue.First.Next;
                    while ((i.Value.burstTime- i.Value.started)  <= p.burstTime)
                    {
                        i = i.Next;
                    }
                    queue.AddBefore(i, p);
                }
            }
            else if (process_type == "Priority (Preemptive)" || process_type == "Priority (Non Preemptive)")
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

        // Round Robin
        static void Round_R()
        {
            process p = new process();
            float d;		// detect the current timing of the process
            //float averageWaitingTime = 0;

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
                            processes.RemoveAt(0);
                            queue.AddLast(k);
                            if (processes.Count == 0)
                            {
                                k.end = 1;
                            }
                            else
                            {
                                k = processes[0];
                            }

                        }
                    }
                    else
                    {

                        temp = queue.Last;
                        queue.AddBefore(temp, k);
                        processes.RemoveAt(0);
                        if (processes.Count == 0)
                        {
                            k.end = 1;
                        }
                        else
                        {
                            k = processes[0];
                        }

                        //list.RemoveFirst();
                    }
                }
                else if (queue.Count == 0)
                {
                    d++;
                }
                else
                {
                    process m = queue.First.Value;
                    if (m.burstTime > quantumTime)
                    {
                        m.on_time = quantumTime;
                    }
                    else
                    {
                        m.on_time = m.burstTime;
                    }
                    output.Add(m);
                    /*
                    if (output.Count != 0 && output[output.Count - 1].pID == queue.First.Value.pID)
                    {
                        process m = output[output.Count - 1];
                        m.on_time+= quantumTime - 1;
                        output.RemoveAt(output.Count - 1);
                        output.Add(m);
                    }
                    else
                    {
                        output.Add(queue.First.Value);
                    }
                    */
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
                        averageWaitingTime = averageWaitingTime + (turnAroundTime - burstTime[queue.First.Value.pID - 1]) / (number_processes);
                        queue.RemoveFirst();
                        detectProcessRemoval = true;
                    }
                    if (!smallerProcess)
                    {
                        d += quantumTime;
                    }


                }
            }

        }

        #endregion



        public CPU_Scheduler()
        {
            InitializeComponent();
        }


        private void Clear_All()
        {
            averageWaitingTime = 0;

            arrivalBox.Clear();
            priorityBox.Clear();
            burstBox.Clear();
            quantemBox.Clear();
            waintingBox.Clear();
            pnumBox.Clear();

            processes.Clear();
            queue.Clear();
            queue_fcfs.Clear();
            list.Clear();
            output.Clear();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

        }

        private void Clear_Data()
        {
            averageWaitingTime = 0;

            waintingBox.Clear();

            processes.Clear();
            queue.Clear();
            queue_fcfs.Clear();
            list.Clear();
            output.Clear();
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();



        }

        private void OUT_Data()
        {
            waintingBox.Text = averageWaitingTime.ToString();

            float time = 0;
            int i;

            for (i = 0; i < output.Count; i++)
            {
                time = i == 0 ? output[i].arrivalTime : time + output[i - 1].on_time;
                if (i != 0 && output[i].arrivalTime > time)
                {
                    Label empty = new Label();
                    empty.BackColor = Color.White;
                    empty.Text = "NOP";
                    empty.Font = new Font("Arial", 10, FontStyle.Bold);
                    empty.Width = 40 + 10 * (int)(output[i].arrivalTime - (time + output[i - 1].on_time));
                    flowLayoutPanel1.Controls.Add(empty);

                    
                    Label empty1 = new Label();
                    empty1.Text = time.ToString();
                    empty1.Font = new Font("Arial", 10, FontStyle.Bold);
                    empty1.Width = 40 + 10 * (int)(output[i].arrivalTime - time);
                    flowLayoutPanel2.Controls.Add(empty1);
                    time = output[i].arrivalTime;
                }
                Label lab = new Label();
                lab.BackColor = output[i].labcolor;
                lab.Text = "P" + output[i].pID.ToString();
                lab.Font = new Font("Arial", 10, FontStyle.Bold);
                lab.Width = 40 + 10 * (int)output[i].on_time;
                flowLayoutPanel1.Controls.Add(lab);

                
                Label lab1 = new Label();
                lab1.Text = time.ToString();
                lab1.Font = new Font("Arial", 10, FontStyle.Bold);
                lab1.Width = 40 + 10 * (int)output[i].on_time;
                flowLayoutPanel2.Controls.Add(lab1);
            }
            Label lab2 = new Label();
            time += output[i - 1].on_time;
            lab2.Text = time.ToString();
            lab2.Font = new Font("Arial", 10, FontStyle.Bold);
            lab2.Width = 40;
            flowLayoutPanel2.Controls.Add(lab2);
        }

        private void SupportListProcess()
        {
            arrival_time_int = Array.ConvertAll(arrivalBox.Text.Split(' '), float.Parse);
            duration_int = Array.ConvertAll(burstBox.Text.Split(' '), float.Parse);
            if (process_type == "Priority (Preemptive)" || process_type == "Priority (Non Preemptive)")
            {
                priority_int = Array.ConvertAll(priorityBox.Text.Split(' '), int.Parse);

            }
            else if (process_type == "Round Robin")
            {
                quantumTime = int.Parse(quantemBox.Text);
            }


            process processi = new process();
            for (int i = 0; i < number_processes; i++)
            {
                processi.pID = i + 1;
                processi.arrivalTime = arrival_time_int[i];
                processi.started = 0;
                processi.on_time = 1;
                processi.end = 0;
                processi.burstTime = duration_int[i];
                processi.labcolor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                if (process_type == "Priority (Preemptive)" || process_type == "Priority (Non Preemptive)")
                {
                    processi.priority = priority_int[i];

                }
                burstTime[i] = duration_int[i];

                processes.Add(processi);
                //Console.WriteLine(processi.arrivalTime);
            }
            // quantumTime = quantum;
            processes.Sort((x, y) => (x.arrivalTime.CompareTo(y.arrivalTime)));
        }


        // Handler 
        private void pnumBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                number_processes = int.Parse(pnumBox.Text);
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                number_processes = 0;
            }
            burstTime = new float[number_processes];
        }

        private void Enterbutton_Click(object sender, EventArgs e)
        {
            Clear_Data();
            SupportListProcess(); // insert the data to processes list

            switch (process_type)
            {
                case "FCFS":
                    FCFS();
                    break;
                case "SJF (Preemptive)":
                case "SJF (Non Preemptive)":
                case "Priority (Preemptive)":
                case "Priority (Non Preemptive)":
                    priority_sjf();
                    break;
                case "Round Robin":
                    Round_R();
                    break;
            }
            OUT_Data();
        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            Clear_All();
        }

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Clear_All();
            process_type = typeBox.Text;
            preemptive = false;

            priorityBox.Visible = false;
            priorityLabel.Visible = false;

            quantemBox.Visible = false;
            quantemLabel.Visible = false;

            if (process_type == "None")
            {
                pnumBox.Visible = false;
                pnumLabel.Visible = false;

                arrivalBox.Visible = false;
                arrivalLabel.Visible = false;

                burstBox.Visible = false;
                burstLabel.Visible = false;

                flowLayoutPanel1.Visible = false;
                flowLayoutPanel2.Visible = false;

                Enterbutton.Enabled = false;
                Clearbutton.Enabled = false;

            }
            else
            {
                pnumBox.Visible = true;
                pnumLabel.Visible = true;

                arrivalBox.Visible = true;
                arrivalLabel.Visible = true;

                burstBox.Visible = true;
                burstLabel.Visible = true;

                flowLayoutPanel1.Visible = true;
                flowLayoutPanel2.Visible = true;

                Enterbutton.Enabled = true;
                Clearbutton.Enabled = true;
            }
            switch (process_type)
            {
                case "FCFS":
                    break;
                case "SJF (Preemptive)":
                    preemptive = true;
                    break;
                case "SJF (Non Preemptive)":
                    break;
                case "Priority (Preemptive)":
                    preemptive = true;
                    priorityBox.Visible = true;
                    priorityLabel.Visible = true;
                    break;
                case "Priority (Non Preemptive)":
                    priorityBox.Visible = true;
                    priorityLabel.Visible = true;
                    break;
                case "Round Robin":
                    quantemBox.Visible = true;
                    quantemLabel.Visible = true;
                    break;
            }
        }

    }
}
