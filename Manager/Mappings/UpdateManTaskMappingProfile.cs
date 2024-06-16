using AutoMapper;
using Core.Domain.Model;
using Shared.Modelviews.ManTask;

namespace Manager.Mappings
{
    public class UpdateManTaskMappingProfile:Profile
    {
        public UpdateManTaskMappingProfile()
        {
            CreateMap<UpdateManTask, ManTask>();
        }
    }
}
