using McMaster.Extensions.CommandLineUtils;
using Stratis.SmartContracts.CLR.Compilation;
using System.IO;

namespace Stratis.SmartContracts.Tools.Sct
{
    /// <summary>
    /// Loads source for the given file or directory.
    /// </summary>
    public static class CompilationLoader
    {

        public static ContractCompilationResult CompileFromFileOrDirectoryName(string fileOrDirectoryName, IConsole console = null)
        {
            if (File.Exists(fileOrDirectoryName))
            {
                console?.WriteLine($"Compiling {fileOrDirectoryName}...");
                return ContractCompiler.CompileFile(fileOrDirectoryName);
            }

            if (Directory.Exists(fileOrDirectoryName))
            {
                console?.WriteLine($"Compiling directory {fileOrDirectoryName}...");
                return ContractCompiler.CompileDirectory(fileOrDirectoryName);
            }

            console?.WriteLine($"No file or directory {fileOrDirectoryName} exists.");
            return null;
        }
    }
}
