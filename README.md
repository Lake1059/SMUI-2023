## 古希腊掌管星露谷模组管理的神 SMUI 2023 / 6
![GitHub Downloads (specific asset, latest release)](https://img.shields.io/github/downloads/Lake1059/SMUI-2023/latest/SMUI.6.Installer.exe?label=最新下载次数&color=blue)
![GitHub Release](https://img.shields.io/github/v/release/Lake1059/SMUI-2023?label=当前版本)
![GitHub License](https://img.shields.io/github/license/Lake1059/SMUI-2023?label=许可证&color=forestgreen)
![GitHub Repo stars](https://img.shields.io/github/stars/Lake1059/SMUI-2023?style=flat&label=星标)
![GitHub repo size](https://img.shields.io/github/repo-size/Lake1059/SMUI-2023?label=仓库大小)
![GitHub last commit](https://img.shields.io/github/last-commit/Lake1059/SMUI-2023?label=上次提交时间&color=forestgreen)  
![Static Badge](https://img.shields.io/badge/推荐操作系统-Windows_10_1809+_&_11-blue)
![Static Badge](https://img.shields.io/badge/可能运行-Windows_7_SP1_&_8_&_8.1-darkred)
![Static Badge](https://img.shields.io/badge/不兼容-任何_32_位操作系统-darkred)

由 1059 Studio 再度打造的 SMUI 系列 第六代 星露谷模组管理器，正在持续开发中。基于 .NET 8 运行框架，使用 SunnyUI 设计的全新现代化交互界面，重新编写的更高性能的核心处理，更好的视觉效果，更高的集成度，全新的特性以及更多。

### [小白提醒：点这里去发行版下载安装程序，而不是下载仓库](https://github.com/Lake1059/SMUI-2023/releases)

寻找跨平台开发者：我没有技术开发其他操作系统上的版本，如果你有相应的前端能力并且能够调用 .NET 的 dll，欢迎联系我协商合作。Linux、macOS、Android、WebUI 都可以。

## 功能
<img src="Res/Cover1.png" width="" height="500" >

---
> ### 如果你还在犹豫
>
> 当你学会了之后你就不会再想换到其他管理器了，除非没学会。
---

| 特点 | 介绍 |
| :--- | :--- |
| 支持全部类型的模组安装方法 | 看家技术，一直在创新从未被超越。全球仅此一个真正做到支持全部类型的模组安装方法，无论是标准 SMAPI 模组、内容覆盖型、文件替换或新增、大量 XNB 替换，还是 Reshade 渲染、进行条件判断、实现高级安装规则等等，全部支持。 |
| 现代风格的 Win32 界面 | 借助 SunnyUI 的高质量界面元素、DarkUI 源代码定制、独特的 Listview 自绘制，六代的视觉效果十分符合现代设计，触控体验也不错。你可能完全想不到这就是用 Windows 标准控件堆出来的界面。 |
| 从多个源直接更新模组 | 支持从 NEXUS、ModDrop、Github 三个源直接更新模组。<br>当然有一点遗憾的是不支持所谓的全自动批量更新，过程中需要人为干预。这里边有无法解决的不稳定因素，其他管理器能全自动也并不代表他们解决了这些问题，当特殊情况发生时他们就会出问题，而使用 SMUI 的你总是主动判断情况进行操作，始终稳如老狗。 |
| 清晰明了的目录型分类 | 每一个模组项都会在自己的分类下，就像你去图书馆，每一本书总会在指定的归类下。当然你可能觉得不够用，那么即将推出的虚拟组会满足你的全部需要，这就像是对每一本书进行标签索引，根据你的自身需要灵活利用其特性来实现意想不到的效果。 |
| 离线使用和数据共享 | SMUI 的设计始终以离线使用为主要路线，联网功能都是辅助，以确保你在任何时候都能畅快使用。你还可以直接将自己的数据导出共享给他人，其他人直接导入就开箱即用，节省大量群体人力成本。 |
| 有史以来上手成本最低的一代 | 通过不断的技术迭代，六代将上手门槛拉到了极低，只要学会了原始的模组安装并且有基本的动手能力就可以放心入手。当然众所周知现在大众的计算机能力大幅下降，这点要求对很多人来说还是太高了，怎么不直接喂饭呢。 |
| 可选付费内容无防护可偷渡 | SMUI 通过可选的 DLC 内容来盈利，完全的离线激活，没有任何身份验证。如果你没有足够的资金，可以通过一些手段偷渡，对技术的要求也不是很高，我也不会生气，当然等你有钱了还是不要忘记补票。 |

## 链接
| 地址 | 状态和用途 |
| --- | --- |
| [Azure DevOps](https://dev.azure.com/Lake1059/SMUI-PROJS) | 仓库实际位置 |
| [GitHub](https://github.com/Lake1059/SMUI-2023) | 当备份、全球下载更新和静态服务器 |
| [Gitee](https://gitee.com/Lake1059/SMUI-2023) | 国内下载更新和静态服务器 |
| [Bitbucket](https://bitbucket.org/smui-projs/smui-2023/downloads/) | 备选下载更新服务器（更新不及时） |

## DLC 购买自动继承
五代与六代的购买互通（注意解锁用的 DLL 文件不互通），如果已经购买五代的内容，则也意味着已经购买六代的对应内容，反之同理。只需下载对应产品的 DLL 文件即可，无需重新购买。

## Git
写给我自己的，我懒得记 Git 代码所以就直接写这里方便复制了

设置全局代理  
<code>git config --global http.proxy http://127.0.0.1:7890</code>  
<code>git config --global https.proxy https://127.0.0.1:7890</code>

同步仓库到 Github  
<code>git push --mirror github</code>