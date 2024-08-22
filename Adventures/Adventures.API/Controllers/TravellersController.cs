using Adventures.Domain.Models;
using Adventures.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adventures.API.Controllers
{
    [Route("api/[controller]")]
    public class TravellersController : Controller
    {
        private readonly IUnitOfWork _uow;
        public TravellersController(IUnitOfWork uow)
        {
            _uow = uow;
        }


        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<Traveller>> GetTravellersAsync()
        {
            var travellers = await _uow.TravellerRepository.ReadAllAsync();
            return travellers;
        }
    }
}