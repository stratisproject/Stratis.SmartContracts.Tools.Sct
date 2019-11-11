using McMaster.Extensions.CommandLineUtils;
using System;
using System.IO;

namespace Stratis.SmartContracts.Tools.Sct
{
    /// <summary>
    /// Loads source for the given file or directory.
    /// </summary>
    public static class SourceLoader
    {

        public static string GetSourceFromFileOrDirectoryName(string fileOrDirectoryName, IConsole console = null)
        {
            if (File.Exists(fileOrDirectoryName))
            {
                return GetSourceFromFileName(fileOrDirectoryName, console);
            }

            if (Directory.Exists(fileOrDirectoryName))
            {
                return GetSourceFromDirectoryName(fileOrDirectoryName, console);
            }

            console?.WriteLine($"{fileOrDirectoryName} does not exist as a file or directory.");
            return null;
        }

        private static string GetSourceFromFileName(string fileName, IConsole console = null)
        {
            console?.WriteLine($"Reading {fileName}...");

            string source;
            using (var sr = new StreamReader(File.OpenRead(fileName)))
            {
                source = sr.ReadToEnd();
            }

            console?.WriteLine($"Read {fileName} OK!");
            console?.WriteLine();

            if (string.IsNullOrWhiteSpace(source))
            {
                console?.WriteLine($"Empty file at {fileName}");
                return null;
            }

            return source;
        }

        private static string GetSourceFromDirectoryName(string directoryName, IConsole console = null)
        {
            throw new NotImplementedException();
        }
    }
}
