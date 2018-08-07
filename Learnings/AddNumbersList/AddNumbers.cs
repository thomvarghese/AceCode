using System.Collections.Generic;

namespace AddNumbersList
{
    public class AddNumbers
    {
        public ListNode AddTwoNumbersReverse(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;
            int carry = 0;
            ListNode newList = new ListNode(0);
            ListNode curr = newList;
            while (l1 != null || l2 != null)
            {
                int x = (l1 != null) ? l1.val : 0;
                int y = (l2 != null) ? l2.val : 0;
                int sum = x + y + carry;
                carry = sum / 10;
                ListNode node = new ListNode(sum % 10);
                curr.next = node;
                curr = curr.next;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }

            if (carry != 0)
                curr.next = new ListNode(carry);

            return newList.next;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null)
                return null;

            Stack<int> s1 = new Stack<int>();
            Stack<int> s2 = new Stack<int>();

            while (l1 != null)
            {
                s1.Push(l1.val);
                l1 = l1.next;
            }
            while (l2 != null)
            {
                s2.Push(l2.val);
                l2 = l2.next;
            }

            int carry = 0;
            ListNode head = null;
            while (s1.Count != 0 || s2.Count != 0)
            {
                int x = (s1.Count != 0) ? s1.Pop() : 0;
                int y = (s2.Count != 0) ? s2.Pop() : 0;
                int sum = x + y + carry;
                carry = sum / 10;
                ListNode node = new ListNode(sum % 10);
                if (head != null)
                    node.next = head;               
                head = node;
            }

            if (carry != 0)
            {
                var lastNode = new ListNode(carry);
                lastNode.next = head;
                head = lastNode;
            }

            return head;
        }
    }
}
