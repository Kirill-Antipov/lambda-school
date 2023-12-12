using AlgorithmsDataStructures2;
using Xunit;

namespace School.UnitTests.ADS2
{
    public class SimpleGraphTests
    {
        [Fact]
        public void Vertex_Added()
        {
            var graph = new SimpleGraph<int>(10);

            graph.AddVertex(1);

            Assert.True(graph.current_vertex_count == 1);
            Assert.NotNull(graph.vertex[0]);
        }

        [Fact]
        public void Can_Maintain_Edges()
        {
            var graph = new SimpleGraph<int>(10);

            graph.AddVertex(1);
            graph.AddVertex(2);

            var result = graph.IsEdge(0, 1);

            Assert.False(result);

            graph.AddEdge(0, 1);

            result = graph.IsEdge(0, 1);

            Assert.True(result);

            graph.RemoveEdge(0, 1);

            result = graph.IsEdge(0, 1);

            Assert.False(result);
        }

        [Fact]
        public void Vertex_Deleted()
        {
            var graph = new SimpleGraph<int>(10);

            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);

            graph.AddEdge(0, 2);

            graph.RemoveVertex(1);

            Assert.True(graph.current_vertex_count == 2);
            Assert.NotNull(graph.vertex[0]);
            Assert.NotNull(graph.vertex[1]);
            Assert.True(graph.IsEdge(0, 1));
            Assert.True(graph.vertex[1].Value == 3);
        }

        [Fact]
        public void DepthFirstSearch_Path_Found()
        {
            var graph = new SimpleGraph<int>(10);

            graph.AddVertex(0);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);

            graph.AddEdge(0, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 4);
            graph.AddEdge(4, 1);

            var result = graph.DepthFirstSearch(0, 1);

            Assert.Equal(5, result.Count);
        }

        [Fact]
        public void DepthFirstSearch_No_Results_When_No_Path()
        {
            var graph = new SimpleGraph<int>(10);

            graph.AddVertex(0);
            graph.AddVertex(1);
            graph.AddVertex(2);
            graph.AddVertex(3);
            graph.AddVertex(4);
            graph.AddVertex(5);
            graph.AddVertex(6);

            graph.AddEdge(0, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 4);

            var result = graph.DepthFirstSearch(0, 1);

            Assert.Empty(result);
        }
    }
}
