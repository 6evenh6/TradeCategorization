using System;
using System.IO;
using Xunit;

public class ProgramTests
{
    [Fact]
    public void TestConsoleInputOutput()
    {
        // Arrange
        string input = "12/11/2020\n4\n2000000 Private 12/29/2025\n400000 Public 07/01/2020\n5000000 Public 01/02/2024\n3000000 Public 10/26/2023\n";
        string expectedOutput = "HIGHRISK\nEXPIRED\nMEDIUMRISK\nMEDIUMRISK\n";

        var stringReader = new StringReader(input);
        var stringWriter = new StringWriter();

        Console.SetIn(stringReader);  // Redireciona a entrada do Console
        Console.SetOut(stringWriter); // Redireciona a saída do Console

        // Act
        Program.Main(); // Executa o método Main

        // Assert
        string actualOutput = stringWriter.ToString().Replace("\r\n", "\n").Trim(); // Normaliza as quebras de linha
        expectedOutput = expectedOutput.Replace("\r\n", "\n").Trim(); // Normaliza a saída esperada

        Assert.Equal(expectedOutput, actualOutput);
    }
}
