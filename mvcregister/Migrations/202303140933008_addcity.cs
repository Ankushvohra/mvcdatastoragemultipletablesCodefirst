namespace mvcregister.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcity : DbMigration
    {
        public override void Up()
        {

            Sql("insert States values('HP',6)"); //1
            Sql("insert States values('UP',6)"); //2
            Sql("insert States values('Punjab',6)"); //3
            Sql("insert States values('Brisbane',7)"); //4
            Sql("insert States values('Sydney',7)"); //5
            Sql("insert States values('Melbourne',7)"); //6
            Sql("insert States values('California',8)"); //7
            Sql("insert States values('Washington D.C.',8)"); //8
        }
        
        public override void Down()
        {
        }
    }
}
