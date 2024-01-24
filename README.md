# Binary To Bytes

Program written in C# to simplify the conversion of binary data, such as images, into C-style array representations. This allows to generate easily readable C code that represents the binary content as an array of bytes.

## Usage

```bash
BinaryToBytes.exe <image file path> [-output <output path>] [-name <name>] [-decimal]
```

- **&lt;image file path&gt;**: Path to the binary file (e.g., an image) that you want to convert.
- **-output &lt;output path&gt;**: Optional. Specifies the output file path and name. Default is "output.txt".
- **-name &lt;name&gt;**: Optional. Specifies the name of the generated array. Default is "bytes".
- **-decimal**: Optional. Use this flag if you want to output decimal values instead of hexadecimal.

## Usage example

BinaryToBytes.exe image.png -output myarray.txt -name myImageArray -decimal

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please open an issue or submit a pull request. Make sure to adhere to the existing code style.
