namespace CasgemMicroservice.Services.Cargo.Entities.Entities;

public class CargoState
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public List<CargoDetail>? CargoDetails { get; set; }

}