using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace WpfApp4
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> CbChange //заполняем Combobox
        {
            get
            {
                return Model.datalist;
            }
        }

        public string TBResult //Отображаем результат
        {
            get
            {
                return Model.count.ToString();
            }
        }

        double firstNum = 0; //первое число
        double secondNum = 0; //второе число

        public double TBFirstNum //для первого числа
        {
            set
            {
                firstNum = value;
            }
        }

        public double TBSecondNum //для второго числа
        {
            set
            {
                secondNum = value;
            }
        }

        int choice = -1; //индекс

        public int IndexSelected //находим индекс выбранного элемента
        {
            set
            {
                choice = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TBkSymb")); //событие, которое реагирует на изменение свойства
            }
        }

        public string TBkSymb //отображаем символ
        {
            get
            {
                if (choice == -1)
                {
                    return "";
                }
                else
                {
                    return Model.dataSymb[choice];
                }
            }
        }

        public RoutedCommand BtnCommand { get; set; } = new RoutedCommand();
        public CommandBinding bind;
        
        //private void OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        //{
        //    e.Handled = "0123456789,".IndexOf(e.Text) < 0;

        //}

        public void calculations(object sender, ExecutedRoutedEventArgs e)
        {

            switch (choice)
            {
                case 0:
                    Model.count = firstNum + secondNum;
                    break;

                case 1:
                    Model.count = firstNum - secondNum;
                    break;

                case 2:
                    Model.count = firstNum * secondNum;
                    break;

                case 3:
                    Model.count = firstNum / secondNum;
                    break;
            }

            PropertyChanged(this, new PropertyChangedEventArgs("TBResult"));
        }

        public ViewModel()
        {
            bind = new CommandBinding(BtnCommand);
            bind.Executed += calculations;
        }

    }
}
