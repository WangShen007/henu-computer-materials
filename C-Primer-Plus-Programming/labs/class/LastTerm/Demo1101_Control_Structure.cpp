/*
 * 控制结构的连接方式：嵌套、堆叠
 * 堆叠：控制结构的顺序出现
 * 嵌套：控制结构里又出现了别的控制结构
 */

#include <iostream>

using namespace std;

int main()
{
    // 回文数判断，假定输入是五位数
    int selection;
    cout << "*********************************************" << endl;
    cout << "**           Welcome to app home           **" << endl;
    cout << "**           1: play palindromic           **" << endl;
    cout << "**           2: play leap year             **" << endl;
    cout << "**           3: play compute days          **" << endl;
    cout << "**           4: play Triangle              **" << endl;
    cout << "**           0: exit the app               **" << endl;
    cout << "*********************************************" << endl;
    cout << "Input your selection: ";
    cin >> selection;

    while(selection)
    {
        if(1==selection) // 回文数
        {
            int choice;
            int number;
            cout << "Do you want to play palindromic app?" << endl;
            cout << "If you want input 1, orelse input 0"  << endl;
            cout << "Input your choice: ";
            cin >> choice;
            while(choice)
            {
                cout << "Input a number: ";
                cin >> number;

                if(number/10000==number%10 && (number%10000)/1000==(number%100)/10)
                    cout << number << " is a palindromic number!" << endl;
                else
                    cout << number << " is not a palindromic number!" << endl;

                cout << "Do you want to play palindromic app agin?" << endl;
                cout << "If you want input 1, orelse input 0"  << endl;
                cout << "Input your choice: ";
                cin >> choice;
            }
        }
        if(2==selection) // 闰年判定
        {
            int choice;
            int year;
            cout << "Do you want to play leap year app?" << endl;
            cout << "If you want input 1, orelse input 0"  << endl;
            cout << "Input your choice: ";
            cin >> choice;
            while(choice)
            {
                cout << "Input a year: ";
                cin >> year;

                // 待添加的程序逻辑，此处是闰年判定
                if( 0==year%400 || (0==year%4&&0!=year%100) )
                    cout << year << " is a leap year!" << endl;
                else
                    cout << year << " is not a leap year!" << endl;

                cout << "Do you want to play leap year app again?" << endl;
                cout << "If you want input 1, orelse input 0"  << endl;
                cout << "Input your choice: ";
                cin >> choice;
            }
        }
        if(3==selection)// 日期计算 2023-11-1
        {
            int choice;
            int year,month,day;
            // Array:数组，指的是具有相同类型的一族元素的总称，元素紧挨着存储
            // 数组元素通过数组名和下标来引用，下标从0开始，直到数组元素个数-1，
            int Days[13]={0,31,28,31,30,31,30,31,31,30,31,30,31};
            int sum=0; //记录第几天
            cout << "Do you want to play Date Compute app?" << endl;
            cout << "If you want input 1, orelse input 0"  << endl;
            cout << "Input your choice: ";
            cin >> choice;
            while(choice)
            {
                cout << "Input a Date such as 2023 11 1:";
                cin >> year >> month >> day;
                sum=0;

                // 待添加的程序逻辑，此处是闰年判定
                if( 0==year%400 || (0==year%4&&0!=year%100) )
                    Days[2]++;

                for(int i=1; i<month;i++) //计算的是1月到month-1月的天数
                    sum+=Days[i];
                sum+=day;// 当月的天数
                cout << "Date:" << year << "-" << month
                     << "-" << day << " is the " << sum
                     << "th day of the year: " << year << endl;

                cout << "Do you want to play Date Compute app again?" << endl;
                cout << "If you want input 1, orelse input 0"  << endl;
                cout << "Input your choice: ";
                cin >> choice;
            }
        }

        cout << "*********************************************" << endl;
        cout << "**           Welcome to app home           **" << endl;
        cout << "**           1: play palindromic           **" << endl;
        cout << "**           2: play leap year             **" << endl;
        cout << "**           3: play compute days          **" << endl;
        cout << "**           0: exit the app               **" << endl;
        cout << "*********************************************" << endl;
        cout << "Input your selection: ";
        cin >> selection;
    }

    return 0;
}
