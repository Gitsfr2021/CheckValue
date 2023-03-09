namespace Kaspid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rangevalue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RangeValue", "Oprate1", c => c.Boolean(nullable: false));
            AddColumn("dbo.RangeValue", "Oprate2", c => c.Boolean(nullable: false));
            DropColumn("dbo.RangeValue", "Oprate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RangeValue", "Oprate", c => c.Boolean(nullable: false));
            DropColumn("dbo.RangeValue", "Oprate2");
            DropColumn("dbo.RangeValue", "Oprate1");
        }
    }
}
