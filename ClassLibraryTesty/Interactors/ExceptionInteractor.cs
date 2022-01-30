using MusicPlayerBackend.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend
{
    public class ExceptionInteractor : IExceptionInteractor
    {
        public event IExceptionInteractor.OnDialog onDialog;
        public event IExceptionInteractor.OnFatal onFatal;

        public IExceptionHandler ExceptionHandler { get; set; }
        
        public ExceptionInteractor(IExceptionHandler exceptionHandler)
        {
            ExceptionHandler = exceptionHandler;
            ExceptionHandler.onDialog += (DialogModel dialog) => onDialog.Invoke(dialog);
            ExceptionHandler.onFatal += () => onFatal.Invoke();
        }

        public void HandleException(Exception exception)
        {
            ExceptionHandler.HandleException(exception);
        }
    }
}
