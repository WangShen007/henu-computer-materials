#include <iostream>

using namespace std;

template <typename T>

T maxValue(T a[], int n)
{
    T max = a[0];
    for (int i = 1; i < n; i++)
    {
        if (a[i] > max)
        {
            max = a[i];
        }
    }
    return max;
}


int main()
{
    int a[] = {1, 2, 3, 4, 5};
    double b[] = {1.1, 2.2, 3.3, 4.4, 5.5};
    cout << "Max of a: " << maxValue(a, 5) << endl;
    cout << "Max of b: " << maxValue(b, 5) << endl;
    string c[] = {"a", "b", "c", "d", "e"};
    cout << "Max of c: " << maxValue(c, 5) << endl;
    return 0;
}