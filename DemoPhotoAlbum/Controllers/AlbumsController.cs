using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoPhotoAlbum.Models;
using DemoPhotoAlbum.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoPhotoAlbum.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class AlbumsController : ControllerBase {

    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public AlbumsController(IPhotoAlbumRepository photoAlbumRepository) {
      this.photoAlbumRepository = photoAlbumRepository;
    }

    // GET: api/Albums
    [HttpGet]
    public async Task<IEnumerable<Album>> GetAsync() {
      var albums = await photoAlbumRepository.GetPhotoAlbumsAsync();
      return albums;
    }

    // GET: api/Albums/5
    [HttpGet("{id}", Name = "Get")]
    public async Task<IEnumerable<Album>> Get(int id) {
      var albums = await photoAlbumRepository.GetPhotoAlbumsAsync(id);
      return albums;
    }
  }
}
