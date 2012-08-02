using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NHibernate;
using StructureMap;
using WebIdeas.Infrastructure;
using WebIdeas.Models;
using WebIdeas.ViewModels;
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
                IoC.Initialize();
                using (var unitOfWork = new UnitOfWork(ObjectFactory.GetInstance<ISessionFactory>()))
                {
                    var controller = new HomeController{UnitOfWork = unitOfWork};

                    // Act
                    var result = controller.Index();

                    // Assert
                    var viewResult = Assert.IsType<ViewResult>(result);
                    Assert.Empty(viewResult.ViewName);
                }
            }

            [Fact]
            public void SetsViewModel_HasCategoriesAndTagsAndIdeasAndLastIdea()
            {
                // Arrange
                var contributers = new List<Contributer>
                                         {
                                             new Contributer {Id = 1, Name = "Barbara"},
                                             new Contributer {Id = 2, Name = "César"},
                                             new Contributer {Id = 3, Name = "Rocha"},
                                             new Contributer {Id = 4, Name = "Tiago"},
                                         };
                var tags = new List<Tag>
                                         {
                                             new Tag {Id = 1, Name = "Papel"},
                                             new Tag {Id = 2, Name = "WC"},
                                             new Tag {Id = 3, Name = "Secretárias"},
                                             new Tag {Id = 4, Name = "Cadeiras"},
                                             new Tag {Id = 5, Name = "Portáteis"}
                                         };
                var now = DateTime.Now;
                var ideas = new List<Idea>
                                         {
                                             new Idea {Id = 1, Text = "Ideia marada", Date = now},
                                             new Idea {Id = 2, Text = "Olha que boa ideia", Date = now},
                                             new Idea {Id = 3, Text = "Não sei porquê mas parece-me boa ideia", Date = now},
                                         };
                var lastIdea = new Idea { Id = 3, Text = "Não sei porquê mas parece-me boa ideia", Date = now };

                var vm = new HomeIndexViewModel { Tags = tags, Contributers = contributers, Ideas = ideas, LastIdea = lastIdea };

                IoC.Initialize();
                using (var unitOfWork = new UnitOfWork(ObjectFactory.GetInstance<ISessionFactory>()))
                {
                    CreateTags(unitOfWork);
                    CreateTopContributers(unitOfWork);
                    CreateTopIdeas(unitOfWork);
                    unitOfWork.Commit();
                }

                using (var unitOfWork = new UnitOfWork(ObjectFactory.GetInstance<ISessionFactory>()))
                {
                    var controller = new HomeController { UnitOfWork = unitOfWork };

                    // Act
                    var result = controller.Index();

                    // Assert
                    Assert.IsType<ViewResult>(result);
                    var viewResult = (ViewResult) result;

                    Assert.Equal("ViewBag.Message - Home", viewResult.ViewBag.Message);
                    Assert.Equal(vm, viewResult.Model);
                }
            }

            [Fact]
            public void SetsViewModel_WhenNoDataStillHaveAllSetWithNoData()
            {
                // Arrange
                IoC.Initialize();

                using (var unitOfWork = new UnitOfWork(ObjectFactory.GetInstance<ISessionFactory>()))
                {
                    var controller = new HomeController { UnitOfWork = unitOfWork };

                    // Act
                    var result = controller.Index();

                    // Assert
                    Assert.IsType<ViewResult>(result);
                    var viewResult = (ViewResult)result;
                    var vm = (HomeIndexViewModel)viewResult.Model;

                    Assert.NotNull(vm.Contributers);
                    Assert.NotNull(vm.Ideas);
                    Assert.NotNull(vm.Tags);
                    Assert.Equal(0, vm.Contributers.Count);
                    Assert.Equal(0, vm.Ideas.Count);
                    Assert.Equal(0, vm.Tags.Count);
                    Assert.Null(vm.LastIdea);
                }
            }

            private void CreateTopIdeas(UnitOfWork unitOfWork)
            {
                var idea1 = new Idea {Text = "Ideia marada"};
                var idea2 = new Idea {Text = "Olha que boa ideia"};
                var idea3 = new Idea {Text = "Não sei porquê mas parece-me boa ideia"};
                unitOfWork.Session.Save(idea1);
                unitOfWork.Session.Save(idea2);
                unitOfWork.Session.Save(idea3);
            }

            private void CreateTopContributers(UnitOfWork unitOfWork)
            {
                var contributer1 = new Contributer { Name = "Barbara" };
                var contributer2 = new Contributer { Name = "César" };
                var contributer3 = new Contributer { Name = "Rocha" };
                var contributer4 = new Contributer { Name = "Tiago" };
                unitOfWork.Session.Save(contributer1);
                unitOfWork.Session.Save(contributer2);
                unitOfWork.Session.Save(contributer3);
                unitOfWork.Session.Save(contributer4);
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
            }

        }
    }
}