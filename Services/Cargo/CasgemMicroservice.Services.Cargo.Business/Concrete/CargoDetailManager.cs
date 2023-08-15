using CasgemMicroservice.Services.Cargo.Business.Abstract;
using CasgemMicroservice.Services.Cargo.DataAccess.Abstract;
using CasgemMicroservice.Services.Cargo.Entities.Entities;

namespace CasgemMicroservice.Services.Cargo.Business.Concrete;

public class CargoDetailManager : ICargoDetailService
{
    private readonly ICargoDetailDal _cargoDetailDal;

    public CargoDetailManager(ICargoDetailDal cargoDetailDal)
    {
        _cargoDetailDal = cargoDetailDal;
    }

    public void Insert(CargoDetail entity)
    {
        _cargoDetailDal.Insert(entity);
    }

    public void Update(CargoDetail entity)
    {
        _cargoDetailDal.Update(entity);
    }

    public void Delete(CargoDetail entity)
    {
        _cargoDetailDal.Delete(entity);
    }

    public List<CargoDetail> GetAll()
    {
        return _cargoDetailDal.GetAll();
    }

    public CargoDetail? GetById(int id)
    {
        return _cargoDetailDal.GetById(id);
    }
}