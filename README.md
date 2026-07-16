# 2D Demo

一个基于 Unity 开发的 2D 动作生存类 Demo。项目包含玩家战斗、怪物 AI、Boss 多阶段战斗、对象池、UI 流程、音频管理、设置保存和 ScriptableObject 数值配置等系统。

本项目主要用于展示 Unity 客户端 / 玩法开发能力。

## 项目亮点

- 使用状态机管理玩家、小怪和 Boss 的行为切换
- 使用对象池管理怪物、子弹、火焰、剑气和技能特效
- 使用事件机制解耦血量、UI、音频和游戏流程
- 实现 Boss 入场、小怪撤离、Boss 双阶段战斗和胜利流程
- 使用 ScriptableObject 配置 Boss 血量、阶段阈值、移动速度和攻击节奏
- 使用 PlayerPrefs 保存音量、静音和分辨率设置

## 项目信息

- 引擎版本：Unity 2022.3.62f3c1
- 开发语言：C#
- 项目类型：2D 动作 / 生存 / Boss 战 Demo
- 主要场景：
  - `MainMenu`：主菜单
  - `SampleScene`：战斗场景

## 玩法简介

玩家在场景中移动并攻击不断出现的小怪。击杀一定数量的小怪后，游戏进入 Boss 出场流程：场上存活小怪撤离，Boss 登场并进入 Boss 战。Boss 拥有阶段切换和多种攻击方式，玩家击败 Boss 后进入胜利界面。

## 操作方式

- 移动：WASD / 方向键
- 攻击：鼠标左键
- 暂停：Esc
- 设置：主菜单或暂停菜单中进入 Setting

## 已实现功能

### 玩家系统

- 玩家移动
- 鼠标点击方向攻击
- 攻击方向判定
- SwordWave 攻击生成
- 玩家血量
- 受击反馈
- 死亡流程
- 输入在暂停、死亡、Boss 入场阶段自动禁用

### 怪物系统

项目中实现了多种怪物类型：

- Torch 近战怪
- TNT 自爆 / 投掷类怪物
- Barrel 爆炸桶怪物

怪物包含：

- 状态切换
- 移动 / 追逐 / 游走 / 攻击 / 死亡
- 受击与死亡事件
- 音效绑定
- 对象池回收
- Boss 入场时撤离逻辑

### Boss 系统

Boss 包含完整的战斗流程：

- Boss 入场
- Boss 血条 UI
- Boss 双阶段战斗
- Phase 1 火焰攻击
- Phase 2 子弹类攻击
- MagicCircle 攻击前摇提示
- Boss 受击音效
- Boss 死亡后进入胜利流程
- Boss 数值使用 ScriptableObject 配置

### UI 系统

已实现：

- 主菜单
- 暂停菜单
- 设置界面
- GameOver 界面
- Win 界面
- 玩家血量显示
- Boss 血条
- Boss 入场 Warning 提示

UI 与游戏流程通过事件和状态联动，避免直接由角色脚本控制 UI。

#### 栈式 UI 返回

设置界面可以从主菜单或暂停菜单进入。为避免不同入口各自编写返回逻辑，项目使用 `UINavigator` 维护 UI 返回栈：

- 打开新界面时，将当前界面压入栈中，并显示目标界面
- 点击 Back 或按下 Esc 时，优先从栈中返回上一级界面
- 如果已经没有上一级界面，则执行当前场景的默认行为，例如退出暂停或退出游戏

主菜单场景和战斗场景分别维护自己的 `UINavigator`。同一条 UI 路径中的入口界面和设置界面必须引用同一个 `UINavigator`，例如：

```text
MainMenuUI.navigator == EditUI.navigator
PauseUI.navigator    == EditUI.navigator
```

这样 `Setting` 不需要关心自己来自主菜单还是暂停菜单，Back 按钮和 Esc 键可以复用同一套返回逻辑。

### 音频系统

已实现：

- BGM / SFX 分离
- 主菜单 BGM
- 战斗 BGM
- Boss 战 BGM
- 按钮音效
- 玩家攻击 / 受击 / 死亡音效
- 怪物受击 / 死亡音效
- Boss 攻击 / 受击 / 死亡音效
- 音量 Slider
- Master / BGM / SFX 静音
- PlayerPrefs 保存音量和静音设置

### 对象池系统

项目中使用对象池管理频繁生成和回收的对象，例如：

- 怪物
- 子弹
- 火焰
- SwordWave
- Bomb
- BulletCircle
- FlameballCircle

通过对象池减少频繁 `Instantiate` / `Destroy` 带来的性能开销。

### 配置系统

Boss 数值使用 `ScriptableObject` 配置：

- 最大血量
- 二阶段血量阈值
- 移动速度
- 追逐距离
- 攻击前摇时间
- 攻击冷却时间

配置文件位置：

```text
Assets/Config/BossConfig.asset
```

配置脚本位置：

```text
Assets/Scripts/Config/BossConfig.cs
```

## 技术点

本项目主要练习和展示以下 Unity 客户端开发能力：

- 状态机控制角色、怪物和 Boss 行为
- 事件驱动 UI / 音频 / 游戏流程
- 对象池复用动态生成物
- ScriptableObject 数值配置
- PlayerPrefs 本地设置保存
- Unity UI 系统
- 栈式 UI 导航与 Back / Esc 统一返回逻辑
- Animator / 动画事件
- 2D 碰撞与 Hitbox
- 协程控制攻击前摇、回收、阶段切换流程
- 场景切换与暂停控制

## 项目结构

```text
Assets/Scripts
├── Player              玩家输入、移动、攻击、血量、动画、音频
├── Torch               近战怪物
├── TNT                 TNT 怪物
├── Barrel              爆炸桶怪物
├── Boss                Boss 状态、移动、攻击、阶段、血量
├── BossIntro           Boss 入场流程
├── Bullet              子弹
├── BulletCircle        子弹圆形组
├── Fire                火焰攻击
├── FlameballCircle     火焰环绕攻击
├── SwordWave           玩家剑气
├── UI                  菜单、设置、血条、胜负界面
├── Config              ScriptableObject 配置
├── PoolManager.cs      对象池
├── GameFlowController.cs 游戏流程控制
└── AudioManager.cs     音频管理
```

## 如何运行

1. 使用 Unity 2022.3.62f3c1 或相近版本打开项目
2. 打开场景：

```text
Assets/Scenes/MainMenu.unity
```

3. 点击 Play
4. 从主菜单进入游戏

## 项目展示

- 演示视频：待补充
- 可运行版本：待补充
- 项目截图：待补充

## 后续优化计划

- 增加 MonsterConfig 和 PlayerConfig，继续减少硬编码数值
- 进一步拆分通用受击反馈组件
- 优化 Boss 技能表现和阶段提示
- 增加屏幕震动、受击停顿等战斗反馈
- 清理残留调试代码
- 补充演示视频和项目截图

## 个人负责

本项目由本人独立开发，负责玩法逻辑、怪物 AI、Boss 战斗、UI 流程、音频系统、对象池和配置系统实现。项目目标是完成一个具有开始、战斗、Boss、胜利 / 失败流程的 2D 动作生存类 Demo。
