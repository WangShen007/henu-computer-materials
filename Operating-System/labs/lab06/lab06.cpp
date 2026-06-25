#include <iostream>
#include <vector>
#include <string>
#include <iomanip>
#include <deque>
#include <algorithm>

using namespace std;

// 常量定义
const int BLOCK_SIZE = 1024; // 页面大小 1KB
const int MAX_FRAMES = 4;    // 假设分配给作业的主存块数为4 (根据初始页表推断)

// 页表项结构
struct PageItem {
    int pageNo;       // 页号
    int flag;         // 标志: 1-在内存, 0-不在内存
    int blockNo;      // 块号: -1表示无效
    string diskAddr;  // 磁盘地址
    int modified;     // 修改位: 1-已修改, 0-未修改
    // 辅助字段用于算法
    int enterTime;    // 进入时间 (FIFO)
    int lastAccessTime; // 最后访问时间 (LRU)

    PageItem(int p, int f, int b, string d, int m)
        : pageNo(p), flag(f), blockNo(b), diskAddr(d), modified(m), enterTime(0), lastAccessTime(0) {}
};

// 指令结构
struct Instruction {
    string op;        // 操作: +, -, *, 存, 取, 移位
    int pageNo;       // 页号
    int offset;       // 页内地址

    Instruction(string o, int p, int off) : op(o), pageNo(p), offset(off) {}
};

// 全局数据用于重置
vector<PageItem> INITIAL_PAGE_TABLE;
vector<Instruction> INSTRUCTIONS;

// 初始化数据
void initData() {
    // 初始化页表
    INITIAL_PAGE_TABLE.clear();
    INITIAL_PAGE_TABLE.push_back(PageItem(0, 1, 5, "011", 0));
    INITIAL_PAGE_TABLE.push_back(PageItem(1, 1, 8, "012", 0));
    INITIAL_PAGE_TABLE.push_back(PageItem(2, 1, 9, "013", 0));
    INITIAL_PAGE_TABLE.push_back(PageItem(3, 1, 1, "021", 0));
    INITIAL_PAGE_TABLE.push_back(PageItem(4, 0, -1, "022", 0));
    INITIAL_PAGE_TABLE.push_back(PageItem(5, 0, -1, "023", 0));
    INITIAL_PAGE_TABLE.push_back(PageItem(6, 0, -1, "121", 0));

    // 初始化指令序列
    INSTRUCTIONS.clear();
    INSTRUCTIONS.push_back(Instruction("+", 0, 70));
    INSTRUCTIONS.push_back(Instruction("+", 1, 50));
    INSTRUCTIONS.push_back(Instruction("*", 2, 15));
    INSTRUCTIONS.push_back(Instruction("存", 3, 21));
    INSTRUCTIONS.push_back(Instruction("取", 0, 56));
    INSTRUCTIONS.push_back(Instruction("-", 6, 40));
    INSTRUCTIONS.push_back(Instruction("移位", 4, 53));
    INSTRUCTIONS.push_back(Instruction("+", 5, 23));
    INSTRUCTIONS.push_back(Instruction("存", 1, 37));
    INSTRUCTIONS.push_back(Instruction("取", 2, 78));
    INSTRUCTIONS.push_back(Instruction("+", 4, 1));
    INSTRUCTIONS.push_back(Instruction("存", 6, 84));
}

// 打印页表状态
void printPageTable(const vector<PageItem>& pageTable) {
    cout << "当前页表状态:" << endl;
    cout << "页号\t标志\t块号\t磁盘地址\t修改位" << endl;
    for (const auto& page : pageTable) {
        cout << page.pageNo << "\t" << page.flag << "\t"
             << (page.blockNo == -1 ? "-" : to_string(page.blockNo)) << "\t"
             << page.diskAddr << "\t\t" << page.modified << endl;
    }
    cout << "----------------------------------------" << endl;
}

// 任务1: 模拟硬件地址变换
void simulateTask1() {
    cout << "\n========== 任务 1: 硬件地址变换模拟 ==========" << endl;
    vector<PageItem> pageTable = INITIAL_PAGE_TABLE;

    cout << "每条指令执行时的地址计算结果:" << endl;
    for (int i = 0; i < INSTRUCTIONS.size(); ++i) {
        Instruction inst = INSTRUCTIONS[i];
        cout << "指令 " << i + 1 << ": (" << inst.op << ", " << inst.pageNo << ", " << setfill('0') << setw(3) << inst.offset << ") -> ";

        // 检查页号是否合法
        if (inst.pageNo < 0 || inst.pageNo >= pageTable.size()) {
            cout << "错误: 页号越界" << endl;
            continue;
        }

        const PageItem& page = pageTable[inst.pageNo];

        if (page.flag == 1) {
            // 页面在内存中
            int absAddr = page.blockNo * BLOCK_SIZE + inst.offset;
            cout << "绝对地址: " << absAddr << endl;
        } else {
            // 页面不在内存中，产生缺页中断
            cout << "* " << inst.pageNo << " (缺页中断)" << endl;
        }
    }
}

// 任务 2: FIFO 算法
void simulateFIFO() {
    cout << "\n========== 任务 2: FIFO 页面置换算法模拟 ==========" << endl;
    vector<PageItem> pageTable = INITIAL_PAGE_TABLE;

    // 维护内存中的页面队列 (存放页号)
    deque<int> memoryQueue;
    // 初始化队列，按照初始页表中 Flag=1 的项
    // 这里假设初始页面进入顺序就是页号顺序 0, 1, 2, 3
    for(const auto& page : pageTable) {
        if(page.flag == 1) {
            memoryQueue.push_back(page.pageNo);
        }
    }

    int totalFaults = 0;
    int currentTime = 0; // 模拟时间步

    for (int i = 0; i < INSTRUCTIONS.size(); ++i) {
        Instruction inst = INSTRUCTIONS[i];
        currentTime++;
        cout << "执行指令 " << i + 1 << ": (" << inst.op << ", " << inst.pageNo << ", " << setfill('0') << setw(3) << inst.offset << ")";

        // 是否“存”操作（修改）
        bool isWrite = (inst.op == "存");

        // 检查是否在内存
        if (pageTable[inst.pageNo].flag == 1) {
            cout << " -> 命中。";
            if (isWrite) {
                pageTable[inst.pageNo].modified = 1;
                cout << " [修改位置1]";
            }
            cout << endl;
        } else {
            cout << " -> 缺页!";
            totalFaults++;

            // 需要调入页面 inst.pageNo
            // 检查内存是否已满
            if (memoryQueue.size() >= MAX_FRAMES) {
                // FIFO: 淘汰队头
                int victimPageNo = memoryQueue.front();
                memoryQueue.pop_front();

                cout << " 淘汰页 " << victimPageNo;
                if (pageTable[victimPageNo].modified == 1) {
                    cout << " (写回磁盘 " << pageTable[victimPageNo].diskAddr << ")";
                }

                // 更新淘汰页状态
                pageTable[victimPageNo].flag = 0;
                pageTable[victimPageNo].blockNo = -1;
                pageTable[victimPageNo].modified = 0; // 移出后重置? 还是保留? 通常重置
            }

            // 调入新页
            // 简单分配一个模拟块号 (为了演示完整性，可以循环利用被淘汰的块号，或者简单给个占位值，这里复用原逻辑太复杂，简单假设它获得了一个空闲块)
            // 实际上块号应该从被淘汰的那个页那里拿过来
            // 但为了简单，在这个模拟中我们只关注置换逻辑，块号可以打印为 '新分配' 或复用
            // 让我们尝试复用逻辑：如果发生了置换，就用那个块号；如果通过空闲进入，那是初始状态我们没空闲。
            // 初始全是满的(4个)，所以每次必置换。

            // 为了更真实，这里我们不具体追踪物理块号的流转(因为题目给了初始块号5,8,9,1，后面新进来的页块号未知)
            // 但为了Task1那样的计算，我们暂时给个占位块号 999
            pageTable[inst.pageNo].flag = 1;
            pageTable[inst.pageNo].blockNo = 999;
            pageTable[inst.pageNo].modified = (isWrite ? 1 : 0);

            memoryQueue.push_back(inst.pageNo);
            cout << " -> 调入页 " << inst.pageNo << endl;
        }
    }

    double failureRate = (double)totalFaults / INSTRUCTIONS.size() * 100;
    cout << "----------------------------------------" << endl;
    cout << "FIFO 统计结果: 缺页次数 = " << totalFaults << ", 缺页率 = " << failureRate << "%" << endl;
}

// 任务 3: LRU 算法
void simulateLRU() {
    cout << "\n========== 任务 3: LRU 页面置换算法模拟 ==========" << endl;
    vector<PageItem> pageTable = INITIAL_PAGE_TABLE;

    // 维护内存页面的最后访问时间
    // 或者直接用一个vector/list维护LRU栈，栈顶是最新的
    vector<int> lruStack;

    // 初始化
    for(const auto& page : pageTable) {
        if(page.flag == 1) {
            lruStack.push_back(page.pageNo); // 假设序是 0,1,2,3 (3是最近)
        }
    }

    int totalFaults = 0;

    for (int i = 0; i < INSTRUCTIONS.size(); ++i) {
        Instruction inst = INSTRUCTIONS[i];
        cout << "执行指令 " << i + 1 << ": (" << inst.op << ", " << inst.pageNo << ", " << setfill('0') << setw(3) << inst.offset << ")";

        bool isWrite = (inst.op == "存");
        int targetPage = inst.pageNo;

        // 检查是否在内存
        auto it = find(lruStack.begin(), lruStack.end(), targetPage);
        bool hit = (it != lruStack.end());

        if (hit) {
            cout << " -> 命中。";
            if (isWrite) {
                pageTable[targetPage].modified = 1;
                cout << " [修改位置1]";
            }
            // LRU更新: 移到栈顶(vector末尾)
            lruStack.erase(it);
            lruStack.push_back(targetPage);
            cout << endl;
        } else {
            cout << " -> 缺页!";
            totalFaults++;

            if (lruStack.size() >= MAX_FRAMES) {
                // LRU: 淘汰栈底(vector开头)
                int victimPageNo = lruStack.front();
                lruStack.erase(lruStack.begin());

                cout << " 淘汰页 " << victimPageNo;
                if (pageTable[victimPageNo].modified == 1) {
                    cout << " (写回磁盘 " << pageTable[victimPageNo].diskAddr << ")";
                }

                // 更新
                pageTable[victimPageNo].flag = 0;
                pageTable[victimPageNo].blockNo = -1;
                pageTable[victimPageNo].modified = 0;
            }

            // 调入
            pageTable[targetPage].flag = 1;
            pageTable[targetPage].blockNo = 999; // 模拟分配
            pageTable[targetPage].modified = (isWrite ? 1 : 0);

            lruStack.push_back(targetPage);
            cout << " -> 调入页 " << targetPage << endl;
        }
    }

    double failureRate = (double)totalFaults / INSTRUCTIONS.size() * 100;
    cout << "----------------------------------------" << endl;
    cout << "LRU 统计结果: 缺页次数 = " << totalFaults << ", 缺页率 = " << failureRate << "%" << endl;
}

int main() {
    initData();

    simulateTask1();
    printPageTable(INITIAL_PAGE_TABLE); // 打印初始状态 (Task1没改它)

    simulateFIFO();

    simulateLRU();

    return 0;
}
