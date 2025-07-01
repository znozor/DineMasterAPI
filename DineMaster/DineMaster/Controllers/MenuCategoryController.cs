using AutoMapper;
using DineMaster.Data;
using DineMaster.DTO;
using DineMaster.Mapper;
using DineMaster.Models;
using DineMaster.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuCategoryController : ControllerBase
    {
        private readonly IMenuCategoryRepo Repo;
        private readonly IMapper mapper;
        public MenuCategoryController(IMenuCategoryRepo Repo, IMapper mapper)
        {
            this.Repo = Repo;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll MenuCategory")]
        public IActionResult GetAll()
        {
            var categories = Repo.GetAll();
            var result = mapper.Map<IEnumerable<MenuCategoryReadDTO>>(categories);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetMenuById MenuCategory/{id}")]
        public IActionResult GetById(int id)
        {
            var category = Repo.GetById(id);
            if (category == null)
            {
                return NotFound();
            }
            var result = mapper.Map<MenuCategoryReadDTO>(category);
            return Ok(result);
        }

        [HttpPost]
        [Route("Add MenuCategory")]

        public IActionResult Add(MenuCategoryCreateDTO dto)
        {
            var item = mapper.Map<MenuCategory>(dto);
            Repo.Add(item); 
            return Ok("Add SuccessFully");
        }

        [HttpPut]
        [Route("Update MenuCategory/{id}")]
        public IActionResult Update(int id, DineMaster.DTO.MenuCategoryUpdateDTO dto)
        {
            var data = Repo.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            var item = mapper.Map<MenuCategory>(dto);
            item.CategoryId = id; 
            Repo.Update(data);
            return Ok("Update SuccessFully");
        }

        [HttpDelete]
        [Route("Delete MenuCategory/{id}")]
        public IActionResult Delete(int id)
        {
            var data = Repo.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            Repo.Delete(id);
            return Ok("Delete SuccessFully");
        }

        
    }
    
}
