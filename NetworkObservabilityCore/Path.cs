using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkObservabilityCore
{
    class Path
    {
        public double Cost { get; set; }
        private List<Node> path;

        public Path()
        {
            path = new List<Node>();
         
        }

        public void add(Node node)
        {
            path.Add(node);
            
        }

        public Node Source => path[0];

        public Node Destination => path[path.Count - 1];

        public double GetPathCost()
        {
            //double cost = 0;
            //foreach(var tempPath in path)
            //{
            //    //
            //}
                throw new NotImplementedException();
        }
    }
}
