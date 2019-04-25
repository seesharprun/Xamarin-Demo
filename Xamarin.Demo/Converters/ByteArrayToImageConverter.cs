﻿using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace Xamarin.Demo.Converters
{
    public class ByteArrayToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            byte[] imageAsBytes = (byte[])value;
            return ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}