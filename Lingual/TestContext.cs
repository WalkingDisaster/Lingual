using System;
using System.Collections.Generic;
using System.Linq;

namespace Lingual
{
    public class TestContext
    {
        public bool HasTests { get { return Tests.Any(); } }
        public string ArrangeDescription { get; set; }
        public string ActDescription { get; set; }
        public IEnumerable<TestInformation> Tests { get; set; }
    }
}