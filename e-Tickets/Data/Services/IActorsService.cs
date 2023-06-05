using e_Tickets.Models;

namespace e_Tickets.Data.Services
{
    public interface IActorsService
    {
       Task< IEnumerable<Actor> >GetAllASync();

        Task<Actor> GetByIdASync(int id);

       Task AddASync(Actor actor);

        Task <Actor> UpdateASync(int id, Actor newActor);

        Task DeleteASync(int id);
        Task AddAsync(Actor actor);
    }
}
