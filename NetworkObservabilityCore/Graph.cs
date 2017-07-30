using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NetworkObservabilityCore
{
    public class Graph<NType, EType> : IGraph 
		where NType : INode 
		where EType : IEdge
    {

		public HashSet<INode> AllNodes
		{
			get;
			private set;
		}

		public HashSet<IEdge> AllEdges
		{
			get;
			private set;
		}

		public int Count => AllNodes.Count;

		public bool IsReadOnly => throw new NotImplementedException();

		public Graph()
		{
			AllNodes = new HashSet<INode>();
			AllEdges = new HashSet<IEdge>();
		}

		public void AddNode(NType node)
		{
			AllNodes.Add(node);
		}

		public void ConnectNodeToWith(NType lhs, NType rhs, EType edge)
		{
			AllEdges.Add(edge);
			lhs.Links.Add(edge);
			edge.From = lhs;
			edge.To = rhs;
		}

		public Dictionary<Tuple<INode, INode>, bool>
		ObserveConnectivity(ICollection<INode> observers)
		{
			var result = new Dictionary<Tuple<INode, INode>, bool>();

			foreach (var from in AllNodes)
			{
				if (observers.Contains(from) && !from.IsObserverInclusive)
					continue;

				Dijkstra dijkstra = new Dijkstra(this, from);

				foreach (var to in AllNodes)
				{
					if (from.Equals(to))
						continue;

					foreach (var observer in observers)
					{
						bool flag = dijkstra.PathTo(to).Contains(observer);
						result[new Tuple<INode, INode>(from, to)] = flag;
					}
				}
			}

			return result;
		}

		public void Add(NType node)
		{
			AddNode(node);
		}

		public void Add(INode item)
		{
			AddNode((NType)item);
		}

		public void Clear()
		{
			AllNodes.Clear();
			AllEdges.Clear();
		}

		public void CopyTo(INode[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public bool Remove(INode item)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<INode> GetEnumerator()
		{
			return AllNodes.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return AllNodes.GetEnumerator();
		}

		public bool Contains(INode item)
		{
			return AllNodes.Contains(item);
		}
	}
}
