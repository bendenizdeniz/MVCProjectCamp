﻿namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addImageFile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageFiles",
                c => new
                    {
                        IDImage = c.Int(nullable: false, identity: true),
                        ImageName = c.String(maxLength: 100),
                        AboutImage = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.IDImage);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ImageFiles");
        }
    }
}
