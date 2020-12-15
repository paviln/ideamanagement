using System;
using EskobInnovation.IdeaManagement.API.Controllers;
using EskobInnovation.IdeaManagement.API.Data;
using EskobInnovation.IdeaManagement.API.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Xunit;
using Task = System.Threading.Tasks.Task;

namespace EskobInnovation.IdeaManagement
{
  public class IdeaControllerTest
  {
    [Fact]
    public async Task Idea_GetIdeaById()
    {
      //ARRANGE
      var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: "ApplicationDatabase")
        .Options;
      
      var operationalStoreOptions = Options.Create(new OperationalStoreOptions());

      using (var context = new ApplicationDbContext(options, operationalStoreOptions))
      {
        context.Ideas.Add(new Idea
        {
          IdeaId = 12345,
          Title = "Test",
          Description = "This is a xunit test!",
          Effort = "1",
          Impact = "2",
          EmployeeNumber = "54321",
          SiteId = 1
        });

        context.SaveChanges();
      }

      //ACT
      using (var context = new ApplicationDbContext(options, operationalStoreOptions))
      {
        IdeaController controller = new IdeaController(context);
        var result = await controller.GetIdea(12345);
        var value = result.Value;

        // ASSERT
        Assert.Equal(12345,((Idea)value).IdeaId);
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
