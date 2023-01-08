#include "leet.h"
#include <iostream>

/// <summary>
/// https://leetcode.cn/problems/merge-k-sorted-lists/
/// 
/// 
/// </summary>
class _23MergekSortedLists 
{
public:
    ListNode* mergeKLists(vector<ListNode*>& lists) {
        ListNode* prev = nullptr;
        ListNode* first = nullptr;

        int smallestNodeIndex;
        do
        {
            // vector里包含每个链表的当前Node，每次拿出最小的Node串到前一个节点，然后后移到下一个Node，继续再找下一个最小的node，直到都查完
            smallestNodeIndex = getSmallestNode(lists);
            std::cout << smallestNodeIndex << ", ";
            if (smallestNodeIndex >= 0)
            {
                if (prev == nullptr)
                    first = lists[smallestNodeIndex];
                else
                    prev->next = lists[smallestNodeIndex];

                prev = lists[smallestNodeIndex];
                lists[smallestNodeIndex] = lists[smallestNodeIndex]->next;
            }

        } while (smallestNodeIndex >= 0);

        std::cout << endl;
        return first;
    }

    int getSmallestNode(vector<ListNode*>& lists)
    {
        int smallestIndex = -1;
        for (int i = 0; i < lists.size(); i++)
        {
            if (lists[i] == nullptr)
                continue;

            if (smallestIndex < 0)
                smallestIndex = i;
            else if (lists[i]->val < lists[smallestIndex]->val)
                smallestIndex = i;
        }

        return smallestIndex;
    }
};

