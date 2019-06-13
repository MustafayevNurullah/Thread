using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Thread.ViewModel;

namespace Thread.Command.DecryptCommand
{
    public class Stop : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Text text;
        public Stop(Text text)
        {
            this.text = text;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (text.Dectypt_thread.ThreadState != System.Threading.ThreadState.Aborted)
            {
                text.Dectypt_thread.Resume();
                text.Dectypt_thread.Abort();
            }
        }
    }
}
