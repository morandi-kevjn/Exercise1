namespace Exercise1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    // created in ep92

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2e009799-bcd7-47c7-a174-0c5cc5d363a3', N'mk@domai.com', 0, N'AOGWhGug6P9GsmSEnZ+Vk+w1pchRCSGgunEZ4ZAQGxs52+ntQ3LOhLzK/C0yuunFgg==', N'ec900687-39a9-4845-99a6-1d6932cf62b9', NULL, 0, 0, NULL, 1, 0, N'mk@domai.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a41eb62c-4bf3-4646-8c8d-17b56d1eecc9', N'administrator@ex1.com', 0, N'APJAX82kr1LrEUgoSbTwuFwE544bH1c0MXHXWleGeSBSplHRx/tjQkcLaC/igq+Tcg==', N'28a6a6e1-880a-4d52-bd2b-4b3315e5215d', NULL, 0, 0, NULL, 1, 0, N'administrator@ex1.com')

            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'954479ce-cc4a-4511-9a99-12c04985b9ed', N'CanManageMovie')
    
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a41eb62c-4bf3-4646-8c8d-17b56d1eecc9', N'954479ce-cc4a-4511-9a99-12c04985b9ed')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
