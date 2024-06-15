using AutoMapper;
using Core.Domain.Model;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;
using Shared.Modelviews.ManTask;

namespace Manager.Implementation.Manager
{
    public class ManTaskManager : IManTaskManager
    {
        private readonly IManTaskRepository _manTaskRepository;
        private readonly IMapper _mapper;

        public ManTaskManager(IManTaskRepository manTaskRepository, IMapper mapper)
        {
            _manTaskRepository = manTaskRepository;
            _mapper = mapper;
        }

        public async Task<ManTaskView> DeleteManTaskAsync(int id)
        {
            var manTask = await _manTaskRepository.DeleteManTaskAsync(id);
            return _mapper.Map<ManTaskView>(manTask);
        }

        public async Task<IEnumerable<ManTaskView>> GetAllManTasksAsync()
        {
            var manTasks =  await _manTaskRepository.GetAllManTasksAsync();
            return _mapper.Map<IEnumerable<ManTask>, IEnumerable<ManTaskView>>(manTasks);
        }

        public async Task<ManTaskView> GetManTaskByIdAsync(int id)
        {
            var manTask =  await _manTaskRepository.GetManTaskByIdAsync(id);
            return _mapper.Map<ManTaskView>(manTask);
        }

        public async Task<ManTaskView> InsertManTaskAsync(NewManTask newManTask)
        {
            var manTask = _mapper.Map<ManTask>(newManTask);
            manTask = await _manTaskRepository.InsertManTaskAsync(manTask);
            return _mapper.Map<ManTaskView>(manTask);
        }

        public async Task<ManTaskView> UpdateManTaskAsync(UpdateManTask updateManTask)
        {
            var manTask = _mapper.Map<ManTask>(updateManTask);
            manTask = await _manTaskRepository.UpdateManTaskAsync(manTask);
            return _mapper.Map<ManTaskView>(manTask);
        }
    }
}
