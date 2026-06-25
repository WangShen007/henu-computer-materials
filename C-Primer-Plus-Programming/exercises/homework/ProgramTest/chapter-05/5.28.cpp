#include <iostream>
#include <iomanip>
using namespace std;

int main()
{
    double e = 1;

    for(int x = 10000;x <= 100000;x += 10000)
    {

    for(int i = 1;i <= x;i++)
    {

        double ii = 1.0;
        for(int x = 1;x <= i;x++)
        {
            ii *= x;
        }
        e += 1.0 / ii;
    }
        cout<<fixed<<setprecision(50)<<e<<endl<<endl;
        e = 1;

    }
}
