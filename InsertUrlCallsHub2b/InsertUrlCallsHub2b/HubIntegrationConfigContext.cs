using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InsertUrlCallsHub2b
{
    public partial class HubIntegrationConfigContext : DbContext
    {
        public HubIntegrationConfigContext()
        {
        }

        public HubIntegrationConfigContext(DbContextOptions<HubIntegrationConfigContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IntegrationConfig> IntegrationConfigs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=mysqldb.infra.plataformahub.com.br;database=HubIntegrationConfig;uid=joaocarniel;pwd=\"5=XjkZV!f7mgEXAX\"", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.33-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<IntegrationConfig>(entity =>
            {
                entity.ToTable("IntegrationConfig");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Enabled)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.FrequencyTime).HasColumnType("text");

                entity.Property(e => e.FrequencyUnit).HasColumnType("text");

                entity.Property(e => e.IdSystem)
                    .HasColumnType("int(11)")
                    .HasColumnName("idSystem");

                entity.Property(e => e.IdSystemResponsibility)
                    .HasColumnType("int(11)")
                    .HasColumnName("idSystemResponsibility");

                entity.Property(e => e.IdTenant)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTenant");

                entity.Property(e => e.IdTenantSystemHasResponsibility)
                    .HasColumnType("int(11)")
                    .HasColumnName("idTenantSystemHasResponsibility");

                entity.Property(e => e.LastCall).HasMaxLength(100);

                entity.Property(e => e.Note).HasColumnType("text");

                entity.Property(e => e.Success).HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .HasColumnName("type");

                entity.Property(e => e.UrlCall).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
