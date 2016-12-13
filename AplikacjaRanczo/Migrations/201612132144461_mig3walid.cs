namespace AplikacjaRanczo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3walid : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Wojewodztwo", "nazwa", c => c.String(nullable: false));
            AlterColumn("dbo.Samochod", "nr_rejestracyjny", c => c.String(nullable: false));
            AlterColumn("dbo.Marka", "nazwa", c => c.String(nullable: false));
            AlterColumn("dbo.Plec", "skrot", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plec", "skrot", c => c.String());
            AlterColumn("dbo.Marka", "nazwa", c => c.String());
            AlterColumn("dbo.Samochod", "nr_rejestracyjny", c => c.String());
            AlterColumn("dbo.Wojewodztwo", "nazwa", c => c.String());
        }
    }
}
