#include "leet.h"
#include <iostream>

class _1339MaximumProductofSplittedBinaryTree {
public:
    TreeNode* _root;
    int maxProduct(TreeNode* root) {
        if (_root == nullptr)
            _root = root;

        if (root == nullptr)
            return INT_MIN;

        long p = productByNode(root);
        long leftMax = maxProduct(root->left);
        long rightMax = maxProduct(root->right);

        return max(max(p, leftMax), rightMax);
    }


    long productByNode(TreeNode* node) {
        if (node == nullptr)
            return INT_MIN;

        long p1 = productByEdge(node, node->left);
        long p2 = productByEdge(node, node->right);

        if (p1 > p2)
            return p1;

        return p2;
    }


    long productByEdge(TreeNode* from, TreeNode* to)
    {
        if (to == nullptr)
            return INT_MIN;

        long sum1 = getSum(to);
        long sum2 = getSum(_root) - sum1;

        std::cout << from->val << ", " << to->val << " | "
            << sum1 << " * " << sum2 << " = " << sum1 * sum2 << endl;
        return sum1 * sum2;
    }



    long getSum(TreeNode* node)
    {
        if (node == nullptr)
            return 0;

        long sum = node->val + getSum(node->left) + getSum(node->right);
        return sum;
    }

};