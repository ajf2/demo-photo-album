using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DemoPhotoAlbum.Models {
  public class PhotoAlbum {
    public int UserId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<Photo> Photos { get; set; }

    public PhotoAlbum(Album album, IEnumerable<Photo> photos) {
      UserId = album.UserId;
      Id = album.Id;
      Title = album.Title;
      Photos = photos.Where(p => p.AlbumId == album.Id);
    }
  }
}
