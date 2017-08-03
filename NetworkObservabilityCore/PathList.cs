using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkObservabilityCore
{
    class PathList
    {
        private List<Path> paths;
        private Dictionary<KeyValuePair<Node, Node>, List<Path>> pathGroups;
        private bool max;

        public PathList(bool max)
        {
            this.max = max;
            paths = new List<Path>();
            pathGroups = new Dictionary<KeyValuePair<Node, Node>, List<Path>>();
        }


        private void GroupPath()
        {
            foreach (Path path in paths)
            {
                pathGroups[new KeyValuePair<Node, Node>(path.Source, path.Destination)] = new List<Path>();
            }

            foreach (Path path in paths)
            {
                var list = pathGroups[new KeyValuePair<Node, Node>(path.Source, path.Destination)];
                list.Add(path);
            }
        }

        private void FilterPath()
        {
            Dictionary<KeyValuePair<Node, Node>, List<Path>> newPathGroups = new Dictionary<KeyValuePair<Node, Node>, List<Path>>();
            foreach (var paths in pathGroups)
            {
                List<Path> mins = new List<Path>();
            
                foreach (Path path in paths.Value)
                {
                    if (mins.Count == 0 || path.Cost <= mins[0].Cost )
                    {
                        if (path.Cost < mins[0].Cost)
                            mins.Clear();
                        mins.Add(path);
                    }
                }
                newPathGroups[paths.Key] = mins;
            }
            pathGroups = newPathGroups;
        }

        public Dictionary<KeyValuePair<Node, Node>, List<Path>> GetAllThePaths()
        {
            this.GroupPath();
            this.FilterPath();
            return pathGroups;
        }
    }
}
