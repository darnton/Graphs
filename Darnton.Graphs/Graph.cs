using System.Collections;
using System.Collections.Generic;

namespace Darnton.Graphs
{
    /// <summary>
    /// A generic directed graph.
    /// </summary>
    /// <typeparam name="T">The node type of the graph.</typeparam>
    public class Graph<T> : IEnumerable<T>
    {
        /// <summary>
        /// Constructs an empty Graph.
        /// </summary>
        public Graph() : this(null) { }
        /// <summary>
        /// Constructs a new Graph from the supplied set of nodes.
        /// </summary>
        /// <param name="nodeSet">The initial set of nodes for the graph.</param>
        public Graph(GraphNodeList<T> nodeSet)
        {
            Nodes = nodeSet ?? new GraphNodeList<T>();
        }

        /// <summary>
        /// A <see cref="GraphNodeList{T}"/> of the Graphs nodes.
        /// </summary>
        public GraphNodeList<T> Nodes { get; }

        /// <summary>
        /// Gets the number of nodes in the graph.
        /// </summary>
        public int Count
        {
            get { return Nodes.Count; }
        }

        /// <summary>
        /// Adds a node to the graph if it has not already been added.
        /// </summary>
        /// <param name="node">The node to be added.</param>
        /// <returns>The node that was added.</returns>
        public virtual GraphNode<T> AddNode(GraphNode<T> node)
        {
            if (!Contains(node))
            {
                Nodes.Add(node);
            }
            return node;
        }

        /// <summary>
        /// Creates a node and adds it the graph if a node with the given has not already been added.
        /// </summary>
        /// <param name="value">The value of the node to be added.</param>
        /// <returns>The node that was added.</returns>
        public virtual GraphNode<T> AddNode(T value)
        {
            var node = Nodes.FindByValue(value) ?? new GraphNode<T>(value);
            return AddNode(node);
        }

        /// <summary>
        /// Adds a directed edge to the graph along with source and destination nodes
        /// if they are not already part of the graph.
        /// </summary>
        /// <param name="from">The source node for the edge.</param>
        /// <param name="to">The destination node for the edge.</param>
        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to)
        {
            AddNode(from);
            AddNode(to);
            from.OutList.Add(to);
            to.InList.Add(from);
        }

        /// <summary>
        /// Adds a directed edge to the graph along with source and destination nodes
        /// if they are not already part of the graph.
        /// </summary>
        /// <param name="from">The value of the source node for the edge.</param>
        /// <param name="to">The value of the destination node for the edge.</param>
        public void AddDirectedEdge(T from, T to)
        {
            var fromNode = AddNode(from);
            var toNode = AddNode(to);
            fromNode.OutList.Add(toNode);
            toNode.InList.Add(fromNode);
        }

        /// <summary>
        /// Removes all nodes from the graph.
        /// </summary>
        public void Clear()
        {
            Nodes.Clear();
        }

        /// <summary>
        /// Determines whether a node is part of the graph.
        /// </summary>
        /// <param name="node">The node to be tested.</param>
        /// <returns>A boolean indicating the presence of the node.</returns>
        public bool Contains(GraphNode<T> node)
        {
            return Nodes.Contains(node);
        }

        /// <summary>
        /// Determines whether a node with a given value is part of the graph.
        /// </summary>
        /// <param name="value">The value to be tested.</param>
        /// <returns>A boolean indicating the presence of a node with the given value.</returns>
        public bool Contains(T value)
        {
            return Nodes.FindByValue(value) != null;
        }

        /// <summary>
        /// Removes a node from the graph if it is present along with all associated edges.
        /// </summary>
        /// <param name="value">The node to be removed.</param>
        /// <returns>A boolean indicating whether a node was removed.</returns>
        public bool Remove(T value)
        {
            var nodeToRemove = Nodes.FindByValue(value);
            if (nodeToRemove == null)
            {
                return false;
            }

            Nodes.Remove(nodeToRemove);

            foreach (GraphNode<T> node in Nodes)
            {
                var inIndex = node.InList.IndexOf(nodeToRemove);
                if (inIndex != -1)
                {
                    node.InList.RemoveAt(inIndex);
                }
            }
            foreach (GraphNode<T> node in Nodes)
            {
                var outIndex = node.OutList.IndexOf(nodeToRemove);
                if (outIndex != -1)
                {
                    node.InList.RemoveAt(outIndex);
                }
            }

            return true;
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (GraphNode<T> node in Nodes)
            {
                yield return node.Value;
            }
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
