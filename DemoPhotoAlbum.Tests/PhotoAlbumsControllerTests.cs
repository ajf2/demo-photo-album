using DemoPhotoAlbum.Controllers;
using DemoPhotoAlbum.Models;
using DemoPhotoAlbum.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPhotoAlbum.Tests {
  [TestClass]
  public class PhotoAlbumsControllerTests {
    private IEnumerable<PhotoAlbum> MockData => new List<PhotoAlbum> {
      new PhotoAlbum {
        Id = 1,
        Photos = new List<Photo> {
          
        },
        Title = "First User's First Mock Album",
        UserId = 1
      },
      new PhotoAlbum {
        Id = 2,
        Photos = new List<Photo> {

        },
        Title = "First User's Second Mock Album",
        UserId = 1
      },
      new PhotoAlbum {
        Id = 3,
        Photos = new List<Photo> {

        },
        Title = "Second User's First Mock Album",
        UserId = 2
      },
      new PhotoAlbum {
        Id = 4,
        Photos = new List<Photo> {

        },
        Title = "Second User's Second Mock Album",
        UserId = 2
      },
    };

    [TestMethod]
    public async Task GetAsync_ReturnsPhotoAlbums_WithPhotosPropertyPopulated() {
      var mockRepo = new Mock<IPhotoAlbumRepository>();
      var userId = 1;
      mockRepo
        .Setup(repo => repo.GetPhotoAlbumsAsync(userId))
        .ReturnsAsync(MockData.Where(a => a.UserId == userId));
      var controller = new PhotoAlbumsController(mockRepo.Object);

      var result = await controller.GetAsync(userId);

      Assert.AreEqual(2, result.Count());
    }
  }
}
