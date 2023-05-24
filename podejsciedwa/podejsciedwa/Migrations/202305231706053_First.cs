namespace podejsciedwa.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aktors",
                c => new
                    {
                        AktorId = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AktorId);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        Tytul = c.String(),
                        Gatunek = c.Int(nullable: false),
                        AktorId = c.Int(),
                        BibliotekaId = c.Int(),
                    })
                .PrimaryKey(t => t.FilmId)
                .ForeignKey("dbo.Aktors", t => t.AktorId)
                .ForeignKey("dbo.Bibliotekas", t => t.BibliotekaId)
                .Index(t => t.AktorId)
                .Index(t => t.BibliotekaId);
            
            CreateTable(
                "dbo.Bibliotekas",
                c => new
                    {
                        BibliotekaId = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                    })
                .PrimaryKey(t => t.BibliotekaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "BibliotekaId", "dbo.Bibliotekas");
            DropForeignKey("dbo.Films", "AktorId", "dbo.Aktors");
            DropIndex("dbo.Films", new[] { "BibliotekaId" });
            DropIndex("dbo.Films", new[] { "AktorId" });
            DropTable("dbo.Bibliotekas");
            DropTable("dbo.Films");
            DropTable("dbo.Aktors");
        }
    }
}
