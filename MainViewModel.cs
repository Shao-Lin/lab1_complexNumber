using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ComplexNumberApp.Models;

namespace ComplexNumberApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private double _real1, _imaginary1, _real2, _imaginary2;
        private string _result;

        // Свойства с уведомлением об изменении
        public double Real1
        {
            get => _real1;
            set
            {
                if (SetField(ref _real1, value))
                {
                    // При изменении Real1 обновляем состояние команд
                    ((RelayCommand)AddCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)SubtractCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)MultiplyCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)DivideCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public double Imaginary1
        {
            get => _imaginary1;
            set
            {
                if (SetField(ref _imaginary1, value))
                {
                    // При изменении Imaginary1 обновляем состояние команд
                    ((RelayCommand)AddCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)SubtractCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)MultiplyCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)DivideCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public double Real2
        {
            get => _real2;
            set
            {
                if (SetField(ref _real2, value))
                {
                    // При изменении Real2 обновляем состояние команд
                    ((RelayCommand)AddCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)SubtractCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)MultiplyCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)DivideCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public double Imaginary2
        {
            get => _imaginary2;
            set
            {
                if (SetField(ref _imaginary2, value))
                {
                    // При изменении Imaginary2 обновляем состояние команд
                    ((RelayCommand)AddCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)SubtractCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)MultiplyCommand).RaiseCanExecuteChanged();
                    ((RelayCommand)DivideCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string Result
        {
            get => _result;
            set => SetField(ref _result, value);
        }

        // Команды
        public ICommand AddCommand { get; }
        public ICommand SubtractCommand { get; }
        public ICommand MultiplyCommand { get; }
        public ICommand DivideCommand { get; }

        public MainViewModel()
        {
            // Инициализация команд
            AddCommand = new RelayCommand(() => Calculate('+'), CanExecuteCommands);
            SubtractCommand = new RelayCommand(() => Calculate('-'), CanExecuteCommands);
            MultiplyCommand = new RelayCommand(() => Calculate('*'), CanExecuteCommands);
            DivideCommand = new RelayCommand(() => Calculate('/'), CanExecuteCommands);
        }

        // Метод для выполнения операций
        private void Calculate(char operation)
        {
            var num1 = new ComplexNumber(Real1, Imaginary1);
            var num2 = new ComplexNumber(Real2, Imaginary2);

            ComplexNumber result = operation switch
            {
                '+' => num1 + num2,
                '-' => num1 - num2,
                '*' => num1 * num2,
                '/' => num1 / num2,
                _ => new ComplexNumber(0, 0)
            };

            Result = result.ToString();
        }

        // Метод для проверки доступности команд
        private bool CanExecuteCommands()
        {
            // Пример: команды доступны, если все поля заполнены
            return !double.IsNaN(Real1) && !double.IsNaN(Imaginary1) &&
                   !double.IsNaN(Real2) && !double.IsNaN(Imaginary2);
        }

        // Реализация INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}