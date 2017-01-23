using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCoreApp.Model;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreApp.Controllers
{
    [Route("api/[controller]")]
    public class OsobyController : Controller
    {
        private readonly OsobyContext _context;

        public OsobyController(OsobyContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public JsonResult Get()
        {            
            return Json(_context.Osoba.ToList());
        }        

        [HttpPost]
        public ActionResult Post([FromBody]Osoba osoba)
        {
            try
            {                
                _context.Add(osoba);
                _context.SaveChanges();
                var nowaOsoba = _context.Osoba.Last();

                return Json(nowaOsoba);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public StatusCodeResult Delete([FromBody]Osoba osoba)
        {
            try
            {
                var doUsuniecia = _context.Osoba.Find(osoba.Id);
                _context.Osoba.Remove(doUsuniecia);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public StatusCodeResult Put([FromBody]Osoba osoba)
        {
            try
            {
                var doEdycji = _context.Osoba.Find(osoba.Id);
                doEdycji.Imie = osoba.Imie;
                doEdycji.Nazwisko = osoba.Nazwisko;
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
