#include <iostream>
#include <iomanip>
#include <cmath>

using namespace std;

int main()
{
    cout <<left<<setw(12)<< "Number"<<setw(12)<<"SquareRoot"<<endl;
    int x = 0;
    for(int i = 0;i < 22;i += 2)
    {
        x = i;
        cout<<setw(12)<<x<<setw(12)<<fixed<<setprecision(4)<<sqrt(x)<<endl;
    }
}
