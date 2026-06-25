#include <iostream>
#include <cstdlib>

using namespace std;

int caculateindex(int num)
{
    int sum = 0;

    do
    {
        sum++;
        num /= 10;
    }while(num != 0);

    return sum;
}

string format(int number, int width)
{
    int index = caculateindex(number);

    char num[index];
    itoa(number, num, 10);

    string x;

    if(index > width)

    {
        for(int i = 0;i < index; i++)
        {
            x += num[i];
        }
    }

    else

    {
        for(int i = index; i < width; i++)
        {
            x += '0';
        }

        for(int i = 0;i < index;i++)
        {
            x += num[i];
        }

    }

    return x;
}

int main()
{
    cout<<"Enter a number and a width: ";
    int number;
    int width;
    cin>>number>>width;
    string x = format(number, width);
    cout<<x<<endl;
    return 0;
}
