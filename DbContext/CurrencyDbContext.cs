using Microsoft.EntityFrameworkCore;
using Aweton.Labs.CurrencyRates.Models;
namespace Aweton.Labs.CurrencyRates.DbContext;
public class CurrencyDbContext : Microsoft.EntityFrameworkCore.DbContext
{
  public CurrencyDbContext(DbContextOptions<CurrencyDbContext> options) : base(options)
  {
  }
  public DbSet<CbrDailyLog> CbrDailyLog =>Set<CbrDailyLog>();
  public DbSet<RateModel> CurrencyRates =>Set<RateModel>();
  public DbSet<CurrencyType> CurrencyTypes =>Set<CurrencyType>();
  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<CbrDailyLog>((eb)=>{
      eb.ToTable("awjCbrDailyLog");
      eb.HasKey(p=>p.CbrDailyLogID);
      eb.Property(p=>p.CbrDailyLogID).HasColumnName("awjCbrDailyLogID");
      eb.Property(p=>p.HashBytes).HasMaxLength(80);      
    });
    builder.Entity<CurrencyType>((eb)=>{
      eb.ToTable("CurrencyTypes");
      eb.HasKey(e=>e.CurrencyTypesId);
      eb.HasAlternateKey(e=>e.CurrCodeChr);
    });
    builder.Entity<RateModel>((eb)=>{
      eb.ToTable("CurrencyRates");
      eb.HasKey(e=>e.CurrencyRatesId);
      eb.HasAlternateKey(e=>new {e.ADate, e.CurrencyTypesId, e.RateTypesId});
      eb.Property(e=>e.UserName).HasColumnName("UserName").HasMaxLength(128);
    });
  }
}
