#include "Header.h";

int BinarySearch(int array[], int val, int from, int to)
{
    if (from > to)
        return -1;

    int index = (from + to) / 2;
    if (array[index] == val)
        return index;

    if (array[index] > val)
        return BinarySearch(array, val, from, index - 1);

    return BinarySearch(array, val, index + 1, to);
}


void BinarySearchCase()
{
    int array[] = { 1, 2, 5, 8, 9, 10 };

    int index = BinarySearch(array, 1, 0, 5);
    index = BinarySearch(array, 0, 0, 5);
    index = BinarySearch(array, 10, 0, 5);
    index = BinarySearch(array, 11, 0, 5);

    std::cout << "Hello World!\n";
}