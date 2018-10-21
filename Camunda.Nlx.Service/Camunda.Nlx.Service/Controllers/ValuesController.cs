using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.NodeServices;

namespace camunda.nlx.service.Controllers
{
    public class DmnInputParameters {
        public string Name {get;set;}
        public string Value {get;set;}
    }

    public class DmnExecutionPayload {
        public string Uri {get;set;}
        public List<DmnInputParameters> Parameters {get;set;}

        public string Input{get;set;}

        // public DmnExecutionPayload(){
        //     Parameters = new List<DmnInputParameters>();
        // }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class DmnController : ControllerBase
    {
        // /// <summary>
        // /// Get values
        // /// </summary>
        // /// <returns>Values</returns>
        // [HttpGet]
        // [Description("Who Am I")]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // GET api/values/5
        [HttpGet("{id}")]
        [Description("Get value by providing an Id")]
        public async Task<string> Get(int id,[FromServices] INodeServices nodeServices)
        {
            return await nodeServices.InvokeAsync<string>("main.js");
            
        }

        // POST api/values
        [HttpPost]
        [Description("Execute a Decision Model")]
        public async Task<string> Post([FromBody] DmnExecutionPayload payload,  [FromServices] INodeServices nodeServices)
        {
            using(WebClient client = new WebClient()) {
                string dmnModel = client.DownloadString(payload.Uri);
                return await nodeServices.InvokeAsync<string>("decision.js",dmnModel,payload.Input);
            }
        }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // [Description("Update a value by providing its Id")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        
        // [Description("Delete a value by providing its Id")]
        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
