using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree_traversal
{
    class node
    {
        public node l;
        public node r;
        public int k;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            node temp;
            List<node> list = new List<node>(); 
            for(int i = 0; i < k; i++)
            {
                temp = new node();
                list.Add(temp);
            }
            for(int i = 0; i < k; i++)
            {
                string[] temp1 = Console.ReadLine().Split();
                list[i].k = int.Parse(temp1[0]);
                if(int.Parse(temp1[1])!= -1)
                {
                    list[i].l = list[int.Parse(temp1[1])];
                }
                if (int.Parse(temp1[2]) != -1)
                {
                    list[i].r = list[int.Parse(temp1[2])];
                }
            }
            StringBuilder result = new StringBuilder(); 
            inOrder(list[0], ref result);
            Console.WriteLine(result);
            StringBuilder result1 = new StringBuilder();
            preOrder(list[0], ref result1);
            Console.WriteLine(result1);
            StringBuilder result2 = new StringBuilder();
            postOrder(list[0],ref result2);
            Console.WriteLine(result2);
        }

        static void inOrder(node root,ref StringBuilder result)
        {
            if(root != null)
            {
                inOrder(root.l,ref result);
                result.Append(root.k + "\t");
                inOrder(root.r,ref result);
            }
        }
        static void preOrder(node root, ref StringBuilder result1)
        {
            if (root != null)
            {
                result1.Append(root.k + "\t");
                preOrder(root.l, ref result1);                
                preOrder(root.r, ref result1);
            }
        }
        static void postOrder(node root, ref StringBuilder result2)
        {
            if (root != null)
            {
                postOrder(root.l, ref result2);                
                postOrder(root.r, ref result2);
                result2.Append(root.k + "\t");
            }
        }
    }
}
