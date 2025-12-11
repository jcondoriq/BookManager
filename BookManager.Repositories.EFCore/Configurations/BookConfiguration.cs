using BookManager.Repositories.EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Repositories.EFCore.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Isbn)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.NormalizedTitle)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(b => b.CoverUrl)
                .IsRequired();

            builder.Property(b => b.PublicationYear)
                .IsRequired();

            builder.Property(b => b.PageNumber)
                .IsRequired();

            builder.HasOne<Author>(a => a.Author)
                .WithMany(b => b.Books)
                .HasForeignKey(b => b.AuthorId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(x => x.NormalizedTitle);
        }
    }
}
