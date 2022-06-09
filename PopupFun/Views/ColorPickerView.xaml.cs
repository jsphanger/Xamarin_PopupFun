
using ColorPicker.BaseClasses.ColorPickerEventArgs;
using PopupFun.Delegates;
using PopupFun.Models;
using PopupFun.ViewModels;

namespace PopupFun.Views
{
    public partial class ColorPickerView : Rg.Plugins.Popup.Pages.PopupPage
    {
        public ColorPickerView(LabelProperties currentProperties, ColorPickerCompleteHandler handler)
        {
            InitializeComponent();

            BindingContext = new ColorPickerViewModel() { ColorLabelProperties = currentProperties, Handler = handler };
        }

        public void ColorChangedHandler(object sender, ColorChangedEventArgs e)
        {
            var viewModel = (ColorPickerViewModel)BindingContext;
            viewModel.ColorLabelProperties.TextColor = e.NewColor;
        }
    }
}
