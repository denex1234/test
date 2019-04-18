namespace MagazaMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kullanici : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanicis",
                c => new
                    {
                        KullaniciId = c.Int(nullable: false, identity: true),
                        KullaniciAdi = c.String(),
                        KullaniciSifre = c.String(),
                    })
                .PrimaryKey(t => t.KullaniciId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kullanicis");
        }
    }
}
