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
        public int started;
    };



    unsafe class Program
    {
        public static bool preemptive;

        public static LinkedList<process> list = new LinkedList<process>();
        public static LinkedList<process> queue = new LinkedList<process>();

        static void pl(process p)
        {
            LinkedListNode<process> i;
            if (list.Count == 0)
            {
                list.AddLast(p);
            }
            else if(p.start_time < list.First.Value.start_time)
            {
                list.AddFirst(p);
            }
            else if(p.start_time >= list.Last.Value.start_time)
            {
                list.AddLast(p);
            }
            else
            {
                i = list.Last;
                
                while(i.Value.start_time > p.start_time)
                {
                    i = i.Previous;
                }
                list.AddAfter(i, p); 
            }
        }

        //*******************************************
        static void RQ(process p)
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
            else if(p.priority > queue.Last.Value.priority)
            {
                queue.AddLast(p);
            }
            else
            {
                LinkedListNode<process> i = preemptive? queue.First : queue.First.Next;

                while(i.Value.priority <= p.priority)
                {
                    i = i.Next;
                }
                queue.AddBefore(i, p);

            }
            /*
            if(queue.Count == 1 && !preemptive)
            {
                queue.AddLast(p);
            }
            else if( p.priority >= queue.Last.Value.priority)
            {
                queue.AddLast(p);
            }
            else if(p.priority < queue.First.Value.priority)
            {
                if (preemptive)
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
                LinkedListNode<process> i = queue.Last;
                while(i.Value.priority < p.priority)
                {
                    i = i.Previous;
                }
                queue.AddAfter(i, p);
            }
            */
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

                p.started = 0;
                pl(p);
            }
            Console.Write("\nSequence : ");

            LinkedListNode<process> k = list.First;
            d = k.Value.start_time;

            RQ(k.Value);
            k = k.Next;
            list.RemoveFirst();

            while (queue.Count != 0 || list.Count != 0)
            {
                if (k != null && k.Value.start_time == d)
                {
                    RQ(k.Value);
                    k = k.Next;
                    list.RemoveFirst();
                }
                else if (queue.Count == 0) {
                    d++;
                }
                else
                {
                    Console.Write(queue.First.Value.num + " ");
                    p = queue.First.Value;
                    queue.RemoveFirst();
                    p.started++;
                    d++;
                    if (p.started == p.duration)
                    {

                        waiting += (d - p.duration - p.start_time) / P_num;
                    }
                    else
                    {
                        queue.AddFirst(p);
                    }
                    
                }
            }
            
            Console.Write("\nAverage waiting time = " + waiting+"\n");
        }


    }
}
