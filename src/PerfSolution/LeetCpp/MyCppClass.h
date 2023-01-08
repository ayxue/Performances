#pragma once
#include "InputParam.h"
#include "Output.h"

namespace CppTests_Mine
{
	class MyCppClass
	{
		public:
			Output Add(InputParam i, InputParam j);
	};
}


extern "C"
{
	__declspec(dllexport) long _cdecl SumArrayTest(int* height, int size);
}


