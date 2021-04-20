using System.Collections.Generic;

namespace Flags
{
    internal enum FlagType
    {
        None, Int, Float, Bool, String
    }

    internal struct FlagInfo
    {
        public string Description;
        public FlagType Type;
    }

    internal class Flags
    {
        internal static Dictionary<string, FlagInfo> FlagInfos = new Dictionary<string, FlagInfo>();
    }
}
