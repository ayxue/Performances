#include "MyCppClass.h"
using namespace CppTests_Mine;


Output MyCppClass::Add(InputParam i, InputParam j)
{
	Output o;
	o.Output = i.Input + j.Input;
	return o;
}


extern "C"
{
	__declspec(dllexport) long _cdecl SumArrayTest(int* height, int size)
	{
		long sum = 0;
		for (int i = 0; i < size; i++)
			sum += height[i];

		return sum;
	}
}
