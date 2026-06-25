#include <iostream>
#include <string>
#include <ctime>
#include <cstdlib>
#include <algorithm>//random-shuffle(a,a+?)
using namespace std;
void shuffle(string& s)
{
    srand(time(0));
    int digit = s.size();
    char a[digit];
    for(int i = 0;i < digit;i++)
    {
        a[i] = s.at(i);
    }
    random_shuffle(a,a + digit);
    string rand;
    for(int i = 0;i < digit;i++)
    {
        rand += a[i];
    }
    s = rand;
}

int main()
{
    cout<<"Enter a string: ";
    string s;
    cin>>s;
    shuffle(s);
    cout<<s<<endl;
}
