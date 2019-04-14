using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace SARCEM_TCC.web.Data.Configs
{
    public class IdentityUserClaimConfig:EntityTypeConfiguration<IdentityUserClaim>
    {
        public IdentityUserClaimConfig()
        {
            ToTable("AspNetUserClaims");

            HasKey(c => c.Id);
            Property(c => c.UserId).HasMaxLength(128);
            Property(c => c.ClaimType ).HasMaxLength(8000);
            Property(c => c.ClaimValue).HasMaxLength(8000);

            
        }
    }
}