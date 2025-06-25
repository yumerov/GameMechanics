namespace Common;

using BaseException = System.Exception;

public abstract class Exception(string message) : BaseException(message);