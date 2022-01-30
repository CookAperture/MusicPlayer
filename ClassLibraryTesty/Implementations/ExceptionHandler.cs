using MusicPlayerBackend.Contracts;
using MusicPlayerBackend.Exceptions;

namespace MusicPlayerBackend
{
    public class ExceptionHandler : IExceptionHandler
    {
        public event IExceptionHandler.OnDialog onDialog;
        public event IExceptionHandler.OnFatal onFatal;

        private void HandleException(ConfigFileNotFoundException ex)
        {
            onDialog.Invoke(ex.DialogModel);
        }

        private void HandleException(UnauthorizedIOAccessException ex)
        {
            onDialog.Invoke(ex.DialogModel);
        }

        private void HandleException(RootDirectoryNotFoundException ex)
        {
            onDialog.Invoke(ex.DialogModel);
        }

        public void HandleException(Exception exception)
        {
            switch (exception)
            {
                case ConfigFileNotFoundException ex:
                    HandleException(ex);
                    break;
                case UnauthorizedIOAccessException ex:
                    HandleException(ex);
                    break;
                case RootDirectoryNotFoundException ex:
                    HandleException(ex);
                    break;
                case Exception ex:
                    onFatal.Invoke();
                    break;
                default:
                    throw new Exception("Unkown Exception!");
            }
        }
    }
}