﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNC.WPF.Command
{
    internal class LambdaCommand : Command
    {

        // если поля помечены readonly, то они будут работать быстрее
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        // в конструкторе надо получить два делегата Action и Func
        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _canExecute = CanExecute;
        }

        public override bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true;

        public override void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
