#include <iostream>

using namespace std;

int* count(const string& s)
{
    int* counts = new int [10];
    for(int i = 0;i < 10;i++)
    {
        counts[i] = 0;
    }
    for(int i = 0;i < s.length();i++)
    {
        if(s[i] >= '0' && s[i] <= '9')
        {
            counts[s[i] - '0']++;
        }
    }
    return counts;
}

void count(const string& s, int counts[], int size)
{
    for(int i = 0;i < size;i++)
    {
        counts[i] = 0;
    }
    for(int i = 0;i < s.length();i++)
    {
        if(s[i] >= '0' && s[i] <= '9')
        {
            counts[s[i] - '0']++;
        }
    }
}

int main()
{
    string s;
    cout<<"Enter a string: ";
    cin>>s;
    int* counts = count(s);
    for(int i = 0;i < 10;i++)
    {
        cout<<i<<" appears "<<counts[i]<<" times"<<endl;
    }

    int counts2[10];
    count(s, counts2, 10);
    //count(s, *&counts2, 10);//counts2 is a pointer to the first element of the array so we need to pass the address of the first element
    for(int i = 0;i < 10;i++)
    {
        cout<<i<<" appears "<<counts2[i]<<" times"<<endl;
    }


    delete[] counts;
    return 0;
}