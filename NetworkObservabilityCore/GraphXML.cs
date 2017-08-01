using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace NetworkObservabilityCore
{
    public class GraphXML
    {
		private XDocument file;
		private String filename;
		
		public GraphXML(String filename, String version, String encode, String standalone)
		{
			file = new XDocument(new XDeclaration(version, encode, standalone));
		}

		public void Save(String path, IGraph graph)
		{
			Dump(graph);

			var logFile = File.Create(path);
			var writer = new StreamWriter(logFile);
			file.Save(writer);
			writer.Dispose();

		}

		private void Dump(IGraph graph)
		{
			foreach (INode node in graph.AllNodes)
			{
				file.Add(CreateXElement(node));
			}
			foreach (IEdge edge in graph.AllEdges)
			{
				file.Add(CreateXElement(edge));
			}

		}

		private XElement CreateXElement(INode node)
		{
			XElement xelement = new XElement("Node", new XAttribute("Id", node.Id));

			var isObserver = new XElement("IsObserver", node.IsObserver);
			var isObserverInclusive = new XElement("IsObserverInclusive", node.IsObserverInclusive);
			var label = new XElement("Label", node.Label);
			var links = CreateSubXElement(node.Links);
			var name = new XElement("Name", node.Name);

			xelement.Add(isObserver);
			xelement.Add(isObserverInclusive);
			xelement.Add(label);
			xelement.Add(links);
			xelement.Add(name);

			return xelement;
		}

		private XElement CreateXElement(IEdge edge)
		{
			XElement xelement = new XElement("Edge", new XAttribute("Id", edge.Id));

			var from = new XElement("From", edge.From);
			var label = new XElement("Label", edge.Label);
			var to = new XElement("To", edge.To);

			xelement.Add(from);
			xelement.Add(label);
			xelement.Add(to);

			return xelement;
		}

		private XElement CreateSubXElement(IEnumerable<IEdge> links)
		{
			XElement linksNode = new XElement("NLinks");

			foreach (IEdge link in links)
			{
				linksNode.Add(new XElement("EdgeID", link.Id));
			}

			return linksNode;
		}
    }
}
