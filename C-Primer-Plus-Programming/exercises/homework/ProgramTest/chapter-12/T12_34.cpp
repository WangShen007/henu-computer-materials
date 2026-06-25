#include <iostream>
#include <cmath>
#include <vector>
#include <cstdlib>
#include <ctime>

using namespace std;

int main()
{
    srand(time(0));
    vector<int> answer(0);
    int x = rand() % 100;
    int y = rand() % 100;
    cout<<"What is "<<x<<" - "<<y<<"? ";
        int result;
        cin>>result;
        if(result == x - y)
        {
            cout<<"You got it!"<<endl;
        }
        else
        {
            do
            {
                for(int i = 0; i < answer.size(); i++)
                {
                    if(answer[i] == result)
                    {
                        cout<<"You already entered "<<result<<endl;
                        break;
                    }
                }
                cout<<"Wrong answer. Try again. ";
                cout<<"What is "<<x<<" - "<<y<<"? ";
                answer.push_back(result);
                cin>>result;
            } while (result != x - y);
            cout<<"You got it!"<<endl;
        }
    return 0;
}