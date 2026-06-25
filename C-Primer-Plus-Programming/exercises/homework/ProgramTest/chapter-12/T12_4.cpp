#include <iostream>

using namespace std;

template <typename T>

bool isSorted(const T list[], int size)
{
    for (int i = 0; i < size - 1; i++)
    {
        if (list[i] > list[i + 1])
        {
            return false;
        }
    }
    return true;
}

int main()
{
    int list1[] = {1, 2, 3, 4, 5};
    cout << isSorted(list1, 5) << endl;

    int list2[] = {1, 2, 3, 5, 4};
    cout << isSorted(list2, 5) << endl;

    return 0;
}