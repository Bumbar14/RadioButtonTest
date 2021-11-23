using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using FreshMvvm;
using RadioButtonTest.Model;
using RadioButtonTest.Services;
using Xamarin.Forms;
using FreshMvvm.Popups;
using System.Linq;
using System.Threading.Tasks;

namespace RadioButtonTest
{
    class FirstPageModel : FreshBasePageModel
    {
        public async override void Init(object initData)
        {
            await Refresh();
           
           
            RaisePropertyChanged("Categories");
            
        }
        void ListenToPopup()
        {
            MessagingCenter.Subscribe<SecondPageModel>(this, "ID", async (p) =>
            {
                await Refresh();
            });
        }
        async Task Refresh()
        {
            DatabaseConnection database = await DatabaseConnection.Instance;
            var c = await database.GetAllCategories();
            Categories = new ObservableCollection<Category>(c);
            Categories.Add(new Category() { CategoryID = 1, CategoryName = "Added with code 1", FlowType = "1" });
            Categories.Add(new Category() { CategoryID = 2, CategoryName = "Added with code 2", FlowType = "2" });
            Categories.Add(new Category() { CategoryID = 3, CategoryName = "Added with code 3", FlowType = "1" });
            Categories.Add(new Category() { CategoryID = 4, CategoryName = "Added with code 4 ", FlowType = "0" });
        }
        public Command GoToTestPage => new Command(async () =>
            {
                ListenToPopup();
                await CoreMethods.PushPopupPageModel<SecondPageModel>(ChosenObject);
            });
        
        public Command AddNewWithCode => new Command(async () =>
        {
            int maxID;
            if (Categories.Count == 0)
            {
                maxID = 1;
            }
            else
            {
                maxID = Categories.OrderByDescending(i => i.CategoryID).FirstOrDefault().CategoryID + 1;
            }
            Category newObject = new Category() { CategoryID = maxID, CategoryName = "", FlowType = "" };
            ListenToPopup();
            await CoreMethods.PushPopupPageModel<SecondPageModel>(newObject);
        });
        private ObservableCollection<Category> categories;
        public ObservableCollection<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                RaisePropertyChanged();
            }
        }
        private Category chosenObject;
        public Category ChosenObject
        {
            get => chosenObject;
            set
            {
                chosenObject = value;
                RaisePropertyChanged();
            }
        }
    }
}
