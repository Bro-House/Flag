using System;
using System.Linq;

namespace Flags
{
    public class Flag
    {
        private static string[] cachedArgs = Environment.GetCommandLineArgs();

        internal static string GetFlag(string flag)
        {
            return cachedArgs.Where(x =>
            {
                if (x.StartsWith("-") && x.Contains('='))
                {
                    return x.Split('=')[0].Substring(1) == flag;
                }
                return false;
            }).FirstOrDefault();
        }

        public static void StringVar(ref string var, string flag, string defaultVar, string description)
        {
            Flags.FlagInfos.Add(flag, new FlagInfo
            {
                Description = description,
                Type = FlagType.String
            });

            string one = GetFlag(flag);

            if (one != null)
            {
                var = one.Split('=')[1];
                return;
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

            string one = GetFlag(flag);

            if (one != null)
            {
                var = Convert.ToInt32(one.Split('=')[1].Replace('.', ','));
                return;
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
            
            string one = GetFlag(flag);

            if (one != null)
            {
                var = Convert.ToSingle(one.Split('=')[1].Replace('.', ','));
                return;
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

            string one = cachedArgs.Where(x =>
            {
                if (x.StartsWith("-"))
                {
                    return x.Substring(1) == flag;
                }

                return false;
            }).FirstOrDefault();

            if (one != null)
            {
                var = true;
                return;
            }

            var = defaultVar;
        }

        public static void Parse()
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
                Environment.Exit(-1);
            }
        }
    }
}
