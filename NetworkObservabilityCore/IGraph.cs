using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkObservabilityCore
{
    public interface IGraph : ICollection<INode>
    {
		HashSet<INode> AllNodes { get; }

		HashSet<IEdge> AllEdges { get; }


    }
}
