using System.Runtime.InteropServices;

namespace LibDynamite_cs {
/// <summary>
/// .NET wrapper for libdynamite.
/// </summary>
public static class LibDynamite {
    /// <summary>
    /// Decompress binary data using Dynamite's PKWARE decompression library.
    /// </summary>
    /// <param name="input">The compressed data to be decompressed.</param>
    /// <param name="output">The buffer to write the decompressed data to. If this is smaller than the actual decompressed data, this will cause a WriteError.</param>
    /// <exception cref="DynamiteException">If Dynamite returned a non-success result. See DynamiteException.Result for the actual error type.</exception>
    public static void Explode(byte[] input, byte[] output) {
        int intResult = dynamitewrapper_explode(input, input.Length, output, output.Length);
        DynamiteResult result = (DynamiteResult) intResult;
        if (result != DynamiteResult.Success) {
            throw new DynamiteException(result);
        }
    }
    
    [DllImport("libdynamite.so", EntryPoint = "dynamitewrapper_explode")]
    private static extern int dynamitewrapper_explode(byte[] arr, int size, byte[] dest, int dest_size);

    [DllImport("libdynamite.so", EntryPoint = "dynamite_explode")]
    private static extern int dynamite_explode(int reader, int writer, int cookie);
}
}