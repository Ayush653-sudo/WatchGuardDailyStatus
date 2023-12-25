using System;

public sealed class Logger
{
    private Logger() { }

    private static Logger myInstance;

    public static Logger getInstance()
    {
        if (myInstance == null)
        {
            myInstance = new Logger();
        }

        return myInstance;
    }

}
