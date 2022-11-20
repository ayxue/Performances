#include "leet.h"

struct ListNode {
    int val;
    ListNode* next;
    ListNode() : val(0), next(nullptr) {}
    ListNode(int x) : val(x), next(nullptr) {}
    ListNode(int x, ListNode* next) : val(x), next(next) {}
};

ListNode* addTwoNumbers(ListNode* l1, ListNode* l2) 
{
    return addTwoNumbers(l1, l2, 0);
}


ListNode* addTwoNumbers(ListNode* l1, ListNode* l2, int addition)
{
    if (l1 == nullptr && l2 == nullptr && addition == 0)
        return nullptr;

    ListNode* result = new ListNode();
    result->val = (l1 == nullptr ? 0 : l1->val) + (l2 == nullptr ? 0 : l2->val) + addition;
    int nextAddition = result->val / 10;
    result->val = result->val % 10;
    result->next = addTwoNumbers(l1 == nullptr ? nullptr : l1->next, l2 == nullptr ? nullptr : l2->next, nextAddition);
    return result;
}