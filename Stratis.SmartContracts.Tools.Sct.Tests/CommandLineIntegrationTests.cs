using Stratis.SmartContracts.Tools.Sct.Tests.Utils;
using Xunit;

namespace Stratis.SmartContracts.Tools.Sct.Tests
{
    public class CommandLineIntegrationTests
    {
        [Fact]
        public void SingleFileCompilationWithByteCode()
        {
            using (var consoleOutput = new ConsoleOutput())
            {
                string[] args = new string[]
                {
                    "validate",
                    "Contracts/Single/DigitalLocker.cs",
                    "-sb"
                };
                Program.Main(args);

                string consoleText = consoleOutput.GetOuput();

                Assert.Contains("Compilation OK", consoleText);
                Assert.Contains("ByteCode", consoleText);
            }
        }

        [Fact]
        public void MultipleFileCompilationWithByteCode()
        {
            using (var consoleOutput = new ConsoleOutput())
            {
                string[] args = new string[]
                {
                    "validate",
                    "Contracts/Multiple",
                    "-sb"
                };
                Program.Main(args);

                string consoleText = consoleOutput.GetOuput();

                Assert.Contains("Compilation OK", consoleText);
                Assert.Contains("ByteCode", consoleText);
            }
        }
    }
}
