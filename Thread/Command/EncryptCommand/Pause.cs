using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Thread.ViewModel;

namespace Thread.Command.EncryptCommand
{
    public class Pause : ICommand
    {
        public event EventHandler CanExecuteChanged;
        Text Text;
        public Pause(Text text)
        {
            Text = text;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        [Obsolete]
        public void Execute(object parameter)
        {
            if (Text.Encrypt_thread.ThreadState != System.Threading.ThreadState.Stopped )
            {
                Text.Encrypt_thread.Suspend();
            }
        }
    }
}
