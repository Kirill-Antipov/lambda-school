using AlgorithmsDataStructures2;
using Xunit;

namespace School.UnitTests.ADS2
{
    public class SimpleGraphTests
    {
        [Fact]
        public void Vertex_Added()
        {
            var graph = new SimpleGraph(10);

            graph.AddVertex(1);

            Assert.True(graph.current_vertex_count == 1);
            Assert.NotNull(graph.vertex[0]);
        }

        [Fact]
        public void Can_Maintain_Edges()
        {
            var graph = new SimpleGraph(10);

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
            var graph = new SimpleGraph(10);

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
    }
}
