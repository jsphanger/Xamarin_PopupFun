# Xamarin_PopupFun
---

An example application that shows the use of a delegate to handle data being passed back from a pop up.

In this example we have a pop up window that prompts the user for a color selection.  The selection then gets passed back to the calling screen through a delegate allowing us to utilize the data.

## The basics

Delegate definition:

`public delegate void ColorPickerCompleteHandler(LabelProperties userchoice);`

Initiate the popup passing in the current label properties and a delegate method to handle the information coming back:

`//Pop up our color picker and when the user has officially selected a new color use that
await PopupNavigation.Instance.PushAsync(new ColorPickerView(ColorLabelProperties, (obj) => {
    ColorLabelProperties = obj;
    SetColorLabel();
}));`

Utilize the handler from our view model when ready passing back the label properties

`public ColorPickerCompleteHandler Handler { get { return handler; } set { handler = value; OnPropertyChanged(nameof(Handler)); } }`

`public ICommand SetSelectedColor => new Command(() =>
{
    Handler(ColorLabelProperties);
    ...
});
`
