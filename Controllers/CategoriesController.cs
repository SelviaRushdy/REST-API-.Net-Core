using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using REST_API_.Net_Core.Models;
using REST_API_.Net_Core.Services;

namespace REST_API_.Net_Core.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoriesController: ControllerBase
    {
        private ICategoriesRepository categoriesRepository;
        private readonly IMapper mapper;

        public CategoriesController(ICategoriesRepository categoriesRepository,
            IMapper mapper)
        {
            this.categoriesRepository = categoriesRepository;
            this.mapper = mapper;
        }

        [HttpGet()]
        public ResponseModel<List<CategoriesDto>> GetAllCategories()
        {
            var ResponseModel = new ResponseModel<List<CategoriesDto>>();
            try
            {
                var result = categoriesRepository.GetAllCategories();
                ResponseModel.Success = true;
                ResponseModel.Result = mapper.Map<List<CategoriesDto>>(result);
                ResponseModel.Message = "Success";

                return ResponseModel;
            }
            catch (Exception ex)
            {
                ResponseModel.Success = false;
                ResponseModel.Message = ex.Message;
                return ResponseModel;
            }
        }
    }
}
