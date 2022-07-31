namespace AgreementDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agreements",
                c => new
                    {
                        AgreementID = c.Int(nullable: false, identity: true),
                        RecordNumber = c.String(),
                        IdentityNumber = c.String(),
                        Name = c.String(),
                        StratDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ProcessStatus = c.Int(nullable: false),
                        AgreementType = c.Int(nullable: false),
                        Description = c.String(),
                        RequestNumber = c.String(),
                        IngoingDocumentDate = c.DateTime(nullable: false),
                        IngoingDocumentNumber = c.Int(nullable: false),
                        HappensDateTime = c.DateTime(nullable: false),
                        HappensCount = c.Int(nullable: false),
                        FileUrl = c.String(),
                        InsertionDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AgreementID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Agreements");
        }
    }
}
