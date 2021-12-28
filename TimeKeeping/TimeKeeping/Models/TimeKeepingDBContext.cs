using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TimeKeeping.Models
{
    public partial class TimeKeepingDBContext : DbContext
    {
        public TimeKeepingDBContext()
        {
        }

        public TimeKeepingDBContext(DbContextOptions<TimeKeepingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplySeniorityPolicy> ApplySeniorityPolicies { get; set; }
        public virtual DbSet<ApprovalProcess> ApprovalProcesses { get; set; }
        public virtual DbSet<Checkin> Checkins { get; set; }
        public virtual DbSet<CheckinPolicy> CheckinPolicies { get; set; }
        public virtual DbSet<DayOff> DayOffs { get; set; }
        public virtual DbSet<DaysOfWeek> DaysOfWeeks { get; set; }
        public virtual DbSet<FormTimeOff> FormTimeOffs { get; set; }
        public virtual DbSet<NumberOfShift> NumberOfShifts { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Personnel> Personnel { get; set; }
        public virtual DbSet<PersonnelApplyTimeOffPolicy> PersonnelApplyTimeOffPolicies { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<SalaryPolicy> SalaryPolicies { get; set; }
        public virtual DbSet<SeniorityPolicy> SeniorityPolicies { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<TimeKeepingFeedback> TimeKeepingFeedbacks { get; set; }
        public virtual DbSet<TimeOffApprover> TimeOffApprovers { get; set; }
        public virtual DbSet<TimeOffFollower> TimeOffFollowers { get; set; }
        public virtual DbSet<TimeOffPolicy> TimeOffPolicies { get; set; }
        public virtual DbSet<TimeOffRequest> TimeOffRequests { get; set; }
        public virtual DbSet<TimeOffRequestState> TimeOffRequestStates { get; set; }
        public virtual DbSet<TypePersonnel> TypePersonnel { get; set; }
        public virtual DbSet<TypePolicy> TypePolicies { get; set; }
        public virtual DbSet<TypePosition> TypePositions { get; set; }
        public virtual DbSet<TypeShift> TypeShifts { get; set; }
        public virtual DbSet<TypeTimeOff> TypeTimeOffs { get; set; }
        public virtual DbSet<TypeWorkSchedule> TypeWorkSchedules { get; set; }
        public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }
        public virtual DbSet<WorkingArea> WorkingAreas { get; set; }
        public virtual DbSet<WorkingAreaApplyFormTimeOff> WorkingAreaApplyFormTimeOffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.


                //optionsBuilder.UseSqlServer("Server=.;Database=TimeKeepingDB;Trusted_Connection=True;UID=sa;PWD=123456");
                //optionsBuilder.UseSqlServer("Server=SONIC\\SQLEXPRESS;Database=TimeKeepingDB1;Trusted_Connection=True");
               // optionsBuilder.UseSqlServer("Server=ST7\\SQLEXPRESS;Database=TimeKeepingDB;Trusted_Connection=True");
                //optionsBuilder.UseSqlServer("Server=.;Trusted_Connection=True;UID=sa;PWD=123456");
                //optionsBuilder.UseSqlServer("Server=DESKTOP-CA57SN6\\SQLEXPRESS;Database=TimeKeepingDB;Trusted_Connection=True;");
                optionsBuilder.UseLazyLoadingProxies();


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ApplySeniorityPolicy>(entity =>
            {
                entity.HasKey(e => new { e.TimeOffPolicyId, e.SeniorityPolicyId });

                entity.ToTable("ApplySeniorityPolicy");

                entity.Property(e => e.TimeOffPolicyId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SeniorityPolicyId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.SeniorityPolicy)
                    .WithMany(p => p.ApplySeniorityPolicies)
                    .HasForeignKey(d => d.SeniorityPolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_ApplySeniorityPolicy_SeniorityPolicy");

                entity.HasOne(d => d.TimeOffPolicy)
                    .WithMany(p => p.ApplySeniorityPolicies)
                    .HasForeignKey(d => d.TimeOffPolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_ApplySeniorityPolicy_TimeOffPolicy");
            });

            modelBuilder.Entity<ApprovalProcess>(entity =>
            {
                entity.ToTable("ApprovalProcess");

                entity.Property(e => e.ApprovalProcessId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.ApprovalProcessName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Checkin>(entity =>
            {
                entity.ToTable("Checkin");

                entity.Property(e => e.CheckinId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.PersonnelId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Personnel)
                    .WithMany(p => p.Checkins)
                    .HasForeignKey(d => d.PersonnelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_Checkin_Personnel");
            });

            modelBuilder.Entity<CheckinPolicy>(entity =>
            {
                entity.ToTable("CheckinPolicy");

                entity.Property(e => e.CheckinPolicyId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CheckinPolicyName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<DayOff>(entity =>
            {
                entity.ToTable("DayOff");

                entity.Property(e => e.DayOffId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.DayOffAt).HasColumnType("datetime");

                entity.Property(e => e.FromHour)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TimeOffRequestId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ToHour)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.TimeOffRequest)
                    .WithMany(p => p.DayOffs)
                    .HasForeignKey(d => d.TimeOffRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_DayOff_TimeOffRequest");
            });

            modelBuilder.Entity<DaysOfWeek>(entity =>
            {
                entity.ToTable("DaysOfWeek");

                entity.Property(e => e.DaysOfWeekId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.DaysOfWeekName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<FormTimeOff>(entity =>
            {
                entity.ToTable("FormTimeOff");

                entity.Property(e => e.FormTimeOffId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.ApprovalProcessId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FormTimeOffName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LimitedDaysOff).HasDefaultValueSql("((5))");

                entity.Property(e => e.NumberOfDaysBeforeTimeOff).HasDefaultValueSql("((2))");

                entity.Property(e => e.ProcessingTime).HasDefaultValueSql("((24))");

                entity.Property(e => e.Regulations).HasMaxLength(100);

                entity.Property(e => e.RequireApproval)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.RequireLimitedDaysOff)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeTimeOffId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApprovalProcess)
                    .WithMany(p => p.FormTimeOffs)
                    .HasForeignKey(d => d.ApprovalProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_FormTimeOff_ApprovalProcess");

                entity.HasOne(d => d.TypeTimeOff)
                    .WithMany(p => p.FormTimeOffs)
                    .HasForeignKey(d => d.TypeTimeOffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_FormTimeOff_TypeTimeOff");
            });

            modelBuilder.Entity<NumberOfShift>(entity =>
            {
                entity.ToTable("NumberOfShift");

                entity.Property(e => e.NumberOfShiftId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Office>(entity =>
            {
                entity.ToTable("Office");

                entity.Property(e => e.OfficeId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.OfficeAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OfficeEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OfficeName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OfficePhone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personnel>(entity =>
            {
                entity.Property(e => e.PersonnelId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.ActualSalary).HasColumnType("money");

                entity.Property(e => e.BasicSalary).HasColumnType("money");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OfficeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.OfficialDate).HasColumnType("datetime");

                entity.Property(e => e.PersonnelAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SalaryPolicyId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.TypePersonnelId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkScheduleId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkingAreaId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Office)
                    .WithMany(p => p.Personnel)
                    .HasForeignKey(d => d.OfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_Personnel_Office");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Personnel)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_Personnel_Position");

                entity.HasOne(d => d.SalaryPolicy)
                    .WithMany(p => p.Personnel)
                    .HasForeignKey(d => d.SalaryPolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_Personnel_SalaryPolicy");

                entity.HasOne(d => d.TypePersonnel)
                    .WithMany(p => p.Personnel)
                    .HasForeignKey(d => d.TypePersonnelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_Personnel_TypePersonnel");

                entity.HasOne(d => d.WorkSchedule)
                    .WithMany(p => p.Personnel)
                    .HasForeignKey(d => d.WorkScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_Personnel_WorkSchedule");

                entity.HasOne(d => d.WorkingArea)
                    .WithMany(p => p.Personnel)
                    .HasForeignKey(d => d.WorkingAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_Personnel_WorkingArea");
            });

            modelBuilder.Entity<PersonnelApplyTimeOffPolicy>(entity =>
            {
                entity.HasKey(e => new { e.PersonnelId, e.TimeOffPolicyId });

                entity.ToTable("PersonnelApplyTimeOffPolicy");

                entity.Property(e => e.PersonnelId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TimeOffPolicyId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.HasOne(d => d.Personnel)
                    .WithMany(p => p.PersonnelApplyTimeOffPolicies)
                    .HasForeignKey(d => d.PersonnelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_PersonnelApplyTimeOffPolicy_Personnel");

                entity.HasOne(d => d.TimeOffPolicy)
                    .WithMany(p => p.PersonnelApplyTimeOffPolicies)
                    .HasForeignKey(d => d.TimeOffPolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_PersonnelApplyTimeOffPolicy_TimeOffPolicy");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.PositionId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.HighestSalary).HasColumnType("money");

                entity.Property(e => e.LowestSalary).HasColumnType("money");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TypePositionId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkingAreaId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.TypePosition)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.TypePositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_Position_TypePosition");

                entity.HasOne(d => d.WorkingArea)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.WorkingAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_Position_WorkingArea");
            });

            modelBuilder.Entity<SalaryPolicy>(entity =>
            {
                entity.ToTable("SalaryPolicy");

                entity.Property(e => e.SalaryPolicyId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Describe).HasMaxLength(100);

                entity.Property(e => e.SalaryPolicyName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.States).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<SeniorityPolicy>(entity =>
            {
                entity.ToTable("SeniorityPolicy");

                entity.Property(e => e.SeniorityPolicyId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift");

                entity.Property(e => e.ShiftId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.DayOff)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.DaysOfWeekId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TypeShiftId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkScheduleId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.DaysOfWeek)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.DaysOfWeekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_Shift_DaysOfWeek");

                entity.HasOne(d => d.TypeShift)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.TypeShiftId)
                    .HasConstraintName("PR_Shift_TypeShift");

                entity.HasOne(d => d.WorkSchedule)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.WorkScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_Shift_WorkSchedule");
            });

            modelBuilder.Entity<TimeKeepingFeedback>(entity =>
            {
                entity.ToTable("TimeKeepingFeedback");

                entity.Property(e => e.TimeKeepingFeedbackId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CheckinId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.TimeOffRequestStateId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Checkin)
                    .WithMany(p => p.TimeKeepingFeedbacks)
                    .HasForeignKey(d => d.CheckinId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_TimeKeepingFeedback_Checkin");

                entity.HasOne(d => d.TimeOffRequestState)
                    .WithMany(p => p.TimeKeepingFeedbacks)
                    .HasForeignKey(d => d.TimeOffRequestStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_TimeKeepingFeedback_TimeOffRequestState");
            });

            modelBuilder.Entity<TimeOffApprover>(entity =>
            {
                entity.HasKey(e => new { e.PersonnelId, e.FormTimeOffId });

                entity.ToTable("TimeOffApprover");

                entity.Property(e => e.PersonnelId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FormTimeOffId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FormTimeOff)
                    .WithMany(p => p.TimeOffApprovers)
                    .HasForeignKey(d => d.FormTimeOffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_TimeOffApprover_FormTimeOff");

                entity.HasOne(d => d.Personnel)
                    .WithMany(p => p.TimeOffApprovers)
                    .HasForeignKey(d => d.PersonnelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_TimeOffApprover_Personnel");
            });

            modelBuilder.Entity<TimeOffFollower>(entity =>
            {
                entity.HasKey(e => new { e.PersonnelId, e.FormTimeOffId });

                entity.ToTable("TimeOffFollower");

                entity.Property(e => e.PersonnelId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FormTimeOffId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FormTimeOff)
                    .WithMany(p => p.TimeOffFollowers)
                    .HasForeignKey(d => d.FormTimeOffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_TimeOffFollower_FormTimeOff");

                entity.HasOne(d => d.Personnel)
                    .WithMany(p => p.TimeOffFollowers)
                    .HasForeignKey(d => d.PersonnelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_TimeOffFollower_Personnel");
            });

            modelBuilder.Entity<TimeOffPolicy>(entity =>
            {
                entity.ToTable("TimeOffPolicy");

                entity.Property(e => e.TimeOffPolicyId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Describe).HasMaxLength(100);

                entity.Property(e => e.TimeOffPolicyName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TypePolicyId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.TypePolicy)
                    .WithMany(p => p.TimeOffPolicies)
                    .HasForeignKey(d => d.TypePolicyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_TimeOffPolicy_TypePolicy");
            });

            modelBuilder.Entity<TimeOffRequest>(entity =>
            {
                entity.ToTable("TimeOffRequest");

                entity.Property(e => e.TimeOffRequestId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Attachment).HasMaxLength(100);

                entity.Property(e => e.Feedback).HasMaxLength(100);

                entity.Property(e => e.FormTimeOffId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HandOverWorks).HasMaxLength(200);

                entity.Property(e => e.ManagerId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PersonnelId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Reason)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.TimeOffDate).HasColumnType("datetime");

                entity.Property(e => e.TimeOffRequestStateId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.FormTimeOff)
                    .WithMany(p => p.TimeOffRequests)
                    .HasForeignKey(d => d.FormTimeOffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_TimeOffRequest_FormTimeOff");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.TimeOffRequestManagers)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_TimeOffRequest_Manager");

                entity.HasOne(d => d.Personnel)
                    .WithMany(p => p.TimeOffRequestPersonnel)
                    .HasForeignKey(d => d.PersonnelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_TimeOffRequest_Personnel");

                entity.HasOne(d => d.TimeOffRequestState)
                    .WithMany(p => p.TimeOffRequests)
                    .HasForeignKey(d => d.TimeOffRequestStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_TimeOffRequest_TimeOffRequestState");
            });

            modelBuilder.Entity<TimeOffRequestState>(entity =>
            {
                entity.ToTable("TimeOffRequestState");

                entity.Property(e => e.TimeOffRequestStateId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.TimeOffRequestStateName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypePersonnel>(entity =>
            {
                entity.Property(e => e.TypePersonnelId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Describe).HasMaxLength(100);

                entity.Property(e => e.States).HasDefaultValueSql("((1))");

                entity.Property(e => e.TypePersonnelName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TypePolicy>(entity =>
            {
                entity.ToTable("TypePolicy");

                entity.Property(e => e.TypePolicyId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.TypePolicyName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypePosition>(entity =>
            {
                entity.ToTable("TypePosition");

                entity.Property(e => e.TypePositionId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Describe).HasMaxLength(100);

                entity.Property(e => e.TypePositionName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypeShift>(entity =>
            {
                entity.ToTable("TypeShift");

                entity.Property(e => e.TypeShiftId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeShiftName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypeTimeOff>(entity =>
            {
                entity.ToTable("TypeTimeOff");

                entity.Property(e => e.TypeTimeOffId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeTimeOffName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypeWorkSchedule>(entity =>
            {
                entity.ToTable("TypeWorkSchedule");

                entity.Property(e => e.TypeWorkScheduleId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeWorkScheduleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<WorkSchedule>(entity =>
            {
                entity.ToTable("WorkSchedule");

                entity.Property(e => e.WorkScheduleId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.CheckinPolicyId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.MinutesEarly).HasDefaultValueSql("((15))");

                entity.Property(e => e.MinutesLate).HasDefaultValueSql("((15))");

                entity.Property(e => e.NumberOfShiftId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Regulations).HasMaxLength(100);

                entity.Property(e => e.RequireCheckout)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.States).HasDefaultValueSql("((1))");

                entity.Property(e => e.TypeWorkScheduleId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkScheduleName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.WorkingHoursPerDay).HasDefaultValueSql("((8))");

                entity.HasOne(d => d.CheckinPolicy)
                    .WithMany(p => p.WorkSchedules)
                    .HasForeignKey(d => d.CheckinPolicyId)
                    .HasConstraintName("PR_WorkSchedule_CheckinPolicy");

                entity.HasOne(d => d.NumberOfShift)
                    .WithMany(p => p.WorkSchedules)
                    .HasForeignKey(d => d.NumberOfShiftId)
                    .HasConstraintName("PR_WorkSchedule_NumberOfShift");

                entity.HasOne(d => d.TypeWorkSchedule)
                    .WithMany(p => p.WorkSchedules)
                    .HasForeignKey(d => d.TypeWorkScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_WorkSchedule_TypeWorkSchedule");
            });

            modelBuilder.Entity<WorkingArea>(entity =>
            {
                entity.ToTable("WorkingArea");

                entity.Property(e => e.WorkingAreaId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Describe).HasMaxLength(100);

                entity.Property(e => e.States).HasDefaultValueSql("((1))");

                entity.Property(e => e.WorkingAreaName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<WorkingAreaApplyFormTimeOff>(entity =>
            {
                entity.HasKey(e => new { e.WorkingAreaId, e.FormTimeOffId });

                entity.ToTable("WorkingAreaApplyFormTimeOff");

                entity.Property(e => e.WorkingAreaId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FormTimeOffId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.FormTimeOff)
                    .WithMany(p => p.WorkingAreaApplyFormTimeOffs)
                    .HasForeignKey(d => d.FormTimeOffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_WorkingAreaApplyFormTimeOff_FormTimeOff");

                entity.HasOne(d => d.WorkingArea)
                    .WithMany(p => p.WorkingAreaApplyFormTimeOffs)
                    .HasForeignKey(d => d.WorkingAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PR_WorkingAreaApplyFormTimeOff_WorkingArea");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
