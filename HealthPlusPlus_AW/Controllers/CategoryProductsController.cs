using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HealthPlusPlus_AW.Domain.Models;
using HealthPlusPlus_AW.Domain.Services;
using HealthPlusPlus_AW.Resources;
using Microsoft.AspNetCore.Mvc;

namespace HealthPlusPlus_AW.Controllers
{
    [Route("/api/v1/[controller]")]
    public class CategoryProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CategoryProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        
        [HttpGet("{id}")]
        public async Task<IEnumerable<ProductResource>> GetAllAsync(int id)
        {
            var products = await _productService.ListByCategoryIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }
        
        // [HttpGet("{id}")]
        // public async Task<IActionResult> GetByIdAsync(int id)
        // {
        //     var result = await _patientService.FindIdAsync(id);
        //     if (!result.Success)
        //         return BadRequest(result.Message);
        //     var patientResource = _mapper.Map<Patient, PatientResource>(result.Resource);
        //     return Ok(patientResource);    
        // }
    }
}