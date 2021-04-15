using System;
using System.Collections.Generic;

namespace Priority_Schedular
{
    unsafe struct process
    {

        public int priority;           // the priority of the process
        public int start_time;         // the start time of the process
        public int duration;           // time for the process to finish
        public int num ;                // number of the process
        public bool started;
    };



    unsafe class Program
    {
        public static bool preemptive;

        public static LinkedList<process> list = new LinkedList<process>();
        public static LinkedList<process> queue = new LinkedList<process>();

        static void pl(process p)
        {
            if(list.Count == 0)
            {
                list.AddFirst(p);
            }
            else
            {
                var i = list.Last;
                while(i.Value.start_time > p.start_time)
                {
                    i = i.Previous;
                }
                list.AddAfter(i, p); 
            }
        }
        static void RQ(process p)
        {
            if (queue.Count == 0)
            {
                queue.AddFirst(p);
            }
            else if (p.priority > 5/2)
            {
                LinkedListNode<process> i = queue.First;
                if (!preemptive)
                {
                    i = i.Next;
                }

                while(i.Value.priority >= p.priority)
                {
                    i = i.Next;
                }
                queue.AddBefore(i, p);
                
            }
            else
            {
                var i = queue.Last;
                while(i.Value.priority < p.priority)
                {
                    i = i.Previous;
                }
                queue.AddAfter(i, p);
            }
        }

        unsafe static void Main(string[] args)
        {
            preemptive = false;
            string q;
            process p = new process();
            float P_num;	// number of process entered by the user
            int i;      // flag for the loops
            int d;		// detect the current timing of the process
            float waiting = 0;

            Console.WriteLine("******** Settings for the system **********\n");
            Console.WriteLine("Do you want it preemptive? (y/n)");
            q = Console.ReadLine();
            if(q[0] == 'y')
            {
                preemptive = true;
            }


            Console.Write("Enter number of process : ");
            P_num = Convert.ToInt32( Console.ReadLine());
            for (i = 0; i < P_num; i++)
            {
                p.num = i + 1;
                Console.Write("\nEnter start time of process " + (i + 1) + ": ");
                p.start_time = Convert.ToInt32(Console.ReadLine()); 

                Console.Write("Enter duration of process " + (i + 1) + ": ");
                p.duration = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter priority of process " + (i + 1) + ": ");
                p.priority= Convert.ToInt32(Console.ReadLine());

                p.started = false;
                pl(p);
            }
            Console.Write("\nSequence : ");
            
            var k = list.First;
            d = k.Value.start_time;

            RQ(k.Value);
            k = k.Next;
            list.RemoveFirst();

            while (queue.Count != 0)
            {
                if (k != null && k.Value.start_time == d)
                {
                    RQ(k.Value);
                    k = k.Next;
                    list.RemoveFirst();
                }
                else
                {
                    Console.Write(queue.First.Value.num + " ");
                    p = queue.First.Value;
                    queue.RemoveFirst();
                    if(p.started == false)
                    {
                        p.started = true;
                        waiting += (d - p.start_time)/P_num;
                    }
                    p.duration--;
                    if (p.duration != 0)
                    {
                        queue.AddFirst(p);
                    }
                    d++;
                }
            }
            
            Console.Write("\nAverage waiting time = " + waiting+"\n");
        }


    }
}
