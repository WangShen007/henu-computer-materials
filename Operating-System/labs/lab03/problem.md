# 实验三 进程管理与同步 题目整理

本文件根据原始实验题目材料整理，已统一为适合 GitHub 提交的 Markdown 版本。

## 题目材料 1：实验三 进程管理1 fork调用

## 实验二 进程管理

### 一、实验目的

1.加深对进程概念的理解，尤其是进程的动态性，并发性；

2.了解父进程和子进程之间的关系；

3.查看进程管理命令；

### 二、实验内容

**1.练习在shell环境下编译执行程序**

(注意：①在 `vi` 编辑器中编写名为 `sample.c` 的 C 语言源程序
②用 Linux 自带的编译器 `gcc` 编译程序，例如：`gcc –o test sample.c`
③编译后生成名为 `test.out` 的可执行文件
④最后执行分析结果；命令为：`./test`)

注意：Linux 自带的编译程序 `gcc` 的语法是：`gcc –o 目标程序名 源程序名`，例如：`gcc –o sample1 sample1.c`，然后利用命令：`./sample` 来执行。如果仅用 `gcc 源程序名`，将会把任何名字的源程序都编译成名为 `a.out` 的目标程序，这样新编译的程序会覆盖原来的程序，所以最好给每个源程序都起个新目标程序名。

**2.进程的创建**

仿照例子自己编写一段程序，使用系统调用 `fork()` 创建两个子进程。当此程序运行时，在系统中有一个父进程和两个子进程活动。让每一个进程在屏幕上显示一个字符：父进程显示 `a`，子进程分别显示字符 `b` 和 `c`。观察记录屏幕上的显示结果，并分析原因。

**3.分析程序**

实验内容要在给出的例子程序基础上，根据要求进行修改，对执行结果进行分析。

- **子进程对存储空间的复制**

**(1) 使用文本编辑器输入源程序**

输入如下源程序：

```c
#include <sys/types.h>
#include <unistd.h>
#include <stdio.h>
int main(void)
{
int x, i;
printf("Input a initial value for i: ");
scanf("%d", &i);
while((x=fork())==-1);
if(x==0) /* child run */
{
printf("When child runs, i=%d\n", i);
printf("Input a value in child: ");
scanf("%d", &i);
printf("i=%d\n", i);
}
else /* parent run */
{
wait();
printf("After child runs, in parent, i=%d\n", i);
}
}
```

**(2) 预测程序的执行结果**

阅读程序，根据自己的理解，预期程序执行后的结果。

**(3) 实际执行结果分析**

编译生成执行文件，执行后记录结果，说明与预期的结果是否一致。分析为什么是这样的结果。

- **父子进程执行过程分析**

**(1) 按照给定框架编程**

按照如下程序框架，完成源程序编写：

```c
#include <sys/types.h>
#include <unistd.h>
#include <stdio.h>
int main(void)
{
    // ①
pid=fork();
// ②
if(pid==0)
{
sleep(3);
printf("Child: pid=%d, ppid=%d\n", getpid(), getppid());
}
else
{
printf("Parent: Child=%d, pid=%d, ppid=%d\n", pid, getpid(), getppid());
wait();
printf("After Child ends.\n");
}
printf("In which process?\n"); // ③
```

**(2) 预测程序的执行结果**

阅读程序，根据自己的理解，预期程序执行后的结果。

**(3) 实际执行结果分析**

编译生成执行文件，执行后记录结果，说明与预期的结果是否一致。分析为什么是这样的结果。

**(4) 修改程序并分析执行结果**

把程序框架中最后一句输出语句（位置③处）分别移至位置①和②处，预期输出结果是什么？实际执行结果如何？分析原因。

**(5) 修改程序验证父子进程关系**

修改程序，使父进程先执行完成，验证子进程是否会一起终止？如果不是，前后子进程的父进程号是否变化？记录并分析结果。

### 三、实验报告书写要求

应在实验报告中说明如下事项：

1、所使用的文本编辑器；

2、编译生成执行文件的命令；

3、相关程序的名称及存储位置，以便指导教师抽查；

4、实验内容1的结果：包括预期结果和实际执行结果，以及结果分析；

5、实验内容2的结果：包括预期结果和实际执行结果，对结果的分析；按照要求进行修改后的预期结果、实际结果及分析。

## 题目材料 2：实验三 进程管理2 进程互斥

## 实验三 Linux进程互斥

### 一、实验目的

熟悉Linux下信号量机制，能够使用信号量实现在并发进程间的互斥和同步。

### 二、实验题目

使用共享存储区机制，使多个并发进程分别模拟生产者－消费者模式同步关系、临界资源的互斥访问关系，使用信号量机制实现相应的同步和互斥。

### 三、背景材料

#### （一）需要用到的系统调用

实验可能需要用到的主要系统调用和库函数在下面列出，详细的使用方法说明通过 `man 2 系统调用名` 或者 `man 3 函数名` 命令获取。

- `fork()` 创建一个子进程，通过返回值区分是在父进程还是子进程中执行
- `wait()` 等待子进程执行完成
- `shmget()` 建立一个共享存储区
- `shmctl()` 操纵一个共享存储区
- `shmat()` 把一个共享存储区附接到进程内存空间
- `shmdt()` 把一个已经附接的共享存储区从进程内存空间断开
- `semget()` 建立一个信号量集
- `semctl()` 操纵一个信号量集，包括赋初值
- `semop()` 对信号量集进行 `wait` 和 `signal` 操作
- `signal()` 设置对信号的处理方式或处理过程

#### （二）模拟生产者－消费者的示例程序

本示例主要体现进程间的直接制约关系，由于使用共享存储区，也存在间接制约关系。进程分为服务进程和客户进程，服务进程只有一个，作为消费者，在每次客户进程改变共享存储区内容时显示其数值。各客户进程作为生产者，如果共享存储区内容已经显示（被消费），可以接收用户从键盘输入的整数，放在共享存储区。

编译后执行，第一个进程实例将作为服务进程，提示：

`ACT CONSUMER!!! To end, try Ctrl+C or use kill.`

服务进程一直循环执行，直到用户按 `Ctrl+C` 终止执行，或使用 `kill` 命令杀死服务进程。

其他进程实例作为客户进程，提示：

`Act as producer. To end, input 0 when prompted.`

客户进程一直循环执行，直到用户输入 `0`。

示例程序代码如下：

```c
#include <sys/types.h>
#include <unistd.h>
#include <signal.h>
#include <stdio.h>
#include <string.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#include <sys/sem.h>
#define MY_SHMKEY 10071500 // need to change
#define MY_SEMKEY 10071500 // need to change
void sigend(int);
int shmid, semid;
int main(void)
{
int *shmptr, semval, local;
struct sembuf semopbuf;
if((shmid=shmget(MY_SHMKEY, sizeof(int), IPC_CREAT|IPC_EXCL|0666)) < 0)
{ /* shared memory exists, act as client */
shmid=shmget(MY_SHMKEY, sizeof(int), 0666);
semid=semget(MY_SEMKEY, 2, 0666);
shmptr=(int *)shmat(shmid, 0, 0);
printf("Act as producer. To end, input 0 when prompted.\n\n");
printf("Input a number:\n");
scanf("%d", &local);
while( local )
{
semopbuf.sem_num=0;
semopbuf.sem_op=-1;
semopbuf.sem_flg=SEM_UNDO;
semop(semid, &semopbuf, 1); /* P(S1) */
*shmptr = local;
semopbuf.sem_num=1;
semopbuf.sem_op=1;
semopbuf.sem_flg=SEM_UNDO;
semop(semid, &semopbuf, 1); /* V(S2) */
printf("Input a number:\n");
scanf("%d", &local);
}
}
else /* acts as server */
{
semid=semget(MY_SEMKEY, 2, IPC_CREAT|0666);
shmptr=(int *)shmat(shmid, 0, 0);
semval=1;
semctl(semid, 0, SETVAL, semval); /* set S1=1 */
semval=0;
semctl(semid, 1, SETVAL, semval); /* set S2=0 */
signal(SIGINT, sigend);
signal(SIGTERM, sigend);
printf("ACT CONSUMER!!! To end, try Ctrl+C or use kill.\n\n");
while(1)
{
semopbuf.sem_num=1;
semopbuf.sem_op=-1;
semopbuf.sem_flg=SEM_UNDO;
semop(semid, &semopbuf, 1); /* P(S2) */
printf("Shared memory set to %d\n", *shmptr);
semopbuf.sem_num=0;
semopbuf.sem_op=1;
semopbuf.sem_flg=SEM_UNDO;
semop(semid, &semopbuf, 1); /* V(S1) */
}
}
}
void sigend(int sig)
{
shmctl(shmid, IPC_RMID, 0);
semctl(semid, IPC_RMID, 0);
exit(0);
}
```

#### （三）模拟临界资源访问的示例程序

本示例的临界资源是一个建立在共享存储区的栈，由服务进程建立并初始化。初始状态下共享栈满，里面顺序放置一系列正整数（自栈顶向下：1,2,3...），代表空闲块号。客户进程利用共享栈进行数据块的分配和释放，以得到、归还一个块号代表，并不进行任何后续操作。程序中 `getblock` 过程从共享栈中弹出一个块号（分配），`relblock` 过程把一个已分配块号压入共享栈（释放）。为简单起见，已分配块号在本地也使用栈结构保存，因而每次释放的是最后分配的块号。

编译后执行，第一个进程实例将作为服务进程，提示：

`NO OTHER OPERATION but press Ctrl+C or use kill to end.`

服务进程完成初始化后将进入睡眠状态，直到用户按 `Ctrl+C` 终止执行，或使用 `kill` 命令杀死服务进程。

其他进程实例作为客户进程，进入后首先有命令帮助提示，然后显示命令提示符 `?>`，在命令提示下可以使用的命令包括：

- `help` 显示可用命令
- `list` 列出所有已分配块号
- `get` 分配一个新块
- `rel` 释放最后分配块号
- `end` 退出程序

示例程序的代码如下：

```c
#include <sys/types.h>
#include <unistd.h>
#include <signal.h>
#include <stdio.h>
#include <string.h>
#include <sys/ipc.h>
#include <sys/shm.h>
#define MY_SHMKEY 10071800 // need to change
#define MAX_BLOCK 1024
#define MAX_CMD 8
struct shmbuf {
int top;
int stack[MAX_BLOCK];
} *shmptr, local;
char cmdbuf[MAX_CMD];
int shmid, semid;
void sigend(int);
void relblock(void);
int getblock(void);
void showhelp(void);
void showlist(void);
void getcmdline(void);
int main(void)
{
if((shmid=shmget(MY_SHMKEY, sizeof(struct shmbuf), IPC_CREAT|IPC_EXCL|0666)) < 0)
{ /* shared memory exists, act as client */
shmid=shmget(MY_SHMKEY, sizeof(struct shmbuf), 0666);
shmptr=(struct shmbuf *)shmat(shmid, 0, 0);
local.top=-1;
showhelp();
getcmdline();
while(strcmp(cmdbuf,"end\n"))
{
if(!strcmp(cmdbuf,"get\n"))
getblock();
else if(!strcmp(cmdbuf,"rel\n"))
relblock();
else if(!strcmp(cmdbuf,"list\n"))
showlist();
else if(!strcmp(cmdbuf,"help\n"))
showhelp();
getcmdline();
}
}
else /* acts as server */
{
int i;
shmptr=(struct shmbuf *)shmat(shmid, 0, 0);
signal(SIGINT, sigend);
signal(SIGTERM, sigend);
printf("NO OTHER OPERATION but press Ctrl+C or use kill to end.\n");
shmptr->top=MAX_BLOCK-1;
for(i=0; i<MAX_BLOCK; i++)
shmptr->stack[i]=MAX_BLOCK-i;
sleep(1000000); /* cause sleep forever. */
}
}
void sigend(int sig)
{
shmctl(shmid, IPC_RMID, 0);
semctl(semid, IPC_RMID, 0);
exit(0);
}
void relblock(void)
{
if(local.top<0)
{
printf("No block to release!");
return;
}
shmptr->top++;
shmptr->stack[shmptr->top]=local.stack[local.top--];
}
int getblock(void)
{
if(shmptr->top<0)
{
printf("No free block to get!");
return;
}
local.stack[++local.top]=shmptr->stack[shmptr->top];
shmptr->top--;
}
void showhelp(void)
{
printf("\navailable COMMAND:\n\n");
printf("help\tlist this help\n");
printf("list\tlist all gotten block number\n");
printf("get\tget a new block\n");
printf("rel\trelease the last gotten block\n");
printf("end\texit this program\n");
}
void showlist(void)
{
int i;
printf("List all gotten block number:\n");
for(i=0; i<=local.top; i++)
printf("%d\t", local.stack[i]);
}
void getcmdline(void)
{
printf("\n?> ");
fgets(cmdbuf, MAX_CMD-1, stdin);
}
```

### 四、实验内容

本实验要求内容如下：

#### 1、模拟生产者－消费者

实现相应的示例程序功能，记录执行结果；改造该程序，取消所有的同步机制，记录执行结果，看是否能观察到程序出现错误情况；进一步改造程序，使错误情况易于观察到；记录执行情况并进行分析。

> 【注意】取消同步机制后，消费者进程会连续输出。可以采用诸如增加延时、等待用户输入等方法修改程序，以便观察和记录执行结果。

#### 2、模拟临界资源访问

实现相应的示例程序功能，记录执行结果，看是否能观察到程序出现错误情况；改造该程序，使错误情况易于观察到，记录执行情况并进行分析；利用信号量机制实现进程互斥功能，记录执行结果，并进行对比分析。

---

### 五、实验报告书写要求

应在实验报告中说明如下事项：

1. 相关程序的名称及存储位置，以便指导教师抽查
2. 实验内容 1 中自己修改部分的描述，不同程序执行结果的描述和对比分析
3. 实验内容 2 中自己修改部分的描述，不同程序执行结果的描述和对比分析
