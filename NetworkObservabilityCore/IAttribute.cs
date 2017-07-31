using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkObservabilityCore
{
    public interface IAttribute
    {
        string Name { get; set; }
        double Value { get; set; }
    }
}
