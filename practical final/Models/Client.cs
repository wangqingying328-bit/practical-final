using System;

// 客户类（OOP：字段 + 属性 + 构造函数）
public class Client
{
    // 客户 ID（数据库主键）
    public int ClientID { get; set; }

    // 客户姓名
    public string Name { get; set; }

    // 出生日期
    public string DOB { get; set; }

    // 地址
    public string Address { get; set; }

    // 手机号
    public string Mobile { get; set; }

}
