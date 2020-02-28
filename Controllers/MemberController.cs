using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EF_task.Models;
namespace EF_task
{
      [ApiController]
    [Route("member")]
    public class MemberController : ControllerBase
    {
        public readonly ILogger<MemberController> _logger;
        public readonly MemberContext _context;

        public MemberController(ILogger<MemberController> logger, MemberContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateMember(Member member)
        {
            _context.members.Add(member);
            _context.SaveChanges();

            return Ok(member);
        }

        [HttpGet]
        public IActionResult GetMember()
        {
            var member = _context.members;
            return Ok(member);
        }

        [HttpGet("{id}")]
        public IActionResult GetMemberById(int id)
        {
            var member = _context.members.First(i => i.id == id);
            return Ok(member);
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateMember(int id)
        {
            var member = _context.members.First(i => i.id == id);
            member.full_name = "nugi";
            _context.SaveChanges();
            return Ok(member);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            var member = _context.members.First(i => i.id == id);
            _context.members.Remove(member);
            _context.SaveChanges();
            return Ok(member);
        }

    } 

}