using Xunit;

namespace GlobalXChallenge.Tests
{
    public class UnitTest_Person
    {
        [Theory,
        InlineData(null,null),
        InlineData("given",null),
        InlineData(null,"family")]
        public void TestNullNames(string given, string family)
        {
            var a = new Person(given, family);
            Assert.Null(a);
        }

        [Fact]
        public void TestPerson()
        {
            var person = new Person("two", "names");
            Assert.NotNull(person);
        }

        [Fact]
        public void testFamilyNameSame()
        {
            var a = new Person("a", "family");
            var b = new Person("b", "family");
            Assert.True(b.CompareTo(a) > 0);
        }

        [Fact]
        public void testSameName()
        {
            var a = new Person("Jane", "Doe");
            var b = new Person("Jane", "Doe");
            
            Assert.True(a.CompareTo(b) == 0);
        }

        [Fact]
        public void testName()
        {
            var a = new Person("a", "Adams");
            var b = new Person("b", "Bravo");
            
            Assert.True(b.CompareTo(a) > 0);
        }
    }
}