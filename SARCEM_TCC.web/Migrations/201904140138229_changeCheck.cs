namespace SARCEM_TCC.web.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class changeCheck : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Cecos", new[] { "EmpresaID" });
            AlterColumn("dbo.Cecos", "EmpresaID", c => c.Long());
            CreateIndex("dbo.Cecos", "EmpresaID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Cecos", new[] { "EmpresaID" });
            AlterColumn("dbo.Cecos", "EmpresaID", c => c.Long(nullable: false));
            CreateIndex("dbo.Cecos", "EmpresaID");
        }
    }
}
