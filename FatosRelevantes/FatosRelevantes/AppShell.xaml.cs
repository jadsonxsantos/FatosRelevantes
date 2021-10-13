
using FatosRelevantes.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace FatosRelevantes
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            Routing.RegisterRoute("pageone", typeof(Sobre));
            InitializeComponent();
           
        }

    }
}
