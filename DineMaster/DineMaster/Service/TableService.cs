using DineMaster.Data;
using DineMaster.DTO;
using DineMaster.Models;
using DineMaster.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace DineMaster.Service
{
    public class TableService: ITableRepo
    {
        DineMasterDbContext _db;

        public TableService( DineMasterDbContext db )
        {
            this._db = db;
        }

        public async Task<TableDTO> Addtable(TableDTO dto )
        {
            var tb = new Table()
            {
                TableName = dto.TableName,
                Capacity = dto.Capacity,
                CreatedAt = DateTime.Now,
                CreatedBy = "Admin"
            };

            _db.Tables.Add(tb);
            await _db.SaveChangesAsync();

            dto.TableId = tb.TableId;

            return dto;
                
            
        }

        public async Task<IEnumerable<Table>> GetAllTables()
        {
            return await _db.Tables.ToListAsync();
            
        }

        public async Task<Table> FindById(int id)
        {
            
             var data = await _db.Tables.FirstOrDefaultAsync(x => x.TableId == id);
            return data ?? throw new Exception("Table Not Found");

            
        }

        public async Task<bool> DeleteTable(int id)
        {
            var del = await _db.Tables.FindAsync(id);
            if(del==null)
            {
                return false;
            }

             _db.Tables.Remove(del);
            await _db.SaveChangesAsync();
            return true;

        }

        public async Task<bool> EditTable(TableDTO dto)
        {
            var edit = await _db.Tables.FindAsync(dto.TableId);
            if (edit == null)
            {
                return false;
            }
            edit.TableName = dto.TableName;
            edit.Capacity = dto.Capacity;
            edit.Status = dto.Status;
            edit.ModifiedAt = DateTime.Now;
            edit.ModifiedBy = "Admin2";

            await _db.SaveChangesAsync();
            return true;
        }



    }
}
