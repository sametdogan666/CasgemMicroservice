using CasgemMicroservice.Services.Cargo.DataAccess.Abstract;
using CasgemMicroservice.Services.Cargo.DataAccess.Repository;
using CasgemMicroservice.Services.Cargo.Entities.Entities;

namespace CasgemMicroservice.Services.Cargo.DataAccess.Concrete.EntityFramework;

public class EfCargoDetailDal : Repository<CargoDetail>, ICargoDetailDal
{
    public EfCargoDetailDal(CargoContext context) : base(context)
    {
    }
}