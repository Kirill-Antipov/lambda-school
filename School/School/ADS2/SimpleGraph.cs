using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T>
    {
        public bool Hit;
        public T Value;
        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }

    public class SimpleGraph<T>
    {
        public Vertex<T>[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;
        public int current_vertex_count;


        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex<T>[size];
            current_vertex_count = 0;
        }

        public void AddVertex(T value)
        {
            if (current_vertex_count >= max_vertex)
            {
                return;
            }

            vertex[current_vertex_count] = new Vertex<T>(value);
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

        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {
            Stack<Vertex<T>> result = new Stack<Vertex<T>>();
            DepthFirstSearch(VFrom, VTo, result);

            var path = result.ToList();
            path.Reverse();

            return path;
        }

        public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo)
        {
            for (int i = 0; i < current_vertex_count; i++)
            {
                vertex[i].Hit = false;
            }

            int[] path = new int[max_vertex];
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(VFrom);
            BreadthFirstSearch(VTo, queue, path);

            return vertex[VTo].Hit ? GetPath(VTo, VFrom, path, new List<Vertex<T>>()) : new List<Vertex<T>>();
        }

        public List<Vertex<T>> WeakVertices()
        {
            var result = new List<Vertex<T>>();
            var adjacencyPowThree = PowThree(m_adjacency, current_vertex_count);

            for (int i = 0; i < current_vertex_count; i++)
            {
                if (adjacencyPowThree[i, i] == 0)
                {
                    result.Add(vertex[i]);
                }
            }

            return result;
        }

        private void BreadthFirstSearch(int VTo, Queue<int> queue, int[] path)
        {
            if (queue.Count == 0)
            {
                return;
            }

            int currentVertexIndex = queue.Dequeue();
            Vertex<T> currentVertex = vertex[currentVertexIndex];
            currentVertex.Hit = true;

            if (currentVertexIndex == VTo)
            {
                return;
            }

            for (int i = 0; i < current_vertex_count; i++)
            {
                if (m_adjacency[currentVertexIndex, i] == 1 && !vertex[i].Hit)
                {
                    queue.Enqueue(i);
                    vertex[i].Hit = true;
                    path[i] = currentVertexIndex;
                }
            }

            BreadthFirstSearch(VTo, queue, path);
        }

        private List<Vertex<T>> GetPath(int vFrom, int vTo, int[] path, List<Vertex<T>> result)
        {
            if (vFrom == vTo)
            {
                result.Add(vertex[vTo]);

                result.Reverse();

                return result;
            }

            result.Add(vertex[vFrom]);

            return GetPath(path[vFrom], vTo, path, result);
        }

        private bool DepthFirstSearch(int currentVertex, int VTo, Stack<Vertex<T>> result)
        {
            vertex[currentVertex].Hit = true;
            result.Push(vertex[currentVertex]);

            for (int i = 0; i < max_vertex; i++)
            {
                if (m_adjacency[currentVertex, i] == 1 && i == VTo)
                {
                    result.Push(vertex[VTo]);
                    return true;
                }
            }

            for (int i = 0; i < max_vertex; i++)
            {
                if (m_adjacency[currentVertex, i] != 1 || vertex[i].Hit)
                {
                    continue;
                }

                var finished = DepthFirstSearch(i, VTo, result);

                if (finished)
                {
                    return true;
                }
            }

            result.Pop();

            if (result.Count == 0)
            {
                return true;
            }

            return false;
        }

        private int[,] PowThree(int[,] matrix, int size)
        {
            var matrixPowTwo = Multiply(matrix, matrix, size);
            var marixPowThree = Multiply(matrix, matrixPowTwo, size);

            return marixPowThree;
        }

        private int[,] Multiply(int[,] matrixA, int[,] matrixB, int size)
        {
            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < size; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }
    }
}