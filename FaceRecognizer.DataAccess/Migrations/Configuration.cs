using FaceRecognizer.DataAccess.Database;
using FaceRecognizer.DataAccess.Migrations.Seed;
using System.Data.Entity.Migrations;

namespace FaceRecognizer.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(MyDbContext context)
        {
            UserStatusSeed.Seed(context);
            TokenStatusSeed.Seed(context);
            ContractStatusSeed.Seed(context);
            DocumentTypeSeed.Seed(context);
            OperationTypeSeed.Seed(context);
            ContractFileTypeSeed.Seed(context);
            UserFileTypeSeed.Seed(context);
            SubscriptionTypeSeed.Seed(context);
            context.SaveChanges();
            CitizenshipSeed.Seed(context);
            ClaimSeed.Seed(context);
            OrganizationSeed.Seed(context);
            RegionSeed.Seed(context);
            TarifSeed.Seed(context);
            GenderSeed.Seed(context);
            context.SaveChanges();
            BranchSeed.Seed(context);
			RoleGroupSeed.Seed(context);
			context.SaveChanges();
			RoleSeed.Seed(context);
            context.SaveChanges();

            DocumentInformationSeed.Seed(context);
            context.SaveChanges();

            UserSeed.Seed(context);
            ContractSeed.Seed(context);
            context.SaveChanges();

            TokenSeed.Seed(context);
            context.SaveChanges();
        }
    }
}
