using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace LeetCodeCSharp
{
    /// <summary>
    /// https://leetcode.cn/problems/two-sum/
    /// 
    /// </summary>
    [MemoryDiagnoser]
    public class _02AddTwoNumbers
    {
        
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
               this.val = val;
                this.next = next;
            }
        }



        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            return AddTwoNumbers(l1, l2, 0);
        }


        private ListNode AddTwoNumbers(ListNode l1, ListNode l2, int addition)
        {
            if (l1 == null && l2 == null && addition == 0)
                return null;

            var result = new ListNode();
            result.val = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + addition;
            var nextAddition = result.val / 10;
            result.val = result.val % 10;
            result.next = AddTwoNumbers(l1 == null ? null : l1.next, l2 == null ? null : l2.next, nextAddition);
            return result;
        }


        [Benchmark]
        public ListNode Case1()
        {
            var l1 = new ListNode
            {
                val = 2,
                next = new ListNode
                {
                    val = 4,
                    next = new ListNode
                    {
                        val = 3
                    }
                }
            };

            var l2 = new ListNode
            {
                val = 5,
                next = new ListNode
                {
                    val = 6,
                    next = new ListNode
                    {
                        val = 7
                    }
                }
            };

            return AddTwoNumbers(l1, l2);
        }

        //[Benchmark]
        //public int[] Case2() => AddTwoNumbers(new[] { 4, 2, 7, 11, 15 }, 36);
    }
}
