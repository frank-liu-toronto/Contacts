using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Contacts.Maui.Models;
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

        public Contact Contact
        {
            get => contact;
            set
            {
                SetProperty(ref contact, value);
            }
        }

        public ContactViewModel(IViewContactUseCase viewContactUseCase)
        {
            this.Contact = new Contact();
            this.viewContactUseCase = viewContactUseCase;
        }

        public async Task LoadContact(int contactId)
        {
            this.Contact = await this.viewContactUseCase.ExecuteAsync(contactId);
        }

        //[RelayCommand]
        //public void SaveContact()
        //{
        //    ContactRepository.UpdateContact(
        //        this.Contact.ContactId,
        //        this.Contact);
        //}
    }
}
