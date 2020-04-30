# How to change selected image in Xamarin.Forms ListView (SfListView)

You can change the selected item image in Xamarin.Forms [SfListView](https://help.syncfusion.com/xamarin/listview/overview?) using [Converters](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/data-binding/converters).

You can also refer the following article.

https://www.syncfusion.com/kb/11486/how-to-change-selected-image-in-xamarin-forms-listview-sflistview

**C#**

Defining **IsSelected** property in **Model** with [INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netcore-3.1).
``` c#
namespace ListViewXamarin
{
    public class BookInfo : INotifyPropertyChanged
    {
        private bool _isSelected = false;
 
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
 
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
 
        }
    }
}
```
**C#**

Updating the **IsSelected** value in [TapCommand](https://help.syncfusion.com/cr/xamarin/Syncfusion.SfListView.XForms~Syncfusion.ListView.XForms.SfListView~TapCommand.html?) execute method.
``` c#
namespace ListViewXamarin
{
    public class ViewModel
    {
        private Command<object> _itemTappedCommand;
 
        public Command<object> ItemTappedCommand { get => _itemTappedCommand; set => _itemTappedCommand = value; }
 
        public ViewModel()
        {
            ItemTappedCommand = new Command<object>(ItemTappedExecute);
        }
 
        private void ItemTappedExecute(object obj)
        {
            bool IsSelected = ((obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData as BookInfo).IsSelected;
 
            if (IsSelected)
                return;
 
            foreach (var item in bookList)
            {
                item.IsSelected = false;
            }
            ((obj as Syncfusion.ListView.XForms.ItemTappedEventArgs).ItemData as BookInfo).IsSelected = true;
        }
 
    }
}
```
**C#**

Setting Image based on the **IsSelected** value in **Converter**.
``` c#
namespace ListViewXamarin
{
    class Converter : IValueConverter
    {
 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? ImageSource.FromResource("ListViewXamarin.Images.Checked.png") : ImageSource.FromResource("ListViewXamarin.Images.Unchecked.png");
        }
 
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
```
**XAML**

Binding **IsSelected** Property and converter to Image Source.
``` xml
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:ListViewXamarin"
             xmlns:syncfusion="clr-namespace:Syncfusion.ListView.XForms;assembly=Syncfusion.SfListView.XForms"
             x:Class="ListViewXamarin.MainPage" Padding="{OnPlatform iOS='0,40,0,0'}">
    <ContentPage.Resources>
        <ResourceDictionary>
            <local:Converter x:Key="converter"/>
        </ResourceDictionary>
    </ContentPage.Resources>
 
    <ContentPage.Content>
        <syncfusion:SfListView ItemsSource="{Binding bookList}" x:Name="listView" ItemSize="60" SelectionMode="Single"
                               AllowKeyboardNavigation="True" TapCommand="{Binding ItemTappedCommand}">
            <syncfusion:SfListView.ItemTemplate>
                <DataTemplate>
                    ...
                    <Image Grid.Column="1" x:Name="selectionImage" HeightRequest="30" WidthRequest="30" VerticalOptions="Center" Margin="20,5"
                               Source="{Binding IsSelected, Converter={StaticResource converter}}" HorizontalOptions="End" />
                    ...
                </DataTemplate>
            </syncfusion:SfListView.ItemTemplate>
        </syncfusion:SfListView>
    </ContentPage.Content>
 
</ContentPage>
```
**Output**

![SelectedImageChange](https://github.com/SyncfusionExamples/selected-image-change-listview-xamarin/blob/master/ScreenShots/SelectedImageChange.gif)
