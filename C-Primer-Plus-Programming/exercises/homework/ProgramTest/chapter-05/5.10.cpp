#include <iostream>
#include <algorithm>
#include <string>
using namespace std;

int main()
{
    int n;
    cout<<"Enter the number of students: ";
    cin>>n;
    string name[n];
    double grade[n];
    double grade2[n];
    for(int i = 0;i < n;i++)
    {
        cout<<"Enter the name of the student: ";
        cin.get();
        getline(cin,name[i]);
        //cin>>name[i];
//        cin.getline(name[i],50);
        cout<<"Enter the grade of the student: ";
        cin>>grade[i];
        grade2[i] = grade[i];
    }


    sort(grade2,grade2+n,greater<double>());
    double grademax = grade2[0];
    int index = find(grade,grade + n,grademax) - grade;
    cout<<"The student is: "<<name[index]<<" "<<grademax<<endl;
}


/*
3
Jack
99.5
Sonder Elysia
100.0
Utopia
50
*/
