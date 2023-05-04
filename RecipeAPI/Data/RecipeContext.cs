using Microsoft.EntityFrameworkCore;
using RfCommonLibrary.DatabaseModels;

namespace RecipeAPI.Data
{
    public class RecipeContext:DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Recipe>(r =>
            { 
                r.HasMany(i=>i.Ingredients).WithOne(r=>r.Recipe).HasForeignKey(fk=>fk.RecipeID).OnDelete(DeleteBehavior.Cascade);
                r.HasMany(i => i.Instructions).WithOne(r => r.Recipe).HasForeignKey(fk => fk.RecipeID).OnDelete(DeleteBehavior.Cascade);
            } );

        }

        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Instruction> Instructions { get; set; }
    }
}
