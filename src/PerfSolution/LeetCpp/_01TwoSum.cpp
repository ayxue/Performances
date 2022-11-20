#include <vector>
#include <map>
using namespace std;


vector<int> twoSumDic(vector<int>& nums, int target) 
{
    map<int, int> map;
    for (vector<int>::size_type i = 0; i < nums.size(); i++)
    {
        int num1 = nums[i];
        int num2 = target - num1;

        auto iter = map.find(num2);
        if (iter != map.end())
        {
            vector<int> ret;
            ret.push_back((*iter).second);
            ret.push_back(i);
            return ret;
        }

        map[num1] = i;
    }

    return { 0,0 };
}



vector<int> twoSum(vector<int>& nums, int target) 
{
    vector<int> ret = { 0,0 };
    for (vector<int>::size_type i = 0; i < nums.size() - 1; i++)
    {
        int num2 = target - nums[i];
        for (vector<int>::size_type j = i + 1; j < nums.size(); j++)
            if (nums[j] == num2)
            {
                ret[0] = i;
                ret[1] = j;
                return ret;
            }
    }

    return { 0,0 };
}

