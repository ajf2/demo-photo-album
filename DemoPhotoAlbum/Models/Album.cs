using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DemoPhotoAlbum.Models {
  [DataContract]
  public class Album {
    [DataMember(Name = "userId")]
    public int UserId { get; set; }
    [DataMember(Name = "id")]
    public int Id { get; set; }
    [DataMember(Name = "title")]
    public string Title { get; set; }
  }
}
