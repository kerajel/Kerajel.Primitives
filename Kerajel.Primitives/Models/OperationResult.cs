using Kerajel.Primitives.Enums;

namespace Kerajel.Primitives.Models;

public class OperationResult<T> : OperationResultBase
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

    public static OperationResult<T> Faulted(Exception ex)
    {
        return new OperationResult<T>(OperationStatus.Faulted, ex.Message, ex);
    }

    public static OperationResult<T> Succeeded(T result)
    {
        return new()
        {
            Content = result,
            OperationStatus = OperationStatus.Succeeded,
        };
    }
}

public class OperationResult : OperationResultBase
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

    public static OperationResult FromFaulted<T>(OperationResult<T> operationResult)
    {
        return new OperationResult(OperationStatus.Faulted, operationResult.ErrorMessage, operationResult.Exception);
    }

    public static OperationResult FromFaulted(OperationResult operationResult)
    {
        return new OperationResult(OperationStatus.Faulted, operationResult.ErrorMessage, operationResult.Exception);
    }
}

public abstract class OperationResultBase
{
    public OperationStatus OperationStatus { get; set; }

    public Exception? Exception { get; set; }

    public string? ErrorMessage { get; set; }

    public bool IsSuccessful => OperationStatus == OperationStatus.Succeeded;
}