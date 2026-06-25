#include <iostream>

using namespace std;

template <typename T>

void change(T& a, T& b)
{
    T temp = a;
    a = b;
    b = temp;
}

int main()
{
    int a = 1;
    int b = 2;
    change(a, b);
    cout << a << " " << b << endl;

    return 0;
}