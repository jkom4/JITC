using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JITC.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        [MaxLength(50)]
        public string? Firstname { get; set; }

        
        [MaxLength(50)]
        public string? Name { get; set; }
        public DateTime Birthdate { get; set; }
    }
    public class JITCDbContext : IdentityDbContext<ApplicationUser>
    {
        public JITCDbContext(DbContextOptions<JITCDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Rendre le UserName unique 
            modelBuilder.Entity<ApplicationUser>().HasIndex(u => u.UserName).IsUnique();

            //Aeroport 
            modelBuilder.Entity<Aeroport>().HasData(new Aeroport() { Id = 1, Nom = "Liège" });
            modelBuilder.Entity<Aeroport>().HasData(new Aeroport() { Id = 2, Nom = "Bruxelles" });
            modelBuilder.Entity<Aeroport>().HasData(new Aeroport() { Id = 3, Nom = "Oostende" });
            modelBuilder.Entity<Aeroport>().HasData(new Aeroport() { Id = 4, Nom = "Charleroi" });

            
            //Rôles
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "1", Name = "Responsable", NormalizedName = "RESPONSABLE".ToUpper() });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = "2", Name = "Pilote", NormalizedName = "PILOTE".ToUpper() });

            //Users
            var hasher = new PasswordHasher<ApplicationUser>();
            
            //Seeding the User to AspNetUsers table

            //Responsable
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1", // primary key
                    Firstname = "Mo",
                    Name = "Ney",
                    UserName = "MoNey",
                    NormalizedUserName = "MONEY",
                    Email = "M.Ney@jitc.com",
                    NormalizedEmail = "M.NEY@JITC.COM",
                    PasswordHash = hasher.HashPassword(null, "responsable"),
                    SecurityStamp = Guid.NewGuid().ToString("D")
                }
            );

            //Pilotes
            modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser
               {
                   Id = "2", // primary key
                   Firstname = "Daniele",
                   Name = "Balav",
                   UserName = "DanieleBalav",
                   NormalizedUserName = "DANIELEBALAV",
                   Email = "D.Balav@jitc.com",
                   NormalizedEmail = "D.BALAV@JITC.COM",
                   PasswordHash = hasher.HashPassword(null, "pilote"),
                   SecurityStamp = Guid.NewGuid().ToString("D")
               }
           );

            modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser
               {
                   Id = "3", // primary key
                   Firstname = "Thierry",
                   Name = "Sabine",
                   UserName = "ThierrySabine",
                   NormalizedUserName = "THIERRYSABINE",
                   Email = "T.Sabine@jitc.com",
                   NormalizedEmail = "T.SABINE@JITC.COM",
                   PasswordHash = hasher.HashPassword(null, "pilote"),
                   SecurityStamp = Guid.NewGuid().ToString("D")
               }
           );

            modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser
               {
                   Id = "4", // primary key
                   Firstname = "Eli",
                   Name = "Copetre",
                   UserName = "EliCoptere",
                   NormalizedUserName = "ELICOPTERE",
                   Email = "E.Coptere@jitc.com",
                   NormalizedEmail = "E.COPTERE@JITC.COM",
                   PasswordHash = hasher.HashPassword(null, "pilote"),
                   SecurityStamp = Guid.NewGuid().ToString("D")
               }
           );
            //Seeding the relation between our user and role to AspNetUserRoles table
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "1",
                    UserId = "1"
                }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2",
                    UserId = "2"
                }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2",
                    UserId = "3"
                }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2",
                    UserId = "4"
                }
            );

        }


        public DbSet<Aeroport> Aeroport { get; set; }
        

    }

}
