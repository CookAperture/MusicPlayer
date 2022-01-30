using System;

namespace MusicPlayerBackend.Exceptions
{
    //Dialog Required
    //- FileNotFoundException
    public class ConfigFileNotFoundException : FileNotFoundException
    {
        public DialogModel DialogModel { get; }
        public ConfigFileNotFoundException(string msg, string fn, DialogModel dialogModel, Exception innerEx) : base(msg, fn, innerEx)
        {
            DialogModel = dialogModel;
        }
    }
    //- PathTooLongExcpetion
    //- DirectoryNotFoundException
    public class RootDirectoryNotFoundException : DirectoryNotFoundException
    {
        public DialogModel DialogModel { get; }
        public RootDirectoryNotFoundException(string msg, DialogModel dialogModel, Exception innerEx) : base(msg, innerEx)
        {
            DialogModel = dialogModel;
        }
    }
    //- UnauthorizedAccesException
    public class UnauthorizedIOAccessException : UnauthorizedAccessException
    {
        public DialogModel DialogModel { get; }
        public UnauthorizedIOAccessException(string msg, DialogModel dialogModel, Exception innerEx) : base(msg, innerEx)
        {
            DialogModel = dialogModel;
        }
    }

    //Notificaton with automatic action
    //- BassException
    //- CorruptFileException
    //- UnsupportedFormatException
    //- NotSupportedException
    //- JsonException
    //- IOException
    //- SecruityException

    //To be minimized by debug.assert -> if still happening raise debug.fail or exit programm with message box
    //- NotImplementedException
    //- ArgumentException
    //- OverflowException
    //- ObjectDisposedExceptio
    //- ArgumentOutOfRangeException
    //- ArgumentNullException
    //- AggregateException
    //- InvalidOperationException
    //- TaskCancelledException
}