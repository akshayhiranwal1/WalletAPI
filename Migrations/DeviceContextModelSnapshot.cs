using System;
using WalletAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WalletAPI.Migrations
{
    [DbContext(typeof(DeviceContext))]
    partial class DeviceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentityApi.Data.Model.Device", b =>
                {
                    b.Property<Guid>("DeviceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DeviceTitle");

                    b.HasKey("DeviceId");

                    b.ToTable("Devices");
                });
        }
    }
}
