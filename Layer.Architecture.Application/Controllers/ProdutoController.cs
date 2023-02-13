using Autoglass.Architecture.Application.Models;
using Autoglass.Architecture.Domain.Entities;
using Autoglass.Architecture.Domain.Interfaces;
using Autoglass.Architecture.Service.Validators;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Autoglass.Architecture.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IBaseService<Produto> _baseProdutoService;

        public ProdutoController(IBaseService<Produto> baseProdutoService)
        {
            _baseProdutoService = baseProdutoService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto product)
        {
            if (product == null)
                return NotFound();

            return Execute(() => _baseProdutoService.Add(product));
        }

        [HttpPut]
        public IActionResult Update([FromBody] Produto product)
        {
            if (product == null)
                return NotFound();

            return Execute(() => _baseProdutoService.Update(product));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseProdutoService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseProdutoService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseProdutoService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
