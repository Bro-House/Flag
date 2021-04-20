using System;
using System.Linq;

namespace Flags
{
    public class Flag
    {
        private static string[] cachedArgs = Environment.GetCommandLineArgs();

        public static void StringVar(ref string var, string flag, string defaultVar, string description)
        {
            Flags.FlagInfos.Add(flag, new FlagInfo
            {
                Description = description,
                Type = FlagType.String
            });
            
            string one = cachedArgs.Where(x => x.StartsWith(flag)).FirstOrDefault();
            
            if (one != null)
            {
                if (one.Contains("="))
                {
                    var = one.Split('=')[1];
                    return;
                }
            }

            var = defaultVar;
        }

        public static void IntVar(ref int var, string flag, int defaultVar, string description)
        {
            Flags.FlagInfos.Add(flag, new FlagInfo
            {
                Description = description,
                Type = FlagType.Int
            });

            string one = cachedArgs.Where(x => x.StartsWith(flag)).FirstOrDefault();

            if (one != null)
            {
                if (one.Contains("="))
                {
                    var = Convert.ToInt32(one.Split('=')[1]);
                    return;
                }
            }

            var = defaultVar;
        }

        public static void FloatVar(ref float var, string flag, float defaultVar, string description)
        {
            Flags.FlagInfos.Add(flag, new FlagInfo
            {
                Description = description,
                Type = FlagType.Float
            });
            
            string one = cachedArgs.Where(x => x.StartsWith(flag)).FirstOrDefault();

            if (one != null)
            {
                if (one.Contains("="))
                {
                    var = Convert.ToSingle(one.Split('=')[1]);
                    return;
                }
            }

            var = defaultVar;
        }

        public static void BoolVar(ref bool var, string flag, bool defaultVar, string description)
        {
            Flags.FlagInfos.Add(flag, new FlagInfo
            {
                Description = description,
                Type = FlagType.Bool
            });

            string one = cachedArgs.Where(x => x.Equals(flag)).FirstOrDefault();

            if (one != null)
            {
                var = true;
                return;
            }

            var = defaultVar;
        }

        public static bool Parse()
        {
            string Description = string.Empty;

            string[] split = cachedArgs[0].Split('\\');

            Description = $"Flags for {split[split.Length - 1]}\n";

            foreach (var pinf in Flags.FlagInfos)
            {
                Description += $"{pinf.Key} : {pinf.Value.Type.ToString()}\n\t{pinf.Value.Description}.\n";
            }
            
            if (cachedArgs.Contains("-h") || cachedArgs.Contains("-help"))
            {
                Console.WriteLine(Description);
                return true;
            }

            return false;
        }
    }
}
