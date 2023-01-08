#include "leet.h"

class _25ReverseNodesinkGroup {
public:
    ListNode* reverseKGroup(ListNode* head, int k)
    {
        if (k == 1)
            return head;

        ListNode* last = nullptr;
        ListNode* newHead = nullptr;
        ListNode* current = head;
        vector<ListNode*> group;
        while (current != nullptr)
        {
            group.push_back(current);
            if (group.size() == k)
            {
                current = reverse(group, last);
                last = group[0];
                if (newHead == nullptr)
                    newHead = group[group.size() - 1];

                group.clear();
            }
            else
                current = current->next;
        }

        return newHead;
    }


    ListNode* reverse(vector<ListNode*> group, ListNode* prevLast) {
        auto last = group[group.size() - 1];
        auto first = group[0];

        first->next = last->next;
        for (int i = group.size() - 1; i > 0; i--)
            group[i]->next = group[i - 1];

        if (prevLast != nullptr)
            prevLast->next = last;

        return first->next;
    }
};


