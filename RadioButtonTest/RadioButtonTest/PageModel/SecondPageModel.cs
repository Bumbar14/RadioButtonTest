using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using FreshMvvm;
using Xamarin.Forms;
using FreshMvvm.Popups;
using RadioButtonTest.Model;
using RadioButtonTest.Services;
using System.Threading.Tasks;

namespace RadioButtonTest
{
    class SecondPageModel : FreshBasePageModel
    {
        public async override void Init(object initData)
        {
            if (initData != null)
            {
                Category cat = (Category)initData;
                ChosenObject = cat;
                // Workaround();
            }
        }
        void Workaround()
        {
            switch (ChosenObject.FlowType)
            {
                case "0":
                    RB_first = true;
                    break;
                case "1":
                    RB_second = true;
                    break;
                case "2":
                    RB_third = true;
                    break;
                default:
                    break;
            }
        }

        private async Task<int> Update(int option)
        {
            DatabaseConnection database = await DatabaseConnection.Instance;
            // 1 = SAVE CATEGORY
            // 2 = Delete Category
            if (option == 1)
            {
                await database.SaveOrUpdateCategory(ChosenObject);
                return 1;
            }
            if (option == 2)
            {
                await database.DeleteCategory(ChosenObject);
                return 2;
            }
            return -1;
        }
        async Task Delete()
        {
            int result = await Update(2);
            if (result == 2)
            {
                await CoreMethods.DisplayAlert("SUCCESS", "Saved", "OK");
                MessagingCenter.Send<SecondPageModel>(this, "ID");
                await CoreMethods.PopPopupPageModel();
            }
            else
            {
                await CoreMethods.DisplayAlert("Error", "Could not delete", "OK");
            }
        }
        public Command Cancel => new Command(async () =>
        {
            await CoreMethods.PopPopupPageModel();
        });
        public Command Save => new Command(async () =>
        {
            int result = await Update(1);
            if (result == 1)
            {
                await CoreMethods.DisplayAlert("Done", "Saved" + ChosenObject.CategoryName, "OK");
                MessagingCenter.Send<SecondPageModel>(this, "ID");
                await CoreMethods.PopPopupPageModel();
            }
            else
            {
                await CoreMethods.DisplayAlert("UPS", "Nekaj je šlo narobe", "OK");
            }
        });


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
        private bool rB_first;
        public bool RB_first
        {
            get => rB_first;
            set
            {
                rB_first = value;
                RaisePropertyChanged();
            }
        }
        private bool rB_second;
        public bool RB_second
        {
            get => rB_second;
            set
            {
                rB_second = value;
                RaisePropertyChanged();
            }
        }
        private bool rB_third;
        public bool RB_third
        {
            get => rB_third;

            set
            {
                rB_third = value;
                RaisePropertyChanged();
            }
        }
    }
   
}
