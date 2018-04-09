namespace ToDo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A_FKUSER_ID : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ToDoDBs", name: "User_Id", newName: "UserId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.ToDoDBs", name: "UserId", newName: "User_Id");
        }
    }
}
