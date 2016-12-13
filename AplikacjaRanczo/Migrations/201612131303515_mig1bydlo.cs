namespace AplikacjaRanczo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1bydlo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Kraj", "nazwa", c => c.String(nullable: false));
            AlterColumn("dbo.Plec", "nazwa", c => c.String(nullable: false));
            AlterColumn("dbo.Rasa", "nazwa", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rasa", "nazwa", c => c.String());
            AlterColumn("dbo.Plec", "nazwa", c => c.String());
            AlterColumn("dbo.Kraj", "nazwa", c => c.String());
        }
    }
}
