
namespace StateManagement.Performance.Models.Services;
public class LoadDataService : ILoadDataService
{
    public IEnumerable<BodyModel> LoadData()
    {
        var dataList = new List<BodyModel>();

        for (int i = 0; i < 10000; i++)
        {
            dataList.Add(new BodyModel
            {
                Id = i + 1,
                Company = $"Test company {i}",
                Contact = $"test{i}@mail.tt",
                Country = $"Country: {i}",
                Number = $"+3333{i}",
            });
        }

        return dataList;
    }
}
