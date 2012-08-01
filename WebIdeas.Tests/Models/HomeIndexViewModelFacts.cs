using System;
using System.Collections.Generic;
using WebIdeas.Models;
using WebIdeas.ViewModels;
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

        [Fact]
        public void TestEqualIdeas()
        {
            var ideas1 = new List<Idea>
                            {
                                new Idea
                                    {
                                        Text = "abc", Title = "title", Date = new DateTime(2012,11,15),
                                        Contributer = new Contributer{Id = 1, Name = "contributer"}, 
                                        Tag = new Tag{Id = 1, Name = "tag"}
                                    }, 
                                new Idea
                                    {
                                        Text = "def", Title = "title2", Date = new DateTime(2011,09,15),
                                        Contributer = new Contributer{Id = 2, Name = "contributer2"}, 
                                        Tag = new Tag{Id = 2, Name = "tag2"}
                                    }
                            };

            var ideas2 = new List<Idea>
                            {
                                new Idea
                                    {
                                        Text = "abc", Title = "title", Date = new DateTime(2012,11,15),
                                        Contributer = new Contributer{Id = 1, Name = "contributer"}, 
                                        Tag = new Tag{Id = 1, Name = "tag"}
                                    }, 
                                new Idea
                                    {
                                        Text = "def", Title = "title2", Date = new DateTime(2011,09,15),
                                        Contributer = new Contributer{Id = 2, Name = "contributer2"}, 
                                        Tag = new Tag{Id = 2, Name = "tag2"}
                                    }
                            };
            var ideas3 = new List<Idea>
                            {
                                new Idea
                                    {
                                        Text = "abc", Title = "title", Date = new DateTime(2012,11,15),
                                        Contributer = new Contributer{Id = 1, Name = "contributer"}, 
                                        Tag = new Tag{Id = 1, Name = "tag"}
                                    }, 
                                new Idea
                                    {
                                        Text = "def", Title = "title2", Date = new DateTime(2011,09,15),
                                        Contributer = new Contributer{Id = 2, Name = "contributer2"}, 
                                        Tag = new Tag{Id = 2, Name = "tag6"}
                                    }
                            };

            var model1 = new HomeIndexViewModel { Ideas = ideas1 };
            var model2 = new HomeIndexViewModel { Ideas = ideas2 };
            var model3 = new HomeIndexViewModel { Ideas = ideas3 };

            Assert.Equal(model1, model2);
            Assert.NotEqual(model1, model3);
        }

        [Fact]
        public void TestEqualContributersAndTagsAndIdeas()
        {
            var contributers1 = new List<Contributer>
                            {
                                new Contributer {Name = "abc"}, 
                                new Contributer {Name = "def"}
                            };

            var contributers2 = new List<Contributer>
                            {
                                new Contributer {Name = "abc"}, 
                                new Contributer {Name = "def"}
                            };
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

            var ideas1 = new List<Idea>
                            {
                                new Idea {Text = "abc"}, 
                                new Idea {Text = "def"}
                            };

            var ideas2 = new List<Idea>
                            {
                                new Idea {Text = "abc"}, 
                                new Idea {Text = "def"}
                            };
            var model1 = new HomeIndexViewModel { Tags = tags1, Contributers = contributers1, Ideas = ideas1 };
            var model2 = new HomeIndexViewModel { Tags = tags2, Contributers = contributers2, Ideas = ideas2 };

            Assert.Equal(model1, model2);
        }
    }
}
