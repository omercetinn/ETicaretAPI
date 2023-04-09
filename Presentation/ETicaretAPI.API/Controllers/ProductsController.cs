using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IProductReadRepository _productReadRepository;

        private readonly IProductWriteRepository _productWriteRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;

        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;


        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IProductService productService, IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productService = productService;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }

        //[HttpGet]
        //public async Task Get1()
        //{
        //    //await _productWriteRepository.AddRangeAsync(new()
        //    //{
        //    //    new() {Id = Guid.NewGuid(),Name="Pro1",Price=500,CreatedDate=DateTime.UtcNow,Stock=5},
        //    //    new() {Id = Guid.NewGuid(),Name="Pro2",Price=400,CreatedDate=DateTime.UtcNow,Stock=8},
        //    //    new() {Id = Guid.NewGuid(),Name="Pro3",Price=300,CreatedDate=DateTime.UtcNow,Stock=9},
        //    //});

        //    //var count = await _productWriteRepository.SaveAsync();
        //    Product product = await _productReadRepository.GetByIdAsync("7a1cd13b-efc2-4d61-a0ea-1275230732d8",false);
        //    product.Name = "Mehmet";
        //    await _productWriteRepository.SaveAsync();          
        //}

        //[HttpPost]
        //public async Task Get2()
        //{
        //    var customerId=Guid.NewGuid();
        //    await _customerWriteRepository.AddAsync(new Customer { Id = customerId, Name = "Muhittin" });

        //    await _orderWriteRepository.AddRangeAsync(new()
        //    {
        //        new() {Description="bla bla",Address="Ankara,Çankaya",CustomerId=customerId},
        //        new() {Description="bla bla",Address="Ankara,Pursaklar",CustomerId = customerId}
        //    });

        //   await _orderWriteRepository.SaveAsync();
        //}
        [HttpPost]
        public async Task Get3()
        {
            Order order = await _orderReadRepository.GetByIdAsync("14c90c26-5f3b-442d-8c8e-7f2812bd355f");
            order.Address = "Istanbul";
            await _orderWriteRepository.SaveAsync();
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Product product= await _productReadRepository.GetByIdAsync(id);
        //    return Ok(product);

        //}
    }
}
