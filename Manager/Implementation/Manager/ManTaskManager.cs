using Core.Domain.Model;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;

namespace Manager.Implementation.Manager
{
    public class ManTaskManager : IManTaskManager
    {
        private readonly IManTaskRepository _manTaskRepository;

        public ManTaskManager(IManTaskRepository manTaskRepository)
        {
            _manTaskRepository = manTaskRepository;
        }

        public async Task<ManTask> DeleteManTaskAsync(int id)
        {
            return await _manTaskRepository.DeleteManTaskAsync(id);
        }

        public async Task<IEnumerable<ManTask>> GetAllManTasksAsync()
        {
            return await _manTaskRepository.GetAllManTasksAsync();
        }

        public async Task<ManTask> GetManTaskByIdAsync(int id)
        {
            return await _manTaskRepository.GetManTaskByIdAsync(id);
        }

        public async Task<ManTask> InsertManTaskAsync(ManTask manTask)
        {
            return await _manTaskRepository.InsertManTaskAsync(manTask);
        }

        public async Task<ManTask> UpdateManTaskAsync(ManTask manTask)
        {
            return await _manTaskRepository.UpdateManTaskAsync(manTask);
        }
    }
}
