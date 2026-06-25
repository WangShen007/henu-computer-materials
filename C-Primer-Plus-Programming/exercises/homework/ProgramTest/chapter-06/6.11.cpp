#include <iostream>

using namespace std;
void printChars(char ch1, char ch2, int numberPerLine)
{
    char i = ch1;
    int sum = 0;
    for(ch1;ch1 <= ch2;ch1++)
    {
        cout<<ch1<<" ";
        sum++;
        if(sum == numberPerLine)
        {
            cout<<endl;
            sum = 0;
        }
    }
}
int main()
{
    printChars('I', 'Z', 10);
}
