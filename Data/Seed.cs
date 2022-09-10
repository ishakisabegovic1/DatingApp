using DatingAppServer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace DatingAppServer.Data
{
    public class Seed
    {
        public static async Task SeedUsers(AppDbContext context)
        {
            if (await context.Users.AnyAsync()) return; 

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
         
            foreach(var user in users)
            {
                using var hmac = new HMACSHA512();

                user.userName = user.userName.ToLower();
                user.PaswwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PaswwordSalt = hmac.Key;
                
                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
            

        }

    }
}
