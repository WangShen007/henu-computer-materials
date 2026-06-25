#include <iostream>
#include <cmath>
#include <iomanip>
using namespace std;

int main()
{
    double pi = 0;
    for(int n = 10000;n <= 100000;n += 10000)
    {
        for(int i = 1;i <= n;i ++)
        {
            pi += pow(-1,i + 1) / (2.0 * i - 1.0);
        }
        pi *= 4;
        cout<<fixed<<setprecision(50)<<pi<<endl<<endl;
        pi = 0;
    }
}
