using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Text;

namespace ConsumeWebApi.Controllers
{
    class Node
    {
        public string Data;
        public double Data1;
        public Node Next;
        public Node prev;
    }
    class List
    {
        StringBuilder sb = new StringBuilder();
        List<string> dsc = new List<string>();
        Node Start;
        public List()
        {
            Start = null;
        }
        public void Add(string str,string str1)
        {
           
            Node newNode = new Node();
            newNode.Data = str;
            newNode.Data1 = Convert.ToDouble(str1);

            if (Start == null)
            {
                newNode.Next = null;
                newNode.prev = null;
                Start = newNode;
                sb.Append(Start.Data);
                sb.Append(Start.Data1);
            }

            else
            {
                Node current = Start;

                while ((current.Next != null)) 
                {
                    current = current.Next;
                }

                if (current.Next == null)
                {
                    //Insertion at the end of list
                    newNode.Next = null;
                    current.Next = newNode;
                    newNode.prev = current;
                    sb.Append(newNode.Data);
                    sb.Append(newNode.Data1);
                }                
            }           
        }
        public List<string> BubbleSorted()
        {
            int swapped;
            Node ptr1;
            Node lptr = null;
                do
                {
                    swapped = 0;
                    ptr1 = Start;

                while (ptr1.Next != lptr)
                {
                    if (ptr1.Data1 > ptr1.Next.Data1)
                    {
                        double d = ptr1.Data1;
                        string s = ptr1.Data;

                        ptr1.Data1 = ptr1.Next.Data1;
                        ptr1.Data = ptr1.Next.Data;

                        ptr1.Next.Data1 = d;
                        ptr1.Next.Data = s;
                        swapped = 1;
                    }

                    ptr1 = ptr1.Next;
                }
                lptr = ptr1;

                dsc.Add((lptr.Data1).ToString());
                    dsc.Add(lptr.Data);
                }
                while (swapped != 0);
             return dsc;
        }
    }   
}