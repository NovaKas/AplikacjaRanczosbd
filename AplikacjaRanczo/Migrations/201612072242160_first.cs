namespace AplikacjaRanczo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bydlo",
                c => new
                    {
                        BydloID = c.Int(nullable: false, identity: true),
                        id_armir = c.String(nullable: false, maxLength: 9),
                        nr_paszportu = c.String(nullable: false),
                        MatkaID = c.Int(),
                        RasaID = c.Int(nullable: false),
                        PlecID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BydloID)
                .ForeignKey("dbo.Bydlo", t => t.MatkaID)
                .ForeignKey("dbo.Plec", t => t.PlecID, cascadeDelete: true)
                .ForeignKey("dbo.Rasa", t => t.RasaID, cascadeDelete: true)
                .Index(t => t.MatkaID)
                .Index(t => t.RasaID)
                .Index(t => t.PlecID);
            
            CreateTable(
                "dbo.KsiegaSprzedazy",
                c => new
                    {
                        KsiegaSprzedazyID = c.Int(nullable: false, identity: true),
                        BydloID = c.Int(nullable: false),
                        KontrahentID = c.Int(nullable: false),
                        SamochodID = c.Int(nullable: false),
                        data = c.DateTime(nullable: false),
                        czyZakup = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.KsiegaSprzedazyID)
                .ForeignKey("dbo.Bydlo", t => t.BydloID, cascadeDelete: true)
                .ForeignKey("dbo.Kontrahent", t => t.KontrahentID, cascadeDelete: true)
                .ForeignKey("dbo.Samochod", t => t.SamochodID, cascadeDelete: true)
                .Index(t => t.BydloID)
                .Index(t => t.KontrahentID)
                .Index(t => t.SamochodID);
            
            CreateTable(
                "dbo.Kontrahent",
                c => new
                    {
                        KontrahentID = c.Int(nullable: false, identity: true),
                        nazwa = c.String(nullable: false),
                        nip = c.String(nullable: false, maxLength: 10),
                        KodPocztowyID = c.Int(nullable: false),
                        ulica = c.String(nullable: false),
                        nr_domu = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.KontrahentID)
                .ForeignKey("dbo.KodPocztowy", t => t.KodPocztowyID, cascadeDelete: true)
                .Index(t => t.KodPocztowyID);
            
            CreateTable(
                "dbo.KodPocztowy",
                c => new
                    {
                        KodPocztowyID = c.Int(nullable: false, identity: true),
                        kod = c.String(),
                        MiejscowoscID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KodPocztowyID)
                .ForeignKey("dbo.Miejscowosc", t => t.MiejscowoscID, cascadeDelete: true)
                .Index(t => t.MiejscowoscID);
            
            CreateTable(
                "dbo.Miejscowosc",
                c => new
                    {
                        MiejscowoscID = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                        WojewodztwoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MiejscowoscID)
                .ForeignKey("dbo.Wojewodztwo", t => t.WojewodztwoID, cascadeDelete: true)
                .Index(t => t.WojewodztwoID);
            
            CreateTable(
                "dbo.Wojewodztwo",
                c => new
                    {
                        WojewodztwoID = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                    })
                .PrimaryKey(t => t.WojewodztwoID);
            
            CreateTable(
                "dbo.Samochod",
                c => new
                    {
                        SamochodID = c.Int(nullable: false, identity: true),
                        nr_rejestracyjny = c.String(),
                        MarkaID = c.Int(nullable: false),
                        model = c.String(),
                        rocznik = c.DateTime(nullable: false),
                        KrajID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SamochodID)
                .ForeignKey("dbo.Kraj", t => t.KrajID, cascadeDelete: true)
                .ForeignKey("dbo.Marka", t => t.MarkaID, cascadeDelete: true)
                .Index(t => t.MarkaID)
                .Index(t => t.KrajID);
            
            CreateTable(
                "dbo.Kraj",
                c => new
                    {
                        KrajID = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                    })
                .PrimaryKey(t => t.KrajID);
            
            CreateTable(
                "dbo.Marka",
                c => new
                    {
                        MarkaID = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                    })
                .PrimaryKey(t => t.MarkaID);
            
            CreateTable(
                "dbo.Plec",
                c => new
                    {
                        PlecID = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                        skrot = c.String(),
                    })
                .PrimaryKey(t => t.PlecID);
            
            CreateTable(
                "dbo.Rasa",
                c => new
                    {
                        RasaID = c.Int(nullable: false, identity: true),
                        nazwa = c.String(),
                        skrot = c.String(),
                    })
                .PrimaryKey(t => t.RasaID);
            
            CreateTable(
                "dbo.SamochodKontrahent",
                c => new
                    {
                        Samochod_SamochodID = c.Int(nullable: false),
                        Kontrahent_KontrahentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Samochod_SamochodID, t.Kontrahent_KontrahentID })
                .ForeignKey("dbo.Samochod", t => t.Samochod_SamochodID, cascadeDelete: true)
                .ForeignKey("dbo.Kontrahent", t => t.Kontrahent_KontrahentID, cascadeDelete: true)
                .Index(t => t.Samochod_SamochodID)
                .Index(t => t.Kontrahent_KontrahentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bydlo", "RasaID", "dbo.Rasa");
            DropForeignKey("dbo.Bydlo", "PlecID", "dbo.Plec");
            DropForeignKey("dbo.Bydlo", "MatkaID", "dbo.Bydlo");
            DropForeignKey("dbo.KsiegaSprzedazy", "SamochodID", "dbo.Samochod");
            DropForeignKey("dbo.Samochod", "MarkaID", "dbo.Marka");
            DropForeignKey("dbo.Samochod", "KrajID", "dbo.Kraj");
            DropForeignKey("dbo.SamochodKontrahent", "Kontrahent_KontrahentID", "dbo.Kontrahent");
            DropForeignKey("dbo.SamochodKontrahent", "Samochod_SamochodID", "dbo.Samochod");
            DropForeignKey("dbo.KsiegaSprzedazy", "KontrahentID", "dbo.Kontrahent");
            DropForeignKey("dbo.Miejscowosc", "WojewodztwoID", "dbo.Wojewodztwo");
            DropForeignKey("dbo.KodPocztowy", "MiejscowoscID", "dbo.Miejscowosc");
            DropForeignKey("dbo.Kontrahent", "KodPocztowyID", "dbo.KodPocztowy");
            DropForeignKey("dbo.KsiegaSprzedazy", "BydloID", "dbo.Bydlo");
            DropIndex("dbo.SamochodKontrahent", new[] { "Kontrahent_KontrahentID" });
            DropIndex("dbo.SamochodKontrahent", new[] { "Samochod_SamochodID" });
            DropIndex("dbo.Samochod", new[] { "KrajID" });
            DropIndex("dbo.Samochod", new[] { "MarkaID" });
            DropIndex("dbo.Miejscowosc", new[] { "WojewodztwoID" });
            DropIndex("dbo.KodPocztowy", new[] { "MiejscowoscID" });
            DropIndex("dbo.Kontrahent", new[] { "KodPocztowyID" });
            DropIndex("dbo.KsiegaSprzedazy", new[] { "SamochodID" });
            DropIndex("dbo.KsiegaSprzedazy", new[] { "KontrahentID" });
            DropIndex("dbo.KsiegaSprzedazy", new[] { "BydloID" });
            DropIndex("dbo.Bydlo", new[] { "PlecID" });
            DropIndex("dbo.Bydlo", new[] { "RasaID" });
            DropIndex("dbo.Bydlo", new[] { "MatkaID" });
            DropTable("dbo.SamochodKontrahent");
            DropTable("dbo.Rasa");
            DropTable("dbo.Plec");
            DropTable("dbo.Marka");
            DropTable("dbo.Kraj");
            DropTable("dbo.Samochod");
            DropTable("dbo.Wojewodztwo");
            DropTable("dbo.Miejscowosc");
            DropTable("dbo.KodPocztowy");
            DropTable("dbo.Kontrahent");
            DropTable("dbo.KsiegaSprzedazy");
            DropTable("dbo.Bydlo");
        }
    }
}
