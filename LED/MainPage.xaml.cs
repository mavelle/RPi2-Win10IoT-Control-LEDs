using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Gpio;
using Windows.UI;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LED
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        GpioController gpio;
        GpioPin redpin;
        GpioPin yellowpin;
        GpioPin greenpin;

        public MainPage()
        {
            this.InitializeComponent();
            InitGPIO();
        }

        private void InitGPIO()
        {
            gpio = GpioController.GetDefault();

            if (gpio == null)
                return;

            redpin = gpio.OpenPin(0);      // GPIO #0
            yellowpin = gpio.OpenPin(5);   // GPIO #5
            greenpin = gpio.OpenPin(6);    // GPIO #6

        }
        
        private void turnOffAllLED()
        {
            redpin.Write(GpioPinValue.Low);
            yellowpin.Write(GpioPinValue.Low);
            greenpin.Write(GpioPinValue.Low);

            redpin.SetDriveMode(GpioPinDriveMode.Output);
            yellowpin.SetDriveMode(GpioPinDriveMode.Output);
            greenpin.SetDriveMode(GpioPinDriveMode.Output);

            redBtn.Background = new SolidColorBrush(Colors.Transparent);
            yellowBtn.Background = new SolidColorBrush(Colors.Transparent);
            greenBtn.Background = new SolidColorBrush(Colors.Transparent);
        }
        
        private void redBtn_Click(object sender, RoutedEventArgs e)
        {
            turnOffAllLED();
            redpin.Write(GpioPinValue.High);
            redpin.SetDriveMode(GpioPinDriveMode.Output);

            redBtn.Background = new SolidColorBrush(Colors.Red);
        }

        private void yellowBtn_Click(object sender, RoutedEventArgs e)
        {
            turnOffAllLED();
            yellowpin.Write(GpioPinValue.High);
            yellowpin.SetDriveMode(GpioPinDriveMode.Output);

            yellowBtn.Background = new SolidColorBrush(Colors.Yellow);
        }

        private void greenBtn_Click(object sender, RoutedEventArgs e)
        {
            turnOffAllLED();
            greenpin.Write(GpioPinValue.High);
            greenpin.SetDriveMode(GpioPinDriveMode.Output);

            greenBtn.Background = new SolidColorBrush(Colors.Green);
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            turnOffAllLED();
        }
    }
}
