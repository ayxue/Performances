#include <string>
using namespace std;

string longestPalindrome(string s) 
{
    for (int length = s.size(); length > 0; length--)
        for (int i = 0; i + length <= s.size(); i++)
        {
            int start = i;
            int end = i + length - 1;

            while (start <= end)
            {
                if (s[start] != s[end])
                    break;

                start++;
                end--;
            }

            if (start >= end)
                return s.substr(i, length);
        }

    return "";
}

