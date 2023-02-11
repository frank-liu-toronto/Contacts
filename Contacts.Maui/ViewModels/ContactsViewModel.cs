using Contacts.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.Maui.ViewModels
{
    public class ContactsViewModel
    {
        private readonly IViewContactsUseCase viewContactsUseCase;

        public ObservableCollection<Contact> Contacts { get; set; }

        public ContactsViewModel(IViewContactsUseCase viewContactsUseCase)
        {
            this.viewContactsUseCase = viewContactsUseCase;

            this.Contacts = new ObservableCollection<Contact>();
        }

        public async Task LoadContactsAsync()
        {
            this.Contacts.Clear();

            var contacts = await viewContactsUseCase.ExecuteAsync(null);
            if (contacts != null && contacts.Count > 0)
            {
                foreach(var contact in contacts)
                {
                    this.Contacts.Add(contact);
                }
            }
        }

    }
}
