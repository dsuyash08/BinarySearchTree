
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chacking_binary_search_tree
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
            for (int i = 0; i < k; i++)
            {
                temp = new node();
                list.Add(temp);
            }
            for (int i = 0; i < k; i++)
            {
                string[] temp1 = Console.ReadLine().Split();
                list[i].k = int.Parse(temp1[0]);
                if (int.Parse(temp1[1]) != -1)
                {
                    list[i].l = list[int.Parse(temp1[1])];                   
                }
                if (int.Parse(temp1[2]) != -1)
                {
                    list[i].r = list[int.Parse(temp1[2])];                    
                }
            }
            int max = int.MinValue;
            int r = 0;
            if(list.Count > 0)
                inOrder(list[0],ref r,ref max);
            if (r != 1)
                Console.WriteLine("CORRECT"); 
            else
                Console.WriteLine("INCORRECT");
            Console.Read();
        }

        static void inOrder(node root,ref int r,ref int max)
        {
            if (root == null || r == 1)
                return;
            inOrder(root.l,ref r,ref max);
            if (root.k < max)
            {                
                r = 1;
                return;
            }
            max = root.k;
            inOrder(root.r,ref r,ref max);
        }       
    }
}
