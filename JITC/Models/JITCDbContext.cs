using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JITC.Models;
using System.Text.Json;
using Newtonsoft.Json;
using JITC.Models.ViewModels;

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
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
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
               new ApplicationUser()
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
            modelBuilder.Entity<Vol>().Property(f => f.Id).ValueGeneratedOnAdd();


            //SEED DES USERS LAMBDAS
            modelBuilder.Entity<ApplicationUser>().HasData(
              new ApplicationUser
              {
                  Id = "5", // primary key
                  Firstname = "Job",
                  Name = "Kom",
                  UserName = "JobKom",
                  NormalizedUserName = "JOBKOM",
                  Email = "JobKom@jitc.com",
                  NormalizedEmail = "JOBKOM@JITC.COM",
                  PasswordHash = hasher.HashPassword(null, "visiteur"),
                  SecurityStamp = Guid.NewGuid().ToString("D")
              },
              new ApplicationUser
              {
                  Id = "6", // primary key
                  Firstname = "Blaise",
                  Name = "Pascal",
                  UserName = "BlaisePascal",
                  NormalizedUserName = "BLAISEPASCAL",
                  Email = "BlaisePascal@jitc.com",
                  NormalizedEmail = "BLAISEPASCAL@JITC.COM",
                  PasswordHash = hasher.HashPassword(null, "visiteur"),
                  SecurityStamp = Guid.NewGuid().ToString("D")
              },
               new ApplicationUser
               {
                   Id = "7", // primary key
                   Firstname = "Jean",
                   Name = "Pierre",
                   UserName = "JeanPierre",
                   NormalizedUserName = "JEANPIERRE",
                   Email = "JeanPierre@jitc.com",
                   NormalizedEmail = "JEANPIERRE@JITC.COM",
                   PasswordHash = hasher.HashPassword(null, "visiteur"),
                   SecurityStamp = Guid.NewGuid().ToString("D")
               }
          );
         
            //SEEDING VOLS

            modelBuilder.Entity<Vol>().HasData(
                new Vol()
                {
                    Id = 1,
                    AeroportDepartId = 1,
                    AeroportArriveId = 2,
                    NombrePlace = 10,
                    HeureDepartPrevue = new DateTime(2022, 08, 01, 08, 02, 00),
                    HeureArrivePrevue = new DateTime(2022, 08, 01, 10, 02, 00),
                    HeureDepartReelle = new DateTime(2022, 08, 01, 08, 02, 00),
                    HeureArriveReelle = new DateTime(2022, 08, 01, 11, 02, 00),
                    PiloteId = "2",
                    Distance = 29.515449800117239,
                    AppareilId = 1,
                    Retard = true,
                    Raison = "Mauvais temps",
                    ModifVolId = 1

                },
                 new Vol()
                 {
                     Id = 2,
                     AeroportDepartId = 2,
                     AeroportArriveId = 1,
                     NombrePlace = 10,
                     HeureDepartPrevue = new DateTime(2022, 08, 07, 08, 02, 00),
                     HeureArrivePrevue = new DateTime(2022, 08, 07, 10, 02, 00),
                     HeureDepartReelle = new DateTime(2022, 08, 01, 08, 02, 00),
                     HeureArriveReelle = new DateTime(2022, 08, 01, 10, 02, 00),
                     PiloteId = "2",
                     Distance = 29.515449800117239,
                     AppareilId = 1,
                     ModifVolId = 2

                 },
                  new Vol()
                  {
                      Id = 3,
                      AeroportDepartId = 1,
                      AeroportArriveId = 3,
                      NombrePlace = 5,
                      HeureDepartPrevue = new DateTime(2022, 08, 15, 08, 02, 00),
                      HeureArrivePrevue = new DateTime(2022, 08, 15, 11, 02, 00),
                      PiloteId = "3",
                      Distance = 49.515449800117239,
                      AppareilId = 2,
                      ModifVolId = 3

                  },
                   new Vol()
                   {
                       Id = 4,
                       AeroportDepartId = 2,
                       AeroportArriveId = 4,
                       NombrePlace = 15,
                       HeureDepartPrevue = new DateTime(2022, 08, 16, 08, 02, 00),
                       HeureArrivePrevue = new DateTime(2022, 08, 16, 10, 02, 00),
                       PiloteId = "4",
                       Distance = 49.515449800117239,
                       AppareilId = 3,
                       ModifVolId = 4

                   },
                    new Vol()
                    {
                        Id = 5,
                        AeroportDepartId = 4,
                        AeroportArriveId = 2,
                        NombrePlace = 6,
                        HeureDepartPrevue = new DateTime(2022, 08, 17, 08, 02, 00),
                        HeureArrivePrevue = new DateTime(2022, 08, 17, 10, 02, 00),
                        PiloteId = "3",
                        Distance = 59.515449800117239,
                        AppareilId = 3,
                        ModifVolId = 5

                    }
            );
            //ON SEED LES MODIFICATIONS CE QUI VAS AVEC UN VOL
            modelBuilder.Entity<ModifVol>().HasData(
                new ModifVol() {Id = 1, VolModifs = AddModif()},
                new ModifVol() {Id = 2, VolModifs = AddModif1()},
                new ModifVol() {Id = 3, VolModifs = AddModif2()},
                new ModifVol() {Id = 4, VolModifs = AddModif3()},
                new ModifVol() {Id = 5, VolModifs = AddModif4()}
                );

            //ON SEED LES RESERVATIONS

            modelBuilder.Entity<Reservation>().HasData(
                new Reservation() { Id = 1, UserId = "5", volId = 1, place = 5   },
                new Reservation() { Id = 2, UserId = "6", volId = 2, place = 10   },
                new Reservation() { Id = 3, UserId = "5", volId = 3, place = 5   },
                new Reservation() { Id = 4, UserId = "7", volId = 4, place = 10   },
                new Reservation() { Id = 5, UserId = "6", volId = 5, place = 5   }
                );
        }
       //ModifId1
    private List<string>? AddModif()
        {
            List<string> modifVolList = new List<string>();
            VolViewModel volViewModel = CreateViewModel();
            modifVolList.Add(CreateModifObject(volViewModel));
            return modifVolList;
        }
        private static VolViewModel CreateViewModel()
        {
            VolViewModel volViewModel = new VolViewModel();
            volViewModel.IdVol = 1;
            volViewModel.Depart = new Aeroport() { Id = 1, Nom = "Liège", Latitude = 50.63583079, Longitude = 5.439331576 };
            volViewModel.Arrive = new Aeroport() { Id = 2, Nom = "Bruxelles", Latitude = 50.90082973, Longitude = 4.483998064 };
            volViewModel.DepartPrevue = new DateTime(2022, 08, 01, 08, 02, 00);
            volViewModel.ArrivePrevue = new DateTime(2022, 08, 01, 10, 02, 00);
            volViewModel.NombrePlace = 10;
            volViewModel.Appareil = new Appareil() { Id = 1, Nom = "Eurocopter AS 355 F1/F2 Ecureuil III", Description = "", Capacite_Cab = 5, Vitesse = 220, Moteur = "Deux turbines du modèle de Rolls Royce 250-C20F", Statut = false };
            return volViewModel;
        }
        //ModifId2
        private List<string>? AddModif1()
        {
            List<string> modifVolList = new List<string>();
            VolViewModel volViewModel = CreateViewModel1();
            modifVolList.Add(CreateModifObject(volViewModel));
            return modifVolList;
        }
        private static VolViewModel CreateViewModel1()
        {
            VolViewModel volViewModel = new VolViewModel();
            volViewModel.IdVol = 2;
            volViewModel.Depart = new Aeroport() { Id = 2, Nom = "Bruxelles", Latitude = 50.90082973, Longitude = 4.483998064 };
            volViewModel.Arrive = new Aeroport() { Id = 1, Nom = "Liège", Latitude = 50.63583079, Longitude = 5.439331576 };
            volViewModel.DepartPrevue = new DateTime(2022, 08, 07, 08, 02, 00);
            volViewModel.ArrivePrevue = new DateTime(2022, 08, 07, 10, 02, 00);
            volViewModel.NombrePlace = 10;
            volViewModel.Appareil = new Appareil() { Id = 1, Nom = "Eurocopter AS 355 F1/F2 Ecureuil III", Description = "", Capacite_Cab = 5, Vitesse = 220, Moteur = "Deux turbines du modèle de Rolls Royce 250-C20F", Statut = false };
            return volViewModel;
        }

        //ModifId3
        private List<string>? AddModif2()
        {
            List<string> modifVolList = new List<string>();
            VolViewModel volViewModel = CreateViewModel2();
            modifVolList.Add(CreateModifObject(volViewModel));
            return modifVolList;
        }
        private static VolViewModel CreateViewModel2()
        {
            VolViewModel volViewModel = new VolViewModel();
            volViewModel.IdVol = 3;
            volViewModel.Depart = new Aeroport() { Id = 1, Nom = "Liège", Latitude = 50.63583079, Longitude = 5.439331576 };
            volViewModel.Arrive = new Aeroport() { Id = 3, Nom = "Oostende", Latitude = 51.193165894, Longitude = 2.858163234 };
            volViewModel.DepartPrevue = new DateTime(2022, 08, 15, 08, 02, 00);
            volViewModel.ArrivePrevue = new DateTime(2022, 08, 15, 11, 02, 00);
            volViewModel.NombrePlace = 5;
            volViewModel.Appareil = new Appareil() { Id = 2, Nom = "Bell 206 JetRanger", Description = "", Capacite_Cab = 4, Vitesse = 190, Moteur = "Une turbine du type Rolls Royce 250-C20B", Statut = false };
            return volViewModel;
        }

        //ModifId4
        private List<string>? AddModif3()
        {
            List<string> modifVolList = new List<string>();
            VolViewModel volViewModel = CreateViewModel3();
            modifVolList.Add(CreateModifObject(volViewModel));
            return modifVolList;
        }
        private static VolViewModel CreateViewModel3()
        {
            VolViewModel volViewModel = new VolViewModel();
            volViewModel.IdVol = 4;
            volViewModel.Depart = new Aeroport() { Id = 2, Nom = "Bruxelles", Latitude = 50.90082973, Longitude = 4.483998064 };
            volViewModel.Arrive = new Aeroport() { Id = 4, Nom = "Charleroi", Latitude = 50.455998176, Longitude = 4.45166486 };
            volViewModel.DepartPrevue = new DateTime(2022, 08, 16, 08, 02, 00);
            volViewModel.ArrivePrevue = new DateTime(2022, 08, 16, 10, 02, 00);
            volViewModel.NombrePlace = 15;
            volViewModel.Appareil = new Appareil() { Id = 3, Nom = "Robinson R44 Raven II", Description = "", Capacite_Cab = 3, Vitesse = 190, Moteur = "Un piston du type Lycoming modèle IO-540", Statut = false };
            return volViewModel;
        }

        //ModifId5
        private List<string>? AddModif4()
        {
            List<string> modifVolList = new List<string>();
            VolViewModel volViewModel = CreateViewModel4();
            modifVolList.Add(CreateModifObject(volViewModel));
            return modifVolList;
        }
        private static VolViewModel CreateViewModel4()
        {
            VolViewModel volViewModel = new VolViewModel();
            volViewModel.IdVol = 5;
            volViewModel.Depart = new Aeroport() { Id = 4, Nom = "Charleroi", Latitude = 50.455998176, Longitude = 4.45166486 };
            volViewModel.Arrive = new Aeroport() { Id = 2, Nom = "Bruxelles", Latitude = 50.90082973, Longitude = 4.483998064 };
            volViewModel.DepartPrevue = new DateTime(2022, 08, 17, 08, 02, 00);
            volViewModel.ArrivePrevue = new DateTime(2022, 08, 17, 10, 02, 00);
            volViewModel.NombrePlace = 6;
            volViewModel.Appareil = new Appareil() { Id = 3, Nom = "Robinson R44 Raven II", Description = "", Capacite_Cab = 3, Vitesse = 190, Moteur = "Un piston du type Lycoming modèle IO-540", Statut = false };
            return volViewModel;
        }


        private string CreateModifObject(VolViewModel vol)
        {
            return JsonConvert.SerializeObject(vol,
             new JsonSerializerSettings
             {
                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
             });
        }


        public DbSet<Aeroport> Aeroport { get; set; }
        public DbSet<Appareil> Appareil { get; set; }
        public DbSet<Vol> Vol { get; set; }
        public DbSet<JITC.Models.ModifVol>? ModifVol { get; set; }
        public DbSet<JITC.Models.Reservation>? Reservation { get; set; }
        


    }

}
