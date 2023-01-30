﻿using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.UseCases.PluginInterfaces
{
    public interface IContactRepository
    {
        Task AddContactAsync(Contact contact);
        Task<Contact> GetContactByIdAsync(int contactId);
        Task<List<Contact>> GetContactsAsync(string filterText);
        Task UpdateContactAsync(int contactId, Contact contact);
    }
}
