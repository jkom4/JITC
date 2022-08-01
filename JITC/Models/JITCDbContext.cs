using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JITC.Models;
using System.Text.Json;
using Newtonsoft.Json;

namespace JITC.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        [MaxLength(50)]
        public string? Firstname { get; set; }

        
        [MaxLength(50)]
        public string? Name { get; set; }
        public DateTime Birthdate { get; set; }
        public virtual ICollection<Vol> Vols { get; set; } = new List<Vol>();
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
            modelBuilder.Entity<Aeroport>().HasData(new Aeroport() { Id = 1, Nom = "Liège", Latitude = 50.63583079 , Longitude = 5.439331576 });
            modelBuilder.Entity<Aeroport>().HasData(new Aeroport() { Id = 2, Nom = "Bruxelles" , Latitude = 50.90082973, Longitude = 4.483998064 });
            modelBuilder.Entity<Aeroport>().HasData(new Aeroport() { Id = 3, Nom = "Oostende", Latitude = 51.193165894 , Longitude = 2.858163234 });
            modelBuilder.Entity<Aeroport>().HasData(new Aeroport() { Id = 4, Nom = "Charleroi", Latitude = 50.455998176 , Longitude = 4.45166486 });

            
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
 

            //Appareils
            modelBuilder.Entity<Appareil>().HasData(new Appareil() { Id = 1, Nom = "Eurocopter AS 355 F1/F2 Ecureuil III", Description = "", Capacite_Cab = 5, Vitesse = 220, Moteur = "Deux turbines du modèle de Rolls Royce 250-C20F", Statut = false });
            modelBuilder.Entity<Appareil>().HasData(new Appareil() { Id = 2, Nom = "Bell 206 JetRanger", Description = "", Capacite_Cab = 4, Vitesse = 190, Moteur = "Une turbine du type Rolls Royce 250-C20B", Statut = false });
            modelBuilder.Entity<Appareil>().HasData(new Appareil() { Id = 3, Nom = "Robinson R44 Raven II", Description = "", Capacite_Cab = 3, Vitesse = 190, Moteur = "Un piston du type Lycoming modèle IO-540", Statut = false });
    
            modelBuilder.Entity<Vol>().HasOne(v => v.ModifVol).WithMany(m => m.Vols);
            modelBuilder.Entity<Vol>().HasOne(v => v.Appareil).WithMany(a => a.Vols).HasForeignKey(v => v.AppareilId);
            modelBuilder.Entity<ModifVol>().Property(m => m.VolModifs)
    .HasConversion(
        v => JsonConvert.SerializeObject(v),
        v => JsonConvert.DeserializeObject<List<string>>(v));

        }

         

        public DbSet<Aeroport> Aeroport { get; set; }
        public DbSet<Appareil> Appareil { get; set; }
        public DbSet<Vol> Vol { get; set; }
        public DbSet<JITC.Models.ModifVol>? ModifVol { get; set; }
        public DbSet<JITC.Models.Reservation>? Reservation { get; set; }
        


    }

}
