#include <iostream>
#include <iomanip>
#include <ctime>
#include <cstdlib>
using namespace std;

int main()
{
    //side == 2;side / 2 == 1
    srand(time(0));
    int sum = 0;
    for(int i = 0;i < 1000000;i++)
    {
        double x = rand() % 20000 / 10000.0 - 1.0;
        double y = rand() % 20000 / 10000.0 - 1.0;
        //cout<<x<<" "<<y<<" ";
        if(((x >= 0 && x <= 1) && (y >= 0 && y <= 1) && (x + y < 1)) || ((x <= 0 && x >= -1) && (y >= -1 && y <= 1)))
        {
            sum++;
        }
    }
    cout<<sum<<endl;

    return 0;
}
