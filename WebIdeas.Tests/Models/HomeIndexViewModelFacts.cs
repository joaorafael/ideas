using System.Collections.Generic;
using WebIdeas.Models;
using Xunit;

namespace WebIdeas.Tests.Models
{
    public class HomeIndexViewModelFacts
    {
        [Fact]
        public void TestEqual()
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

            var model1 = new HomeIndexViewModel(tags1);
            var model2 = new HomeIndexViewModel(tags2);

            Assert.Equal(model1, model2);
        }
    }
}
