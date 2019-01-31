using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UserList.Api.Controllers
{
    public class BaseController : Controller
    {
        public async Task<IActionResult> ResponsePoint(object result, IEnumerable<string> exceptions)
        {
            if (!exceptions.Any())
            {
                try
                {
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch (Exception ex)
                {
                    //Logar o erro
                    return BadRequest(new
                    {
                        success = false,
                        errors = exceptions
                    });
                }
            }

            return BadRequest(new
            {
                success = false,
                errors = exceptions
            });
        }
    }
}