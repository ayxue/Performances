#include <vector>
using namespace std;

double findMedianSortedArrays(vector<int>& nums1, vector<int>& nums2)
{
    int i = 0;
    int j = 0;
    int count = 0;

    int current = 0;
    int prev = 0;
    while (count <= ((nums1.size() + nums2.size()) / 2))
    {
        prev = current;
        if (i < nums1.size() && j < nums2.size())
        {
            if (nums1[i] < nums2[j])
            {
                current = nums1[i];
                i++;
            }
            else
            {
                current = nums2[j];
                j++;
            }
        }
        else if (i < nums1.size())
        {
            current = nums1[i];
            i++;
        }
        else if (j < nums2.size())
        {
            current = nums2[j];
            j++;
        }

        count++;
    }

    if ((nums1.size() + nums2.size()) % 2 == 0)
        return (current + prev) / 2.0;

    return current;
}