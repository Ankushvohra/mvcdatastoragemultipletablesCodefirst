namespace mvcregister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcity1 : DbMigration
    {
        public override void Up()
        {
            Sql("insert Cities values('Una',13)"); //1
            Sql("insert Cities values('Hamirpur',13)"); //2
            Sql("insert Cities values('Varanasi',14)"); //3
            Sql("insert Cities values('Mohali',14)"); //4
            Sql("insert Cities values('Queensland',16)"); //5
        }
        
        public override void Down()
        {
        }
    }
}
