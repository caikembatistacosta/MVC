using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.Mappings
{
    internal class PetMapConfig : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("PETS");

            //COR VARCHAR(15) NOT NULL
            builder.Property(p => p.Cor).IsRequired().HasMaxLength(15).IsUnicode(false);
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(30).IsUnicode(true);
            builder.Property(p => p.DataNascimento).IsRequired().HasColumnType("date");
            builder.Property(p => p.Raca).IsRequired().HasMaxLength(20).IsUnicode(false);

            //Caso houvesse chave unica no nome do pet!
            //builder.HasIndex(p => p.Nome).IsUnique().HasDatabaseName("UQ_PET_NOME");
        }
    }
}
