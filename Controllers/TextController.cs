using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using TextCollab.Models;
using TextCollab.ViewModels;

namespace TextCollab.Controllers {

    [Route("text")]
    public class TextController : Controller {

        private readonly TextContext _dbContext;

        public TextController(TextContext dbContext) {
            _dbContext = dbContext;
        }
        //
        // GET: /text/{textID}
        [HttpGet("{textID}")]
        public IActionResult Text(int textID){

            Text text = _dbContext.Text
                .FirstOrDefault(t => t.id == textID);

            TextViewModel vm = new TextViewModel();
            vm.text = text?.textBody;

            return View(vm);
        }
    }
}