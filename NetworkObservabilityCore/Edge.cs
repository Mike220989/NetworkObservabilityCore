using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkObservabilityCore
{
    public class Edge : IEdge
    {
		private static int idIndex = 0;
		private readonly String id;
        public List<Attribute> attributes;

        #region Property
        public String Id => id;

		public String Label
		{
			get;
			set;
		}

        public int Weight
        {
            get;
            set;
        }

        public INode From
		{
			get;
			set;
		}

		public INode To
		{
			get;
			set;
		}

		#endregion

		#region Constructors
		public Edge(int weight) : this(weight, "BasicEdge") { }

		public Edge(int weight, String label)
		{
			id = String.Format("E{0:00000000}", idIndex++);
			Label = label;
			Weight = weight;
		}
		#endregion

		public override string ToString()
		{
			return String.Format("{0}: {1}", Id, Label);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return Id == (obj as Edge).Id;
		}

		bool IEquatable<IEdge>.Equals(IEdge other)
		{
			return other is Edge && Equals(other);
		}

        public double Value { get; set; }
    }
}
