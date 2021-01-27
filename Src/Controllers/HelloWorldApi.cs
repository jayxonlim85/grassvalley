// <copyright file="HelloWorldApi.cs" company="Grass Valley">
// Copyright (c) Grass Valley. All rights reserved.
// </copyright>

#pragma warning disable SA1005,SA1201,SA1507,SA1512,SA1611,SA1614,SA1629,SA1633,SA1636,SA1641,CS1573 //suppress static code analysis

namespace GV.SCS.Store.HelloWorld.Controllers
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using GV.Platform.Logging;
    using GV.Platform.MultiTenancy;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Swashbuckle.AspNetCore.Annotations;

    /// debug: http://localhost:5000/swagger/index.html
    /// debug: http://localhost:5000/api/v1/store/helloworld/swagger/index.html
    /// <summary>
    /// blablabla.
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = false)]
    [Description("Controller for HelloWorld API.")]
    public class HelloWorldApi : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelloWorldApi"/> class.
        /// </summary>
        /// <param name="tenantContext">Tenant.</param>
        public HelloWorldApi(ILogging logger, ITenantContext tenantContext)
        {
            TenantContext = tenantContext;
        }

        private ILogging Logger { get; } 

        private ITenantContext TenantContext { get; }

        /// <summary>
        /// Choice description.
        /// </summary>
        /// <param name="id">Id of the channel.</param>
        /// <response code="200">Return.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="403">Forbidden.</response>
        /// <response code="404">Not found.</response>
        /// <response code="500">Bad gateway.</response>
        /// <returns>Task.</returns>
        [HttpGet]
        [Route("/Choices/{id}")]
        [SwaggerOperation("Choices")]
        [SwaggerResponse(statusCode: 200, type: typeof(string), description: "Return requested channel information.")]
        [SwaggerResponse(statusCode: 404, type: typeof(string), description: "Requested id not found.")]
        [Authorize(Policy = "platform.readonly")]
        [Authorize(Policy = "platform")]
        public virtual async Task<IActionResult> Choices([FromRoute(Name = "id")][Required]string id)
        {
            await Task.Run(() =>  
            {
                var ret = ReadData();
                
            });
            return StatusCode(StatusCodes.Status200OK, "Success");
            //return StatusCode(StatusCodes.Status404NotFound, "Error detected");
        }
        
        private List<int> ReadData()
        {
            //long process
            var list = new List<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            return list;
        }
    }
}