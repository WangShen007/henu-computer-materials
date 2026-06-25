#include <iostream>

using namespace std;

int main()
{
    int n;
    cout << "Enter a number: ";
    cin >> n;
    int x[n];
    for (int i = 0; i < n; i++)
    {
        cout << "Enter a number: ";
        cin >> x[i];
    }
    int len = 0;
    bool z[n];
    for(int i = 0; i < n; i++)
    {
        z[i] = true;
    }
    for(int i = 0;i < n;i++)
    {
        if(z[i] == true)
        {
            for(int j = i + 1;j < n;j++)
            {
                if(x[i] == x[j])
                {
                    //z[i] = true;
                    z[j] = false;
                }
                else
                {
                    //z[i] = true;
                    //z[j] = true;
                }
            }
            len++;
        }
    } 

    int c[len];
    int index = 0;
    for(int i = 0;i < n;i++)
    {
        if(z[i] == true)
        {
            c[index] = x[i];
            index++;
        }
    }
    for(int i = 0;i < len;i++)
    {
        cout<<c[i]<<" ";
    }
}