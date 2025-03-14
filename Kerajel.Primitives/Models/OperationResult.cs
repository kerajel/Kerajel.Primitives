using Kerajel.Primitives.Enums;

namespace Kerajel.Primitives.Models;

public class OperationResult<T>
{
    public OperationResult()
    {
        
    }

    public OperationResult(OperationStatus operationStatus, string? errorMessage = default, Exception? exception = default)
    {
        OperationStatus = operationStatus;
        ErrorMessage = errorMessage;
        Exception = exception;
    }

    public OperationResult(OperationStatus operationStatus, string? errorMessage = default)
    {
        OperationStatus = operationStatus;
        ErrorMessage = errorMessage;
    }

    public OperationResult(OperationStatus operationStatus, T content)
    {
        OperationStatus = operationStatus;
        Content = content;
    }

    public OperationResult(OperationStatus operationStatus)
    {
        OperationStatus = operationStatus;
    }

    public T? Content { get; set; }

    public OperationStatus OperationStatus { get; set; }

    public Exception? Exception { get; set; }

    public string? ErrorMessage { get; set; }

    public bool Succeeded => OperationStatus == OperationStatus.Succeeded;
}

public class OperationResult
{
    public OperationResult(OperationStatus operationStatus, string? errorMessage = default, Exception? exception = default)
    {
        OperationStatus = operationStatus;
        ErrorMessage = errorMessage;
        Exception = exception;
    }

    public OperationResult(OperationStatus operationStatus, Exception? exception = default)
    {
        OperationStatus = operationStatus;
        Exception = exception;
    }

    public OperationResult(OperationStatus operationStatus)
    {
        OperationStatus = operationStatus;
    }

    public OperationStatus OperationStatus { get; set; }

    public string? ErrorMessage { get; set; }

    public Exception? Exception { get; set; }

    public bool Succeeded => OperationStatus == OperationStatus.Succeeded;

    public static OperationResult FromFaulted<T>(OperationResult<T> operationResult)
    {
        return new OperationResult(OperationStatus.Faulted, operationResult.ErrorMessage, operationResult.Exception);
    }

    public static OperationResult Faulted(string errorMessage, Exception? ex = default)
    {
        return new OperationResult(OperationStatus.Faulted, errorMessage, ex);
    }
}