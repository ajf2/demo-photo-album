using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DemoPhotoAlbum.Models {
  /// <summary>
  /// Represents an album of photos.
  /// </summary>
  public class PhotoAlbum {
    /// <summary>
    /// The ID of the user this album belongs to.
    /// </summary>
    public int UserId { get; set; }
    /// <summary>
    /// The ID of this album.
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// The title of this album.
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// The photos contained in this album.
    /// </summary>
    public IEnumerable<Photo> Photos { get; set; }

    /// <summary>
    /// Creates a new instance of the class, assigning only the valid photos based on their album IDs.
    /// </summary>
    /// <param name="album">The Web API model representing the album.</param>
    /// <param name="photos">A collection of Web API models representing photos.</param>
    // TODO: AutoMapper may help loosely couple this class from the Web API's models.
    public PhotoAlbum(Album album, IEnumerable<Photo> photos) {
      UserId = album.UserId;
      Id = album.Id;
      Title = album.Title;
      Photos = photos.Where(p => p.AlbumId == album.Id);
    }
  }
}
