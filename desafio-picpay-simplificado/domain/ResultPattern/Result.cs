namespace desafio_picpay_simplificado.domain.ResultPattern;

public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public string error_message { get; private set; }
    public T value { get; set; }

    private Result(bool isSuccess, T value, string error_message)
    {
        IsSuccess = isSuccess;
        this.value = value;
        this.error_message = error_message;
    }

    private Result(bool IsSuccess)
    {
        this.IsSuccess = IsSuccess;
    }

    public static Result<T> Success(T value) => new Result<T>(true, value, null);
    public static Result<T> Failed(string error_message) => new Result<T>(false, default, error_message);
}