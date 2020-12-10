using BlazorLocal.Data.ModelsDB;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorLocal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        DbSet<Auftrag> AuftragDbSet { get; set; }
        DbSet<Kunde> KundeDbSet { get; set; }
        DbSet<LogApplicationError> LogApplicationErrorDbSet { get; set; }
        public DbSet<SMTPSetting> SMTPSettingDbSet { get; set; }
    }
}
