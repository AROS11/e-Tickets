using e_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace e_Tickets.Data.Services
{
    public class ActorsService : IActorsService

    {
        private readonly AppDbContext _dbContext;
        public ActorsService(AppDbContext context)
        {
            _dbContext = context;
        }
        public async Task AddASync(Actor actor)
        {
             await  _dbContext.AddASync(actor);
            await _dbContext.SaveChangesAsync();
        }

        public Task AddAsync(Actor actor)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteASync(int id)
        {
            var result = await _dbContext.Actors.FirstOrDefaultAsync(n => n.Id == id);
             _dbContext.Actors.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _dbContext.Actors.ToListAsync();
            return result;
        }

        public Task<IEnumerable<Actor>> GetAllASync()
        {
            throw new NotImplementedException();
            //return GetAllAsync();
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _dbContext.Actors.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public Task<Actor> GetByIdASync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Actor> UpdateASync(int id, Actor newActor)
        {
            _dbContext.Update(newActor);
            await _dbContext.SaveChangesAsync();
            return newActor;
        }
    }
}
