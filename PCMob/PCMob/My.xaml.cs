using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PCMob
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class My : ContentPage
    {
        User user;
        public My(User user)
        {
            InitializeComponent();
            this.user = user;
        }
    }
}