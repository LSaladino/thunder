using Core.Domain.Model;

namespace Manager.Interfaces.Managers
{
    public interface IManTaskManager
    {
        Task<IEnumerable<ManTask>> GetAllManTasksAsync();
        Task<ManTask> GetManTaskByIdAsync(int id);
        Task<ManTask> InsertManTaskAsync(ManTask manTask);
        Task<ManTask> UpdateManTaskAsync(ManTask manTask);
        Task<ManTask> DeleteManTaskAsync(int id);
    }
}
