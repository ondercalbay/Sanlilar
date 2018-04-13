namespace Sanlilar.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Kategoriler : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Mobilya.Kategori",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adi = c.String(nullable: false, maxLength: 100),
                        UstKategoriId = c.Int(),
                        EkleyenId = c.Int(nullable: false),
                        EklemeZamani = c.DateTime(nullable: false),
                        GuncelleyenId = c.Int(nullable: false),
                        GuncellemeZamani = c.DateTime(nullable: false),
                        Aktif = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("Mobilya.Kategori");
        }
    }
}
