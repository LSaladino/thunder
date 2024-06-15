using Core.Domain.Model;
using Shared.Modelviews.ManTask;

namespace Manager.Interfaces.Managers
{
    public interface IManTaskManager
    {
        Task<IEnumerable<ManTaskView>> GetAllManTasksAsync();
        Task<ManTaskView> GetManTaskByIdAsync(int id);
        Task<ManTaskView> InsertManTaskAsync(NewManTask manTask);
        Task<ManTaskView> UpdateManTaskAsync(UpdateManTask manTask);
        Task<ManTaskView> DeleteManTaskAsync(int id);
    }
}
