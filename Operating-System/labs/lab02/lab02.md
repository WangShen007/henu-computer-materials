# lab02 实验二 Linux 编程基础 实验报告

本文档已完成姓名、学号等个人信息脱敏，并保留原实验内容与关键实现。

## 实验内容

1. 使用 `vi` 编辑 C 语言源程序
2. 使用 `gcc`、`make` 等工具进行编译；执行编译生成的执行文件并分析结果

---

## 实验步骤

- （一）编辑器 `vi` 的使用
- （二）`gcc` 和 `make` 的使用

---

## 实验数据记录

### （一）编辑器 `vi` 的使用

#### 1、调用 `vi`

```bash
$ vi a.c
```

![](assets/lab02/image-01.png)

#### 2、文件的保存和退出

```bash
ESC :wq b.c
```

![](assets/lab02/image-08.png)

![](assets/lab02/image-09.png)

#### 3、可视模式

```bash
ESC V
```

![](assets/lab02/image-10.png)

#### 9、行号

```bash
:set number
```

![](assets/lab02/image-11.png)

#### 10、查找功能

```bash
/t
```

![](assets/lab02/image-12.png)

`n` 查找下一个：

![](assets/lab02/image-13.png)

#### 11、替换功能

```bash
:s /b/a/g
```

![](assets/lab02/image-14.png)

---

### （二）`gcc` 和 `make` 的使用

#### 1、`gcc` 的使用

##### (1) 简单使用方法

```bash
$ gcc a.c
```

![](assets/lab02/image-15.png)

```bash
$ gcc -o testa a.c
```

![](assets/lab02/image-02.png)

##### (2) 分解使用

```bash
$ gcc -E a.c -o a.i
```

![](assets/lab02/image-03.png)

```bash
$ gcc -c hello.i -o hello.o
```

![](assets/lab02/image-04.png)

```bash
$ gcc a.o -o aa
```

![](assets/lab02/image-05.png)

##### (3) 常用参数

#### 2、`make` 的使用

##### (1) `make` 工具简介

```bash
$ make [option] [macrodef] [target]
$ man make
```

![](assets/lab02/image-06.png)

##### (2) `makefile` 文件编写

![](assets/lab02/image-07.png)

---

## 问题讨论

1. 系统 CentOS 6，在 `gcc` 生成 `.h` 文件之后，如果删除会直接卡死，可能是正在占用没关闭
2. 用 `make` 之后，再使用 `make` 需要删除之前 `make` 生成的
