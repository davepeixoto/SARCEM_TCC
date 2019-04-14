namespace SARCEM_TCC.web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajustaCentroLogistico : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CentrosLogisticos", "CentroLogisticoCodSap", c => c.String(maxLength: 8, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CentrosLogisticos", "CentroLogisticoCodSap", c => c.String(maxLength: 4, unicode: false));
        }
    }
}
