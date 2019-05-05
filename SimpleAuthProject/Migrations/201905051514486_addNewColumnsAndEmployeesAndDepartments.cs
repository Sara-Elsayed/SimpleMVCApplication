namespace SimpleAuthProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewColumnsAndEmployeesAndDepartments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Email = c.String(),
                        Fk_DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.Fk_DepartmentId, cascadeDelete: true)
                .Index(t => t.Fk_DepartmentId);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(maxLength: 50));
            AddColumn("dbo.AspNetUsers", "Address", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "Fk_DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "Fk_DepartmentId" });
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
