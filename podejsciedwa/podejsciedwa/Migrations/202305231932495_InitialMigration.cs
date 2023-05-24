namespace podejsciedwa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aktors", "Nazwisko", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Aktors", "Nazwisko", c => c.Int(nullable: false));
        }
    }
}
