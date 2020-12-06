namespace Darnton.Graphs
{
    /// <summary>
    /// A generic graph node.
    /// </summary>
    /// <typeparam name="T">The type of the node value.</typeparam>
    public class GraphNode<T>
    {
        /// <summary>
        /// The value of the node.
        /// </summary>
        public T Value { get; }
        private GraphNodeList<T> inList = null;
        private GraphNodeList<T> outList = null;

        /// <summary>
        /// Constructs a GraphNode with the given value.
        /// </summary>
        /// <param name="value">The value of the node.</param>
        public GraphNode(T value) : this(value, null, null) { }
        /// <summary>
        /// Constructs a GraphNode with the given value and directed edges.
        /// </summary>
        /// <param name="value">The value of the node.</param>
        /// <param name="inList">The <see cref="GraphNodeList{T}"/> of source nodes with edges into this node.</param>
        /// <param name="outList">The <see cref="GraphNodeList{T}"/> of destination nodes with edges out of this node.</param>
        public GraphNode(T value, GraphNodeList<T> inList, GraphNodeList<T> outList)
        {
            Value = value;
            this.inList = inList;
            this.outList = outList;
        }

        /// <summary>
        /// Gets the list of nodes that have edges directed to this node.
        /// </summary>
        public GraphNodeList<T> InList
        {
            get
            {
                return inList ?? (inList = new GraphNodeList<T>());
            }
        }

        /// <summary>
        /// Gets the list of nodes that edges directed from this node.
        /// </summary>
        public GraphNodeList<T> OutList
        {
            get
            {
                return outList ?? (outList = new GraphNodeList<T>());
            }
        }
    }
}
