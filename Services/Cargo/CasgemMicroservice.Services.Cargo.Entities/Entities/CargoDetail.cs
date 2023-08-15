namespace CasgemMicroservice.Services.Cargo.Entities.Entities;

public class CargoDetail
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int CargoStateId { get; set; }
    public virtual CargoState? CargoState { get; set; }

}