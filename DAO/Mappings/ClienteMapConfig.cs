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
    internal class ClienteMapConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTES");

            //COR VARCHAR(15) NOT NULL
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(15).IsUnicode(false);
            builder.Property(p => p.CPF).IsRequired().HasMaxLength(30).IsUnicode(true);
            builder.Property(p => p.DataNascimento).IsRequired().HasColumnType("date");
            builder.Property(p => p.Email).IsRequired().HasMaxLength(20).IsUnicode(true);

            //Caso houvesse chave unica no nome do pet!
            //builder.HasIndex(p => p.Nome).IsUnique().HasDatabaseName("UQ_PET_NOME");
        }
    }
}
