using System.ComponentModel.DataAnnotations;

namespace e_Tickets.Models
{
    public class ActorMovie
    {
        [Key]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
