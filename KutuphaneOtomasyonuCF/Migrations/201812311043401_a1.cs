namespace KutuphaneOtomasyonuCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kitaplar", "Ad", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kitaplar", "Ad", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
