using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Test
{    
    public class FinderTests
    {
        [Fact]
        public void Returns_Null_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finder = new Finder(list);

            var result = finder.Find(FinderFlag.Closest);

            Assert.Null(result.Younger);
            Assert.Null(result.Older);
        }

        [Fact]
        public void Returns_Null_When_Given_1_Person()
        {
            var list = new List<Person>() { sue };
            var finder = new Finder(list);

            var result = finder.Find(FinderFlag.Closest);

            Assert.Null(result.Younger);
            Assert.Null(result.Older);
        }

        [Fact]
        public void Returns_Closest_AgePair_For_2_People()
        {
            var list = new List<Person>() { sue, greg };
            var finder = new Finder(list);

            var result = finder.Find(FinderFlag.Closest);

            Assert.Same(sue, result.Younger);
            Assert.Same(greg, result.Older);
        }

        [Fact]
        public void Returns_Furthest_AgePair_For_2_People()
        {
            var list = new List<Person>() { greg, mike };
            var finder = new Finder(list);

            var result = finder.Find(FinderFlag.Furthest);

            Assert.Same(greg, result.Younger);
            Assert.Same(mike, result.Older);
        }

        [Fact]
        public void Returns_Furthest_AgePair_For_4_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(FinderFlag.Furthest);

            Assert.Same(sue, result.Younger);
            Assert.Same(sarah, result.Older);
        }

        [Fact]
        public void Returns_Closest_AgePair_For_4_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(FinderFlag.Closest);

            Assert.Same(sue, result.Younger);
            Assert.Same(greg, result.Older);
        }

        Person sue = new Person() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        Person greg = new Person() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}