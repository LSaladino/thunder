using Core.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> op) : base(op)
        {

        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.Entity<ManTask>().HasData(
        //        new ManTask
        //        {
        //            Id = 1,
        //            Description = "Criar nova tela de avaliações",
        //            CollaboratorName = "Jorge Alberto",
        //            Comments = "ja iniciei, sem impedimentos",
        //            StartDate = DateTime.Now,
        //            EndDate = DateTime.Now
        //        },
        //        new ManTask
        //        {
        //            Id = 2,
        //            Description = "Ajuste na nova tela de avaliações",
        //            CollaboratorName = "Jorge Alberto",
        //            Comments = "ja iniciei, sem impedimentos",
        //            StartDate = DateTime.Now,
        //            EndDate = DateTime.Now
        //        },
        //        new ManTask
        //        {
        //            Id = 3,
        //            Description = "Corrigir erro ao clicar botão Editar tela de avaliações",
        //            CollaboratorName = "Marcos Paulo",
        //            Comments = "ja iniciei, sem impedimentos",
        //            StartDate = DateTime.Now,
        //            EndDate = DateTime.Now
        //        },
        //        new ManTask
        //        {
        //            Id = 4,
        //            Description = "Mostrar mensagem alinhada",
        //            CollaboratorName = "Manfredo Luis",
        //            Comments = "Tela de avaliações - ja iniciei, sem impedimentos",
        //            StartDate = DateTime.Now,
        //            EndDate = DateTime.Now
        //        },
        //        new ManTask
        //        {
        //            Id = 5,
        //            Description = "Consulta da quantidade de usuarios errada",
        //            CollaboratorName = "Sergio Ramos",
        //            Comments = "Quary com agrupamento do somatorio errado",
        //            StartDate = DateTime.Now,
        //            EndDate = DateTime.Now
        //        }

        //        );
        //}

        public DbSet<ManTask> ManTasks { get; set; }
    }
}
