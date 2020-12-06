using Xunit;

namespace Darnton.Graphs.Tests
{
    public class GraphNodeTests
    {
        [Fact]
        public void Constructor_InitialState()
        {
            //Arrange
            var node = new GraphNode<int>(3);

            //Act

            //Assert
            Assert.Equal(3, node.Value);
            Assert.Empty(node.InList);
            Assert.Empty(node.OutList);
        }
    }
}
