﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestAdvices.ViewModel.Commands
{
   public class CustomCommand : ICommand
   {
      private Action<object>    _execute;
      private Predicate<object> _canExecute;

      public event EventHandler CanExecuteChanged
      {
         add    { CommandManager.RequerySuggested += value; }
         remove { CommandManager.RequerySuggested -= value; }
      }

      public CustomCommand(Action<object> execute, Predicate<object> canExecute)
      {
         _execute    = execute;
         _canExecute = canExecute;
      }

      public bool CanExecute(object parameter)
      {
         return (_canExecute == null) ? false : _canExecute(parameter);
      }

      public void Execute(object parameter)
      {
         _execute(parameter);
      }
   }
}
