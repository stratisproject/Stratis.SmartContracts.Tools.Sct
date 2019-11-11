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
        /// <summary>
        /// Compile a file or directory, returning a ContractCompilationResult.
        /// </summary>
        /// <returns>ContractCompilationResult if the file exists, and null otherwise.</returns>
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

            // TODO: Ideally this guy would return a ContractCompilationResult too but dealing with Diagnostics is a nightmare. This works for now.
            console?.WriteLine($"No file or directory {fileOrDirectoryName} exists.");
            return null;
        }
    }
}
