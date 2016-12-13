namespace AplikacjaRanczo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4poprawkanazwyarimr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bydlo", "id_arimr", c => c.String(nullable: false, maxLength: 9));
            DropColumn("dbo.Bydlo", "id_armir");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bydlo", "id_armir", c => c.String(nullable: false, maxLength: 9));
            DropColumn("dbo.Bydlo", "id_arimr");
        }
    }
}
