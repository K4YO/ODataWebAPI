using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataWebAPI.Infrastructure;
using ODataWebAPI.Models;

namespace ODataWebAPI.Controllers.v1
{
    [ODataModel("v1")]
    [ODataRouting]
    public class PessoasController : ODataController
    {
        private DbPrfContext _dbContext;

        public PessoasController(DbPrfContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [EnableQuery(PageSize = 5000, 
            AllowedFunctions = AllowedFunctions.AllFunctions, 
            AllowedQueryOptions = AllowedQueryOptions.All, 
            AllowedLogicalOperators = AllowedLogicalOperators.All,
            AllowedArithmeticOperators = AllowedArithmeticOperators.All)]
        public IQueryable<Pessoa> Get()
        {
            return _dbContext.Pessoas;
        }

        [HttpGet]
        [EnableQuery(PageSize = 5000,
            AllowedFunctions = AllowedFunctions.AllFunctions,
            AllowedQueryOptions = AllowedQueryOptions.All,
            AllowedLogicalOperators = AllowedLogicalOperators.All,
            AllowedArithmeticOperators = AllowedArithmeticOperators.All)]
        public SingleResult<Pessoa> Get(int key)
        {
            IQueryable<Pessoa> result = _dbContext.Pessoas.Where(p => p.Id == key);

            return SingleResult.Create(result);
        }

        [HttpGet]
        [EnableQuery(PageSize = 5000, AllowedFunctions = AllowedFunctions.AllFunctions & AllowedFunctions.Any)]
        public IActionResult GetProperty(int key, string propertyName)
        {
            Pessoa pessoa = _dbContext.Pessoas.FirstOrDefault(c => c.Id == key);
            if (pessoa == null)
            {
                return NotFound();
            }

            PropertyInfo info = typeof(Pessoa).GetProperty(propertyName);

            object value = info.GetValue(pessoa);

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Pessoa pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.Pessoas.Add(pessoa);
            await _dbContext.SaveChangesAsync();
            return Created(pessoa);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int key, Delta<Pessoa> pessoa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await _dbContext.Pessoas.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            pessoa.Patch(entity);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Pessoas.Contains(entity))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, Pessoa update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(update).State = EntityState.Modified;
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_dbContext.Pessoas.Contains(update))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int key)
        {
            var product = await _dbContext.Pessoas.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            _dbContext.Pessoas.Remove(product);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
