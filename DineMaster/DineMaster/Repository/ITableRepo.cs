using DineMaster.DTO;
using DineMaster.Models;

namespace DineMaster.Repository
{
    public interface ITableRepo
    {
        Task<TableDTO> Addtable(TableDTO dto);
        Task<IEnumerable<Table>> GetAllTables();
        Task<Table> FindById(int id);
        Task<bool> DeleteTable(int id);
        Task<bool> EditTable(TableDTO dto);

    }
}
