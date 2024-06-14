namespace Teodor_11a_23.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vegetables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VegetableTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VegetableTypes", t => t.VegetableTypeId, cascadeDelete: true)
                .Index(t => t.VegetableTypeId);
            
            CreateTable(
                "dbo.VegetableTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vegetables", "VegetableTypeId", "dbo.VegetableTypes");
            DropIndex("dbo.Vegetables", new[] { "VegetableTypeId" });
            DropTable("dbo.VegetableTypes");
            DropTable("dbo.Vegetables");
        }
    }
}
