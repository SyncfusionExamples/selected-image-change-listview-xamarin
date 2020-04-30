
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViewXamarin
{
    public class ViewModel
    {
        private Command<object> _itemTappedCommand;

        public Command<object> ItemTappedCommand { get => _itemTappedCommand; set => _itemTappedCommand = value; }
        public ObservableCollection<BookInfo> bookList { get; set; }
        public ViewModel()
        {
            ItemTappedCommand = new Command<object>(ItemTappedExecute);
            Populate();
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

        private void Populate()
        {
            bookList = new ObservableCollection<BookInfo>()
            {
                new BookInfo(){Name = "Adventures of Sherlock Holmes", Author= "Sir Arthur Conan Doyle"},
                new BookInfo(){Name = "Adventures of Tom Sawyer", Author= "Mark Twain"},
                new BookInfo(){Name = "Alchemist", Author= "Paulo Coelho"},
                new BookInfo(){Name = "Alice in the Wonderland", Author= "Lewis Carroll"},
                new BookInfo(){Name = "All’s Well that Ends well", Author= "William Shakespeare"},
                new BookInfo(){Name = "An American Tragedy", Author= "Theodore Dreiser"},
                new BookInfo(){Name = "An idealist view of life", Author= "Dr.S.Radhakrishnan"},
                new BookInfo(){Name = "Androcles and the Lion", Author= "George Bernard Shaw"},
                new BookInfo(){Name = "Ape and Essence", Author= "A. Huxley"},
                new BookInfo(){Name = "Apple Cart", Author= "George Bernard Shaw"},
                new BookInfo(){Name = "Arabian Nights", Author= "Sir Richard Burton"},
                new BookInfo(){Name = "Arms and the man", Author= "George Bernard Shaw"},
                new BookInfo(){Name = "Around the World in Eighty Days", Author= "Jules Verne"},
                new BookInfo(){Name = "As you like it", Author= "William Shakespeare"}
            };
        }
    }
}
