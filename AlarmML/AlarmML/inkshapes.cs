using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Media;
using Windows.Storage;
using Windows.AI.MachineLearning.Preview;

// 2371a82d-c7ee-4e3e-95ce-12b84ca1681b_9a83b0ef-9ca1-4d5f-9929-9340f04571dd

namespace AlarmML
{
    public sealed class _x0032_371a82d_x002D_c7ee_x002D_4e3e_x002D_95ce_x002D_12b84ca1681b_9a83b0ef_x002D_9ca1_x002D_4d5f_x002D_9929_x002D_9340f04571ddModelInput
    {
        public VideoFrame data { get; set; }
    }

    public sealed class _x0032_371a82d_x002D_c7ee_x002D_4e3e_x002D_95ce_x002D_12b84ca1681b_9a83b0ef_x002D_9ca1_x002D_4d5f_x002D_9929_x002D_9340f04571ddModelOutput
    {
        public IList<string> classLabel { get; set; }
        public IDictionary<string, float> loss { get; set; }
        public _x0032_371a82d_x002D_c7ee_x002D_4e3e_x002D_95ce_x002D_12b84ca1681b_9a83b0ef_x002D_9ca1_x002D_4d5f_x002D_9929_x002D_9340f04571ddModelOutput()
        {
            this.classLabel = new List<string>();
            this.loss = new Dictionary<string, float>()
            {
                { "fish", float.NaN },
                { "flower", float.NaN },
                { "stick_figure", float.NaN },
            };
        }
    }

    public sealed class _x0032_371a82d_x002D_c7ee_x002D_4e3e_x002D_95ce_x002D_12b84ca1681b_9a83b0ef_x002D_9ca1_x002D_4d5f_x002D_9929_x002D_9340f04571ddModel
    {
        private LearningModelPreview learningModel;
        public static async Task<_x0032_371a82d_x002D_c7ee_x002D_4e3e_x002D_95ce_x002D_12b84ca1681b_9a83b0ef_x002D_9ca1_x002D_4d5f_x002D_9929_x002D_9340f04571ddModel> Create_x0032_371a82d_x002D_c7ee_x002D_4e3e_x002D_95ce_x002D_12b84ca1681b_9a83b0ef_x002D_9ca1_x002D_4d5f_x002D_9929_x002D_9340f04571ddModel(StorageFile file)
        {
            LearningModelPreview learningModel = await LearningModelPreview.LoadModelFromStorageFileAsync(file);
            _x0032_371a82d_x002D_c7ee_x002D_4e3e_x002D_95ce_x002D_12b84ca1681b_9a83b0ef_x002D_9ca1_x002D_4d5f_x002D_9929_x002D_9340f04571ddModel model = new _x0032_371a82d_x002D_c7ee_x002D_4e3e_x002D_95ce_x002D_12b84ca1681b_9a83b0ef_x002D_9ca1_x002D_4d5f_x002D_9929_x002D_9340f04571ddModel();
            model.learningModel = learningModel;
            return model;
        }
        public async Task<_x0032_371a82d_x002D_c7ee_x002D_4e3e_x002D_95ce_x002D_12b84ca1681b_9a83b0ef_x002D_9ca1_x002D_4d5f_x002D_9929_x002D_9340f04571ddModelOutput> EvaluateAsync(_x0032_371a82d_x002D_c7ee_x002D_4e3e_x002D_95ce_x002D_12b84ca1681b_9a83b0ef_x002D_9ca1_x002D_4d5f_x002D_9929_x002D_9340f04571ddModelInput input) {
            _x0032_371a82d_x002D_c7ee_x002D_4e3e_x002D_95ce_x002D_12b84ca1681b_9a83b0ef_x002D_9ca1_x002D_4d5f_x002D_9929_x002D_9340f04571ddModelOutput output = new _x0032_371a82d_x002D_c7ee_x002D_4e3e_x002D_95ce_x002D_12b84ca1681b_9a83b0ef_x002D_9ca1_x002D_4d5f_x002D_9929_x002D_9340f04571ddModelOutput();
            LearningModelBindingPreview binding = new LearningModelBindingPreview(learningModel);
            binding.Bind("data", input.data);
            binding.Bind("classLabel", output.classLabel);
            binding.Bind("loss", output.loss);
            LearningModelEvaluationResultPreview evalResult = await learningModel.EvaluateAsync(binding, string.Empty);
            return output;
        }
    }
}
