using DemoPhotoAlbum.Controllers;
using DemoPhotoAlbum.Models;
using DemoPhotoAlbum.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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
          new Photo {
            AlbumId = 1,
            Id = 1,
            ThumbnailUrl = new Uri("https://example.org/thumb.jpg"),
            Title = "First User's First Mock Album's First Photo",
            Url = new Uri("https://example.org/photo.jpg")
          },
          new Photo {
            AlbumId = 1,
            Id = 2,
            ThumbnailUrl = new Uri("https://example.org/thumb.jpg"),
            Title = "First User's First Mock Album's Second Photo",
            Url = new Uri("https://example.org/photo.jpg")
          }
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
    public async Task GetAsync_ReturnsPhotoAlbums() {
      var mockRepo = new Mock<IPhotoAlbumRepository>();
      var userId = 1;
      mockRepo
        .Setup(repo => repo.GetPhotoAlbumsAsync(userId))
        .ReturnsAsync(MockData.Where(a => a.UserId == userId));
      var controller = new PhotoAlbumsController(mockRepo.Object);

      var result = await controller.GetAsync(userId);

      Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public async Task GetAsync_ReturnsEmptyList_WhenGivenNonsenseUserId() {
      var mockRepo = new Mock<IPhotoAlbumRepository>();
      var userId = -1;
      mockRepo
        .Setup(repo => repo.GetPhotoAlbumsAsync(userId))
        .ReturnsAsync(new List<PhotoAlbum>());
      var controller = new PhotoAlbumsController(mockRepo.Object);

      var result = await controller.GetAsync(userId);

      Assert.AreEqual(0, result.Count());
    }

    [TestMethod]
    public async Task GetAsync_ReturnsAlbumsWithPhotos() {
      var mockRepo = new Mock<IPhotoAlbumRepository>();
      var userId = 1;
      mockRepo
        .Setup(repo => repo.GetPhotoAlbumsAsync(userId))
        .ReturnsAsync(MockData.Where(a => a.UserId == userId));
      var controller = new PhotoAlbumsController(mockRepo.Object);

      var result = await controller.GetAsync(userId);

      Assert.IsTrue(result.SelectMany(a => a.Photos).Any());
    }
  }
}
