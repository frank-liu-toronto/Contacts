using Contacts.UseCases.PluginInterfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.Plugins.DataStore.InMemory
{
    // All the code in this file is included in all platforms.
    public class ContactInMemoryRepository : IContactRepository
    {
        public static List<Contact> _contacts;

        public ContactInMemoryRepository()
        {
            _contacts = new List<Contact>()
            {
                new Contact { ContactId = 1, Name="John Doe", Email="JohnDoe@gmail.com"},
                new Contact { ContactId = 2,  Name="Jane Doe", Email="JaneDoe@gmail.com"},
                new Contact {  ContactId = 3, Name="Tom Hanks", Email="TomHanks@gmail.com"},
                new Contact {  ContactId = 4, Name="Frank Liu", Email="frankliu@gmail.com"},
            };
        }

        public Task AddContactAsync(Contact contact)
        {
            var maxId = _contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            _contacts.Add(contact);

            return Task.CompletedTask;
        }

        public Task DeleteContactAsync(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }

            return Task.CompletedTask;
        }

        public Task<Contact> GetContactByIdAsync(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                return Task.FromResult(new Contact
                {
                    ContactId = contactId,
                    Address = contact.Address,
                    Email = contact.Email,
                    Name = contact.Name,
                    Phone = contact.Phone
                });
            }

            return null;
        }

        public Task<List<Contact>> GetContactsAsync(string filterText)
        {
            if (string.IsNullOrWhiteSpace(filterText))
            {
                return Task.FromResult(_contacts);
            }

            var contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (contacts == null || contacts.Count <= 0)
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return Task.FromResult(contacts);

            if (contacts == null || contacts.Count <= 0)
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return Task.FromResult(contacts);

            if (contacts == null || contacts.Count <= 0)
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return Task.FromResult(contacts);

            return Task.FromResult(contacts);
        }

        public Task UpdateContactAsync(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return Task.CompletedTask;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contactToUpdate != null)
            {
                //AutoMapper
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Phone = contact.Phone;
            }

            return Task.CompletedTask;
        }
    }
}