using System;

namespace LibDynamite_cs {

/// <summary>
/// Exception to indicate a non-
/// </summary>
public class DynamiteException : Exception {
    public readonly DynamiteResult Result;

    public DynamiteException(DynamiteResult result) : base($"Dynamite error: {result}") {
        Result = result;
    }
}
}