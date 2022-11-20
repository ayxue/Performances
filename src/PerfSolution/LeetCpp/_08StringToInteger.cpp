#include <string>
using namespace std;

int myAtoi(string s) 
{
    long result = 0;
    int sign = 1;

    bool allowSpace = true;
    bool allowSign = true;
    for (int i = 0; i < s.size(); i++)
    {
        if (s[i] == ' ' && allowSpace)
            continue;
        else if ((s[i] == '+' || s[i] == '-') && allowSign)
        {
            allowSpace = false;
            allowSign = false;
            sign = (s[i] == '-' ? -1 : 1);
            continue;
        }

        int val = s[i] - '0';
        if (val < 0 || val > 10)
            break;

        allowSpace = false;
        allowSign = false;
        result = result * 10 + val;
        if (sign * result > INT_MAX)
            return INT_MAX;

        if (sign * result < INT_MIN)
            return INT_MIN;
    }

    result = sign * result;
    return (int)result;
}

