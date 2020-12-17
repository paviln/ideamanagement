using System;
using System.Collections.Generic;
using EskobInnovation.IdeaManagement.API.Controllers;
using EskobInnovation.IdeaManagement.API.Data;
using EskobInnovation.IdeaManagement.API.Models;
using EskobInnovation.IdeaManagement.Helpers;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace EskobInnovation.IdeaManagement
{
  public class IdeaControllerTest
  {
    private Mock<UserManager<ApplicationUser>> _userManager;

    public IdeaControllerTest()
    {
      _userManager = MockUserManager.GetUserManager<ApplicationUser>();
      var user = new ApplicationUser()
      {
        UserName = "Jens Christensen",
        Email = "ancon@mail.com"
      };
      _userManager
        .Setup(u => u.CreateAsync(user, "Secret0!")).ReturnsAsync(IdentityResult.Success);
    }

    [Fact]
    public async Task Idea_GetIdeaById()
    {
      //ARRANGE
      var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "ApplicationDatabase")
        .Options;

      var operationalStoreOptions = Options.Create(new OperationalStoreOptions());

      var mockUserManager = new Mock<UserManager<ApplicationUser>>();
      mockUserManager.Setup(p => p.FindByIdAsync(It.IsAny<string>()))
        .ReturnsAsync(new ApplicationUser
        {
          UserName = "test@panel.com"
        });

      using (var context = new ApplicationDbContext(options, operationalStoreOptions))
      {
        context.Sites.Add(new Site
        {
          SiteId = 1,
          Link = "linak"
        });

        var employee = new Employee
        {
          EmployeeId = 1,
          Name = "Jens Christensen",
          Position = "IT"
        };

        context.Employees.Add(employee);

        var task = new EskobInnovation.IdeaManagement.API.Models.Task
        {
          TaskId = 1,
          Content = "This is a task.",
          Employee = employee,
          Date = DateTime.Now,
          TaskStatus = 0
        };

        context.Tasks.Add(task);

        var taskComment = new TaskComment
        {
          TaskCommentId = 1,
          Content = "This is a task comment",
          Employee = employee,
          Date = DateTime.Now,
          Task = task
        };

        context.TaskComments.Add(taskComment);

        var hashtag = new Hashtag
        {
          HashtagId = 1,
          Name = "This is a hashtag"
        };

        context.Hashtags.Add(hashtag);

        var tasks = new List<EskobInnovation.IdeaManagement.API.Models.Task>();
        tasks.Add(task);

        var employess = new List<Employee>();
        employess.Add(employee);

        var hashtags = new List<Hashtag>();
        hashtags.Add(hashtag);

        var ideaComent = new IdeaComment
        {
          IdeaCommentId = 1,
          Content = "I am a idea comment",
          Employee = employee,
          Date = DateTime.Now
        };

        context.IdeaComments.Add(ideaComent);

        var ideaComments = new List<IdeaComment>();
        ideaComments.Add(ideaComent);

        var file = new File
        {
          FileId = 1,
          Name = "I am a file.",
          Type = "application/text",
          FileData = new FileData()
        };

        context.Files.Add(file);

        var files = new List<File>();
        files.Add(file);

        context.Ideas.Add(new Idea
        {
          IdeaId = 12345,
          Title = "Test",
          Description = "This is a xunit test!",
          Effort = "1",
          Impact = "2",
          EmployeeNumber = "54321",
          Date = DateTime.Now,
          Status = 0,
          Challenge = "This is a challenge.",
          Result = "This is a result!",
          Saving = 1000,
          Priority = 0,
          Tasks = tasks,
          Employees = employess,
          Hashtags = hashtags,
          IdeaComments = ideaComments,
          Files = files,
          SiteId = 1
        });

        context.SaveChanges();
      }

      //ACT
      using (var context = new ApplicationDbContext(options, operationalStoreOptions))
      {
        //Mock IHttpContextAccessor
        var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
        IdeaController controller = new IdeaController(context, _userManager.Object, mockHttpContextAccessor.Object);
        var result = await controller.GetIdea("linak", 12345);
        var value = result.Value;

        // ASSERT
        Assert.Equal(12345, ((Idea)value).IdeaId);
        Assert.Equal("Test", ((Idea)value).Title);
        Assert.Equal("This is a xunit test!", ((Idea)value).Description);
        Assert.Equal("1", ((Idea)value).Effort);
        Assert.Equal("2", ((Idea)value).Impact);
        Assert.Equal("54321", ((Idea)value).EmployeeNumber);
        Assert.Equal(1, ((Idea)value).SiteId);
      }
    }
  }
}
