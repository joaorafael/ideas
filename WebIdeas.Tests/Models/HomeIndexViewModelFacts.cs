using System.Collections.Generic;
using WebIdeas.Models;
using Xunit;

namespace WebIdeas.Tests.Models
{
    public class HomeIndexViewModelFacts
    {
        [Fact]
        public void TestEqualTags()
        {
            var tags1 = new List<Tag>
                            {
                                new Tag {Name = "abc"}, 
                                new Tag {Name = "def"}
                            };

            var tags2 = new List<Tag>
                            {
                                new Tag {Name = "abc"}, 
                                new Tag {Name = "def"}
                            };

            var model1 = new HomeIndexViewModel {Tags = tags1};
            var model2 = new HomeIndexViewModel {Tags = tags2 };

            Assert.Equal(model1, model2);
        }

        [Fact]
        public void TestEqualContributers()
        {
            var contributers1= new List<Contributer>
                            {
                                new Contributer {Name = "abc"}, 
                                new Contributer {Name = "def"}
                            };

            var contributers2 = new List<Contributer>
                            {
                                new Contributer {Name = "abc"}, 
                                new Contributer {Name = "def"}
                            };

            var model1 = new HomeIndexViewModel { Contributers = contributers1 };
            var model2 = new HomeIndexViewModel { Contributers = contributers2 };

            Assert.Equal(model1, model2);
        }
    }
}
