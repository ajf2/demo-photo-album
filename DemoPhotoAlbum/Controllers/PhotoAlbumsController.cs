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

    /// <summary>
    /// Data source for photo albums. Assigned by dependency injection in the constructor.
    /// </summary>
    private readonly IPhotoAlbumRepository photoAlbumRepository;

    public PhotoAlbumsController(IPhotoAlbumRepository photoAlbumRepository) {
      this.photoAlbumRepository = photoAlbumRepository;
    }

    /// <summary>
    /// Asynchronously fetches a collection of <see cref="PhotoAlbum"/>s.
    /// </summary>
    /// <param name="userId">A user ID to filter by.</param>
    /// <returns>A collection of <see cref="PhotoAlbum"/>s.</returns>
    // GET: api/PhotoAlbums?userId=5
    [HttpGet]
    public async Task<IEnumerable<PhotoAlbum>> GetAsync(int userId) {
      var albums = await photoAlbumRepository.GetPhotoAlbumsAsync(userId);
      return albums;
    }
  }
}
