using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        public Contact Contact { get; set; }

        public ContactViewModel()
        {
            this.Contact = ContactRepository.GetContactById(1);
        }

        [RelayCommand]
        public void SaveContact()
        {
            ContactRepository.UpdateContact(
                this.Contact.ContactId,
                this.Contact);
        }
    }
}
