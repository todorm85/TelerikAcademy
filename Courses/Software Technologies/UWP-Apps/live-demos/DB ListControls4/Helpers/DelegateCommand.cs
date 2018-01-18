﻿using System;
using System.Windows.Input;

namespace UWPControls.Helpers
{
    internal class DelegateCommand : ICommand
    {
        private Action execute;

        public DelegateCommand(Action execute)
        {
            this.execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.execute();
        }
    }
}