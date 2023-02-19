using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Models;
using Contacts.Maui.Views_MVVM;
using Contacts.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.Maui.ViewModels
{
    public partial class ContactViewModel : ObservableObject
    {
        private Contact contact;
        private readonly IViewContactUseCase viewContactUseCase;
        private readonly IEditContactUseCase editContactUseCase;

        public Contact Contact
        {
            get => contact;
            set
            {
                SetProperty(ref contact, value);
            }
        }

        private bool isContactValid;

        public bool IsContactValid
        {
            get { return isContactValid; }
            set 
            { 
                if (value == false)
                {
                    isContactValid = value;
                }                
            }
        }


        public ContactViewModel(
            IViewContactUseCase viewContactUseCase,
            IEditContactUseCase editContactUseCase)
        {
            this.Contact = new Contact();
            this.viewContactUseCase = viewContactUseCase;
            this.editContactUseCase = editContactUseCase;
        }

        public async Task LoadContact(int contactId)
        {
            this.Contact = await this.viewContactUseCase.ExecuteAsync(contactId);
        }

        [RelayCommand]
        public async Task EditContact()
        {
            await this.editContactUseCase.ExecuteAsync(this.contact.ContactId, this.contact);
            await Shell.Current.GoToAsync($"{nameof(Contacts_MVVM_Page)}");
        }

        [RelayCommand]
        public async Task BackToContacts()
        {
            await Shell.Current.GoToAsync($"{nameof(Contacts_MVVM_Page)}");
        }
        
    }
}
