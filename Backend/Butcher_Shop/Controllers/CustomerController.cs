using AutoMapper;
using Butcher_Shop.Data;
using Butcher_Shop.Dtos;
using Butcher_Shop.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("butcherstore/:id")]
        public async Task<IActionResult> GetCustomersForButcherStore(int Id)
        {
            var ButcherStore = await _unitOfWork.IButcherStoreRepo.GetButcherStore(Id);

            if (ButcherStore != null)
            {
                return Ok(_mapper.Map<List<CustomerDto>>(ButcherStore.Customers)); 
            }

            return NotFound(new { Message = $"Butcher Store with Id:{Id} not found." });
        }

        [HttpGet(":id")]
        public async Task<IActionResult> GetCustomer(int Id)
        {
            var Customer = await _unitOfWork.ICustomerRepo.GetCustomer(Id);

            if (Customer != null)
            {
                return Ok(_mapper.Map<CustomerDto>(Customer));
            }

            return NotFound(new { Message = $"Customer with Id:{Id} not found." });
        }

        [HttpPost(":butcherStore/:articleId")]
        public async Task<IActionResult> GetCustomerForButcherStore(int butcherStoreId, int articleId, [FromBody]AddCustomerDto Customer)
        {
            if(ModelState.IsValid)
            {
                var ButcherStore = await _unitOfWork.IButcherStoreRepo.GetButcherStore(butcherStoreId);

                if (ButcherStore == null)
                {
                    return NotFound(new { Message = $"Butcher Store with Id:{butcherStoreId} not found." });
                }

                var Article = await _unitOfWork.IArticleRepo.GetArticle(articleId);

                if (Article == null)
                {
                    return NotFound(new { Message = $"Article with Id:{articleId} not found." });
                }

                if(Article.CustomerId != null)
                {
                    return BadRequest(new { Message = "Article already bought!" });
                }

                var FoundCustomer = await _unitOfWork.ICustomerRepo.GetCustomerByInfo(Customer.Name, Customer.Lastname, Customer.Address);

                if(FoundCustomer == null)
                {
                    var AddedCustomer = _mapper.Map<Butcher_Shop.Models.Customer>(Customer);
                    await _unitOfWork.ICustomerRepo.AddCustomer(AddedCustomer);
                    await _unitOfWork.Complete();

                    ButcherStore.Customers.Add(AddedCustomer);
                    AddedCustomer.BoughtArticles.Add(Article);
                    Article.CustomerId = AddedCustomer.Id;

                    await _unitOfWork.Complete();
                    return Ok(_mapper.Map<CustomerDto>(AddedCustomer));
                }

                FoundCustomer.BoughtArticles.Add(Article);
                Article.CustomerId = FoundCustomer.Id;
                await _unitOfWork.Complete();
                return Ok(Customer);
            }

            return BadRequest(new { Message = "Invalid info!" });
        }

        [HttpPut(":id")]
        public async Task<IActionResult> Put(int Id, [FromBody] AddCustomerDto Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid info!" });
            }

            var OldCustomer = await _unitOfWork.ICustomerRepo.GetCustomer(Id);

            if (OldCustomer == null)
            {
                return NotFound(new { Message = $"Customer with Id:{Id} not found." });
            }

            _mapper.Map<AddCustomerDto, Customer>(Customer, OldCustomer);

            await _unitOfWork.Complete();

            return Ok(_mapper.Map<CustomerDto>(OldCustomer));
        }

        [HttpDelete(":id")]
        public async Task<IActionResult> DeleteCustomer(int Id)
        {
            var Customer = await _unitOfWork.ICustomerRepo.GetCustomer(Id);

            if (Customer != null)
            {
                _unitOfWork.ICustomerRepo.DeleteCustomer(Customer);
                await _unitOfWork.Complete();

                return Ok(Customer);
            }

            return NotFound(new { Message = $"Customer with Id:{Id} not found." });
        }
    }
}
