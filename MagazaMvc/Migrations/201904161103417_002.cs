namespace MagazaMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategoris",
                c => new
                    {
                        KategoriId = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false),
                        KategoriSira = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KategoriId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kategoris");
        }
    }
}
