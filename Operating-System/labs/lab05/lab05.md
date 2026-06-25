# lab05 实验五 进程调度算法模拟 实验报告

本文档已完成姓名、学号等个人信息脱敏，并保留原实验内容与关键实现。

## 一、 实验目的

在采用多道程序设计的系统中，往往有若干个进程同时处于就绪状态。当就绪状态进程个数大于处理器数时，就必须依照某种策略来决定哪些进程优先占用处理器。本实验模拟在单处理器情况下处理器调度，帮助自己加深了解处理器调度的工作。

## 二、 实验内容

选择 **第一题：设计一个按优先数调度算法实现处理器调度的程序** 进行实验。

### 算法描述

1. 假定系统有五个进程，每一个进程用一个进程控制块PCB来代表。
2. 指针：按优先数的大小把五个进程连成队列，用指针指出下一个进程的进程控制块的首地址，最后一个进程中的指针为NULL。
3. 要求运行时间：假设进程需要运行的单位时间数。
4. 优先数：赋予进程的优先数，调度时总是选取优先数大的进程先执行。
5. 状态：有两种状态，“就绪”和“结束”。初始状态都为“就绪”（R），当一个进程运行结束后，它的状态为“结束”（E）。
6. 处理器调度总是选队首进程运行。采用动态改变优先数的办法，进程每运行一次优先数就减“1”，要求运行时间减“1”。
7. 进程运行一次后，若要求运行时间不为0，则再将它加入队列（按优先数大小插入，且置队首标志）；若要求运行时间为0，则把它的状态修改成“结束”（E），且退出队列。

## 三、 数据结构

程序中使用的数据结构如下：

```c
typedef struct _proc {
    char name[32];      /* 进程名 */
    int run_time;       /* 要求运行时间 */
    int pri;            /* 优先数 */
    char state;         /* 状态：'R'为就绪, 'E'为结束 */
    struct _proc *next; /* 指向下一个进程的指针 */
} PROC;
```

## 四、 核心代码实现

```c
/* 插入进程到有序队列 (按优先数降序排列) */
void insert_proc(PROC *p) {
    if (head == NULL) {
        head = p;
        p->next = NULL;
        return;
    }
    /* 如果当前进程优先数高于队首，则成为新的队首 */
    if (p->pri > head->pri) {
        p->next = head;
        head = p;
        return;
    }
    /* 查找插入位置 */
    PROC *curr = head;
    PROC *prev = NULL;
    while (curr != NULL && curr->pri >= p->pri) {
        prev = curr;
        curr = curr->next;
    }
    /* 插入到 prev 之后 */
    p->next = curr;
    prev->next = p;
}
/* 主循环模拟调度 */
while (head != NULL) {
    step++;
    printf("\nStep %d:\n", step);
    /* 1. 选中队首进程 */
    PROC *run_proc = head;
    head = head->next;
    /* 2. 模拟运行: 优先数-1, 运行时间-1 */
    run_proc->pri -= 1;
    run_proc->run_time -= 1;
    /* 3. 检查是否结束 */
    if (run_proc->run_time == 0) {
        run_proc->state = 'E';
        run_proc->next = NULL;
        printf("Process %s finished.\n", run_proc->name);
    } else {
        /* 4. 未结束，重新插入队列 */
        run_proc->state = 'R';
        insert_proc(run_proc);
    }
    print_procs(NULL, 0, run_proc);
}
```

## 五、 实验结果

初始状态采用实验指导书给定的值：

- P1: Time=2, Pri=1
- P2: Time=3, Pri=5
- P3: Time=1, Pri=3
- P4: Time=2, Pri=4
- P5: Time=4, Pri=2

**运行输出：**

```text
Initial State:
Selected process: None
Queue State:
Name: P2, RunTime: 3, Priority: 5, State: R
Name: P4, RunTime: 2, Priority: 4, State: R
Name: P3, RunTime: 1, Priority: 3, State: R
Name: P5, RunTime: 4, Priority: 2, State: R
Name: P1, RunTime: 2, Priority: 1, State: R
--------------------------------------------------
Step 1:
Selected process: P2
Queue State:
Name: P4, RunTime: 2, Priority: 4, State: R
Name: P2, RunTime: 2, Priority: 4, State: R
Name: P3, RunTime: 1, Priority: 3, State: R
Name: P5, RunTime: 4, Priority: 2, State: R
Name: P1, RunTime: 2, Priority: 1, State: R
--------------------------------------------------
Step 2:
Selected process: P4
Queue State:
Name: P2, RunTime: 2, Priority: 4, State: R
Name: P3, RunTime: 1, Priority: 3, State: R
Name: P4, RunTime: 1, Priority: 3, State: R
Name: P5, RunTime: 4, Priority: 2, State: R
Name: P1, RunTime: 2, Priority: 1, State: R
--------------------------------------------------
Step 3:
Selected process: P2
Queue State:
Name: P3, RunTime: 1, Priority: 3, State: R
Name: P4, RunTime: 1, Priority: 3, State: R
Name: P2, RunTime: 1, Priority: 3, State: R
Name: P5, RunTime: 4, Priority: 2, State: R
Name: P1, RunTime: 2, Priority: 1, State: R
--------------------------------------------------
Step 4:
Process P3 finished.
Selected process: P3
Queue State:
Name: P4, RunTime: 1, Priority: 3, State: R
Name: P2, RunTime: 1, Priority: 3, State: R
Name: P5, RunTime: 4, Priority: 2, State: R
Name: P1, RunTime: 2, Priority: 1, State: R
--------------------------------------------------
Step 5:
Process P4 finished.
Selected process: P4
Queue State:
Name: P2, RunTime: 1, Priority: 3, State: R
Name: P5, RunTime: 4, Priority: 2, State: R
Name: P1, RunTime: 2, Priority: 1, State: R
--------------------------------------------------
Step 6:
Process P2 finished.
Selected process: P2
Queue State:
Name: P5, RunTime: 4, Priority: 2, State: R
Name: P1, RunTime: 2, Priority: 1, State: R
--------------------------------------------------
Step 7:
Selected process: P5
Queue State:
Name: P1, RunTime: 2, Priority: 1, State: R
Name: P5, RunTime: 3, Priority: 1, State: R
--------------------------------------------------
Step 8:
Selected process: P1
Queue State:
Name: P5, RunTime: 3, Priority: 1, State: R
Name: P1, RunTime: 1, Priority: 0, State: R
--------------------------------------------------
Step 9:
Selected process: P5
Queue State:
Name: P1, RunTime: 1, Priority: 0, State: R
Name: P5, RunTime: 2, Priority: 0, State: R
--------------------------------------------------
Step 10:
Process P1 finished.
Selected process: P1
Queue State:
Name: P5, RunTime: 2, Priority: 0, State: R
--------------------------------------------------
Step 11:
Selected process: P5
Queue State:
Name: P5, RunTime: 1, Priority: -1, State: R
--------------------------------------------------
Step 12:
Process P5 finished.
Selected process: P5
Queue State:
--------------------------------------------------
All processes finished.
```

## 六、 问题讨论

### 1. 优先数调度算法的特点与优缺点

本次实验采用的是非抢占式的动态优先数调度算法。

* **优点**：
  * **灵活性**：通过动态调整优先数（每运行一次Priority减1），可以防止长作业长期占用CPU，在一定程度上兼顾了公平性。
  * **简单有效**：算法逻辑清晰，易于实现，适用于批处理系统。
* **缺点**：
  * **饥饿现象**：虽然本实验采用了动态优先级，但在极端情况下（如果有源源不断的高优先级进程进入），低优先级进程仍可能长时间得不到服务。
  * **开销**：每次调度都需要重新排序队列，增加了系统开销。

### 2. 关于进程控制块（PCB）的设计

实验中使用了链表来组织PCB，这在实际操作系统中是非常常见的做法。链表结构使得进程的插入（入队）和删除（出队/结束）操作非常方便，尤其是对于需要频繁调整顺序的优先数调度算法，链表的优势明显高于数组。

### 3. 本次模拟与真实OS的区别

本实验是一个简化的模拟：

* **并发性**：真实OS中，进程调度涉及复杂的上下文切换（保存现场/恢复现场），而本实验仅修改变量模拟运行。
* **时间片**：实验中简单地假设“一次运行”消耗1个单位时间，而实际系统中时间片长度的选取对系统性能影响很大。
* **状态简化**：只考虑了“就绪”和“结束”两种状态，忽略了“阻塞/等待”状态，这在处理I/O密集型任务时是必不可少的。

通过本次实验，我深刻理解了进程调度的核心逻辑：即在有限资源（单CPU）下，如何通过合理的策略（如优先级、时间片）来最大化系统吞吐量或保证公平性。
