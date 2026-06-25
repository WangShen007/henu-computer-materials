#include <iostream>
#include <vector>

using namespace std;

bool validInput(vector<char> &input)
{
    for(int i=0; i<input.size(); i++)
    {
        if(input[i] < 'A' || input[i] > 'A' + input.size() - 1)
        {
            return false;
        }
    }
    return true;
}

bool checkAll(vector<char> &input)
{
    vector<bool> visited(input.size(), false);
    for(int i = 0;i < input.size(); i++)
    {
        visited[input[i] - 'A'] = true;
    }
    for(int i = 0; i < visited.size(); i++)
    {
        if(!visited[i])
        {
            return false;
        }
    }
    return true;
}

bool NoRepeats(vector<char> &input)
{
    vector<bool> visited(input.size(), false);
    for(int i = 0;i < input.size(); i++)
    {
        if(visited[input[i] - 'A'])
        {
            return false;
        }
        visited[input[i] - 'A'] = true;
    }
    return true;
}

int main()
{
    cout<<"Enter number n: ";
    int n;
    cin>>n;
    cout<<"Enter 4 rows of letters separated by spaces: ";
    vector<vector<char>> input;
    for(int i=0; i<4; i++)
    {
        vector<char> row;
        for(int j=0; j<n; j++)
        {
            char temp;
            cin>>temp;
            row.push_back(temp);
        }
        if(!validInput(row))
        {
            cout<<"Wrong input: "<<"the letters must be between A and "<<char('A' + n - 1)<<".\n";
            return 0;
        }
        input.push_back(row);
    }
    for(int i=0; i<4; i++)
    {
        if(!checkAll(input[i]))
        {
            cout<<"Wrong input: "<<"each letter must appear exactly once.\n";
            return 0;
        }
        vector<char> temp;
        for(int j = 0; j < n; j++)
        {
            temp.push_back(input[i][j]);
        }
        if(!checkAll(temp))
        {
            cout<<"Wrong input: "<<"each letter must appear exactly once.\n";
            return 0;
        }
    }

    bool flag = true;
    for(int i=0; i<n; i++)
    {
        vector<char> temp;
        for(int j=0; j<4; j++)
        {
            temp.push_back(input[j][i]);
        }
        if(!NoRepeats(temp))
        {
            cout<<"Wrong input: "<<"each letter must appear exactly once.\n";
            return 0;
        }
    }
    if(flag)
    {
        cout<<"The input is a Latin square.\n";
    }

}