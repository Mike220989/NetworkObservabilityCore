using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkObservabilityCore
{
	public interface INode : IEquatable<INode>
	{
		String Id { get; }

		String Type { get; set; }

		String Label { get; }

		HashSet<IEdge> Links { get; set; }

		bool IsObserver { get; set; }

		bool IsObserverInclusive { get; set; }


	}
}
