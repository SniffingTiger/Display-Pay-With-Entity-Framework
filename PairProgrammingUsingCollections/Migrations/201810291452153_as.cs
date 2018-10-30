namespace PairProgrammingUsingCollections.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _as : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "StandardPay", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "OvertimePay", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "TotalPay", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "TotalPay");
            DropColumn("dbo.Employees", "OvertimePay");
            DropColumn("dbo.Employees", "StandardPay");
        }
    }
}
