# 机器学习复习整理

## 第一章：绪论

* **机器学习的定义、流程（步骤）**
* **机器学习的分类**
* **奥卡姆剃刀原则 (Occam's Razor)** ：若有多个假设与观察一致，则选最简单的那个。

## 第二章：模型评估与选择

* **误差类型**
  * 泛化误差 (Generalization Error)
  * 经验误差 (Empirical Error)
* **拟合情况**
  * **过拟合 (Overfitting)** ：方差大 (High Variance)，定义及缓解方法（正则化等）。
  * **欠拟合 (Underfitting)** ：偏差大 (High Bias)，定义及缓解方法。
  * *笔记关联 P46：偏差(Bias)对应欠拟合，方差(Variance)对应过拟合。*
* **正则化** ：L1 正则化、L2 正则化。
* **评估方法**
  * 留出法 (Hold-out)
  * 分层采样 (Stratified Sampling)
  * 交叉验证 (Cross-validation)
  * 自助法 (Bootstrap)
* **参数类型**
  * 超参数 (Hyperparameters)
  * 模型参数 (Model Parameters)
* **数据集划分**
  * 训练集 (Training Set)
  * 测试集 (Test Set)：只能使用一次。
  * 验证集 (Validation Set)
* **性能度量 (Metrics)**
  * 查准率 (Precision)
  * 查全率 (Recall)
  * 混淆矩阵 (Confusion Matrix)

## 第三章：线性模型

* **线性回归**
  * 最小二乘法 (Least Squares Method) / 均方误差
  * 梯度下降法 (Gradient Descent)
* **对数几率回归 (Logistic Regression)**
  * 虽然叫“回归”，但 **用于分类** 。
  * 损失函数：交叉熵 (Cross Entropy) / 极大似然估计。
  * **Sigmoid 函数** ：![]()，其中 ![]()。
  * 表示 ![]() 为正类的概率 ![]()。
* **多分类问题**
  * 二分类推广：一对一 (OvO)、一对多 (OvR) ![]() 多分类。

## 第四章：决策树

* **决策树的三种停止条件** ( *参考教材 P74 最后两段* )
* **划分选择 (核心算法)**
  1. **信息增益 (Information Gain)** ![]() ID3 算法
  2. **增益率 (Gain Ratio)** ![]() C4.5 算法
  3. **基尼指数 (Gini Index)** ![]() CART 算法 (生成的树是二叉树)
* **剪枝 (Pruning)**
  * 预剪枝 (Pre-pruning)
  * 后剪枝 (Post-pruning)
* **特殊处理**
  * 连续属性离散化：二分法。
  * 如何处理缺失值？

## 第五章：神经网络

* **多层前馈神经网络** ：权重与偏置的计算。
* **感知机 (Perceptron)**
* **BP 算法 (误差逆传播)**
  * 标准 BP vs 累积 BP
* **梯度下降**
  * 批量梯度下降 (Batch GD)
  * 随机梯度下降 (SGD)

## 第六章：支持向量机 (SVM)

* **对偶问题** ：更容易求解。
* **非线性问题** ：核技巧 (Kernel Trick)。
* **软间隔 (Soft Margin) 与正则化**

## 第七章：贝叶斯分类器

* **后验概率公式 (7.8)**
* **朴素贝叶斯 (Naive Bayes)**
* **半朴素贝叶斯**
* **EM 算法 (Expectation-Maximization)**
* **贝叶斯网定义** ( *参考教材 P156* )

## 第八章：集成学习 (Ensemble Learning)

* **Boosting (串行)**
  * 代表：AdaBoost。
  * 特点：降低偏差 (Bias)。
* **Bagging (并行)**
  * 代表：随机森林 (Random Forest)。
  * 采样方式：自助采样 (Bootstrap)。
  * 特点：降低方差 (Variance)。
* **随机森林 (Random Forest)**
  * 同质集成。
  * **双重随机性** ：比普通 Bagging 要好，包含 **样本的随机** (Bootstrap) 和  **属性选择的随机** 。
* **增强个体学习器多样性的方法** (4个扰动)
  1. 数据样本扰动
  2. 输入属性扰动
  3. 输出表示扰动
  4. 算法参数扰动

## 第九章：聚类

* **原型聚类**
  * K-均值 (K-Means)
  * 学习向量量化 (LVQ)
  * 高斯混合聚类 (GMM) - 基于高斯正态分布
* **密度聚类**
  * DBSCAN 的流程 ( *参考教材 P213* )
* **层次聚类**

## 第十章：降维与度量学习

* **k近邻学习 (kNN)**
  * 懒惰式学习 (Lazy Learning)。
* **主成分分析 (PCA)**
  * 10.13章节，无监督降维。

---

## 考试题型与分值分布

* **选择题** ：10 题 ![]() 2 分 = 20 分
* **判断题** ：10 题 ![]() 2 分 = 20 分
* **简答题** ：4 题，共 30 分
* **计算题** ：2 题，共 30 分

## 重点页码索引 (来源于笔记标注)

* **P46** ：偏差与方差、欠拟合与过拟合的关系。
* **P74** ：决策树的停止条件。
* **P156** ：贝叶斯网定义。
* **P213** ：DBSCAN 聚类流程。
