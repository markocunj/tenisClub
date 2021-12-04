using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.DomainModels;
using TC.DomainModels.Models;

namespace TC.DAL.SeedData
{
    public class CourtSeed
    {
        public static void SeedCourts(ApplicationDbContext myDbContext)
        {
            if (!myDbContext.Courts.Any(x => x.Name == "Grand court 1"))
            {
                Court court = new Court();
                court.Name = "Grand court 1";
                myDbContext.Courts.Add(court);
                myDbContext.SaveChanges();
            }
            if (!myDbContext.Courts.Any(x => x.Name == "Grand court 2"))
            {
                Court court = new Court();
                court.Name = "Grand court 2";
                myDbContext.Courts.Add(court);
                myDbContext.SaveChanges();
            }
            if (!myDbContext.Courts.Any(x => x.Name == "Grand court 3"))
            {
                Court court = new Court();
                court.Name = "Grand court 3";
                myDbContext.Courts.Add(court);
                myDbContext.SaveChanges();
            }
            if (!myDbContext.Courts.Any(x => x.Name == "Small court 1"))
            {
                Court court = new Court();
                court.Name = "Small court 1";
                myDbContext.Courts.Add(court);
                myDbContext.SaveChanges();
            }
            if (!myDbContext.Courts.Any(x => x.Name == "Small court 2"))
            {
                Court court = new Court();
                court.Name = "Small court 2";
                myDbContext.Courts.Add(court);
                myDbContext.SaveChanges();
            }
            if (!myDbContext.Courts.Any(x => x.Name == "Training court 1"))
            {
                Court court = new Court();
                court.Name = "Training court 1";
                myDbContext.Courts.Add(court);
                myDbContext.SaveChanges();
            }
            if (!myDbContext.Courts.Any(x => x.Name == "Training court 2"))
            {
                Court court = new Court();
                court.Name = "Training court 2";
                myDbContext.Courts.Add(court);
                myDbContext.SaveChanges();
            }
        }
    }
}
