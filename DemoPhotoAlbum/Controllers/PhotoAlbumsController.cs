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

    // GET: api/PhotoAlbums?userId=5
    [HttpGet]
    public async Task<IEnumerable<PhotoAlbum>> GetAsync(int? userId = null) {
      var albums = await photoAlbumRepository.GetPhotoAlbumsAsync(userId);
      return albums;
    }
  }
}
