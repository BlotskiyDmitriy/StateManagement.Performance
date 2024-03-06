namespace StateManagement.Performance.Models.Services;

public interface ILoadDataService
{
    public IEnumerable<BodyModel> LoadData();
}