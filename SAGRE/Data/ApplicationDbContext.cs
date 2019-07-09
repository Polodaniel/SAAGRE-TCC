using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAGRE.Models;
using SAGRE.Models.MetodosAnalise;
using SAGRE.Models.AnaliseAmbiente;

namespace SAGRE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<GruposRiscoModel> GruposRiscoModel { get; set; }
        public DbSet<SetorModel> SetorModel { get; set; }
        public DbSet<AtividadesModel> AtividadesModel { get; set; }
        public DbSet<BoletimModel> BoletimModel { get; set; }
        public DbSet<LocalModel> LocalModel { get; set; }

        // Model de Analise
        public DbSet<ClassificaoOWAS> ClassificaoOWAS { get; set; }
        public DbSet<AnalisePosturaModel> AnalisePosturaModel { get; set; }
        public DbSet<AnaliseNASATLXModel> AnaliseNASATLXModel { get; set; }
        public DbSet<CheckListAnaliseCondBio> CheckListAnaliseCondBio { get; set; }
        public DbSet<CheckListAnaliseCondErg> CheckListAnaliseCondErg { get; set; }


        // Tabelas Temporarias
        public DbSet<TmpCheckList> TmpCheckList { get; set; }
        
    }
}
