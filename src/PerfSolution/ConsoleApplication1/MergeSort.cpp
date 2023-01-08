#include "Header.h";

using namespace std;

vector<int> Merge(vector<int>& array1, vector<int>& array2)
{
	vector<int> merged;
	int i = 0;
	int j = 0;

	while (merged.size() < array1.size() + array2.size())
	{
		if (i < array1.size() && j < array2.size())
		{
			if (array1[i] < array2[j])
			{
				merged.push_back(array1[i]);
				i++;
			}
			else
			{
				merged.push_back(array2[j]);
				j++;
			}
		}
		else if( i < array1.size())
		{
			merged.push_back(array1[i]);
			i++;
		}
		else if(j < array2.size())
		{
			merged.push_back(array2[j]);
			j++;
		}
	}

	return merged;
}


void MergeCase()
{
	vector<int> a1 = { 1,5,7,8,9 };
	vector<int> a2 = { 4, 6, 10, 11, 12 };

	auto merged = Merge(a1, a2);

}


vector<int> MergeSort(vector<int>& array)
{
	if (array.size() == 1)
		return array;

	int mid = array.size() / 2;
	vector<int> left;
	for (int i = 0; i < mid; i++)
		left.push_back(array[i]);

	vector<int> right;
	for (int j = mid; j < array.size(); j++)
		right.push_back(array[j]);

	auto leftSort = MergeSort(left);
	auto rightSort = MergeSort(right);
	return Merge(leftSort, rightSort);
}


void MergeSortCase()
{
	vector<int> a1 = {1, 343, 3,324, -19 };

	auto merged = MergeSort(a1);
}