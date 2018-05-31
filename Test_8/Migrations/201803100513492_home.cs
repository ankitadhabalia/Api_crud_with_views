namespace Test_8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class home : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserProfiles", "Action", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserProfiles", "Action");
        }
    }
}
