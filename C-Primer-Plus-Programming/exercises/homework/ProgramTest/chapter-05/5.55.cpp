#include <iostream>
#include <ctime>
#include <iomanip>
#include <cstdlib>
using namespace std;

int main()
{
    cout<<"Main Menu"<<endl;
    cout<<"1: Addition"<<endl;
    cout<<"2: Subtraction"<<endl;
    cout<<"3: Multiplication"<<endl;
    cout<<"4: Division"<<endl;
    cout<<"5: Exit"<<endl;
    cout<<"Enter a choice: ";
    int choice;
    cin>>choice;
    srand(time(0));
    while(choice != 5)
    {
        if(choice == 1)
        {
            int num1,num2;
            num1 = rand() % 10;
            num2 = rand() % 10;
            cout<<"What is "<<num1<<" + "<<num2<<"? ";
            int answer;
            cin>>answer;
            if(answer == num1 + num2)
            {
                cout<<"Correct"<<endl;
            }
            else
            {
                cout<<"Your answer is wrong. The correct answer is "<<num1 + num2<<endl;
            }
        }

        else if(choice == 2)
        {
            int num1,num2;
            num1 = rand() % 10;
            num2 = rand() % 10;
            if(num2 > num1)
            {
                int temp = num2;
                num2 = num1;
                num1 = temp;
            }
            cout<<"What is "<<num1<<" - "<<num2<<"? ";
            int answer;
            cin>>answer;
            if(answer == num1 - num2)
            {
                cout<<"Correct"<<endl;
            }
            else
            {
                cout<<"Your answer is wrong. The correct answer is "<<num1 - num2<<endl;
            }
        }

        else if(choice == 3)
        {
            int num1,num2;
            num1 = rand() % 10;
            num2 = rand() % 10;
            cout<<"What is "<<num1<<" * "<<num2<<"? ";
            int answer;
            cin>>answer;
            if(answer == num1 * num2)
            {
                cout<<"Correct"<<endl;
            }
            else
            {
                cout<<"Your answer is wrong. The correct answer is "<<num1 * num2<<endl;
            }
        }

        else if(choice == 4)
        {
            double num1,num2;
            num1 = rand() % 10;
            num2 = rand() % 10;
            while(num2 == 0)
            {
                num2 = rand() % 10;
            }
            cout<<"What is "<<num1<<" / "<<num2<<"? ";
            double answer;
            cin>>answer;
            double correct = num1 / num2;
            if(answer == correct)
            {
                cout<<"Correct"<<endl;
            }
            else
            {
                cout<<"Your answer is wrong. The correct answer is "<<correct<<endl;
            }
        }

        else
        {

        }

        cout<<"Main Menu"<<endl;
        cout<<"1: Addition"<<endl;
        cout<<"2: Subtraction"<<endl;
        cout<<"3: Multiplication"<<endl;
        cout<<"4: Division"<<endl;
        cout<<"5: Exit"<<endl;
        cout<<"Enter a choice: ";
        cin>>choice;
    }
    return 0;
}



























/*
#include <iostream>
#include <ctime>
#include <iomanip>
#include <cstdlib>
using namespace std;

//void mainMenu()
//{
//    cout<<"Main Menu"<<endl;
//    cout<<"1: Addition"<<endl;
//    cout<<"2: Subtraction"<<endl;
//    cout<<"3: Multiplication"<<endl;
//    cout<<"4: Division"<<endl;
//    cout<<"5: Exit"<<endl;
//    cout<<"Enter a choice: ";
//    int choice;
//    cin>>choice;
//}

int main()
{
    cout<<"Main Menu"<<endl;
    cout<<"1: Addition"<<endl;
    cout<<"2: Subtraction"<<endl;
    cout<<"3: Multiplication"<<endl;
    cout<<"4: Division"<<endl;
    cout<<"5: Exit"<<endl;
    cout<<"Enter a choice: ";
    int choice;
    cin>>choice;
    srand(time(0));
    while(choice != 5)
    {

        if(choice == 1)
        {
            int num1,num2;
            num1 = rand() % 10;
            num2 = rand() % 10;
//            if(num2 > num1)
//            {
//                int temp = num2;
//                num2 = num1;
//                num1 = temp;
//            }
            cout<<"What is "<<num1<<" + "<<num2<<"? ";
            int answer;
            cin>>answer;
            if(answer == num1 + num2)
            {
                cout<<"Correct"<<endl;
            }
            else
            {
                cout<<"Your answer is wrong. The correct answer is "<<num1 + num2<<endl;
            }
        }

        else if(choice == 2)
        {
            int num1,num2;
            num1 = rand() % 10;
            num2 = rand() % 10;
            if(num2 > num1)
            {
                int temp = num2;
                num2 = num1;
                num1 = temp;
            }
            cout<<"What is "<<num1<<" - "<<num2<<"? ";
            int answer;
            cin>>answer;
            if(answer == num1 - num2)
            {
                cout<<"Correct"<<endl;
            }
            else
            {
                cout<<"Your answer is wrong. The correct answer is "<<num1 - num2<<endl;
            }
        }

        else if(choice == 3)
        {
            int num1,num2;
            num1 = rand() % 10;
            num2 = rand() % 10;
            cout<<"What is "<<num1<<" * "<<num2<<"? ";
            int answer;
            cin>>answer;
            if(answer == num1 * num2)
            {
                cout<<"Correct"<<endl;
            }
            else
            {
                cout<<"Your answer is wrong. The correct answer is "<<num1 * num2<<endl;
            }
        }

        else if(choice == 4)
        {
            int num1,num2;
            num1 = rand() % 10;
            num2 = rand() % 10;
            while(num2 == 0)
            {
                num2 = rand() % 10;
            }
            cout<<"What is "<<num1<<" / "<<num2<<"? ";
            int answer;
            cin>>answer;
            double correct = num1 / num2;
            if(answer == correct)
            {
                cout<<"Correct"<<endl;
            }
            else
            {
                cout<<"Your answer is wrong. The correct answer is "<<correct<<endl;
            }
        }

        else
        {

        }

        cout<<"Main Menu"<<endl;
        cout<<"1: Addition"<<endl;
        cout<<"2: Subtraction"<<endl;
        cout<<"3: Multiplication"<<endl;
        cout<<"4: Division"<<endl;
        cout<<"5: Exit"<<endl;
        cout<<"Enter a choice: ";
        int choice;
        cin>>choice;
    }
    return 0;
}
*/
