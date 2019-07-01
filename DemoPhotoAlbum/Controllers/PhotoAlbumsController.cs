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
  public class PhotoAlbumsController : ControllerBase {

    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public PhotoAlbumsController(IPhotoAlbumRepository photoAlbumRepository) {
      this.photoAlbumRepository = photoAlbumRepository;
    }

    // GET: api/PhotoAlbums
    [HttpGet]
    public async Task<IEnumerable<PhotoAlbum>> GetAsync() {
      var albums = await photoAlbumRepository.GetPhotoAlbumsAsync();
      return albums;
    }

    // GET: api/PhotoAlbums/5
    [HttpGet("{id}", Name = "Get")]
    public async Task<IEnumerable<PhotoAlbum>> Get(int id) {
      var albums = await photoAlbumRepository.GetPhotoAlbumsAsync(id);
      return albums;
    }
  }
}
