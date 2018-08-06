using System;

namespace AddNumbersList
{
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = new ListNode(7);
            l1.next = new ListNode(1);
            l1.next.next = new ListNode(6);

            var l2 = new ListNode(5);
            l2.next = new ListNode(9);
            l2.next.next = new ListNode(2);
            var obj = new AddNumbers();




            ListNode result = obj.AddTwoNumbersReverse(l1, l2);
            PrintList(result);
            Console.ReadLine();

            //You are given two non - empty linked lists representing two non - negative integers.
            //The most significant digit comes first and each of their nodes contain a single digit.
            //Add the two numbers and return it as a linked list.
            //Input: (7-> 2-> 4-> 3) +(5-> 6-> 4)
            //Output: 7-> 8-> 0-> 7
            result = obj.AddTwoNumbers(l1, l2);
            PrintList(result);

            Console.ReadLine();
        }

        private static void PrintList(ListNode l1)
        {
            while (l1 != null)
            {
                Console.Write(l1.val);
                l1 = l1.next;
            }
        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
 
    
}
