using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using TextCollab.Models;

namespace TextCollab.Controllers {

    [Route("text")]
    public class TextController : Controller {

        //
        // GET: /text/{textID}
        [HttpGet("{textID}")]
        public IActionResult Text(int textID){
            string text = "It was the best of times it was the worst of times.";
            Text vm = new Text(textID, text);

            return View(vm);
        }
    }
}