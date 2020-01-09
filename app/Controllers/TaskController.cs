using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        public class AddRequest
        {
            public StringNode X { get; set; }
            public StringNode Y { get; set; }
        }

        [Route("Add")]
        public Node<char> Add([FromBody] AddRequest request) => Model.Add(request.X.ToGeneric(), request.Y.ToGeneric());

        [Route("Sum")]
        public int Sum([FromBody]int[] values) => Model.Sum(values);
        [Route("IsPolindrom")]
        public bool IsPolindrom(string value) => Model.IsPolindrom(value);
    }
}
