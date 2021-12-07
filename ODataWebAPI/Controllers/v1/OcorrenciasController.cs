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
    public class OcorrenciasController : ODataController
    {
        private DbPrfContext _dbContext;

        public OcorrenciasController(DbPrfContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [EnableQuery(PageSize = 5000, AllowedFunctions = AllowedFunctions.AllFunctions & AllowedFunctions.Any)]
        public IQueryable<Ocorrencia> Get()
        {
            return _dbContext.Ocorrencias;
        }

        [HttpGet]
        [EnableQuery(PageSize = 5000, AllowedFunctions = AllowedFunctions.AllFunctions & AllowedFunctions.Any)]
        public SingleResult<Ocorrencia> Get(int key)
        {
            IQueryable<Ocorrencia> result = _dbContext.Ocorrencias.Where(p => p.Id == key);

            return SingleResult.Create(result);
        }

        [HttpGet]
        [EnableQuery(PageSize = 5000, AllowedFunctions = AllowedFunctions.AllFunctions & AllowedFunctions.Any)]
        public IActionResult GetProperty(int key, string propertyName)
        {
            Ocorrencia ocorrencia  = _dbContext.Ocorrencias.FirstOrDefault(c => c.Id == key);
            if (ocorrencia == null)
            {
                return NotFound();
            }

            PropertyInfo info = typeof(Ocorrencia).GetProperty(propertyName);

            object value = info.GetValue(ocorrencia);

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ocorrencia ocorrencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.Ocorrencias.Add(ocorrencia);
            await _dbContext.SaveChangesAsync();
            return Created(ocorrencia);
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(int key, Delta<Ocorrencia> ocorrencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await _dbContext.Ocorrencias.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            ocorrencia.Patch(entity);
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                if (!_dbContext.Ocorrencias.Contains(entity))
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
        public async Task<IActionResult> Put(int key, Ocorrencia update)
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
                if (!_dbContext.Ocorrencias.Contains(update))
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
            var product = await _dbContext.Ocorrencias.FindAsync(key);
            if (product == null)
            {
                return NotFound();
            }
            _dbContext.Ocorrencias.Remove(product);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
