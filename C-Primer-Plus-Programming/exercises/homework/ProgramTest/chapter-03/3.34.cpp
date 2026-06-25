#include <iostream>
#include <ctime>
#include <cstdlib>
using namespace std;

int main()
{
    srand(time(0));
    double x,y;
    x = rand() % 100000 / 1000.0 - 100 / 2;
    y = rand() % 200000 / 1000.0 - 200 / 2;
    cout<<"("<<x<<", "<<y<<")";
}
