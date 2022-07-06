using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VShop.ProductApi.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert Into Products(Name, Price, Description, Stock, ImageURL, CategoryId) " +
                "Values('Caderno', 7, 'Caderno Marvel',10,'caderno1.jpg', 1)");

            mb.Sql("Insert Into Products(Name, Price, Description, Stock, ImageURL, CategoryId) " +
                "Values('Lapis', 3, 'Lapis Preto',20,'lapis1.jpg', 1)");

            mb.Sql("Insert Into Products(Name, Price, Description, Stock, ImageURL, CategoryId) " +
                "Values('Clips', 5, 'Clips para papel',50,'clips01.jpg', 2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Products");
        }
    }
}
