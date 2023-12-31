## StardewMUI 2023 / SMUI 6
由 1059 Studio 再度打造的 SMUI 系列 第六代 星露谷模组管理器，正在持续开发中。基于 .NET 8 运行框架，使用 SunnyUI 设计的全新现代化交互界面，重新编写的更高性能的核心处理，更好的视觉效果，更高的集成度，全新的特性以及更多。

| 地址 | 状态和用途 |
| --- | --- |
| [Azure DevOps](https://dev.azure.com/Lake1059/SMUI-PROJS) | 开发者协作仓库 |
| [Fandom](https://stardewmui.fandom.com/zh/wiki/StardewMUI_Wiki) | 产品维基 |
| [GitHub](https://github.com/Lake1059/SMUI-2023) | Git 备份、全球下载更新和静态服务器 |
| [Gitee](https://gitee.com/Lake1059/SMUI-2023) | 国内下载更新和静态服务器 |
| [Bitbucket](https://bitbucket.org/smui-projs/smui-2023/downloads/) | 备选下载更新服务器 |

## DLC
第六代继续保持五代一样的 DLC 销售模式，本体免费，部分功能付费解锁。且五代与六代的购买互通（注意解锁用的 DLL 文件不互通），如果已经购买五代的内容，则也意味着已经购买六代的对应内容，反之同理。只需下载对应产品的 DLL 文件即可直接解锁，无需重新购买。

### Season Pass
我将在第六代产品开始推出季票的购买选项，以代替销售平台的捆绑包销售模式，仅需一个季票的 DLL 文件即可代替单独 DLC 的 DLL 文件。首先将推出 Season Pass 2023，可直接获得于 2023 年结束之前的所有 DLC 内容。

## 第六代中的全新内容
核心完全重构，重新定义了全部安装命令以及实现方式，用全新的安装规划取代了安装命令，用户不再需要编写安装命令，现在这部分内容由程序全部负责，在用户端使用全可视化的操作即可完成配置项。当然这意味着你需要重新学习配置项的操作，不过将会变得十分简单。

+ 来自 SunnyUI 的全新交互元素，高端专业
+ 基于 DarkUI 定制的右键菜单重绘样式
+ 全新自绘制列表视图，再无蓝色焦点和键盘虚线框
+ 适配超高 DPI，4K、8K 屏也能舒适使用
+ 分类和项全面支持手动排序，全新的虚拟组概念
+ 统合模组下载更新程序，集成面板显示
+ 全新的指引设计，以及更多新功能

## 技术对比
|  | SMUI 6 | SMUI 5 | Vortex | 传统管理器 | 手动 |
| --- | --- | --- | --- | --- | --- |
| 生态 | 离线为主<br>联网为辅 | 离线为主<br>联网为辅 | 在线为主<br>网站依赖 | 纯本地 | 累死 |
| 开发框架 | .NET 8 独立 | .NET F 4.8 | Script | Electron<br>Java 等 | 无 |
| 批量管理 | 高速批量 | 高速批量 | 又累又慢 | 一般 | 累死 |
| 类型支持 | 全部支持 | 全部支持 | 仅标准 | 仅标准 | 累死 |
| 信息分析 | 全面读取 | 全面读取 | 仅基本 | 可能没有 | 无 |
| 界面元素 | SunnyUI | DarkUI | 类 web | 类 web | 文件管理器 |
| 可扩展性 | 无限制 | 无限制 | 无 | 无 | 无 |
| 语言支持 | 随意编辑 | 随意编辑 | 更新不及时 | 单语言 | 无 |
| 自我更新 | 自动执行 | 自动执行 | 墙了 | 仅检查 | 无 |
| 学习成本 | 基本逻辑思维 | 基本编程思维 | 难蚌 | 简单 | 难以描述 |
| 硬件消耗 | 硬盘消耗 x 2 | 硬盘消耗 x 2 | CPU 消耗 + | 普通 | 难受 |

## Git
写给我自己的，我懒得记 Git 代码所以就直接写这里方便复制了

设置全局代理  
<code>git config --global http.proxy http://127.0.0.1:7890</code>  
<code>git config --global https.proxy https://127.0.0.1:7890</code>

同步仓库到 Github  
<code>git push --mirror github</code>