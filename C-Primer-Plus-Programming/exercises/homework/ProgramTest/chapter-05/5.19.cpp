#include <iostream>

using namespace std;

int main()
{
    cout << "Enter the number of lines: ";
    int line;
    cin>>line;

    for(int i = 1;i < line + 1;i++)
    {
        for(int m = 0;m < 2 * (line  - i);m++)
        {
            cout<<" ";
        }

        for(int j = i;j > 0;j--)
        {
            cout<<j<<" ";
        }

        for(int j = 1;j < i;j++)
        {
            cout<<j + 1<<" ";
        }

        for(int m = 0;m < 2 * (line - 1);m++)
        {
            cout<<" ";
        }

        cout<<endl;
    }
}
