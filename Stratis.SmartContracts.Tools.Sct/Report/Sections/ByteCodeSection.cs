using Stratis.SmartContracts.Core.Hashing;
using Stratis.SmartContracts.Tools.Sct.Report.Elements;
using System.Collections.Generic;

namespace Stratis.SmartContracts.Tools.Sct.Report.Sections
{
    /// <summary>
    /// Represents the section of a smart contract validation report
    /// that outputs the bytecode of a compiled contract.
    /// </summary>
    public class ByteCodeSection : IReportSection
    {
        public IEnumerable<IReportElement> CreateSection(ValidationReportData data)
        {
            if (data.CompilationSuccess && data.FormatValid && data.DeterminismValid)
            {
                yield return new ReportElement("Hash");
                yield return new ReportElement(HashHelper.Keccak256(data.CompilationBytes).ToHexString());
                yield return new NewLineElement();
                yield return new ReportElement("ByteCode");
                yield return new ReportElement(data.CompilationBytes.ToHexString());
            }
        }
    }
}