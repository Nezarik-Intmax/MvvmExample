using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MvvmExample.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        public ICommand button1command { protected set; get; }
        public ICommand button2command { protected set; get; }
        public ICommand button3command { protected set; get; }
        public ICommand button4command { protected set; get; }
        public ICommand button5command { protected set; get; }
        public ICommand button6command { protected set; get; }
        public ICommand button7command { protected set; get; }
        public ICommand button8command { protected set; get; }
        public ICommand button9command { protected set; get; }
        public ICommand zapyatayacommand { protected set; get; }
        public ICommand deletecommand { protected set; get; }
        public ICommand slozheniecommand { protected set; get; }
        public ICommand vichitaniecommand { protected set; get; }
        public ICommand deleniecommand { protected set; get; }
        public ICommand umnozheniecommand { protected set; get; }
        public ICommand stepencommand { protected set; get; }
        public ICommand korencommand { protected set; get; }
        public ICommand smenaznakacommand { protected set; get; }

        /// <summary>
        /// выше моё
        /// ниже препода
        /// </summary>
        public ObservableCollection<double> Stack { get; set; } = new ObservableCollection<double>();

        private string inputData;
        private string myVvod;
        private bool isInputDataCorrect;
        private double inputValue;
        private Color inputDataColor;

        public string InputData{
            get => inputData;
            set{
                if (inputData != value){
                    inputData = value;
                    isInputDataCorrect = double.TryParse(InputData, out inputValue);

                    inputDataColor = IsInputDataCorrect ? Color.Black : Color.Red;

                    OnPropertyChanged(nameof(InputData));
                    OnPropertyChanged(nameof(IsInputDataCorrect));
                    OnPropertyChanged(nameof(inputDataColor));

                    PushCommand.ChangeCanExecute();
                }
            }
        }

        public string MyVvod {
            get => myVvod;
            set {
                if (myVvod != value) {
                    myVvod = value;

                    OnPropertyChanged(nameof(MyVvod));

                    PushCommand.ChangeCanExecute();
                }
            }
        }

        public bool IsInputDataCorrect => isInputDataCorrect;

        public Color InputDataColor => inputDataColor;

        public Command PushCommand { get; protected set; }
        public Command PopCommand { get; protected set; }

        public Command AddCommand { get; protected set; }
        public Command SubCommand { get; protected set; }
        public Command MulCommand { get; protected set; }
        public Command DivCommand { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CalculatorViewModel(){
            PushCommand = new Command(Push, IsPushEnabled);
            PopCommand = new Command(Pop, IsPopEnabled);
            AddCommand = new Command(Add, IsBinaryOperationEnabled);
            button1command = new Command(button1);
        }
        protected void button1(object param) {
            Stack.Insert(0, 1);
            PopCommand.ChangeCanExecute();
            AddCommand.ChangeCanExecute();
            MyVvod = 1.ToString();
        }
        protected void Push(object param){
            Stack.Insert(0, inputValue);
            PopCommand.ChangeCanExecute();

            AddCommand.ChangeCanExecute();
        }

        protected bool IsPushEnabled(object param){
            return IsInputDataCorrect;
        }

        protected void Pop(object param){
            Stack.RemoveAt(0);
            PopCommand.ChangeCanExecute();
        }

        protected bool IsPopEnabled(object param){
            return Stack.Count > 0;
        }

        protected virtual void OnPropertyChanged(string propertyName){
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void Add(object param){
            Stack.Insert(0, inputValue);
            PopCommand.ChangeCanExecute();
        }

        protected bool IsBinaryOperationEnabled(object param){
            return Stack.Count >= 2;
        }
    }
}
