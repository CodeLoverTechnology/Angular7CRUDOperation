using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Angular7CRUDOperation.Models
{
    public class NIASDbContext : DbContext
    {
        public NIASDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
        }

        public DbSet<EnquiryModel> enquiryList { get; set; }
        public DbSet<CategoryMaster> categoryMasters { get; set; }
        public DbSet<MasterInfo> masterInfos { get; set; }
        public DbSet<SubCategoryMaster> subCategoryMasters { get; set; }
        public DbSet<CourseMaster> courseMasters { get; set; }
        public DbSet<BranchMaster> branchMasters { get; set; }
        public DbSet<BannerMaster> bannerMasters { get; set; }
        public DbSet<SocialMediaMasters> socialMediaMasters { get; set; }
        public DbSet<ChatMaster> chatMasters { get; set; }

        public DbSet<FacultyMaster> facultyMaster { get; set; }
        public DbSet<VideoLectures> videoLectures { get; set; }
        public DbSet<NirmanResultMasters> nirmanResultMasters { get; set; }
        public DbSet<BatchTopicDetails> batchTopicDetails { get; set; }
        public DbSet<BatchDetails> batchDetails { get; set; }
        public DbSet<CurrentAffairsMasters> currentAffairsMasters { get; set; }

        public DbSet<NotificationMaster> notificationMaster { get; set; }
        public DbSet<ImageVideoInfo> imageVideoInfo { get; set; }
        public DbSet<UserMaster> userMaster { get; set; }
        public DbSet<StudentMasterInfo> studentMasterInfo { get; set; }
        public DbSet<LoginModel> loginModel { get; set; }

        public DbSet<FileUploadedMaster> fileUploadedMasters { get; set; }
        public DbSet<UploadOptionMaster> uploadOptionMasters { get; set; }
        public DbSet<TestStudentResultModel> testStudentResult { get; set; }
        public DbSet<SMSMessageMaster> sMSMessageMasters { get; set; }
    }

}
