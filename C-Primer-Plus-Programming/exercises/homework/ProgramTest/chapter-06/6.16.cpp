#include <iostream>
#include <ctime>
#include <cstdlib>
using namespace std;
void printMatrix(int n)
{
    srand(time(0));
    for(int i = 1;i <= n;i++)
    {
        for(int j = 1;j <= n;j++)
        {
            cout<<rand() % 2<<" ";
        }
        cout<<endl;
    }
}
int main()
{
    cout<<"Enter an integer: ";
    int n;
    cin>>n;
    printMatrix(n);
}
