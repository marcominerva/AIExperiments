using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Text;
using Windows.UI.Xaml.Data;

namespace EmotionML.Converters
{
    public class EmotionScoreToFontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var fontWeight = FontWeights.Normal;

            if (value is bool isBest && isBest)
            {
                fontWeight = FontWeights.Bold;
            }

            return fontWeight;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
