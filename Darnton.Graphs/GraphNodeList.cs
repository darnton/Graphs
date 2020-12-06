using System.Collections.Generic;

namespace Darnton.Graphs
{
    /// <summary>
    /// A list of generic graph nodes.
    /// </summary>
    /// <typeparam name="T">The type of the node value.</typeparam>
    public class GraphNodeList<T> : List<GraphNode<T>>
    {
        /// <summary>
        /// Constructs an empty GraphNodeList.
        /// </summary>
        public GraphNodeList() : base() { }

        /// <summary>
        /// Creates a new GraphNode with the supplied value and adds it to the end of the GraphNodeList.
        /// </summary>
        /// <param name="value">The value of the new node.</param>
        public void Add(T value)
        {
            Add(new GraphNode<T>(value));
        }

        /// <summary>
        /// Searches for a node for the given value if one is present in the list.
        /// </summary>
        /// <param name="value">The value to be searched for.</param>
        /// <returns>The node if one is present and null if not.</returns>
        public GraphNode<T> FindByValue(T value)
        {
            foreach (GraphNode<T> node in this)
            {
                if (node.Value.Equals(value))
                {
                    return node;
                }
            }

            return null;
        }
    }
}
