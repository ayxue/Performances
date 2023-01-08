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
            // vector�����ÿ������ĵ�ǰNode��ÿ���ó���С��Node����ǰһ���ڵ㣬Ȼ����Ƶ���һ��Node������������һ����С��node��ֱ��������
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

