using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace MultiLauncher {
  class LaunchProfile {
    private static readonly string SETTINGS_FILE = Process.GetCurrentProcess().ProcessName + ".xml";

    private const string XML_PROFILE_ARRAY = "Profiles";
    private const string XML_PROFILE = "Profile";
    private const string XML_NAME = "Name";
    private const string XML_PROGRAM = "Program";
    private const string XML_ARGS = "Arguments";
    private const string XML_SKIP = "SkipFirstArg";
    private const string ARG_REPLACE = "%args%";

    public string Name = "Unknown";
    public string Program = "";
    public string Args = "";

    public static List<LaunchProfile> LoadProfiles() {
      List<LaunchProfile> allProfs = new List<LaunchProfile>();
      if (!File.Exists(SETTINGS_FILE)) {
        CreateDemoFile();
      }

      string[] allArgs = Environment.GetCommandLineArgs();
      // Always skip the current executable
      string fullArgString = string.Join(" ", allArgs.Skip(1));
      string skippedArgString = string.Join(" ", allArgs.Skip(2));

      try {
        foreach (XElement profile in XElement.Load(SETTINGS_FILE).Elements()) {
          LaunchProfile newProf = new LaunchProfile();
          bool skipFirst = true;
          foreach (XElement child in profile.Elements()) {
            if (child.Name == XML_NAME) {
              newProf.Name = child.Value;
            } else if (child.Name == XML_PROGRAM) {
              newProf.Program = child.Value;
            } else if (child.Name == XML_ARGS) {
              newProf.Args = child.Value;
            } else if (child.Name == XML_SKIP) {
              skipFirst = bool.Parse(child.Value);
            }
          }

          newProf.Args = newProf.Args.Replace(
            ARG_REPLACE,
            skipFirst ? skippedArgString : fullArgString
          );

          allProfs.Add(newProf);

        }
      } catch (XmlException) { }

      return allProfs;
    }

    public static void CreateDemoFile() {
      using (XmlWriter writer = XmlWriter.Create(SETTINGS_FILE, new XmlWriterSettings() {
        Indent = true,
        NewLineOnAttributes = true
      })) {
        writer.WriteStartDocument();
        writer.WriteStartElement(XML_PROFILE_ARRAY);
        writer.WriteStartElement(XML_PROFILE);
        writer.WriteElementString(XML_NAME, "Example Profile");
        writer.WriteElementString(XML_PROGRAM, "cmd");
        writer.WriteElementString(XML_ARGS, $"/K \"echo {ARG_REPLACE}\"");
        writer.WriteElementString(XML_SKIP, "True");
        writer.WriteEndElement();
        writer.WriteEndElement();
        writer.WriteEndDocument();
      }
    }

    public void Launch() {
      // cmd /C start MultiLauncher.exe %command%
      new Process() {
        StartInfo = new ProcessStartInfo() {
          FileName = Program,
          Arguments = Args
        }
      }.Start();
    }
  }
}
