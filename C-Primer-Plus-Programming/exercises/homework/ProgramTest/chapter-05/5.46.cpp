#include <iostream>

void printBinary(short num) {
    for (int i = 15; i >= 0; --i) {
        // 使用位运算检查当前位是否为1
        int bit = (num >> i) & 1;
        std::cout << bit;
    }
    std::cout << std::endl;
}

int main() {
    short userInput;

    // 获取用户输入
    std::cout << "请输入一个short类型的整数: ";
    std::cin >> userInput;

    // 输出16位表示
    std::cout << "16位表示为: ";
    printBinary(userInput);

    return 0;
}













//#include <iostream>
//
//using namespace std;
//
//int main()
//{
//    cout<<"Enter an integer: ";
//    short int n;
//    cin>>n;
//
//    cout<<"The bits are ";
//    for(int i = 0;i < 16;i++)
//    {
//        n = n>>1;
//        cout<<n<<" ";
//    }
//}


/*

这C++程序通过以下步骤实现了输出一个short类型整数的16位二进制表示：

包含头文件：

cpp
Copy code
#include <iostream>
包含了输入输出流的头文件，以便使用std::cout和std::cin。

printBinary函数：

cpp
Copy code
void printBinary(short num) {
    for (int i = 15; i >= 0; --i) {
        int bit = (num >> i) & 1;
        std::cout << bit;
    }
    std::cout << std::endl;
}
这个函数接受一个short类型的整数 num 作为参数。使用一个循环从高位到低位依次检查 num 的每一位，通过右移和与运算得到当前位的值（0或1），然后输出到标准输出流。

main函数：

cpp
Copy code
int main() {
    short userInput;
    std::cout << "请输入一个short类型的整数: ";
    std::cin >> userInput;
    std::cout << "16位表示为: ";
    printBinary(userInput);
    return 0;
}
在main函数中，首先声明一个short类型的变量userInput用于存储用户输入。用户被提示输入一个short类型的整数，然后通过std::cin接收输入的值。接着，调用printBinary函数来输出用户输入整数的16位二进制表示。

总体而言，这个程序演示了如何使用位运算和循环来访问和输出一个整数的二进制表示。
*/
