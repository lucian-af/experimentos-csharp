using LOG.API.Model;
using Microsoft.EntityFrameworkCore;

namespace LOG.API.Dados
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.MapAll(typeof(ModelBuilderExtension));

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // todas as tabelas serão criadas em letra maiúscula
                entity.SetTableName(entity.GetTableName().ToUpper());

                foreach (var property in entity.GetProperties())
                {
                    // todas as colunas das tabelas serão criadas em letra maiúscula
                    property.SetColumnName(property.Name.ToUpper());
                }

                // todas as constraints das primary keys serão criadas em letra maiúscula
                foreach (var key in entity.GetKeys())
                {
                    key.SetName(key.GetName().ToUpper());
                }

                // todas as constraints das foreign keys serão criadas em letra maiúscula
                foreach (var key in entity.GetForeignKeys())
                {
                    key.SetConstraintName(key.GetConstraintName().ToUpper());
                }
            }
        }
    }
}
