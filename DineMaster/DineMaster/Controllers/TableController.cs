using DineMaster.DTO;
using DineMaster.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace DineMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        ITableRepo _repo;
        public TableController(ITableRepo repo)
        {
            this._repo = repo;
        }

        [HttpPost]
        [Route("Addtable")]
        public async Task<IActionResult> AddTable([FromBody]TableDTO dto)
        {
            dto.CreatedBy = "Admin";
            await _repo.Addtable(dto);
            return Ok("Added Success");
        }

        [HttpGet]
        [Route("GetAllTable")]
        public async Task<IActionResult> GetTable()
        {
            var getall = await _repo.GetAllTables();
            return Ok(getall);
            
        }

        [HttpGet]
        [Route("GetTableById/{id}")]
        public async Task<IActionResult> GetTableById(int id)
        {
            var tablebyid = await _repo.FindById(id);
            return Ok(tablebyid);
        }

        [HttpDelete]
        [Route("DeleteTable/{id}")]
        public async Task<IActionResult> DeleteTable(int id)
        {
            var deleted = await _repo.DeleteTable(id);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok("Deleted Successful");
        }



        //[HttpDelete("DeleteTable/{id}")]
        //public async Task<IActionResult> DeleteTable(int id)
        //{
        //    bool deleted = await _repo.DeleteTable(id);

        //    if (!deleted)
        //        return BadRequest("Cannot delete table. Future reservations exist or table not found.");

        //    return Ok("Table deleted successfully.");
        //}



        [HttpPut]
        [Route("EditTable")]
        public async Task<IActionResult> EditTable([FromBody] TableDTO dto)
        {
            var updated =  await _repo.EditTable(dto);
            if (!updated)
            {
                return NotFound("Table Not Found");
            }
            return Ok("Updated Successful");
        }
    }
}
