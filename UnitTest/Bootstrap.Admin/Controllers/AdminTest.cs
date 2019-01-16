﻿using System.Net;
using System.Net.Http;
using Xunit;

namespace Bootstrap.Admin.Controllers
{
    public class AdminTest : ControllerTest
    {
        public AdminTest(BAWebHost factory) : base(factory, "Admin", true)
        {

        }

        [Theory]
        [InlineData("Index", "欢迎使用后台管理")]
        [InlineData("Users", "用户管理")]
        [InlineData("Groups", "部门管理")]
        [InlineData("Dicts", "字典表维护")]
        [InlineData("Roles", "角色管理")]
        [InlineData("Menus", "菜单管理")]
        [InlineData("Logs", "系统日志")]
        [InlineData("FAIcon", "图标集")]
        [InlineData("IconView", "图标分类")]
        [InlineData("Settings", "网站设置")]
        [InlineData("Notifications", "通知管理")]
        [InlineData("Profiles", "个人中心")]
        [InlineData("Exceptions", "程序异常")]
        [InlineData("Messages", "站内消息")]
        [InlineData("Tasks", "任务管理")]
        [InlineData("Mobile", "客户端测试")]
        public async void View_Ok(string view, string text)
        {
            var r = await Client.GetAsync(view);
            Assert.True(r.IsSuccessStatusCode);
            var content = await r.Content.ReadAsStringAsync();
            Assert.Contains(text, content);
        }

        [Fact]
        public async void Error_Ok()
        {
            var r = await Client.GetAsync("Error");
            Assert.False(r.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.InternalServerError, r.StatusCode);
        }
    }
}