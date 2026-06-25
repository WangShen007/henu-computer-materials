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
    double gradesecond = grade2[1];
    int index2 = find(grade,grade + n,gradesecond) - grade;
    int index = find(grade,grade + n,grademax) - grade;
    cout<<"The first student is: "<<name[index]<<" "<<grademax<<endl;
    cout<<"The second student is: "<<name[index2]<<" "<<gradesecond<<endl;
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
