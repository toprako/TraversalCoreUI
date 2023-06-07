using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TraversalApi.DAL.Context;
using TraversalApi.DAL.Entities;

namespace TraversalApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var visitors = context.Visitors.ToList();
                return Ok(visitors);
            }
        }

        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet]
        public IActionResult VisitorGet(int Id)
        {
            using (var context = new VisitorContext())
            {
                var visitor = context.Visitors.Find(Id);
                if (visitor is null)
                {
                    return NotFound();
                }
                return Ok(visitor);
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult VisitorDelete(int Id)
        {
            using (var context = new VisitorContext())
            {
                var visitor = context.Visitors.Find(Id);
                if (visitor is null)
                {
                    return NotFound();
                }
                context.Remove(visitor);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                var visitorData = context.Find<Visitor>(visitor.VisitorID);
                if (visitorData is null)
                {
                    return NotFound();
                }
                visitorData.City = visitor.City;
                visitorData.Country = visitor.Country;  
                visitorData.Name = visitor.Name;
                visitorData.Surname = visitor.Surname;  
                visitorData.Mail = visitor.Mail;    
                context.Update(visitorData);
                context.SaveChanges();
                return Ok();
            }
        }

    }
}
