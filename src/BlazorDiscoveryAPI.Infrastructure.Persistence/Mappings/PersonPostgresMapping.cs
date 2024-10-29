using BlazorDiscoveryAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorDiscoveryAPI.Infrastructure.Persistence.Mappings
{
    public class PersonPostgresMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person");

            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasColumnName("id")
                .HasColumnType("UNIQUEIDENTIFIER")
                .ValueGeneratedNever();

            builder
                .Property(x => x.CreationDate)
                .HasColumnName("creation_date")
                .HasColumnType("datetime")
                .IsRequired();

            builder
                .Property(x => x.LastModificationDate)
                .HasColumnName("last_modification_date")
                .HasColumnType("datetime");

            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasColumnType("varchar(60)");

            builder
                .Property(x => x.Document)
                .HasColumnName("document")
                .HasColumnType("char(11)");

            builder
                .Property(x => x.BirthDate)
                .HasColumnName("birth_date")
                .HasColumnType("date");

            builder
                .Property(x => x.Phone)
                .HasColumnName("phone")
                .HasColumnType("char(11)");

            builder
                .Property(x => x.Email)
                .HasColumnName("email")
                .HasColumnType("varchar_60");

            // builder
            //     .OwnsOne(x => x.Address, address =>
            //     {
            //         address.Property(y => y.Street)
            //             .HasColumnName("address_street")
            //             .HasColumnType("varchar(80)");
            //
            //         address.Property(y => y.Number)
            //             .HasColumnName("address_number")
            //             .HasColumnType("int4");
            //
            //         address.Property(y => y.City)
            //             .HasColumnName("address_city")
            //             .HasColumnType("varchar(40)");
            //
            //         address.Property(y => y.State)
            //             .HasColumnName("address_state")
            //             .HasColumnType("varchar(20)");
            //
            //         address.Property(y => y.ZipCode)
            //             .HasColumnName("address_street")
            //             .HasColumnType("char(8)");
            //     });
        }
    }
}
