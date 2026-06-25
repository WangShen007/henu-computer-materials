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
    int sum = 0;
    for (int i = 0; i < n; i++)
    {
        sum += x[i];
    }
    cout<<sum / n<<" is the average of the numbers."<<endl;
    int count = 0;
    for(int i = 0; i < n; i++)
    {
        if(x[i] > sum / n)
        {
            count++;
        }
    }
    cout<<count<<" numbers are greater than the average."<<endl;
    return 0;
}