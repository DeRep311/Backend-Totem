using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

public class DatabaseContext : DbContext {

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {   
        string? connectionString ="Server=167.60.59.109;Database=apheleondb;UID=root;PWD=789874506082005;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}