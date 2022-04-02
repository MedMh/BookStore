using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using UserService.Models;

namespace UserService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder appBuilder, bool isProduction)
        {
            using(var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                
                context.Users
                .AddRange(
                    new User() {FirstName = "Simon", FamilyName = "Sinik", UserName = "SimonSinik", Email = "SimonSink@gmail.com", Password = "0000"},
                    new User() {FirstName = "Jordan", FamilyName = "Peterson", UserName = "JordanPeterson", Email = "JordanPeterson@gmail.com", Password = "0000"},
                    new User() {FirstName = "Mark", FamilyName = "Manson", UserName = "MarkManson", Email = "MarkManson@gmail.com", Password = "0000"},
                    new User() {FirstName = "Jihad", FamilyName = "Torbani", UserName = "JihadTorbani", Email = "JihadTorbani@gmail.com", Password = "0000"}
                    );

                context.SaveChanges();
                

            }
        }
    }
}