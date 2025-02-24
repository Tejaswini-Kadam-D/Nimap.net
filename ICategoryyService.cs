namespace NimapProjectUsingADO.net.Models
{
    public interface ICategoryyService
    {
        IEnumerable<Categoryy> GetCategory();
        Categoryy GetCategoryyById(int id);
        int AddCategory(Categoryy cat);
        int UpdtateCategory(Categoryy c);
        int DeleteCategory(int id);
    }
}
