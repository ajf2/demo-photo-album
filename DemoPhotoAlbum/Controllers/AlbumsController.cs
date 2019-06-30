using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoPhotoAlbum.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class AlbumsController : ControllerBase {
    // GET: api/Albums
    [HttpGet]
    public IEnumerable<string> Get() {
      return new string[] { "value1", "value2" };
    }

    // GET: api/Albums/5
    [HttpGet("{id}", Name = "Get")]
    public string Get(int id) {
      return "value";
    }
  }
}
