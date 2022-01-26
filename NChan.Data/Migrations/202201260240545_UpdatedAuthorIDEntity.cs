namespace NChan.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAuthorIDEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "AuthorId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "AuthorId");
        }
    }
}
