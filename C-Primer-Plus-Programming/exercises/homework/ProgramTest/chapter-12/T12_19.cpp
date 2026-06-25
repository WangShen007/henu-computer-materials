#include <iostream>
#include <cstdlib>
#include <vector>
#include <ctime>
#include <cctype>
#include <sstream>
#include <cstring>
#include <algorithm>
#include <cmath>

using namespace std;

vector<string> names = {"Clubs", "Diamonds", "Hearts", "Spades"};
vector<string> values = {"Ace","2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};

bool expressionIsCorrect(string expression, vector<int> deck)
{
    vector<int> stack;
    stringstream ss(expression);
    while(!ss.eof())
    {
        string temp;
        ss >> temp;
        if(temp == "+")
        {
            if(stack.size() < 2)
            {
                return false;
            }
            int a = stack.back();
            stack.pop_back();
            int b = stack.back();
            stack.pop_back();
            stack.push_back(a + b);
        }
        else if(temp == "-")
        {
            if(stack.size() < 2)
            {
                return false;
            }
            int a = stack.back();
            stack.pop_back();
            int b = stack.back();
            stack.pop_back();
            stack.push_back(b - a);
        }
        else if(temp == "*")
        {
            if(stack.size() < 2)
            {
                return false;
            }
            int a = stack.back();
            stack.pop_back();
            int b = stack.back();
            stack.pop_back();
            stack.push_back(a * b);
        }
        else if(temp == "/")
        {
            if(stack.size() < 2)
            {
                return false;
            }
            int a = stack.back();
            stack.pop_back();
            int b = stack.back();
            stack.pop_back();
            stack.push_back(b / a);
        }
        else
        {
            if(isdigit(temp[0]))
            {
                stack.push_back(stoi(temp));
            }
            else
            {/*
                for(int i = 0;i < 4;i++)
                {
                    if(temp == values[deck[i] % 13] + " of " + names[deck[i] / 13])
                    {
                        stack.push_back(deck[i] % 13 + 1);
                        break;
                    }
                }*/
            }
        }
    }

    if(stack.back() == 24)
    {
        return true;
    }
    return false;
}

bool isValidExpression(double a, double b, char op, double &result) {
    if (op == '+') result = a + b;
    else if (op == '-') result = a - b;
    else if (op == '*') result = a * b;
    else if (op == '/') {
        if (b == 0) return false;
        result = a / b;
    }
    return true;
}

std::string removeTrailingZeros(double num) {
    std::ostringstream out;
    out << std::fixed << num;
    std::string str = out.str();
    str.erase(str.find_last_not_of('0') + 1, std::string::npos);
    if (str.back() == '.') {
        str.pop_back();
    }
    return str;
}

string replaceTemplateWithValues(const string& templateExpr, const vector<double>& nums, const vector<char>& ops) {
    string expr = templateExpr;
    size_t pos;
    while ((pos = expr.find('a')) != string::npos)
        expr.replace(pos, 1, removeTrailingZeros(nums[0]));
    while ((pos = expr.find('b')) != string::npos)
        expr.replace(pos, 1, removeTrailingZeros(nums[1]));
    while ((pos = expr.find('c')) != string::npos)
        expr.replace(pos, 1, removeTrailingZeros(nums[2]));
    while ((pos = expr.find('d')) != string::npos)
        expr.replace(pos, 1, removeTrailingZeros(nums[3]));
    while ((pos = expr.find("o1")) != string::npos)
        expr.replace(pos, 2, string(1, ops[0]));
    while ((pos = expr.find("o2")) != string::npos)
        expr.replace(pos, 2, string(1, ops[1]));
    while ((pos = expr.find("o3")) != string::npos)
        expr.replace(pos, 2, string(1, ops[2]));
    return expr;
}

string getSolution(vector<double> nums, vector<char> ops)
{
    vector<string> expressions = {
        "((a o1 b) o2 c) o3 d",
        "(a o1 (b o2 c)) o3 d",
        "a o1 ((b o2 c) o3 d)",
        "a o1 (b o2 (c o3 d))",
        "(a o1 b) o2 (c o3 d)"
    };
    do {
        do {
            for (const auto &expr : expressions) {
                double res1, res2, res3, res4, finalResult;
                if (expr == "((a o1 b) o2 c) o3 d") {
                    if (isValidExpression(nums[0], nums[1], ops[0], res1) &&
                        isValidExpression(res1, nums[2], ops[1], res2) &&
                        isValidExpression(res2, nums[3], ops[2], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return replaceTemplateWithValues(expr, nums, ops);
                } else if (expr == "(a o1 (b o2 c)) o3 d") {
                    if (isValidExpression(nums[1], nums[2], ops[1], res1) &&
                        isValidExpression(nums[0], res1, ops[0], res2) &&
                        isValidExpression(res2, nums[3], ops[2], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return replaceTemplateWithValues(expr, nums, ops);
                } else if (expr == "a o1 ((b o2 c) o3 d)") {
                    if (isValidExpression(nums[1], nums[2], ops[1], res1) &&
                        isValidExpression(res1, nums[3], ops[2], res2) &&
                        isValidExpression(nums[0], res2, ops[0], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return replaceTemplateWithValues(expr, nums, ops);
                } else if (expr == "a o1 (b o2 (c o3 d))") {
                    if (isValidExpression(nums[2], nums[3], ops[2], res1) &&
                        isValidExpression(nums[1], res1, ops[1], res2) &&
                        isValidExpression(nums[0], res2, ops[0], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return replaceTemplateWithValues(expr, nums, ops);
                } else if (expr == "(a o1 b) o2 (c o3 d)") {
                    if (isValidExpression(nums[0], nums[1], ops[0], res1) &&
                        isValidExpression(nums[2], nums[3], ops[2], res2) &&
                        isValidExpression(res1, res2, ops[1], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return replaceTemplateWithValues(expr, nums, ops);
                }
            }
        } while (next_permutation(ops.begin(), ops.end()));
    } while (next_permutation(nums.begin(), nums.end()));
    return "No solution";
}

int main()
{
    srand(time(0));
    vector<int> deck(4);
    for(int i = 0;i < 4;i++)
    {
        deck[i] = rand() % 52;
        //vector<vector<int>> deck;     deck.push_back({randomValue % 13, randomValue / 13});
        cout << values[deck[i] % 13] << " of " << names[deck[i] / 13] << endl;
    }
    vector <double> nums;
    for (int i = 0; i < 4; i++)
    {
        nums.push_back(deck[i] % 13 + 1);
    }
    cout<<"Enter an expression:";
    string expression;
    getline(cin, expression);
    if(expression == "0" && getSolution(nums, {'+', '-', '*', '/'}) == "No solution")
    {
        cout<<"Yes. No 24 points"<<endl;
    }
    else if(expressionIsCorrect(expression, deck))
    {
        cout<<"Congratulations! You got it!"<<endl;
    }
    else
    {
        cout<<"Sorry, one correct expression is: "<<getSolution(nums, {'+', '-', '*', '/'})<<endl;
    }

}


/*
#include <iostream>
#include <cstdlib>
#include <vector>
#include <ctime>
#include <cctype>
#include <sstream>
#include <cstring>
#include <algorithm>
#include <cmath>

using namespace std;

vector<string> names = {"梅花", "方块", "红心", "黑桃"};
vector<string> values = {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};

bool expressionIsCorrect(string expression, vector<int> deck)
{
    vector<int> stack;
    stringstream ss(expression);
    while(!ss.eof())
    {
        string temp;
        ss >> temp;
        if(temp == "+")
        {
            if(stack.size() < 2)
            {
                return false;
            }
            int a = stack.back();
            stack.pop_back();
            int b = stack.back();
            stack.pop_back();
            stack.push_back(a + b);
        }
        else if(temp == "-")
        {
            if(stack.size() < 2)
            {
                return false;
            }
            int a = stack.back();
            stack.pop_back();
            int b = stack.back();
            stack.pop_back();
            stack.push_back(b - a);
        }
        else if(temp == "*")
        {
            if(stack.size() < 2)
            {
                return false;
            }
            int a = stack.back();
            stack.pop_back();
            int b = stack.back();
            stack.pop_back();
            stack.push_back(a * b);
        }
        else if(temp == "/")
        {
            if(stack.size() < 2)
            {
                return false;
            }
            int a = stack.back();
            stack.pop_back();
            int b = stack.back();
            stack.pop_back();
            stack.push_back(b / a);
        }
        else
        {
            if(isdigit(temp[0]))
            {
                stack.push_back(stoi(temp));
            }
            else
            {
                bool found = false;
                for(int i = 0; i < 4; i++)
                {
                    if(temp == values[deck[i] % 13] + " of " + names[deck[i] / 13])
                    {
                        stack.push_back(deck[i] % 13 + 1);
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    return false;
                }
            }
        }
    }

    if(stack.back() == 24)
    {
        return true;
    }
    return false;
}

bool isValidExpression(double a, double b, char op, double &result) {
    if (op == '+') result = a + b;
    else if (op == '-') result = a - b;
    else if (op == '*') result = a * b;
    else if (op == '/') {
        if (b == 0) return false;
        result = a / b;
    }
    return true;
}

std::string removeTrailingZeros(double num) {
    std::ostringstream out;
    out << std::fixed << num;
    std::string str = out.str();
    str.erase(str.find_last_not_of('0') + 1, std::string::npos);
    if (str.back() == '.') {
        str.pop_back();
    }
    return str;
}

string replaceTemplateWithValues(const string& templateExpr, const vector<double>& nums, const vector<char>& ops) {
    string expr = templateExpr;
    size_t pos;
    while ((pos = expr.find('a')) != string::npos)
        expr.replace(pos, 1, removeTrailingZeros(nums[0]));
    while ((pos = expr.find('b')) != string::npos)
        expr.replace(pos, 1, removeTrailingZeros(nums[1]));
    while ((pos = expr.find('c')) != string::npos)
        expr.replace(pos, 1, removeTrailingZeros(nums[2]));
    while ((pos = expr.find('d')) != string::npos)
        expr.replace(pos, 1, removeTrailingZeros(nums[3]));
    while ((pos = expr.find("o1")) != string::npos)
        expr.replace(pos, 2, string(1, ops[0]));
    while ((pos = expr.find("o2")) != string::npos)
        expr.replace(pos, 2, string(1, ops[1]));
    while ((pos = expr.find("o3")) != string::npos)
        expr.replace(pos, 2, string(1, ops[2]));
    return expr;
}

string getSolution(vector<double> nums, vector<char> ops)
{
    vector<string> expressions = {
        "((a o1 b) o2 c) o3 d",
        "(a o1 (b o2 c)) o3 d",
        "a o1 ((b o2 c) o3 d)",
        "a o1 (b o2 (c o3 d))",
        "(a o1 b) o2 (c o3 d)"
    };
    do {
        do {
            for (const auto &expr : expressions) {
                double res1, res2, res3, res4, finalResult;
                if (expr == "((a o1 b) o2 c) o3 d") {
                    if (isValidExpression(nums[0], nums[1], ops[0], res1) &&
                        isValidExpression(res1, nums[2], ops[1], res2) &&
                        isValidExpression(res2, nums[3], ops[2], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return replaceTemplateWithValues(expr, nums, ops);
                } else if (expr == "(a o1 (b o2 c)) o3 d") {
                    if (isValidExpression(nums[1], nums[2], ops[1], res1) &&
                        isValidExpression(nums[0], res1, ops[0], res2) &&
                        isValidExpression(res2, nums[3], ops[2], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return replaceTemplateWithValues(expr, nums, ops);
                } else if (expr == "a o1 ((b o2 c) o3 d)") {
                    if (isValidExpression(nums[1], nums[2], ops[1], res1) &&
                        isValidExpression(res1, nums[3], ops[2], res2) &&
                        isValidExpression(nums[0], res2, ops[0], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return replaceTemplateWithValues(expr, nums, ops);
                } else if (expr == "a o1 (b o2 (c o3 d))") {
                    if (isValidExpression(nums[2], nums[3], ops[2], res1) &&
                        isValidExpression(nums[1], res1, ops[1], res2) &&
                        isValidExpression(nums[0], res2, ops[0], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return replaceTemplateWithValues(expr, nums, ops);
                } else if (expr == "(a o1 b) o2 (c o3 d)") {
                    if (isValidExpression(nums[0], nums[1], ops[0], res1) &&
                        isValidExpression(nums[2], nums[3], ops[2], res2) &&
                        isValidExpression(res1, res2, ops[1], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return replaceTemplateWithValues(expr, nums, ops);
                }
            }
        } while (next_permutation(ops.begin(), ops.end()));
    } while (next_permutation(nums.begin(), nums.end()));
    return "无解";
}

int main()
{
    srand(time(0));
    vector<int> deck(4);
    for(int i = 0; i < 4; i++)
    {
        bool duplicate;
        do {
            duplicate = false;
            deck[i] = rand() % 52;
            for (int j = 0; j < i; j++) {
                if (deck[i] == deck[j]) {
                    duplicate = true;
                    break;
                }
            }
        } while (duplicate);

        cout << values[deck[i] % 13] << " of " << names[deck[i] / 13] << endl;
    }

    vector<double> nums;
    for (int i = 0; i < 4; i++)
    {
        nums.push_back(deck[i] % 13 + 1);
    }

    cout << "输入一个表达式: ";
    string expression;
    getline(cin, expression);

    if (expression == "0" && getSolution(nums, {'+', '-', '*', '/'}) == "无解")
    {
        cout << "是的，没有24点" << endl;
    }
    else if (expressionIsCorrect(expression, deck))
    {
        cout << "恭喜你！你做对了！" << endl;
    }
    else
    {
        cout << "对不起，一个正确的表达式是: " << getSolution(nums, {'+', '-', '*', '/'}) << endl;
    }

    return 0;
}

*/