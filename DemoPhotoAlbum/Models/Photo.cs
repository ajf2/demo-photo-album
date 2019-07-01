using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DemoPhotoAlbum.Models {
  [DataContract]
  public class Photo {
    [DataMember(Name = "albumId")]
    public int AlbumId { get; set; }
    [DataMember(Name = "id")]
    public int Id { get; set; }
    [DataMember(Name = "title")]
    public string Title { get; set; }
    [DataMember(Name = "url")]
    public Uri Url { get; set; }
    [DataMember(Name = "thumbnailUrl")]
    public Uri ThumbnailUrl { get; set; }
  }
}
