using FaceRecognizer.DataAccess.Database.EntityConfigurations;
using FaceRecognizer.Models.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace FaceRecognizer.DataAccess.Database
{
	public class MyDbContext : DbContext
	{
		public MyDbContext() : base("name=MyDbConnection")
		{
			Configuration.LazyLoadingEnabled = false;
			Configuration.ValidateOnSaveEnabled = false;
			Configuration.EnsureTransactionsForFunctionsAndCommands = false;
			(this as IObjectContextAdapter).ObjectContext.CommandTimeout = 300;
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Token> Tokens { get; set; }
		public DbSet<UserStatus> UserStatuses { get; set; }
		public DbSet<Contract> Contracts { get; set; }
		public DbSet<TokenStatus> TokenStatuses { get; set; }
		public DbSet<ContractStatus> ContractStatuses { get; set; }
		public DbSet<DocumentType> DocumentTypes { get; set; }
		public DbSet<OperationType> OperationTypes { get; set; }
		public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Claim> Claims { get; set; }
		public DbSet<Organization> Organizations { get; set; }
		public DbSet<Region> Regions { get; set; }
		public DbSet<Tarif> Tarifs { get; set; }
		public DbSet<DocumentInformation> DocumentInformations { get; set; }
		public DbSet<Branch> Branches { get; set; }
		public DbSet<Citizenship> Citizenships { get; set; }
		public DbSet<Gender> Genders { get; set; }
		public DbSet<RoleGroup> RoleGroups { get; set; }
		public DbSet<ContractFile> ContractFiles { get; set; }
		public DbSet<ContractFileType> ContractFileTypes { get; set; }
		public DbSet<UserFile> UserFiles { get; set; }
		public DbSet<UserFileType> UserFileTypes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new UserConfiguration());
			modelBuilder.Configurations.Add(new TokenConfiguration());
			modelBuilder.Configurations.Add(new UserStatusConfiguration());
			modelBuilder.Configurations.Add(new ContractConfiguration());
			modelBuilder.Configurations.Add(new TokenStatusConfiguration());
			modelBuilder.Configurations.Add(new DocumentTypeConfiguration());
			modelBuilder.Configurations.Add(new OperationTypeConfiguration());
			modelBuilder.Configurations.Add(new SubscriptionTypeConfiguration());
			modelBuilder.Configurations.Add(new ContractStatusConfiguration());
			modelBuilder.Configurations.Add(new DocumentInformationConfiguration());
			modelBuilder.Configurations.Add(new OrganizationConfiguration());
			modelBuilder.Configurations.Add(new RegionConfiguration());
			modelBuilder.Configurations.Add(new TarifConfiguration());
			modelBuilder.Configurations.Add(new BranchConfiguration());
			modelBuilder.Configurations.Add(new CitizenshipConfiguration());
			modelBuilder.Configurations.Add(new GenderConfiguration());
			modelBuilder.Configurations.Add(new RoleConfiguration());
			modelBuilder.Configurations.Add(new RoleGroupConfiguration());
			modelBuilder.Configurations.Add(new ContractFileConfiguration());
			modelBuilder.Configurations.Add(new ContractFileTypeConfiguration());
			modelBuilder.Configurations.Add(new UserFileConfiguration());
			modelBuilder.Configurations.Add(new UserFileTypeConfiguration());
		}
	}
}
