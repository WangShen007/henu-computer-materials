#include <iostream>
#include <algorithm>

using namespace std;

int start(const string &s, int x)
{
    size_t pos1 = s.find("ATG", x);
    if(pos1 != string::npos)
    {
        return pos1;
    }
    else
    {
        return s.size();
    }
}

int endd(const string &s, int x)
{
    size_t pos1 = s.find("TGA", x + 3);
    size_t pos2 = s.find("TAG", x + 3);
    size_t pos3 = s.find("TAA", x + 3);

    size_t minPos = min({pos1, pos2, pos3});

    if(minPos != string::npos)
    {
        return minPos;
    }
    else
    {
        return s.size();
    }
}

int main()
{
    cout<<"Enter a genome string: ";
    string s;
    cin>>s;

    for(int i = 0; i < s.size();)
    {
        int start_pos = start(s, i);
        if (start_pos == s.size())
        {
            break;
        }
        int end_pos = endd(s, start_pos);
        if (end_pos == s.size())
        {
            break;
        }
        cout << s.substr(start_pos + 3, end_pos - start_pos - 3) << endl;
        i = end_pos + 3;
    }
}


//TTATGTTTTAAGGATGGGGCGTTAGTT






/*
int endd(const string &s, int x)
{
    size_t pos1 = s.find("TGA", x);
    size_t pos2 = s.find("TAG", x);
    size_t pos3 = s.find("TAA", x);
    size_t pos4 = s.find("ATG", x);

    size_t minPos = min(min(pos1, pos2),min(pos3, pos4));

    if (minPos != s.size())
    {
        return minPos;
    }
    else
    {
        return s.size() + 1;
    }
}

int endd(const string &s, int x)
{
    if(s.find("TGA",x) != string::npos)
    {
        return s.find("TGA",x);
    }
    else if(s.find("TAG",x) != string::npos)
    {
        return s.find("TAG",x);
    }
    else if(s.find("TAA",x) != string::npos)
    {
        return s.find("TAA",x);
    }
    else if(s.find("ATG",x) != string::npos)
    {
        return s.find("ATG",x);
    }
    else
    {
        return s.size() + 1;
    }
}

int main()
{
    cout<<"Enter a genome string: ";
    string s;
    cin>>s;
    if(start(s, 0) == -1)
     {
        cout<<"no gene is found"<<endl;
        return 0;
     }

    for(int i = 0; i < s.size();)
    {
    int end = endd(s, i);
    if (end == s.size() + 1)
    {
        break;
    }
    cout << s.substr(start(s, i) + 3, end - start(s, i) - 3) << endl;
    i = end + 3;
    }
}
*/
//TTATGTTTTAAGGATGGGGCGTTAGTT