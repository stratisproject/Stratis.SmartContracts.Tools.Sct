using McMaster.Extensions.CommandLineUtils;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Stratis.SmartContracts.Tools.Sct.Build
{
    [Command(Description = "Builds a smart contract and outputs a dll. For testing purposes.")]
    [HelpOption]
    class Builder
    {
        [Argument(
            0,
            Description = "The file containing the source code of the smart contract to deploy",
            Name = "<File>")]
        [Required]
        [FileExists]
        public string InputFile { get; }

        [Argument(
            1,
            Description = "The destination path",
            Name = "<Path>")]
        [Required]
        public string OutputPath { get; }

        [Option(
            "-params|--params",
            CommandOptionType.MultipleValue,
            Description = "Params to be passed to the constructor when instantiating the contract")]
        public string[] Params { get; }

        public int OnExecute(CommandLineApplication app, IConsole console)
        {
            console.WriteLine();
            console.WriteLine("Smart Contract Builder");
            console.WriteLine();

            if (File.Exists(this.OutputPath))
            {
                console.WriteLine($"Output file already exists!");
                return 1;
            }

            string source = SourceLoader.GetSourceFromFileOrDirectoryName(this.InputFile, console);

            if (source == null)
            {
                return 1;
            }

            ValidationServiceResult validationResult = new ValidatorService().Validate(this.InputFile, source, console, this.Params);
            if (!validationResult.Success)
                return 1;
            else
                console.WriteLine("Validation passed!");

            this.WriteDll(validationResult.CompilationResult.Compilation);
            console.WriteLine($"File {this.OutputPath} written.");

            return 1;
        }

        private void WriteDll(byte[] compilation)
        {
            using (FileStream sw = File.OpenWrite(this.OutputPath))
            {
                sw.Write(compilation, 0, compilation.Length);
            }
        }
    }
}