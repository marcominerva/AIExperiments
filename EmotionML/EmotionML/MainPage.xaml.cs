using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace EmotionML
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private CNTKGraphModel model;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///FER-Emotion-Recognition.onnx"));
            model = await CNTKGraphModel.CreateCNTKGraphModel(file);

            await Camera.StartAsync();
            Camera.CameraHelper.FrameArrived += CameraHelper_FrameArrived;

            base.OnNavigatedTo(e);
        }

        private async void CameraHelper_FrameArrived(object sender, FrameEventArgs e)
        {
            try
            {
                var input = new CNTKGraphModelInput { Input338 = e.VideoFrame };
                var output = await model.EvaluateAsync(input);

                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    var emotions = Emotion.CreateEmotionList(output.Plus692_Output_0);
                    Results.ItemsSource = emotions;
                });
            }
            catch
            {
            }
        }
    }
}
