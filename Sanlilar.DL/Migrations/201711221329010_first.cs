namespace Sanlilar.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Sanlilar.Sayfalar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SayfaTipi = c.Int(nullable: false),
                        Title = c.String(),
                        Html = c.String(),
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
            DropTable("Sanlilar.Sayfalar");
        }
    }
}
