#include <iostream>

using namespace std;

int* doubleCapacity(const int* list, int size)
{
    int* newList = new int[size * 2];
    for (int i = 0; i < size; i++)
    {
        newList[i] = list[i];
    }
    return newList;
}

int main()
{
    int size = 5;
    int* list = new int[size];
    for (int i = 0; i < size; i++)
    {
        list[i] = i;
    }
    int* newList = doubleCapacity(list, size);
    for (int i = 0; i < size * 2; i++)
    {
        cout << newList[i] << " ";
    }
    cout << endl;
    delete[] list;
    delete[] newList;
    return 0;
}