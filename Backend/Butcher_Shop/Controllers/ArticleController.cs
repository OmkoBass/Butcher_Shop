using AutoMapper;
using Butcher_Shop.Data;
using Butcher_Shop.Dtos;
using Butcher_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Butcher_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var AllArticles = await _unitOfWork.IArticleRepo.GetAllArticles();

            return Ok(AllArticles);
        }

        [HttpGet(":id")]
        public async Task<IActionResult> Get(int Id)
        {
            var Article = await _unitOfWork.IArticleRepo.GetArticle(Id);

            if (Article != null)
            {
                return Ok(Article);
            }

            return NotFound(new { Message = $"Article with Id:{Id} not found." });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ArticleDto Article)
        {
            if (ModelState.IsValid)
            {
                var AddedArticle = _mapper.Map<Article>(Article);

                await _unitOfWork.IArticleRepo.AddArticle(AddedArticle);
                await _unitOfWork.Complete();

                return Ok(AddedArticle);
            }

            return BadRequest(new { Message = "Invalid info!" });
        }

        [HttpPut(":id")]
        public async Task<IActionResult> Put(int Id, [FromBody] ArticleDto Article)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid info!" });
            }

            var OldArticle = await _unitOfWork.IArticleRepo.GetArticle(Id);

            if (OldArticle == null)
            {
                return NotFound(new { Message = $"Article with Id:{Id} not found." });
            }

            _mapper.Map<ArticleDto, Article>(Article, OldArticle);

            await _unitOfWork.Complete();

            return Ok(OldArticle);
        }

        [HttpDelete(":id")]
        public async Task<IActionResult> Delete(int Id)
        {
            var Article = await _unitOfWork.IArticleRepo.GetArticle(Id);

            if (Article != null)
            {
                _unitOfWork.IArticleRepo.DeleteArticle(Article);
                await _unitOfWork.Complete();

                return Ok(Article);
            }

            return NotFound(new { Message = $"Article with Id:{Id} not found." });
        }
    }
}
