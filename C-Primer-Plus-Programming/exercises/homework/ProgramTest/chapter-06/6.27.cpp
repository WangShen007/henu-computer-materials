#include <iostream>
using namespace std;

double sqrt(int n)
{
    double nextguess = 1.1;
    double lastguess = 2.5;
    while(!(nextguess - lastguess <= 0.0001) || !(lastguess - nextguess <= 0.0001))
    {
        double temp = nextguess;
        nextguess = (lastguess + (n / lastguess)) / 2.0;
        lastguess = temp;
    }
    return nextguess;
}

int main()
{
    cout<<"Enter an integer: ";
    int n;
    cin>>n;
    cout<<sqrt(n)<<endl;
}
