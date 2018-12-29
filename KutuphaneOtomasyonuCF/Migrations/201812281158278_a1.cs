namespace KutuphaneOtomasyonuCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kitaplar",
                c => new
                    {
                        KitapId = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50),
                        YazarId = c.Int(nullable: false),
                        Stok = c.Short(nullable: false),
                        Odunc_OduncId = c.Int(),
                    })
                .PrimaryKey(t => t.KitapId)
                .ForeignKey("dbo.Yazarlar", t => t.YazarId, cascadeDelete: true)
                .ForeignKey("dbo.Oduncler", t => t.Odunc_OduncId)
                .Index(t => t.YazarId)
                .Index(t => t.Odunc_OduncId);
            
            CreateTable(
                "dbo.Yazarlar",
                c => new
                    {
                        YazarId = c.Int(nullable: false, identity: true),
                        YazarAd = c.String(nullable: false, maxLength: 20),
                        YazarSoyad = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.YazarId);
            
            CreateTable(
                "dbo.OduncDetaylar",
                c => new
                    {
                        OduncDetayId = c.Int(nullable: false, identity: true),
                        OduncId = c.Int(nullable: false),
                        GunSayisi = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.OduncDetayId)
                .ForeignKey("dbo.Oduncler", t => t.OduncId, cascadeDelete: true)
                .Index(t => t.OduncId);
            
            CreateTable(
                "dbo.Oduncler",
                c => new
                    {
                        OduncId = c.Int(nullable: false, identity: true),
                        UyeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OduncId)
                .ForeignKey("dbo.Uyeler", t => t.UyeId, cascadeDelete: true)
                .Index(t => t.UyeId);
            
            CreateTable(
                "dbo.Uyeler",
                c => new
                    {
                        UyeId = c.Int(nullable: false, identity: true),
                        UyeAd = c.String(nullable: false, maxLength: 20),
                        UyeSoyad = c.String(nullable: false, maxLength: 20),
                        UyeTCKN = c.String(nullable: false, maxLength: 11),
                        UyeTelefon = c.String(maxLength: 10),
                        UyeMail = c.String(maxLength: 30),
                    })
                .PrimaryKey(t => t.UyeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OduncDetaylar", "OduncId", "dbo.Oduncler");
            DropForeignKey("dbo.Oduncler", "UyeId", "dbo.Uyeler");
            DropForeignKey("dbo.Kitaplar", "Odunc_OduncId", "dbo.Oduncler");
            DropForeignKey("dbo.Kitaplar", "YazarId", "dbo.Yazarlar");
            DropIndex("dbo.Oduncler", new[] { "UyeId" });
            DropIndex("dbo.OduncDetaylar", new[] { "OduncId" });
            DropIndex("dbo.Kitaplar", new[] { "Odunc_OduncId" });
            DropIndex("dbo.Kitaplar", new[] { "YazarId" });
            DropTable("dbo.Uyeler");
            DropTable("dbo.Oduncler");
            DropTable("dbo.OduncDetaylar");
            DropTable("dbo.Yazarlar");
            DropTable("dbo.Kitaplar");
        }
    }
}
