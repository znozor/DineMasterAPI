using AutoMapper;
using DineMaster.DTO;
using DineMaster.Models;
using DineMaster.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMenuItemRepo Repo;
        private readonly IMapper mapper;
        public MenuItemController(IMenuItemRepo Repo, IMapper mapper)
        {
            this.Repo = Repo;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = Repo.GetAll();
            //if (data != null)
            //{
                var item = mapper.Map<IEnumerable<MenuItemReadDTO>>(data);
                return Ok(item);
            //}
            //return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = Repo.Get(id);
            if (item != null)
            {
                var data = mapper.Map<MenuItemReadDTO>(item);
                return Ok(data);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Add(MenuItemCreateDTO dto)
        {
            var data = mapper.Map<MenuItem>(dto);
            Repo.Add(data);
            return Ok("ADD SuccessFully");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, MenuItemUpdateDTO dto)
        {
            var item = Repo.Get(id);
            if (item != null)
            {
                var data = mapper.Map(dto, item);
                Repo.Update(data);
                return Ok("Update Successfully");
            }
            return NotFound();
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var data = Repo.Get(id);
            if(data == null)
            {
                return NotFound();
            }
            Repo.Delete(id);    
            return Ok("Delete SuccessFully");
        }
    }
}

