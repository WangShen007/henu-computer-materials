#include <iostream>

using namespace std;

int main()
{
    double sum = 0;
    for(int i = 1;i <= 98 / 2;i++)
    {
        sum += (2.0 * i - 1.0) / (2.0 * i + 1.0);
    }
    cout<<sum<<endl;
}
