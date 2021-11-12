using System;
using System.Collections.Generic;
using System.Text;
using FreshMvvm;
using Xamarin.Forms;

namespace RadioButtonTest
{
    class FirstPageModel : FreshBasePageModel
    {

        public Command GoToTestPage
        {
            get => new Command(async () =>
            await CoreMethods.PushPageModel<SecondPageModel>());
            
        }
    }
}
