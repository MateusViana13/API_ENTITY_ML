﻿namespace API_ENTITY_FRAMEWORK.MiddleWare.Exceptions;

public class DataNotFoundException : Exception
{
    public DataNotFoundException(string message) : base(message)
    {}

    public DataNotFoundException(string message, Exception innerException) : base(message, innerException)
    {}

    public DataNotFoundException()
    {}
}
