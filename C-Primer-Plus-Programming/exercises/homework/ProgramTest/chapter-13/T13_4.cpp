#include <iostream>
#include <fstream>
#include <cstdlib>
#include <ctime>
#include <algorithm>
using namespace std;

void test01()
{
    ofstream out("Exercise13_4.txt");
    for(int i = 0; i < 100; i++)
    {
        out << rand() << " ";
    }
    out.close();
}

int* test02()
{
    ifstream in("Exercise13_4.txt");
    int i;
    int *arr = new int[100];
    int k = 0;
    while(in >> i)
    {
        arr[k] = i;
        k++;
    }
    sort(arr, arr + 100);
    in.close();
    return arr;
}

void test03(int* arr)
{
    ofstream out("Exercise13_4.txt");
    for(int i = 0; i < 100; i++)
    {
        out << arr[i] << " ";
    }
    out.close();
}

int main()
{
    srand(time(0));
    test01();
    int* arr = test02();
    test03(arr);
    delete[] arr;
    return 0;
}