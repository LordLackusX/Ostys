﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OstSysMVVM.Annotations;
using OstSysMVVM.Model;

namespace OstSysMVVM.ViewModel
{
    class ApartmentViewModel:INotifyPropertyChanged
    {
        public ApartmentCatalogSingleton ApartmentCatalogSingleton { get; set; }

        public ApartmentViewModel()
        {
            ApartmentCatalogSingleton=ApartmentCatalogSingleton.Instance;
            NewApartment=new Apartment();
        }

        private Apartment _newApartment;

        public Apartment NewApartment
        {
            get
            {
                return _newApartment;
            }
            set
            {
                _newApartment = value; OnPropertyChanged();
            }
        }











        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
