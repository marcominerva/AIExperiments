using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Media;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.AI.MachineLearning;

namespace AlarmML
{
    public sealed class ModelInput
    {
        public ImageFeatureValue data; // BitmapPixelFormat: Bgra8, BitmapAlphaMode: Premultiplied, width: 227, height: 227
    }

    public sealed class ModelOutput
    {
        public TensorString classLabel; // shape(-1,1)
        public IList<IDictionary<string,float>> loss;
    }

    public sealed class Model
    {
        private LearningModel model;
        private LearningModelSession session;
        private LearningModelBinding binding;

        public static async Task<Model> CreateFromStreamAsync(IRandomAccessStreamReference stream)
        {
            var learningModel = new Model();
            learningModel.model = await LearningModel.LoadFromStreamAsync(stream);
            learningModel.session = new LearningModelSession(learningModel.model);
            learningModel.binding = new LearningModelBinding(learningModel.session);

            return learningModel;
        }

        public async Task<ModelOutput> EvaluateAsync(ModelInput input)
        {
            binding.Bind("data", input.data);
            var result = await session.EvaluateAsync(binding, "0");
            var output = new ModelOutput
            {
                classLabel = result.Outputs["classLabel"] as TensorString,
                loss = result.Outputs["loss"] as IList<IDictionary<string, float>>
            };

            return output;
        }
    }
}
