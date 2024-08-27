using Hotel_System.Core.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_System.Infrastructure.Configuration
{
    public class VillaConfiguration : IEntityTypeConfiguration<Villa>
    {
        public void Configure(EntityTypeBuilder<Villa> builder)
        {
            builder.HasKey(x=>x.VillaID);
            builder.Property(x => x.VillaID)
                .ValueGeneratedNever();

            builder.Property(x => x.VillaDescription)
                .IsRequired();

            builder.Property(x=>x.VillaName)
                .IsRequired();

            builder.Property(x=>x.Occupancy)
                .IsRequired();

            builder.Property(x=>x.Amenity)
                .IsRequired();

            builder.Property(x => x.ImageURL)
                .HasColumnType("VARCHAR(max)");

            builder.Property(x => x.Rate)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.Sqft)
                .IsRequired();

            builder.Property(x=>x.UpdatedDate)
                .IsRequired();
            builder.HasData(new Villa
            {
                VillaID = Guid.Parse("9B53E271-19FD-4B84-A14C-598E536EA22C"),
                VillaName = "Royal Villa",
                VillaDescription = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                ImageURL = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                Occupancy = 4,
                Rate = 200,
                Sqft = 550,
                Amenity = ""
            },
              new Villa
              {
                  VillaID = Guid.Parse("BCFAD10A-D4FC-44F1-B5B1-0F5AA2C66147"),
                  VillaName = "Premium Pool Villa",
                  VillaDescription = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageURL = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg",
                  Occupancy = 4,
                  Rate = 300,
                  Sqft = 550,
                  Amenity = ""
              },
              new Villa
              {
                  VillaID = Guid.Parse("AEF0A7D2-1E79-4BDF-8D3E-B46DE9F8656E"),
                  VillaName = "Luxury Pool Villa",
                  VillaDescription = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageURL = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
                  Occupancy = 4,
                  Rate = 400,
                  Sqft = 750,
                  Amenity = ""
              },
              new Villa
              {
                  VillaID = Guid.Parse("6E6FE821-13D2-4567-B674-F616D79E264A"),
                  VillaName = "Diamond Villa",
                  VillaDescription = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageURL = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
                  Occupancy = 4,
                  Rate = 550,
                  Sqft = 900,
                  Amenity = ""
              },
              new Villa
              {
                  VillaID = Guid.Parse("02454E31-1236-4B7B-805F-7ECEC9856090"),
                  VillaName = "Diamond Pool Villa",
                  VillaDescription = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                  ImageURL = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg",
                  Occupancy = 4,
                  Rate = 600,
                  Sqft = 1100,
                  Amenity = ""
              });
            builder.ToTable("Villas");
        }
        
    }
   

}
