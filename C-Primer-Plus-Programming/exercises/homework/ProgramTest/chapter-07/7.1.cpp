#include <iostream>

using namespace std;
/*
4
40 55 70 58
*/
int main()
{
    int len;
    cout<<"Enter the number of students: ";
    cin>>len;
    int* grade = new int [len];
    char score[len];
    int best = 80;//Âú·ÖÊÇ80
    cout<<"Enter "<<len<<" scores: ";
    for(int i = 0; i < len;i++)
    {
        cin>>grade[i];
    }
    for(int i = 0;i < len; i++)
    {
        if(grade[i] >= best - 10)
        {
            score[i] = 'A';
        }
        else if(grade[i] >= best - 20)
        {
            score[i] = 'B';
        }
        else if(grade[i] >= best - 30)
        {
            score[i] = 'C';
        }
        else if(grade[i] >= best - 40)
        {
            score[i] = 'D';
        }
        else
        {
            score[i] = 'F';
        }
        cout<<"Student "<<i<<" score is "<<grade[i]<<" and grade is "<<score[i]<<endl;
    }
    delete [] grade;
    grade = NULL;
}
