using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using webAPIinterviewPractice.Model.Domain;
using webAPIinterviewPractice.Model.DTO;
using webAPIinterviewPractice.Repository.IRepository;

namespace webAPIinterviewPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IRepository _repository;
        public readonly IMapper _mapper;

        public ProductController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        
        [HttpGet]

        public async Task<IActionResult> GetProductAsync()
        {
            var productData = await _repository.GetAllAsync();
            var productDto = _mapper.Map<List<ProductDTOclass>>(productData);
            return Ok(productDto);
        }

        [HttpGet]
        [Route("{id}")]
        [ActionName("GetByIdAsync")]

        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            var productData = await _repository.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDTOclass>(productData);
            return Ok(productDto);
        }


        [HttpPost]
        public async Task<IActionResult>AddProductAsync(AddProductDTO dtoObj)
        {
            var productObj = new Product()
            {
                Name = dtoObj.Name,
                Price = dtoObj.Price,
            };
            productObj = await _repository.AddProductAsync(productObj);
            var productDTO = _mapper.Map<ProductDTOclass>(productObj);
            return Ok(productDTO);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> ProductUpdateAsync(AddProductDTO dtoObj, int id)
        {
            var product = new Product()
            {
                Name = dtoObj.Name,
                Price = dtoObj.Price
            };
            var b= await _repository.UpdateProductAsync(id, product);
            var productDTO = _mapper.Map<ProductDTOclass>(b);
            return Ok(productDTO);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult>ProductDeleteAsync(int id)
        {
            var product = await _repository.DeleteProductAsync(id);
            if(product == null) return NotFound();
            var productDTO = _mapper.Map<ProductDTOclass>(product); 
            return Ok(productDTO);
        }





        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
