#include <iostream>

using namespace std;

int main()
{
    char x ;
    int sum = 0;
    for(int i = 33; i <= 126;i++)
    {
        x = i;
        cout<<x<<" ";
        sum++;
        if(sum == 10)
        {
            cout<<endl;
            sum = 0;
        }
    }
}

/*
//
// * C++ Program to Print ASCII table (0 - 127)
//
#include<iostream>
#include<iomanip>
using namespace std;

char const* character[] = {"NULL(空)", "SOH(标题开始)", "STX(正文开始)", "ETX (正文结束)", "EOT (传送结束)",
                              "ENQ (询问)", "ACK (确认)",
                            "\\a","\\b","\\t","\\n","\\v","\\f","\\r","SO(移出)","SI(移入)",
                              "DLE(退出数据链)",
                            "DC1 (设备控制1)", "DC2(设备控制2)", "DC3(设备控制3)", "DC4(设备控制4)",
                              "NAK (反确认)", "SYN (同步空闲)", "ETB (传输块结束)", "CAN (取消)",
                            "EM (媒介结束)", "SUB (替换)", "ESC (退出)", "FS (文件分隔符)",
                              "GS (组分隔符)", "RS (记录分隔符)", "US (单元分隔符)", "(空格)"};

int main()
{

    char c;
    int row;
    cout << " ASCII Table" << endl << "=============" << endl;

    for(int i = 0; i < 32; i++)
    {
        row = i;
        while (row <= 127) {
            if (row <= 32){

                cout << setfill('0') << setw(2) << setbase(16)
                     << row << " = " << setw(15) << setfill(' ')
                     << character[row] << " | ";
            }
            else if (row > 32 && row < 127)
            {
                c = row;
                cout << setfill('0') << setw(2) << setbase(16)
                     << row << " = " << setw(15) << setfill(' ')
                     << c << " | ";
            }
            else
                cout << setfill('0') << setw(2) << setbase(16)
                     << row << " = " << setw(15) << setfill(' ')
                     << "DEL" << " | ";
            row = row + 32;
        }
        cout << endl;
    }
}

如需使表格严格对齐，需要去掉所有中文字符，如下：

//
// * C++ Program to Print ASCII table (0 - 127)
//

#include<iostream>
#include<iomanip>
using namespace std;

char const* character[] = {"NULL", "SOH", "STX", "ETX ", "EOT ",
                              "ENQ ", "ACK",
                            "\\a","\\b","\\t","\\n","\\v","\\f","\\r","SO","SI",
                              "DLE",
                            "DC1 ", "DC2", "DC3", "DC4",
                              "NAK", "SYN", "ETB", "CAN ",
                            "EM ", "SUB", "ESC", "FS ",
                              "GS ", "RS ", "US ", "(space)"};

int main()
{

    char c;
    int row;
    cout << " ASCII Table" << endl << "=============" << endl;

    for(int i = 0; i < 32; i++)
    {
        row = i;
        while (row <= 127) {
            if (row <= 32){

                cout << setfill('0') << setw(2) << setbase(16)
                     << row << " = " << setw(15) << setfill(' ')
                     << character[row] << " | ";
            }
            else if (row > 32 && row < 127)
            {
                c = row;
                cout << setfill('0') << setw(2) << setbase(16)
                     << row << " = " << setw(15) << setfill(' ')
                     << c << " | ";
            }
            else
                cout << setfill('0') << setw(2) << setbase(16)
                     << row << " = " << setw(15) << setfill(' ')
                     << "DEL" << " | ";
            row = row + 32;
        }
        cout << endl;
    }
}

*/
