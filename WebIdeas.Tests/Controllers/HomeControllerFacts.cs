using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate;
using StructureMap;
using WebIdeas.Infrastructure;
using WebIdeas.Models;
using Xunit;
using WebIdeas.Controllers;

namespace WebIdeas.Tests.Controllers
{
    public class HomeControllerFacts
    {
        public class Index
        {
            [Fact]
            public void ReturnsViewResultWithDefaultViewName()
            {
                // Arrange
                var controller = new HomeController();

                // Act
                var result = controller.Index();

                // Assert
                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.Empty(viewResult.ViewName);
            }

            [Fact]
            public void SetsViewDataWithModel()
            {
                // Arrange
                IoC.Initialize();
                using (var unitOfWork = new UnitOfWork(ObjectFactory.GetInstance<ISessionFactory>()))
                {
                    CreateTags(unitOfWork);
                }

                using (var unitOfWork = new UnitOfWork(ObjectFactory.GetInstance<ISessionFactory>()))
                {
                    var controller = new HomeController { UnitOfWork = unitOfWork };

                    // Act
                    var result = controller.Index();

                    // Assert
                    Assert.IsType<ViewResult>(result);
                    var viewResult = (ViewResult) result;
                    var tags = new List<Tag>
                                         {
                                             new Tag {Id = 1, Name = "Papel"},
                                             new Tag {Id = 2, Name = "WC"},
                                             new Tag {Id = 3, Name = "Secretárias"},
                                             new Tag {Id = 4, Name = "Cadeiras"},
                                             new Tag {Id = 5, Name = "Portáteis"}
                                         };
                    var vm = new HomeIndexViewModel(tags);

                    Assert.Equal("ViewBag.Message - Home", viewResult.ViewBag.Message);
                    Assert.Equal(vm, viewResult.Model);
                }

            }

            private static void CreateTags(UnitOfWork unitOfWork)
            {
                var tag1 = new Tag {Name = "Papel"};
                var tag2 = new Tag {Name = "WC" };
                var tag3 = new Tag {Name = "Secretárias" };
                var tag4 = new Tag {Name = "Cadeiras" };
                var tag5 = new Tag {Name = "Portáteis" };
                unitOfWork.Session.Save(tag1);
                unitOfWork.Session.Save(tag2);
                unitOfWork.Session.Save(tag3);
                unitOfWork.Session.Save(tag4);
                unitOfWork.Session.Save(tag5);
                unitOfWork.Commit();
            }

        }

    }
}