#include <iostream>
#include <cmath>
#include <iomanip>
//#include <bits/stdc++.h>
#define PI acos(-1)

using namespace std;

int main()
{
    cout<<"Enter the radius and length of cylinder: ";
    double r,l;
    cin>>r>>l;
    double area = r * r * PI;
    //cout<<"The area is: "<<area<<endl;
    area = floor(area*10000.0)/10000.0;
    cout<<"The area is: ";
    cout<<area<<endl;
    double volume = r * r * PI * l;
    cout<<"The volume is: "<<volume<<endl;
}
