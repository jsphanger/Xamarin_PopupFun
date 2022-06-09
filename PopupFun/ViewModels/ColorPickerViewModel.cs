using System.Windows.Input;
using PopupFun.Delegates;
using PopupFun.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace PopupFun.ViewModels
{
    public class ColorPickerViewModel : BaseViewModel
    {
        private LabelProperties colorLabelProperties;
        private ColorPickerCompleteHandler handler;

        public LabelProperties ColorLabelProperties { get { return colorLabelProperties; } set { colorLabelProperties = value; OnPropertyChanged(nameof(ColorLabelProperties)); } }
        public ColorPickerCompleteHandler Handler { get { return handler; } set { handler = value; OnPropertyChanged(nameof(Handler)); } }

        public ICommand CloseWindow => new Command(ClosePopup);
        public ICommand SetSelectedColor => new Command(() =>
        {
            Handler(ColorLabelProperties);

            ClosePopup();
        });

        public ColorPickerViewModel() { }

        private async void ClosePopup()
        {
            if (PopupNavigation.Instance.PopupStack != null && PopupNavigation.Instance.PopupStack.Count > 0)
                await PopupNavigation.Instance.PopAsync();
        }
    }
}
