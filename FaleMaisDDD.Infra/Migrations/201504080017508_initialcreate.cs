namespace FaleMaisDDD.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialcreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Administrador",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Login = c.String(nullable: false, maxLength: 20),
                        Senha = c.String(nullable: false, maxLength: 16),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Login, unique: true, name: "IX_LOGIN");
            
            CreateTable(
                "dbo.DDD",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Preco",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ValorMinuto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ativo = c.Boolean(nullable: false),
                        IdOrigem = c.Guid(nullable: false),
                        IdDestino = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DDD", t => t.IdDestino)
                .ForeignKey("dbo.DDD", t => t.IdOrigem)
                .Index(t => t.IdOrigem)
                .Index(t => t.IdDestino);
            
            CreateTable(
                "dbo.Plano",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Descricao = c.String(),
                        Minutos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TarifaExcedente = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Preco", "IdOrigem", "dbo.DDD");
            DropForeignKey("dbo.Preco", "IdDestino", "dbo.DDD");
            DropIndex("dbo.Preco", new[] { "IdDestino" });
            DropIndex("dbo.Preco", new[] { "IdOrigem" });
            DropIndex("dbo.Administrador", "IX_LOGIN");
            DropTable("dbo.Plano");
            DropTable("dbo.Preco");
            DropTable("dbo.DDD");
            DropTable("dbo.Administrador");
        }
    }
}
