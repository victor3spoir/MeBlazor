using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace MeBlazor.Web.Services
{
    public class MyStateService
    {
        public bool ShowInCelcius { get; private set; }
        public event Action<ComponentBase, bool>? ShowInCelciusChanged;

        private void NotifyShowInCelciusChanged(ComponentBase sender, bool showInCelcius)=>ShowInCelciusChanged.Invoke(sender, showInCelcius);
    
        public bool SetShowInCelcius(ComponentBase sender, bool showInCelcius)
        {
            var oldState = showInCelcius;
            if (showInCelcius != ShowInCelcius)
            {
                ShowInCelcius = showInCelcius;
                NotifyShowInCelciusChanged(sender, showInCelcius);
            }

            return oldState;
        }
    }
}