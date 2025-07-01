using AutoMapper;
using DineMaster.DTO;
using DineMaster.Models;

namespace DineMaster.Mapper
{
    public class MappingData :Profile
    {
        public MappingData()
        {
            CreateMap<MenuCategoryCreateDTO, MenuCategory>();
            CreateMap<MenuCategoryUpdateDTO, MenuCategory>();
            CreateMap<MenuCategory, MenuCategoryReadDTO>();

            //-----------------------------------------------------------------------------------------

            CreateMap<MenuItemCreateDTO, MenuItem>();
            CreateMap<MenuItemUpdateDTO, MenuItem>();
            CreateMap<MenuItem, MenuItemReadDTO>();
            //CreateMap<MenuItem, MenuItemReadDTO>()
            //    .ForMember(x => x.CategoryId,
            //    opt => opt.MapFrom
            //    (y => y.Category.CategoryName));


        }
    }
}

