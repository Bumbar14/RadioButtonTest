using System;
using System.Collections.Generic;
using System.Text;
using FreshMvvm;
using Xamarin.Forms;

namespace RadioButtonTest
{
    class SecondPageModel : FreshBasePageModel
    {
        public async override void Init(object initData)
        {
            IsBusyCategory = false;
            FlowType = "3";
        }


        private string flowType;
        public string FlowType
        {
            get => flowType;
            set
            {
                flowType = value;
                RaisePropertyChanged();
            }
        }

        public Command First
        {
            get => new Command(() =>
            {
                FlowType = "1";
                IsBusyCategory = true;

            });
            
        }
        public Command Second
        {
            get => new Command(() =>
            {
                FlowType = "2";
                IsBusyCategory = true;

            });
        }
        public Command Third
        {
            get => new Command(() =>
            {
                FlowType = "3";
                IsBusyCategory = true;

            });
        }

        private bool isBusyCategory;
        public bool IsBusyCategory
        {
            get => isBusyCategory;
            set
            {
                isBusyCategory = value;
                RaisePropertyChanged();
            }
        }
        public Command Hide
        {
            get => new Command(() => IsBusyCategory = false);
        }

    }
}
