#include "MyCppClass.h"
using namespace CppTests_Mine;


Output MyCppClass::Add(InputParam i, InputParam j)
{
	Output o;
	o.Output = i.Input + j.Input;
	return o;
}
