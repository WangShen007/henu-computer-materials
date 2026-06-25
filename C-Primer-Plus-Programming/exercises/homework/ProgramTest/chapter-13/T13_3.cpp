#include <iostream>
#include <fstream>
#include <cstdlib>
#include <ctime>
using namespace std;

void output()
{
    ofstream output("Exercise13_3.txt");
    for(int i = 0; i < 10; i++)
    {
        int x = rand() % 100;
        output << x << " ";
    }
    output.close();
}

int sum()
{
    ifstream input("Exercise13_3.txt");
    int sum = 0;
    int number = 0;
    while(input >> number)
    {
        cout<<number<<" ";
        sum += number;
    }
    /*while (!input.eof())
    {
        input >> number;
        if(!input.eof())
        {
            break;
        }
        cout<<number<<" ";
        sum += number;
    }*/
    input.close();
    return sum;
}

int main()
{
    srand(time(0));
    output();
    cout<<sum()<<endl;
    return 0;
}