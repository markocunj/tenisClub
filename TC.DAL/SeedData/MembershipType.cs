using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TC.DomainModels;
using TC.DomainModels.Models;

namespace TC.DAL.SeedData
{
    public class MembershipTypesSeed
    {
        public static void SeedMembershipTypes(ApplicationDbContext myDbContext)
        {
            if (!myDbContext.MembershipTypes.Any(x => x.Name == "Silver"))
            {
                MembershipType memType = new MembershipType();
                memType.Name = "Silver";
                memType.AnnualFees = "199.99";
                myDbContext.MembershipTypes.Add(memType);
                myDbContext.SaveChanges();
            }
            if (!myDbContext.MembershipTypes.Any(x => x.Name == "Gold"))
            {
                MembershipType memType = new MembershipType();
                memType.Name = "Gold";
                memType.AnnualFees = "249.99";
                myDbContext.MembershipTypes.Add(memType);
                myDbContext.SaveChanges();
            }
            if (!myDbContext.MembershipTypes.Any(x => x.Name == "Platinum"))
            {
                MembershipType memType = new MembershipType();
                memType.Name = "Platinum";
                memType.AnnualFees = "299.99";
                myDbContext.MembershipTypes.Add(memType);
                myDbContext.SaveChanges();
            }
            if (!myDbContext.MembershipTypes.Any(x => x.Name == "Ultimate"))
            {
                MembershipType memType = new MembershipType();
                memType.Name = "Ultimate";
                memType.AnnualFees = "349.99";
                myDbContext.MembershipTypes.Add(memType);
                myDbContext.SaveChanges();
            }
        }
    }
}
