# Caviar

#### 介绍
Caviar这是一个基于 ABP.NET 和 Vue-Element-Admin 的后台管理系统，包含了 ABP.NET 的所有功能，并且国产化了很多功能，如手机号登录、默认中文等。

#### 软件架构
本项目采用前后端分离的架构，前端使用 Vue-Element-Admin 作为 UI 框架，后端使用 ABP.NET 作为后端框架。

#### 文档

ABP文档地址：https://aspnetboilerplate.com/Pages/Documents

Vue-Element-Admin文档地址：https://panjiachen.gitee.io/vue-element-admin-site/zh/guide/

#### 体验地址

http://caviar.jcwlw.top/

#### 功能

|功能|是否支持
|:------:|:------:
|用户管理|√
|角色管理| √
|权限管理| √
|多语言| √
|多租户| √
|日志| √

### 安装教程

#### 前置条件
+ Node.js v12+
+ .NET 6 SDK
+ Visual Studio 2022 或 Visual Studio Code
````
# 克隆项目
git clone https://gitee.com/Cherryblossoms/abp-caviar

# 前端
cd abp-caviar/web/vue-element-admin
# 安装依赖
npm install
# 启动调试
npm run dev
````
#### 后端
使用 Visual Studio 2022打开项目aspnet-core/Caviar.sln
1.  修改Caviar.Web.Host中appsettings.json数据库连接字符串
2.  在程序包管理器控制台中选择EntityFarmeworkCore项目，执行 Update-Database
3.  设置Caviar.Web.Host为启动项，启动项目


#### 参与贡献

1.  Fork 本仓库
2.  新建 Feat_xxx 分支
3.  提交代码
4.  新建 Pull Request

