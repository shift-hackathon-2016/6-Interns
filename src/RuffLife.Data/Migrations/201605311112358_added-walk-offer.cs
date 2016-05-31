namespace RuffLife.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedwalkoffer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Breed = c.String(),
                        Age = c.String(),
                        Description = c.String(),
                        Notes = c.String(),
                        Owner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Owner", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Owner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Location = c.String(),
                        Address = c.String(),
                        ContactNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReviewForWalker",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        Review = c.String(),
                        Walker_Id = c.Int(nullable: false),
                        Owner_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Walker", t => t.Walker_Id, cascadeDelete: true)
                .ForeignKey("dbo.Owner", t => t.Owner_Id)
                .Index(t => t.Walker_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.Walker",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Location = c.String(),
                        Email = c.String(),
                        CostPerHourInHRK = c.Double(nullable: false),
                        ContactNumber = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReviewForDog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        Review = c.String(),
                        Walker_Id = c.Int(nullable: false),
                        Dog_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Walker", t => t.Walker_Id, cascadeDelete: true)
                .ForeignKey("dbo.Dog", t => t.Dog_Id, cascadeDelete: true)
                .Index(t => t.Walker_Id)
                .Index(t => t.Dog_Id);
            
            CreateTable(
                "dbo.Walk",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Location = c.String(),
                        Price = c.Double(nullable: false),
                        Walker_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Walker", t => t.Walker_Id, cascadeDelete: true)
                .Index(t => t.Walker_Id);
            
            CreateTable(
                "dbo.DogWalks",
                c => new
                    {
                        DogId = c.Int(nullable: false),
                        WalkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DogId, t.WalkId })
                .ForeignKey("dbo.Dog", t => t.DogId, cascadeDelete: true)
                .ForeignKey("dbo.Walk", t => t.WalkId, cascadeDelete: true)
                .Index(t => t.DogId)
                .Index(t => t.WalkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DogWalks", "WalkId", "dbo.Walk");
            DropForeignKey("dbo.DogWalks", "DogId", "dbo.Dog");
            DropForeignKey("dbo.ReviewForDog", "Dog_Id", "dbo.Dog");
            DropForeignKey("dbo.Dog", "Owner_Id", "dbo.Owner");
            DropForeignKey("dbo.ReviewForWalker", "Owner_Id", "dbo.Owner");
            DropForeignKey("dbo.Walk", "Walker_Id", "dbo.Walker");
            DropForeignKey("dbo.ReviewForWalker", "Walker_Id", "dbo.Walker");
            DropForeignKey("dbo.ReviewForDog", "Walker_Id", "dbo.Walker");
            DropIndex("dbo.DogWalks", new[] { "WalkId" });
            DropIndex("dbo.DogWalks", new[] { "DogId" });
            DropIndex("dbo.Walk", new[] { "Walker_Id" });
            DropIndex("dbo.ReviewForDog", new[] { "Dog_Id" });
            DropIndex("dbo.ReviewForDog", new[] { "Walker_Id" });
            DropIndex("dbo.ReviewForWalker", new[] { "Owner_Id" });
            DropIndex("dbo.ReviewForWalker", new[] { "Walker_Id" });
            DropIndex("dbo.Dog", new[] { "Owner_Id" });
            DropTable("dbo.DogWalks");
            DropTable("dbo.Walk");
            DropTable("dbo.ReviewForDog");
            DropTable("dbo.Walker");
            DropTable("dbo.ReviewForWalker");
            DropTable("dbo.Owner");
            DropTable("dbo.Dog");
        }
    }
}
