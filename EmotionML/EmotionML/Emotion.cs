using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmotionML
{
    public class Emotion
    {
        public string Name { get; set; }

        public float Score { get; set; }

        public bool IsBest { get; set; }

        public static IEnumerable<Emotion> CreateEmotionList(IList<float> values)
        {
            var list = new List<Emotion>()
            {
                new Emotion { Name = "Neutral", Score = values[0] },
                new Emotion { Name = "Happiness", Score = values[1] },
                new Emotion { Name = "Surprise", Score = values[2] },
                new Emotion { Name = "Sadness", Score = values[3] },
                new Emotion { Name = "Anger", Score = values[4] },
                new Emotion { Name = "Disgust", Score = values[5] },
                new Emotion { Name = "Fear", Score = values[6] },
                new Emotion { Name = "Contempt", Score = values[7] }
            };

            list.ForEach(emotion => emotion.IsBest = emotion.Score == values.Max());
            return list;
        }
    }
}
