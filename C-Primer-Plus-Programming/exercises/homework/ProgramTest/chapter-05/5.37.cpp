#include <iostream>
#include <cmath>
#include <iomanip>
using namespace std;

int main()
{
    double sum = 0;
    for(int i = 1;i <= 624;i++)
    {
        sum += 1.0 / (sqrt(i) + sqrt(i + 1));
        //cout<<sum<<" ";
    }
    cout<<fixed<<setprecision(50)<<sum<<endl;
}
