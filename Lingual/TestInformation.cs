using System;

namespace Lingual
{
    public class TestInformation
    {
        public string AssertDescription { get; set; }
        public string SortableName { get; set; }
        public Action Test { get; set; }
    }
}