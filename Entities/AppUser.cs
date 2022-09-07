using System.ComponentModel.DataAnnotations;

namespace DatingAppServer.Entities
{

    public class AppUser
    {

        public int Id { get; set; } = default;
        public string userName { get; set; } = default;

        
    }
}
