namespace MvcPersonalProject.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgr2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.About", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contact", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Experiences", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ProjectDones", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Services", "ModifiedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.User", "ModifiedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Services", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.ProjectDones", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Experiences", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.Contact", "ModifiedOn", c => c.DateTime());
            AlterColumn("dbo.About", "ModifiedOn", c => c.DateTime());
        }
    }
}
