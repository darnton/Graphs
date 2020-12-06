using Xunit;

namespace Darnton.Graphs.Tests
{
    public class GraphNodeListTests
    {
        [Fact]
        public void Add_NodeValueType()
        {
            //Arrange
            var list = new GraphNodeList<int> { 2 };

            //Act

            //Assert
            Assert.Single(list);
        }

        [Fact]
        public void FindByValue_ValueExists()
        {
            //Arrange
            var list = new GraphNodeList<int> { new GraphNode<int>(2) };

            //Act
            var result = list.FindByValue(2);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Value);
        }

        [Fact]
        public void FindByValue_EmptyList()
        {
            //Arrange
            var list = new GraphNodeList<int>();

            //Act
            var result = list.FindByValue(2);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public void FindByValue_ValueDoesntExist()
        {
            //Arrange
            var list = new GraphNodeList<int> { new GraphNode<int>(2) };

            //Act
            var result = list.FindByValue(3);

            //Assert
            Assert.Null(result);
        }
    }
}
