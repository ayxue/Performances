#include <vector>
#include <string>
using namespace std;


struct TreeNode {
	int val;
	TreeNode* left;
	TreeNode* right;
	TreeNode() : val(0), left(nullptr), right(nullptr) {}
	TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
	TreeNode(int x, TreeNode* left, TreeNode* right) : val(x), left(left), right(right) {}
	
};


/// <summary>
/// 
/// </summary>
/// <param name="nums"></param>
/// <param name="target"></param>
/// <returns></returns>
vector<int> twoSumDic(vector<int>& nums, int target);
vector<int> twoSum(vector<int>& nums, int target);

/// <summary>
/// 两数相加
/// https://leetcode.cn/problems/add-two-numbers/submissions/
/// </summary>
struct ListNode {
	int val;
	ListNode* next;
	ListNode() : val(0), next(nullptr) {}
	ListNode(int x) : val(x), next(nullptr) {}
	ListNode(int x, ListNode* next) : val(x), next(next) {}
};
ListNode* addTwoNumbers(ListNode* l1, ListNode* l2);
ListNode* addTwoNumbers(ListNode* l1, ListNode* l2, int addition);


/// <summary>
/// 中位数
/// https://leetcode.cn/problems/median-of-two-sorted-arrays/
/// </summary>
double findMedianSortedArrays(vector<int>& nums1, vector<int>& nums2);


/// <summary>
/// 最长回文 https://leetcode.cn/problems/longest-palindromic-substring/submissions/
/// </summary>
string longestPalindrome(string s);

/// <summary>
/// 整数翻转 https://leetcode.cn/problems/reverse-integer/submissions/
/// </summary>
int ReverseInteger(int x);

/// <summary>
/// 字符串转整数 https://leetcode.cn/problems/string-to-integer-atoi/
/// </summary>
int myAtoi(string s);

