#include "Header.h";
using namespace std;


int PartSort(int array[], int from, int to)
{
	int key = from;
	while (from < to)
	{
		while (from < to && array[to] > array[key])
			to --;

		while (from < to && array[from] <= array[key])
			from++;

		int i = array[from];
		array[from] = array[to];
		array[to] = i;
	}
	int i = array[key];
	array[key] = array[from];
	array[from] = i;

	return from;
}


void QuickSort(int array[], int from, int to)
{
	if (from > to)
		return;

	int key = PartSort(array, from, to);

	QuickSort(array, 0, key - 1);
	QuickSort(array, key + 1, to);
}




void QuickSortCase()
{
	int a1[] = { 1, 343, 3,324, -19, -20 };

	QuickSort(a1, 0, 5);
}

