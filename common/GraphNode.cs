using System.Collections.Generic;

namespace Common
{
    public class GraphNode
    {
        public int val { get; set; }
        public List<GraphNode> neighbors { get; set; }

        public GraphNode()
        {
            val = 0;
            neighbors = new List<GraphNode>();
        }
        
        public GraphNode(int val)
        {
            this.val = val;
            neighbors = new List<GraphNode>();
        }

        public GraphNode(int val, List<GraphNode> neighbors)
        {
            this.val = val;
            this.neighbors = neighbors;
        }
    }
}