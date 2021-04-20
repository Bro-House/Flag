# Flag
Command Line Arguments Helper Library, useful for quick tools!

# Usage
```cs
int age = 0;
float ratio = 1.0f;
string name = string.Empty;
bool flag = false;

Flag.IntVar(ref age, "-age", 18, "Set the age");
Flag.FloatVar(ref ratio, "-ratio", 1.0f, "Set the ratio");
Flag.StringVar(ref name, "-name", "syne", "Set the name");
Flag.BoolVar(ref flag, "-flag", false, "Set flag");

Flag.Parse();
```
