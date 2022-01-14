using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace MvvmExample.ViewModels
{
    public class RgbViewModel : INotifyPropertyChanged
    {
        double red, green, blue;
        private Color color;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Color Color
        {
            get => color;

            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged(nameof(Color));

                    R = Color.R;
                    G = Color.G;
                    B = Color.B;
                }
            }
        }

        public double R
        {
            get => red;
            set
            {
                if (red != value)
                {
                    red = value;
                    OnPropertyChanged(nameof(R));
                    SetNewColor();
                }
            }
        }

        public double G
        {
            get => green;
            set
            {
                if (green != value)
                {
                    green = value;
                    OnPropertyChanged(nameof(G));
                    SetNewColor();
                }
            }
        }

        public double B
        {
            get => blue;
            set
            {
                if (blue != value)
                {
                    blue = value;
                    OnPropertyChanged(nameof(B));
                    SetNewColor();
                }
            }
        }

        private void SetNewColor()
        {
            Color = Color.FromRgb(red, green, blue);
        }

    }
}
