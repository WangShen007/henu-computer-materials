#include <iostream>
#include <ctime>
#include <cstdlib>
using namespace std;

int main()
{
    srand(time(0));
    int x = rand() % 2;
    int guass;
    cin>>guass;
    if(x == guass)
        cout<<"Right";
    else
        cout<<"Wrong";
}
