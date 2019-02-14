using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace temp_bst_hard
{
    class node
    {
        public node l;
        public node r;
        public node p;
        public Int64 k;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int keys = int.Parse(Console.ReadLine());            
            List<node> list = new List<node>();
            node temp;
            for (int i = 0; i < keys; i++)
            {
                temp = new node();
                list.Add(temp);
            }
            //Reading input
            for (int i = 0; i < keys; i++)
            {
                string[] temp1 = Console.ReadLine().Split();
                list[i].k = Int64.Parse(temp1[0]);
                if (Int64.Parse(temp1[1]) != -1)
                {
                    list[i].l = list[int.Parse(temp1[1])];
                    list[int.Parse(temp1[1])].p = list[i];
                }
                if (Int64.Parse(temp1[2]) != -1)
                {
                    list[i].r = list[int.Parse(temp1[2])];
                    list[int.Parse(temp1[2])].p = list[i];
                }
            }
            Int64 max = Int64.MinValue;
            Int64 r = 0;
            if (list.Count > 0 && list[0] != list[0].l && list[0] != list[0].r)
                inOrder(list[0], ref r, ref max);
            if (r != 1)
                Console.WriteLine("CORRECT");
            else
                Console.WriteLine("INCORRECT");
        }

        static void inOrder(node root, ref Int64 r, ref Int64 max)
        {
            Stack<node> st = new Stack<node>();
            st.Push(root);
            node current = root.l;
            while (st.Count != 0)
            {
                if (current != null)
                {
                    st.Push(current);
                    current = current.l;
                }
                else
                {
                    node temp = st.Pop();
                    if (temp.r != null)
                    {
                        st.Push(temp.r);
                        current = temp.r.l;
                    }                    
                    if (max > temp.k || (temp.l != null && temp.k <= temp.l.k) || (temp.r != null && temp.k > temp.r.k))
                    {
                        r = 1;
                        return;
                    }
                    max = temp.k;
                }
            }
        }

    }
}
