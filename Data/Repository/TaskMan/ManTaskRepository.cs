using Core.Domain.Model;
using Data.Context;
using Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ManTaskRepository : IManTaskRepository
    {
        private readonly MyContext _context;

        public ManTaskRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<ManTask> DeleteManTaskAsync(int id)
        {
            var manTaskFinded = await _context.ManTasks.FindAsync(id);

            if (manTaskFinded == null) { return null; }

            var manTaskRemoved = _context.ManTasks.Remove(manTaskFinded);
            await _context.SaveChangesAsync();
            return manTaskRemoved.Entity;
        }

        public async Task<IEnumerable<ManTask>> GetAllManTasksAsync()
        {
            return await _context.ManTasks.AsNoTracking().ToListAsync();
        }

        public async Task<ManTask> GetManTaskByIdAsync(int id)
        {
            return await _context.ManTasks.FindAsync(id);
        }

        public async Task<ManTask> InsertManTaskAsync(ManTask manTask)
        {
            await _context.ManTasks.AddAsync(manTask);
            await _context.SaveChangesAsync();
            return manTask;
        }

        public async Task<ManTask> UpdateManTaskAsync(ManTask manTask)
        {
            var manTaskFind = await _context.ManTasks.FindAsync(manTask.Id);
            if (manTaskFind != null)
            {
                _context.Entry(manTaskFind).CurrentValues.SetValues(manTask);
                await _context.SaveChangesAsync();
                return manTaskFind;
            }
            return null;
        }
    }
}
