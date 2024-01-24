using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args) {
        if (args.Length == 0) {
            Console.WriteLine("Usage: BinaryToBytes.exe <image file path> [-output <output path>] [-name <name>] [-decimal]");
            return;
        }

        try {
            string inputFilePath = args[0];
            byte[] imageBytes = File.ReadAllBytes(inputFilePath);

            string outputFilePath = GetOptionValue(args, "-output") ?? "output.txt";
            string outputName = GetOptionValue(args, "-name") ?? "bytes";

            bool useDecimal = args.Contains("-decimal");

            string arrayString;
            if (useDecimal)
                arrayString = BytesToArrayString(imageBytes, outputName, true);
            else
                arrayString = BytesToArrayString(imageBytes, outputName, false);

            File.WriteAllText(outputFilePath, arrayString);

            Console.WriteLine("File saved to: {0}", outputFilePath);
        }
        catch (Exception ex) {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    static string GetOptionValue(string[] args, string option) {
        int index = Array.IndexOf(args, option);
        if (index != -1 && index + 1 < args.Length)
            return args[index + 1];

        return null;
    }

    static string BytesToArrayString(byte[] bytes, string name, bool useDecimal) {
        StringBuilder arrayBuilder = new StringBuilder();

        arrayBuilder.Append("unsigned ");
        if (useDecimal)
            arrayBuilder.Append("int ");
        else
            arrayBuilder.Append("char ");

        arrayBuilder.Append(name);
        arrayBuilder.Append("[] = {");

        IEnumerable<string> byteStrings;

        if (useDecimal)
            byteStrings = bytes.Select(b => b.ToString());
        else
            byteStrings = bytes.Select(b => "0x" + b.ToString("X2"));

        arrayBuilder.Append("\n    ");
        arrayBuilder.Append(string.Join(", ", byteStrings));

        arrayBuilder.Append("\n};");

        return arrayBuilder.ToString();
    }
}
