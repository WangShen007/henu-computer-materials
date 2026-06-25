#include <iostream>
#include <algorithm>

using namespace std;

int main()
{
    cout<<"Enter the integers between 1 and 100: ";

    int num[100];

    int x;// 用于读取输入来缓冲
    int n = -1;// 计数

    while(cin >> x)
    {
        n++;

        if(x == 0)
        {
            break;
        }

        num[n] = x;
    }

    sort(num,num + n);

    int location = 0;
    for(int i = 0;i < n + 1;i++)
    {
        int coun = 0;
        int number = num[location];
        for(int j = location;j < n + 1;j++)
        {
            if(number == num[j])
            {
                coun++;
            }
            else
            {
                location = j;
                i = j;
                break;
            }
        }
        cout<<number<<" occurs "<<coun<<" time";
        if(coun > 1)
        {
            cout<<"s";
        }
        cout<<endl;
    }
}
//2 5 6 5 4 3 23 43 2 0


/*
    int* number = new int [sum];
    for(int i = 0;i < 100;i++)
    {
        cin>>number[i];
        if(number[i] == 0)
        {
            break;
        }
        sum++;
    }
    delete [] number;
    number = NULL;
*/









/*
    int len;
    int* grade = new int [len];
    delete [] grade;
    grade = NULL;
*/
