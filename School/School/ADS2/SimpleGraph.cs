using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex
    {
        public int Value;
        public Vertex(int val)
        {
            Value = val;
        }
    }

    public class SimpleGraph
    {
        public Vertex[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;
        public int current_vertex_count;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex[size];
            current_vertex_count = 0;
        }

        public void AddVertex(int value)
        {
            if (current_vertex_count >= max_vertex)
            {
                return;
            }

            vertex[current_vertex_count] = new Vertex(value);
            current_vertex_count++;
        }

        public void RemoveVertex(int v)
        {
            if (v < 0 || v >= current_vertex_count)
            {
                return;
            }

            var lastVertexIndex = current_vertex_count - 1;
            if (v < lastVertexIndex)
            {
                vertex[v] = vertex[lastVertexIndex];

                for (int i = 0; i < current_vertex_count; i++)
                {
                    m_adjacency[i, v] = m_adjacency[i, lastVertexIndex];
                    m_adjacency[v, i] = m_adjacency[lastVertexIndex, i];
                }
            }

            for (int i = 0; i < current_vertex_count; i++)
            {
                m_adjacency[lastVertexIndex, i] = 0;
                m_adjacency[i, lastVertexIndex] = 0;
            }

            vertex[lastVertexIndex] = null;
            current_vertex_count--;
        }

        public bool IsEdge(int v1, int v2)
        {
            return m_adjacency[v1, v2] == 1 && m_adjacency[v2, v1] == 1;
        }

        public void AddEdge(int v1, int v2)
        {
            if (v1 < 0 || v1 >= current_vertex_count || v2 < 0 || v2 >= current_vertex_count)
            {
                return;
            }

            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
        }

        public void RemoveEdge(int v1, int v2)
        {
            if (v1 < 0 || v1 >= current_vertex_count || v2 < 0 || v2 >= current_vertex_count)
            {
                return;
            }

            m_adjacency[v1, v2] = 0;
            m_adjacency[v2, v1] = 0;
        }
    }
}