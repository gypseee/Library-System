using Library_System.Data;
using Library_System.Models.DomainModels;
using Library_System.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LendController : ControllerBase
    {
        private readonly LmDbContext dbContext;

        public LendController(LmDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lendRecords = dbContext.LendRecords.ToList();
            return Ok(lendRecords);
        }

        [HttpPost]
        public IActionResult EnterRecord([FromBody] AddLendRecordDto lendDto) {
            var lendDomainModel = new LendRecords
            {
                Book = lendDto.Book,
                Profile = lendDto.Profile,
                CheckOutDate = DateTime.Now,
                //CheckInDate = lendDto.CheckInDate,
                DueDate = DateTime.Now,
            };
            dbContext.LendRecords.Add(lendDomainModel);
            return Ok();
        }


        [HttpPost]
        [Route("/Return")]
        public IActionResult ReturnBook([FromBody] string id)
        {
            return Ok();
        }
    }
}
