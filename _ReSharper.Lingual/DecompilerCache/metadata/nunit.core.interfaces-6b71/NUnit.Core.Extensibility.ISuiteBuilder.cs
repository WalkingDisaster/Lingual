// Type: NUnit.Core.Extensibility.ISuiteBuilder
// Assembly: nunit.core.interfaces, Version=2.5.4.10098, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77
// Assembly location: D:\Projects\Lingual\lib\NUnit\nunit.core.interfaces.dll

using NUnit.Core;
using System;

namespace NUnit.Core.Extensibility
{
    public interface ISuiteBuilder
    {
        bool CanBuildFrom(Type type);
        Test BuildFrom(Type type);
    }
}
