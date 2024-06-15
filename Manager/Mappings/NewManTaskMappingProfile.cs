using AutoMapper;
using Core.Domain.Model;
using Shared.Modelviews.ManTask;

namespace Manager.Mappings
{
    public class NewManTaskMappingProfile : Profile
    {
        public NewManTaskMappingProfile()
        {
            CreateMap<NewManTask, ManTask>();
            CreateMap<ManTask, NewManTask>();
        }
    }
}
