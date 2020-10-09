namespace CRUD_EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class banco1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agenda", "Cep", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agenda", "Cep");
        }
    }
}
