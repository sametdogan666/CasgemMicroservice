using CasgemMicroservice.Services.Cargo.DataAccess.Abstract;
using CasgemMicroservice.Services.Cargo.DataAccess.Repository;
using CasgemMicroservice.Services.Cargo.Entities.Entities;

namespace CasgemMicroservice.Services.Cargo.DataAccess.Concrete.EntityFramework;

public class EfCargoStateDal : Repository<CargoState>, ICargoStateDal
{
    public EfCargoStateDal(CargoContext context) : base(context)
    {
    }
}