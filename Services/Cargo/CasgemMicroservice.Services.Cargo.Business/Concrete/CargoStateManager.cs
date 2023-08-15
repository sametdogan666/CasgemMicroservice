using CasgemMicroservice.Services.Cargo.Business.Abstract;
using CasgemMicroservice.Services.Cargo.DataAccess.Abstract;
using CasgemMicroservice.Services.Cargo.Entities.Entities;

namespace CasgemMicroservice.Services.Cargo.Business.Concrete;

public class CargoStateManager : ICargoStateService
{
    private readonly ICargoStateDal _cargoStateDal;

    public CargoStateManager(ICargoStateDal cargoStateDal)
    {
        _cargoStateDal = cargoStateDal;
    }


    public void Insert(CargoState entity)
    {
        _cargoStateDal.Insert(entity);
    }

    public void Update(CargoState entity)
    {
        _cargoStateDal.Update(entity);
    }

    public void Delete(CargoState entity)
    {
        _cargoStateDal.Delete(entity);
    }

    public List<CargoState> GetAll()
    {
        return _cargoStateDal.GetAll();
    }

    public CargoState? GetById(int id)
    {
        return _cargoStateDal.GetById(id);
    }
}