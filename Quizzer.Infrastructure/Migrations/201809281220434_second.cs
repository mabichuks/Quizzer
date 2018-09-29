namespace Quizzer.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Options", "QuestionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Questions", "CategoryId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Options", "QuestionId", c => c.Int(nullable: false));
        }
    }
}
