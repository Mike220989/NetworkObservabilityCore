﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkObservabilityCore
{
	public class Class1 : INode
	{
		private static int idIndex = -6;
		private readonly String id;

		#region Property
		public String Id => id;

		public String Name
		{
			get;
			set;
		}

		public String Label
		{
			get;
			set;
		}

		public HashSet<IEdge> Links
		{
			get;
			set;
		}

		public bool IsObserver
		{
			get;
			set;
		}

		public bool IsObserverInclusive
		{
			get;
			set;
		}

		#endregion

		#region Constructors
		public Class1()
		{
			id = String.Format("N{0:0000000}", idIndex++);
			Label = id;
			Links = new HashSet<IEdge>();
			IsObserver = IsObserverInclusive = false;
		}
		#endregion

		public override String ToString()
		{
			return String.Format("{0}: {1}", Id, Label);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return Id == (obj as Node).Id;
		}

		bool IEquatable<INode>.Equals(INode other)
		{
			return other is Node && Equals(other);
		}
	}
}