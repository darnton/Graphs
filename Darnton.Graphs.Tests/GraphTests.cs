using Xunit;

namespace Darnton.Graphs.Tests
{
    public class GraphTests
    {
        [Fact]
        public void Constructor_InitialState()
        {
            //Arrange
            var graph = new Graph<int>();

            //Act

            //Assert
            Assert.NotNull(graph.Nodes);
            Assert.Empty(graph.Nodes);
        }

        [Fact]
        public void AddNode_Single()
        {
            //Arrange
            var graph = new Graph<int>();

            //Act
            graph.AddNode(2);

            //Assert
            Assert.Single(graph.Nodes);
        }

        [Fact]
        public void AddNode_Multiple()
        {
            //Arrange
            var graph = new Graph<int>();

            //Act
            graph.AddNode(2);
            graph.AddNode(3);

            //Assert
            Assert.Equal(2, graph.Nodes.Count);
        }

        [Fact]
        public void AddNode_Duplicate()
        {
            //Arrange
            var graph = new Graph<int>();

            //Act
            graph.AddNode(2);
            graph.AddNode(2);

            //Assert
            Assert.Single(graph.Nodes);
        }

        [Fact]
        public void AddDirectedEdge_ExistingNodes()
        {
            //Arrange
            var graph = new Graph<int>();
            graph.AddNode(2);
            graph.AddNode(3);

            //Act
            graph.AddDirectedEdge(2, 3);

            //Assert
            Assert.Single(graph.Nodes.FindByValue(2).OutList);
            Assert.Empty(graph.Nodes.FindByValue(2).InList);
            Assert.Empty(graph.Nodes.FindByValue(3).OutList);
            Assert.Single(graph.Nodes.FindByValue(3).InList);
        }

        [Fact]
        public void AddDirectedEdge_NewNodes()
        {
            //Arrange
            var graph = new Graph<int>();

            //Act
            graph.AddDirectedEdge(2, 3);

            //Assert
            Assert.Single(graph.Nodes.FindByValue(2).OutList);
            Assert.Empty(graph.Nodes.FindByValue(2).InList);
            Assert.Empty(graph.Nodes.FindByValue(3).OutList);
            Assert.Single(graph.Nodes.FindByValue(3).InList);
        }
    }
}
