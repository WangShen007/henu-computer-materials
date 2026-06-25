# 第3次课测试

### 1. [单选题]

使用两种编码方案对比特流01100111进行编码的结果如下图所示，编码1和编码2分别是

![image](https://qn-sc0.yuketang.cn/ue_i/20210922/639c14bb-d915-402a-af15-2cbfa4c8681a.png)

A. NRZ和曼切斯特编码

B. NRZ和差分曼切斯特编码

C. NRZI 和曼切斯特编码

D. NRZI和差分曼切斯特编码

**答案**：A

> **解析：**
>
> *   **编码1**：电平高低直接代表0和1（例如高电平代表1，低电平代表0，或者反之），且在码元中间不跳变，这是**不归零制 (NRZ)** 编码。
> *   **编码2**：在每个码元的中心均有跳变。上跳（从低到高）表示0，下跳（从高到低）表示1（或者反之），这是**曼彻斯特编码**的特征。
> *   差分曼彻斯特编码的特征是每一位开始处是否有跳变（有跳变代表0，无跳变代表1），编码2不符合。
>
> 因此选A。

---

### 2. [填空题]

物理层的四个特性与协议三要素（语法、语义、同步）的对应关系是

机械特性对应  **[填空1]** ；

电气特性对应  **[填空2]** ；

功能特性对应  **[填空3]** ；

过程特性对应  **[填空4]** 。

**答案**：

[1] 语法
[2] 语法
[3] 语义
[4] 同步

> **解析：**
>
> 网络协议的三要素是：语法、语义、同步（时序）。
> *   **语法 (Syntax)**：数据与控制信息的结构或格式。物理层的**机械特性**（接口形状、引脚数目）和**电气特性**（电压范围）规定了“长什么样”，属于语法范畴。
> *   **语义 (Semantics)**：需要发出何种控制信息，完成何种动作以及做出何种响应。物理层的**功能特性**（某根线上出现的某一电平的电压表示何种意义）属于语义范畴。
> *   **同步 (Timing/Synchronization)**：事件实现顺序的详细说明。物理层的**过程特性**（对于不同功能的各种可能事件的出现顺序）属于同步（时序）范畴。

---

### 3. [填空题]

**假定某信道受奈氏准则限制的最高码元速率为20000码元/秒。如果采用振幅调制，把码元的振幅划分为16个不同等级来传送，那么可以获得的最高数据率是 **[填空1]** （b/s）。**

**答案**：

[1] 80000

> **解析：**
>
> 根据奈氏准则，无噪声信道的最高数据传输速率 $C$ 为：
> $C = R \times \log_2 V$
> 其中 $R$ 是波特率（码元传输速率），$V$ 是信号状态数（亦称信号电平数）。
> $C = 20000 \times \log_2 16 = 20000 \times 4 = 80000 \text{ (b/s)}$。

---

### 4. [填空题]

香农公式表明信道中的极限信息传输速率与信道的 **[填空1]** 和 **[填空2]** 有关。若某链路的带宽为8kHz，信噪比为30dB，该链路实际数据传输速率约为理论最大数据传输速率的50%，则该链路的信号功率S和噪声功率N的比值，S/N= **[填空3]** ，由香农公式计算出的理想最大数据传输速率约是 **[填空4]** kbps，实际数据传输速率约是 **[填空5]** kbps。（

![image](data:image/png;base64,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)

）

**答案**：

[1] 带宽
[2] 信噪比
[3] 1000
[4] 80
[5] 40

> **解析：**
>
> 1.  香农公式 $C = W \times \log_2(1 + S/N)$ 表明极限传输速率与**带宽** ($W$) 和 **信噪比** ($S/N$) 有关。
> 2.  信噪比 $30\text{dB} = 10 \log_{10}(S/N)$，解得 $S/N = 10^3 = \textbf{1000}$。
> 3.  理想最大数据率 $C = 8000 \times \log_2(1 + 1000) \approx 8000 \times \log_2(1024) = 8000 \times 10 = 80000\text{b/s} = \textbf{80}\text{kbps}$。
> 4.  实际速率 = $50\% \times C = 0.5 \times 80 = \textbf{40}\text{kbps}$。

---

### 5. [单选题]

某无噪声理想低通信道带宽为4MHz，采用QAM调制，若该信道的最大数据传输速率是48Mb/s，则该信道采用的QAM调制方案是（        ）

A. QAM-16

B. QAM-32

C. QAM-64

D. QAM-128

**答案**：C

> **解析：**
>
> 根据奈氏准则（无噪声信道）：
> $C = 2 \times W \times \log_2 V$
> 其中 $C = 48\text{Mb/s}, W = 4\text{MHz}$。
> 注意：题目中给的是最大速率。对于QAM，每个符号携带 $k$ 比特，则数据率 $= R \times k$。奈氏速率上限为 $2W$ 码元/秒。
> $48 \times 10^6 = 2 \times 4 \times 10^6 \times \log_2 V$
> $48 = 8 \times \log_2 V$
> $\log_2 V = 6$
> $V = 2^6 = 64$
> 所以采用 QAM-64 (64个状态)。选C。

---
