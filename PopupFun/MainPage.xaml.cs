using System;
using PopupFun.Models;
using PopupFun.Views;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace PopupFun
{
    public partial class MainPage : ContentPage
    {
        LabelProperties ColorLabelProperties = new LabelProperties()
        {
            Text = "This is the currently selected color!",
            TextColor = Color.Green
        };

        public MainPage()
        {
            InitializeComponent();

            SetColorLabel();
        }

        async void btnColorPicker_Clicked(object sender, EventArgs e)
        {
            //Pop up our color picker and when the user has officially selected a new color use that
            await PopupNavigation.Instance.PushAsync(new ColorPickerView(ColorLabelProperties, (obj) => {
                ColorLabelProperties = obj;
                SetColorLabel();
            }));
        }
        private void SetColorLabel()
        {
            lblColorSentence.Text = ColorLabelProperties.Text;
            lblColorSentence.TextColor = ColorLabelProperties.TextColor;
        }
    }
}
