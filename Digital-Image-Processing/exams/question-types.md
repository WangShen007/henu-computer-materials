#  数字图像处理考试题型及复习指导

##  考试题型分布

###  选择题
分值： 30分（15题 × 2分）

### 简答分析题
分值： 10分（2题：4分 + 6分）
内容： 关键技术说明，类似课后习题，包含信息主要内容核心技术

### 程序分析题
分值： 25分（2题：10分 + 15分）
形式：
1. 给出程序，根据注释选择程序功能（需理解程序逻辑）
2. 根据程序写注释，分析程序用途

### 综合题
内容： 图像增强、滤波、写出处理结果及作用

### 应用题
内容： 根据需求阐述操作、核心算法及思想原理

---

## 任务要求

### 选择题：30分 = 15×2（重要的两个）
### 分析题：10分 = 4+6（关键技术分析，类似课后习题，包含信息主要内容核心技术）
### 程序分析题：25分 = 10+15
1. 告诉你进行图像处理，给你程序，从备选项中选择对应功能（需理解程序逻辑）
2. 分析给定程序的用途

### 综合题：
- 核心技术应用（模板处理、平滑锐化）
- 说明处理作用（实域+频域等）
- 写出处理结果

### 需求实现：
- 阐述预处理核心算法、思想、原理及效果
- 图像变换思想（傅立叶变换性质等）
- 技术操作（图像增强、复原、压缩、彩色图像处理）

---

# 《数字图像处理及MATLAB实现（第3版）》

教材信息： 杨杰 主编｜黄朝兵 副主编｜电子工业出版社

---

## 第一部分 图像处理基础

### 第1章 概述（Introduction）

#### 1.1 数字图像处理及特点（Characteristics and Processing of Digital Image）
- 1.1.1 数字图像与数字图像处理（Digital Image and Digital Image Processing）
- 1.2 数字图像处理的特点（Characteristics of Digital Image Processing）
  - !!!概念!!!

#### 1.2 数字图像处理系统（System of Digital Image Processing）
- 1.2.1 数字图像处理系统的结构（Structure of Digital Image Processing System）
- 1.2.2 数字图像处理的优点（Advantages of Digital Image Processing）

####  1.3 数字图像处理的研究内容（Research Content in Digital Image Processing）

##### 重点

#### 1.4 数字图像处理的应用和发展（Applications and Development）
- 1.4.1 数字图像处理的应用（Applications）
- 1.4.2 发展动向（Future Direction）

#### 1.5 全书内容简介（Brief Introduction）
- 小结（Summary）
- 习题（Exercises）

---

### 第2章 数字图像处理的基础（Basics）

#### 2.1 人类的视觉系统（Visual System）
- 2.1.1 视觉系统的基本构造（Basic Structure）
- 2.1.2 亮度适应和鉴别（Intensity Adaption)

#### 2.2 数字图像的基础知识（Basics of Digital Image）
- 重点：采样 量化
- 2.2.1 图像的数字化及表达（Image Digitalization）
- 2.2.2 图像的获取（Image Acquisition）
- 2.2.3 像素间的基本关系（Pixel Relationships）
- 2.2.4 图像的分类（Image Classification）
- 小结（Summary）
- 习题（Exercises）

---

### 第3章 图像基本运算（Basic Operations）

#### 3.1 概述（Introduction）

####  3.2 点运算（Point Operation）

#####重点

- 3.2.1 线性点运算（Linear Point Operation）
- 3.2.2 非线性点运算（Non-Linear Point Operation）

####  3.3 代数运算与逻辑运算（Algebra and Logical Operation）
#####重点

- 3.3.1 加法运算（Addition）
- 3.3.2 减法运算（Subtraction）
- 3.3.3 乘法运算（Multiplication）
- 3.3.4 除法运算（Division）
- 3.3.5 逻辑运算（Logical Operation）

#### 3.4 几何运算（Geometric Operation）
- 3.4.1 图像的平移（Translation）
- 3.4.2 图像的镜像（Mirror）
- 3.4.3 图像的旋转（Rotation）
- 3.4.4 图像的缩放（Zoom）
- 3.4.5 灰度重采样（Gray Resampling）
- 小结（Summary）
- 习题（Exercises）

---

### 第4章 图像变换（Image Transform）

#### 4.1 连续傅里叶变换（Continuous Fourier Transform）

#### 4.2 离散傅里叶变换（Discrete Fourier Transform）

#### 4.3 快速傅里叶变换（Fast Fourier Transform）

#### 4.4 傅里叶变换的性质（Properties）
#####原理!!!!

- 4.4.1 可分离性（Separability）
- 4.4.2 平移性质（Translation）
- 4.4.3 周期性和共轭对称性（Periodicity）
- 4.4.4 旋转性质（Rotation）
- 4.4.5 分配律（Distribution Law）
- 4.4.6 尺度变换（Scaling）
- 4.4.7 平均值（Average Value）
- 4.4.8 卷积定理（Convolution Theorem）

#### 4.5 图像傅里叶变换实例（Examples）

#### 4.6 其他离散变换（Other Discrete Transform）
- 4.6.1 离散余弦变换（DCT）
  #####性质!!
- 4.6.2 沃尔什—哈达玛变换（Walsh-Hadamard）
- 4.6.3 卡胡梅—列夫变换（K-L Transform）
- 小结（Summary）
- 习题（Exercises）

---

## 🔧 第二部分 图像处理技术

### 第5章 图像增强（Image Enhancement）

#### 5.1 图像增强的概念和分类（Concepts）

####  5.2 空间域图像增强（Spatial Domain）

#####重点

- 5.2.1 基于灰度变换（Gray Levels）
- 5.2.2 基于直方图处理（Histogram Processing
- 5.2.3 空间域滤波增强（Spatial Filtering）

#### 5.3 频率域图像增强（Frequency Domain）
- 5.3.1 频率域增强基本理论（Fundamentals）
- 5.3.2 频率域平滑滤波器（Smoothing Filters）
  #####算子
- 5.3.3 频率域锐化滤波器（Sharpening Filters）
  #####算子
- 5.3.4 同态滤波器（Homomorphic Filters）
- 小结（Summary）
- 习题（Exercises）

---

### 第6章 图像复原（Image Restoration）

#### 6.1 图像复原及退化模型（Fundamentals）
#####原理!!!!

- 6.1.1 图像退化的原因及模型（Degradation Model）
- 6.1.2 数学模型（Mathematic Model）
- 6.1.3 复原技术的分类（Categories）

#### 6.2 噪声模型（Noise Models）
#####处理!!!

- 6.2.1 噪声概率密度函数（PDF）
- 6.2.2 噪声参数的估计（Estimation）

#### 6.3 空间域滤波复原（Spatial Filtering）
- 6.3.1 均值滤波器（Mean Filters）
- 6.3.2 顺序统计滤波器（Order-Statistics

#### 6.4 频率域滤波复原（Frequency Domain Filtering）
#####重点!

- 6.4.1 带阻滤波器（Bandreject）
- 6.4.2 带通滤波器（Bandpass）
- 6.4.3 其他频率域滤波器（Other Filters）

#### 6.5 估计退化函数（Estimating Degradation）
- 6.5.1 图像观察估计法（Image Observation）
- 6.5.2 试验估计法（Experimentation）
- 6.5.3 模型估计法（Modeling）

#### 6.6 逆滤波（Inverse Filtering）

#### 6.7 最小均方误差滤波——维纳滤波（Wiener Filtering）

#### 6.8 几何失真校正（Geometric Distortion Correction）
- 6.8.1 空间变换（Spatial Transformation）
- 6.8.2 灰度插值（Gray-Level Interpolation）
- 6.8.3 实现（Implementation）
- 小结（Summary）
- 习题（Exercises）

---

### 第7章 图像压缩编码（Image Compression）

#### 7.1 概述（Introduction）
- 7.1.1 图像的信息量与信息熵（Entropy）
- 7.1.2 图像数据冗余（Data Redundancy）
- 7.1.3 图像压缩编码方法（Coding Methods）
- 7.1.4 性能指标（Performance Index
- 7.1.5 保真度准则（Fidelity Criteria）

####  7.2 无失真图像压缩编码（Lossless Compression）
#####原理

- 7.2.1 哈夫曼编码（Huffman Coding）
- 7.2.2 游程编码（Run-Length Coding）
- 7.2.3 算术编码（Arithmetic Coding）

#### 7.3 有限失真图像压缩编码（Lossy Compression）
#####原理

- 7.3.1 率失真函数（Rate Distortion Function）
- 7.3.2 预测编码和变换编码（Prediction & Transform Coding）
- 7.3.3 矢量量化编码（Vector Quantification）

#### 7.4 图像编码新技术（New Technology）
- 7.4.1 子带编码（Subband Coding）
- 7.4.2 模型基编码（Model-Based Coding）
- 7.4.3 分形编码（Fractal Coding）

#### 7.5 图像压缩技术标准（Compression Standards）
#####度量

- 7.5.2 JPEG 压缩（JPEG Compression）
- 7.5.3 JPEG 2000
- 7.5.4 H.26x 标准（H.26x Standards）
- 7.5.5 MPEG 标准（MPEG Standards）
- 小结（Summary）
- 习题（Exercises）

---

### 第8章 图像分割（Image Segmentation）

#### 8.1 概述（Introduction）

#### 8.2 边缘检测和连接（Edge Detection）
- 8.2.1 边缘检测（Edge Detection）
- 8.2.2 边缘连接（Edge Connection）

#### 8.3 阈值分割（Threshold）
- 8.3.1 基础（Foundation）
- 8.3.2 全局阈值（Global Threshold）
- 8.3.3 自适应阈值（Adaptive Threshold）
- 8.3.4 最佳阈值的选择（Optimal Threshold）
- 8.3.5 分水岭算法（Watershed Algorithm）

#### 8.4 区域分割（Region Segmentation）
- 8.4.1 区域生长法（Region Growing）
- 8.4.2 区域分裂合并法（Region Splitting and Merging）

#### 8.5 二值图像处理（Binary Image Processing）
#####腐蚀膨胀

- 8.5.1 数学形态学（Mathematical Morphology）
- 8.5.2 开运算和闭运算（Open & Close Operation）
- 8.5.3 基本形态学算法（Basic Algorithms）

#### 8.6 分割图像的结构（Construction）
- 8.6.1 物体隶属关系图（Object Relationships）
- 8.6.2 边界链码（Edge Chain Code）
- 小结（Summary）
- 习题（Exercises）

---

## 🎨 第三部分 图像处理的扩展内容

### 第9章 彩色图像处理（Color Image Processing）

#### 9.1 彩色图像基础（Fundamentals）
- 9.1.1 彩色图像的概念（Concepts）
- 9.1.2 彩色基础（Color Fundamentals）

####  9.2 彩色模型（Color Models）
- 9.2.1 RGB 彩色模型（RGB Model）
- 9.2.2 CMY/CMYK 模型（CMY/CMYK Model）
  #####打印机
- 9.2.3 HIS 彩色模型（HSI Model）
  #####人类视觉

#### 9.3 伪彩色处理（Pseudocolor Processing）
#####原理!

- 9.3.1 背景（Background）
- 9.3.2 强度分层（Intensity Slicing）
- 9.3.3 灰度级到彩色变换（Transformation of Gray Levels to Color）
- 9.3.4 假彩色处理（False-Color Image Processing）

#### 9.4 全彩色图像处理（Full-Color Image Processing）
- 9.4.1 全彩色图像处理基础（Basics of Full-Color Image Processing）
- 9.4.2 彩色平衡（Color Balance）
- 9.4.3 彩色图像增强（Color Image Enhancement）
- 9.4.4 彩色图像平滑（Color Image Smoothing）
- 9.4.5 彩色图像锐化（Color Image Sharpening）

#### 9.5 彩色图像分割（Color Image Segmentation）
- 9.5.1 HSI 彩色空间分割（Segmentation in HSI Color Space）
- 9.5.2 RGB 彩色空间分割（Segmentation in RGB Color Space）
- 9.5.3 彩色边缘检测（Color Edge Detection）

#### 9.6 彩色图像处理的应用（Applications of Color Image Processing）
- 小结（Summary）
- 习题（Exercises）

---

### 第10章 图像表示与描述（Image Representation and Description）

#### 10.1 背景（Background）

#### 10.2 颜色特征（Color Feature）
- 10.2.1 灰度特征（Gray Feature）
- 10.2.2 直方图特征（Histogram Feature）
- 10.2.3 颜色矩（Color Moment）

#### 10.3 纹理特征（Textural Feature）
- 10.3.1 自相关函数（Autocorrelation Function）
- 10.3.2 灰度差分统计（Statistics of Intensity Difference）
- 10.3.3 灰度共生矩阵（Gray-Level Co-occurrence Matrix）
- 10.3.4 频谱特征（Spectrum Features）

#### 10.4 边界特征（Boundary Feature）
- 10.4.1 边界表达（Boundary Representation）
- 10.4.2 边界特征描述（Boundary Description）

#### 10.5 区域特征（Region Feature）
- 10.5.1 简单的区域描述（Simple Region Descriptors）
- 10.5.2 拓扑描述（Topological Descriptors）
- 10.5.3 形状描述（Shape Descriptors）
- 10.5.4 矩（Moment）

#### 10.6 运用主成分进行描述（Use of Principal Components for Description）
- 10.6.1 主成分基础（Fundamentals of Principal Components Analysis）
- 10.6.2 主成分描述（Description by Principal Components Analysis）

#### 10.7 特征提取的应用（Application of Feature Extraction）
- 10.7.1 粒度测定（Granularity Mensuration）
- 10.7.2 圆形目标判别（Circle Shape Recognition）
- 10.7.3 运动目标特征提取（Feature Extraction of Moving Object）
- 小结（Summary）