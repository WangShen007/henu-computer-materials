#include <iostream>

using namespace std;

int main()
{
    cout << "Enter v0, v1, and t: " ;
    double v0,v1,t;
    cin>>v0>>v1>>t;
    double a = (v1 - v0) / t;
    cout<<"The average acceleration is "<<a<<endl;
}
