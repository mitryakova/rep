﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2
{[Route("api/[controller]")]
   [ApiController]
   public class Lab1Controller : ControllerBase
   {
       private static List<Lab1Data> _memCache = new List<Lab1Data>();

       [HttpGet]
       public ActionResult<IEnumerable<Lab1Data>> Get()
       {
           return Ok(_memCache);
       }

       [HttpGet("{id}")]
       public ActionResult<Lab1Data> Get(int id)
       {
           if (_memCache.Count <= id) return NotFound("No such");

           return Ok(_memCache[id]);
       }

       [HttpPost]
       public IActionResult Post([FromBody] Lab1Data value)
       {
           var validationResult = value.Validate();

           if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

           _memCache.Add(value);

           return Ok($"{value.ToString()} has been added");
       }

       [HttpPut("{id}")]
       public IActionResult Put(int id, [FromBody] Lab1Data value)
       {
           if (_memCache.Count <= id) return NotFound("No such");

           var validationResult = value.Validate();

           if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

           var previousValue = _memCache[id];
           _memCache[id] = value;

           return Ok($"{previousValue.ToString()} has been updated to {value.ToString()}");
       }

       [HttpDelete("{id}")]
       public IActionResult Delete(int id)
       {
           if (_memCache.Count <= id) return NotFound("No such");

           var valueToRemove = _memCache[id];
           _memCache.RemoveAt(id);

           return Ok($"{valueToRemove.ToString()} has been removed");
       }
   }

}