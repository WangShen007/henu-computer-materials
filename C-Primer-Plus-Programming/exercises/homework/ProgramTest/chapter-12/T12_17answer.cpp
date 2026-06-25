#include <iostream>
#include <vector>
#include <algorithm>
#include <string>
#include <cmath>
#include <iomanip>

using namespace std;

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
#include <sstream>
#include <iomanip>

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

string getSolution(vector<double> nums, vector<char> ops) {
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

int main() {

        cout << "Enter four numbers (between 1 and 13): ";
        vector<double> numbers(4);
        for (int i = 0; i < 4; ++i) {
            cin >> numbers[i];
            if (numbers[i] < 1 || numbers[i] > 13) {
                cout << "Invalid input. Numbers must be between 1 and 13." << endl;
                return 1;
            }
        }

    vector<char> operators = {'+', '-', '*', '/'};
    cout << getSolution(numbers, operators) << endl;

    return 0;
}










/*
#include <iostream>
#include <vector>
#include <algorithm>
#include <string>
#include <cmath>

using namespace std;

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

string getSolution(vector<double> nums, vector<char> ops) {
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
                        return expr;
                } else if (expr == "(a o1 (b o2 c)) o3 d") {
                    if (isValidExpression(nums[1], nums[2], ops[1], res1) &&
                        isValidExpression(nums[0], res1, ops[0], res2) &&
                        isValidExpression(res2, nums[3], ops[2], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return expr;
                } else if (expr == "a o1 ((b o2 c) o3 d)") {
                    if (isValidExpression(nums[1], nums[2], ops[1], res1) &&
                        isValidExpression(res1, nums[3], ops[2], res2) &&
                        isValidExpression(nums[0], res2, ops[0], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return expr;
                } else if (expr == "a o1 (b o2 (c o3 d))") {
                    if (isValidExpression(nums[2], nums[3], ops[2], res1) &&
                        isValidExpression(nums[1], res1, ops[1], res2) &&
                        isValidExpression(nums[0], res2, ops[0], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return expr;
                } else if (expr == "(a o1 b) o2 (c o3 d)") {
                    if (isValidExpression(nums[0], nums[1], ops[0], res1) &&
                        isValidExpression(nums[2], nums[3], ops[2], res2) &&
                        isValidExpression(res1, res2, ops[1], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return expr;
                }
            }
        } while (next_permutation(ops.begin(), ops.end()));
    } while (next_permutation(nums.begin(), nums.end()));
    return "No solution";
}

int main() {
    while (true) {
        cout << "Enter four numbers (between 1 and 13): ";
        vector<double> numbers(4);
        for (int i = 0; i < 4; ++i) {
            cin >> numbers[i];
            if (numbers[i] < 1 || numbers[i] > 13) {
                cout << "Invalid input. Numbers must be between 1 and 13." << endl;
                return 1;
            }
        }

        vector<char> operators = {'+', '-', '*', '/'};
        cout << getSolution(numbers, operators) << endl;
    }
    return 0;
}


*/



/*

#include <iostream>
#include <vector>
#include <algorithm>
#include <string>
#include <cmath>

using namespace std;

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

bool canForm24(vector<double> nums, vector<char> ops)
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
                        return true;
                } else if (expr == "(a o1 (b o2 c)) o3 d") {
                    if (isValidExpression(nums[1], nums[2], ops[1], res1) &&
                        isValidExpression(nums[0], res1, ops[0], res2) &&
                        isValidExpression(res2, nums[3], ops[2], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return true;
                } else if (expr == "a o1 ((b o2 c) o3 d)") {
                    if (isValidExpression(nums[1], nums[2], ops[1], res1) &&
                        isValidExpression(res1, nums[3], ops[2], res2) &&
                        isValidExpression(nums[0], res2, ops[0], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return true;
                } else if (expr == "a o1 (b o2 (c o3 d))") {
                    if (isValidExpression(nums[2], nums[3], ops[2], res1) &&
                        isValidExpression(nums[1], res1, ops[1], res2) &&
                        isValidExpression(nums[0], res2, ops[0], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return true;
                } else if (expr == "(a o1 b) o2 (c o3 d)") {
                    if (isValidExpression(nums[0], nums[1], ops[0], res1) &&
                        isValidExpression(nums[2], nums[3], ops[2], res2) &&
                        isValidExpression(res1, res2, ops[1], finalResult) &&
                        fabs(finalResult - 24) < 1e-6)
                        return true;
                }
            }
        } while (next_permutation(ops.begin(), ops.end()));
    } while (next_permutation(nums.begin(), nums.end()));
    return false;
}

int main() {
    while (true) {
        cout << "Enter four numbers (between 1 and 13): ";
        vector<double> numbers(4);
        for (int i = 0; i < 4; ++i) {
            cin >> numbers[i];
            if (numbers[i] < 1 || numbers[i] > 13) {
                cout << "Invalid input. Numbers must be between 1 and 13." << endl;
                return 1;
            }
        }

        vector<char> operators = {'+', '-', '*', '/'};
        if (canForm24(numbers, operators)) {
            cout << "There is a solution." << endl;
        } else {
            cout << "There is no solution." << endl;
        }
    }
    return 0;
}

*/