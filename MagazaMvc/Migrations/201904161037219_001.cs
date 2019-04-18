namespace MagazaMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Uruns",
                c => new
                    {
                        UrunId = c.Int(nullable: false, identity: true),
                        UrunAdi = c.String(nullable: false),
                        UrunKategori = c.String(nullable: false),
                        UrunAciklama = c.String(),
                        UrunFiyat = c.Double(nullable: false),
                        UrunTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UrunId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Uruns");
        }
    }
}
