#include <iostream>
#include <vector>

using namespace std;

bool check(string s)
{
    char a[3] = {'(','[','{'};
    char b[3] = {')',']','}'};
    vector<char> stack;
    for(int i = 0;i < s.size();i++)
    {
        for(int j = 0;j < 3;j++)
        {
            if(s[i] == a[j])
            {
                stack.push_back(s[i]);
                break;
            }
            if(s[i] == b[j])
            {
                if(stack.size() == 0)
                    return false;
                if(stack[stack.size() - 1 ] == a[j])
                    stack.pop_back();
                else
                    return false;
            }
        }
    }
    if(stack.size() == 0)
        return true;
    else
        return false;
}

int main()
{
    string s;
    cout << "Enter a string: ";
    cin >> s;
    if(check(s))
        cout << "The string is valid" << endl;
    else
        cout << "The string is invalid" << endl;
    return 0;
}





/*
bool check(string s)
{
    char a[3] = {'(','[','{'};
    char b[3] = {')',']','}'};
    vector<char> stack;
    for (int i = 0; i < s.size(); i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (s[i] == a[j])
            {
                stack.push_back(s[i]);
                break;
            }
            if (s[i] == b[j])
            {
                if (stack.size() == 0)
                    return false;
                if (stack[stack.size() - 1] == a[j])
                    stack.pop_back();
                else
                    return false;
            }
        }
    }
}
*/