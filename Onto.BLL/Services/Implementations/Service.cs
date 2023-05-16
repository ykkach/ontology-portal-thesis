using Onto.DAL.Data;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onto.BLL.Services.Implementations
{
    public abstract class Service
    {
        protected IUnitOfWork _unitOfWork { get; }
        protected IMapper _mapper { get; }

        protected Service()
        {
            _unitOfWork = new UnitOfWork();
            var myProfile = new AutomapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);
        }

        protected Service(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
