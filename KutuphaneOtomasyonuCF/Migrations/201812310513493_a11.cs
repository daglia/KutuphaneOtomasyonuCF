namespace KutuphaneOtomasyonuCF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a11 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Yazars", newName: "Yazarlar");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Yazarlar", newName: "Yazars");
        }
    }
}
