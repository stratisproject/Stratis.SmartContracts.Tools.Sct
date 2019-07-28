# Stratis.SmartContracts.Tools.Sct

A command-line tool for compiling and validating Stratis smart contracts.

Takes the relative path of your smart contract (.cs) file, compiles and validates the smart contract. Additionally outputs the contacts hash and bytecode when using the `-sb` flag.

## Using the Tool

From command line, navigate into the Smart Contract Tools project.

**Note:** Navigate into the `Stratis.SmartContracts.Tools.Sct` project within the cloned directory. It is located right beside the solution file and tests project directory.

```console
cd Stratis.SmartContracts.Tools.Sct/Stratis.SmartContracts.Tools.Sct
```

### Validating a Smart Contract

Using the relative path to your smart contracts project file:

```console
dotnet run validate ../../path/to/contract.cs
```

### Generating Smart Contracts Hash and Bytecode

Validate, compile, and output the contracts hash and bytecode using the same validate command but with the addition of the `-sb` flag:

```console
dotnet run validate ../../path/to/contract.cs -sb
```
