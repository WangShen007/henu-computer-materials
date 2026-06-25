#include <iostream>

using namespace std;
//n = 15
//use setw;
void displayPattern(int n)
{
    for(int i = 0;i <= n;i++)
    {
        for(int m = n - i;m > 0;m--)
        {
            cout<<" "<<" ";
        }
        for(int j = i;j > 0;j--)
        {
            cout<<j<<" ";
        }
        cout<<endl;
    }
}
int main()
{
    cout<<"Enter an integer: ";
    int n;
    cin>>n;
    displayPattern(n);
}
