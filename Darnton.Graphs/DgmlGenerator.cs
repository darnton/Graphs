using System.Linq;
using System.Xml.Linq;

namespace Darnton.Graphs
{
    /// <summary>
    /// Generates a DGML document from a Graph.
    /// This abstract class contains the scaffolding for generating the XML document.
    /// </summary>
    /// <typeparam name="T">The GraphNode type.</typeparam>
    public abstract class DgmlGenerator<T>
    {
        protected static XNamespace dgml = "http://schemas.microsoft.com/vs/2009/dgml";

        protected Graph<T> _graph;

        public DgmlGenerator(Graph<T> graph)
        {
            _graph = graph;
        }

        protected virtual void BeforeGenerate() { }

        /// <summary>
        /// Generates the DGML document.
        /// </summary>
        /// <returns>The XDocument containing the DGML</returns>
        public XDocument Generate()
        {
            BeforeGenerate();
            return new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(dgml + "DirectedGraph",
                    new XElement(dgml + "Nodes",
                        GenerateNodes()
                    ),
                    new XElement(dgml + "Links",
                        GenerateLinks()
                    ),
                    new XElement(dgml + "Categories",
                        GenerateCategories() ?? new XElement[] { }
                    ),
                    new XElement(dgml + "Properties",
                        GenerateProperties() ?? new XElement[] { }
                    )
                )
            );
        }

        protected virtual XElement[] GenerateNodes()
        {
            return _graph.Nodes.Select(n =>
                GenerateNode(n)
            ).ToArray();
        }

        protected virtual XElement GenerateNode(GraphNode<T> node)
        {
            return new XElement(dgml + "Node",
                new XAttribute("Id", node.GetHashCode()),
                new XAttribute("Label", node.ToString())
            );
        }

        protected virtual XElement[] GenerateLinks()
        {
            return _graph.Nodes.SelectMany(source =>
                source.OutList.Select(target => GenerateLink(source, target))
            ).ToArray();
        }

        protected virtual XElement GenerateLink(GraphNode<T> sourceNode, GraphNode<T> targetNode)
        {
            return new XElement(dgml + "Link",
                new XAttribute("Source", sourceNode.GetHashCode()),
                new XAttribute("Target", targetNode.GetHashCode())
            );
        }

        protected virtual XElement[] GenerateCategories()
        {
            return null;
        }

        protected virtual XElement[] GenerateProperties()
        {
            return null;
        }
    }
}
