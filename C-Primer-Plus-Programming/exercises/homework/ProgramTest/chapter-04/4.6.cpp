#include <iostream>
#include <cmath>
#include <ctime>
#include <cstdlib>
#define PI acos(-1)
using namespace std;

int main()
{
    srand(time(0));
    double a[3];
    double x[3];
    double y[3];
    int r = 40;
    for(int i = 0;i <3;i++)
    {
        a[i] = rand() % 20000 / 10000.0 * (2 * PI);
        x[i] = r * cos(a[i]);
        y[i] = r * sin(a[i]);
        cout<<a[i]<<" "<<x[i]<<" "<<y[i]<<endl;
    }

    /*
    double distance[3];
    for(int i = 0;i < 3;i++)
    {
        distance[i] = sqrt(pow())
    }
    */

    double aa,bb,cc;
    aa = sqrt(pow(x[0] - x[1],2) + pow(y[0] - y[1],2));
    bb = sqrt(pow(x[0] - x[2],2) + pow(y[0] - y[2],2));
    cc = sqrt(pow(x[2] - x[1],2) + pow(y[2] - y[1],2));
    cout<<aa<<endl;
    cout<<bb<<endl;
    cout<<cc<<endl;
    double aaa,bbb,ccc;
    aaa = acos((pow(aa,2) - pow(bb,2) - pow(cc,2)) / (-2 * bb * cc)) / PI * 180.0;
    bbb = acos((pow(bb,2) - pow(aa,2) - pow(cc,2)) / (-2 * aa * cc)) / PI * 180.0;
    ccc = acos((pow(cc,2) - pow(bb,2) - pow(aa,2)) / (-2 * bb * aa)) / PI * 180.0;
    cout<<"*********"<<endl;
    cout<<aaa<<endl;
    cout<<bbb<<endl;
    cout<<ccc<<endl;
}
