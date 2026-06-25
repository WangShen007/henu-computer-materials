#include <iostream>
#include <ctime>
#include <cstdlib>
using namespace std;
/*
void game()
{
    srand(time(0));
    int num1 = rand() % 6 + 1;
    int num2 = rand() % 6 + 1;
    int sum = num1 + num2;
    cout<<"You rolled "<<num1<<" + "<<num2<<" = "<<num1 + num2<<endl;
    if(sum == 2 || sum == 3 || sum == 12)
    {
        cout<<"You lose"<<endl;
    }
    else if(sum == 7 || sum == 11)
    {
        cout<<"You win"<<endl;
    }
    else
    {
        cout<<"point is "<<sum<<endl;
        while(sum != 0)
        {
            int num3 = rand() % 6 + 1;
            int num4 = rand() % 6 + 1;
            int sum2 = num3 + num4;
            cout<<"You rolled "<<num3<<" + "<<num4<<" = "<<num3 + num4<<endl;
            if(sum2 == sum)
            {
                cout<<"You win"<<endl;
                break;
            }
            else if(sum2 == 7)
            {
                cout<<"You lose"<<endl;
                break;
            }
            else
            {
                cout<<"point is "<<sum2<<endl;
            }
        }
    }
}
*/
int main()
{
    srand(time(0));
    int summm = 0;
    for(int i = 0;i < 10000;i++)
    {
        int num1 = rand() % 6 + 1;
        int num2 = rand() % 6 + 1;
        int sum = num1 + num2;
        cout<<"You rolled "<<num1<<" + "<<num2<<" = "<<num1 + num2<<endl;
        if(sum == 2 || sum == 3 || sum == 12)
        {
            cout<<"You lose"<<endl<<endl;
        }
        else if(sum == 7 || sum == 11)
        {
            cout<<"You win"<<endl<<endl;
            summm++;
        }
        else
        {
            cout<<"point is "<<sum<<endl;
            while(sum != 0)
            {
                int num3 = rand() % 6 + 1;
                int num4 = rand() % 6 + 1;
                int sum2 = num3 + num4;
                cout<<"You rolled "<<num3<<" + "<<num4<<" = "<<num3 + num4<<endl;
                if(sum2 == sum)
                {
                    cout<<"You win"<<endl<<endl;
                    summm++;
                    break;
                }
                else if(sum2 == 7)
                {
                    cout<<"You lose"<<endl<<endl;
                    break;
                }
                else
                {
                    cout<<"point is "<<sum2<<endl;
                }
            }
        }
    }
    cout<<summm<<endl;
}


/*
#include <iostream>
#include <ctime>
#include <cstdlib>
using namespace std;

//void roll()
//{
//    srand(time(0));
//    int num1,int num2;
//    num1 = rand() % 6 + 1;
//    num2 = rand() % 6 + 1;
//    cout<<"You rolled "<<num1<<" + "<<num2<<" = "<<num1 + num2;
//}

int main()
{
    srand(time(0));
    int num1 = rand() % 6 + 1;
    int num2 = rand() % 6 + 1;
    int sum = num1 + num2;
    cout<<"You rolled "<<num1<<" + "<<num2<<" = "<<num1 + num2<<endl;
    if(sum == 2 || sum == 3 || sum == 12)
    {
        cout<<"You lose"<<endl;
    }
    else if(sum == 7 || sum == 11)
    {
        cout<<"You win"<<endl;
    }
    else
    {
        cout<<"point is "<<sum<<endl;
        while(sum != 0)
        {
            int num3 = rand() % 6 + 1;
            int num4 = rand() % 6 + 1;
            int sum2 = num3 + num4;
            cout<<"You rolled "<<num3<<" + "<<num4<<" = "<<num3 + num4<<endl;
            if(sum2 == sum)
            {
                cout<<"You win"<<endl;
                break;
            }
            else if(sum2 == 7)
            {
                cout<<"You lose"<<endl;
                break;
            }
            else
            {
                cout<<"point is "<<sum2<<endl;
            }
        }
    }
}
*/
