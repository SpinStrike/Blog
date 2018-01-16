using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Blog.Data.Model;
using Blog.Data.EF.Configuration;

namespace Blog.Data.EF
{
    public class BlogDbContext : IdentityDbContext<User>
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<ArticleTag> Tags { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Questionnaire> Questionnaires { get; set; }

        public DbSet<CompletedQuestionnaire> CompletedQuestionnaires { get; set; }

        public DbSet<SelectedAnswer> SelectdAnswers { get; set; }

        public DbSet<Voting> Votings { get; set; }

        public BlogDbContext(string nameOrConnectionString)
            :base(nameOrConnectionString)
        {}

        static BlogDbContext()
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<BlogDbContext>()
            );

            Database.SetInitializer<BlogDbContext>(new DbInicializer());
        }

        public static BlogDbContext CreateDb()
        {
            return new BlogDbContext("BlogDbConnection");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArticleConfiguration());
            modelBuilder.Configurations.Add(new ArticleTagConfiguration());
            modelBuilder.Configurations.Add(new ReviewConfiguration());
            modelBuilder.Configurations.Add(new AnswerConfiguration());
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new QuestionnaireConfiguration());
            modelBuilder.Configurations.Add(new CompletedQuestionnaireConfiguration());
            modelBuilder.Configurations.Add(new SelectedAnswerConfiguration());
            modelBuilder.Configurations.Add(new VotingConfiguration());
            modelBuilder.Configurations.Add(new VotingOptionConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public Database GetDatabase()
        {
            return base.Database;
        }

        public new void Dispose()
        {
            base.Dispose(true);
        }
    }
}
