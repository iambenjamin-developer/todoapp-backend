using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Entities;

namespace WebApi.Infrastructure.Configurations
{
     public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
    {
        public void Configure(EntityTypeBuilder<ToDoItem> builder)
        {
            builder.ToTable("ToDoItems");

            builder.HasKey(e => e.Id);

            builder.Property(x => x.Name)
                  .HasMaxLength(256)
                  .IsUnicode(false)
                  .IsRequired();

            builder.Property(x => x.IsCompleted)
                   .IsRequired();
        }
    }
}
