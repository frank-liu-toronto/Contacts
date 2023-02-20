using Contacts.UseCases.PluginInterfaces;
using SQLite;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.Plugins.DataStore.SQLLite
{
    // All the code in this file is included in all platforms.
    public class ContactSQLiteRepository : IContactRepository
    {
        private SQLiteAsyncConnection database;

        public ContactSQLiteRepository()
        {
            this.database = new SQLiteAsyncConnection(Constants.DatabasePath);            
            this.database.CreateTableAsync<Contact>();
        }

        public async Task AddContactAsync(Contacts.CoreBusiness.Contact contact)
        {
            await this.database.InsertAsync(contact);
        }

        public async Task DeleteContactAsync(int contactId)
        {
            var contact = await GetContactByIdAsync(contactId);
            if (contact != null && contact.ContactId == contactId)
                await this.database.DeleteAsync(contact);
        }

        public async Task<Contacts.CoreBusiness.Contact> GetContactByIdAsync(int contactId)
        {
            return await this.database.Table<Contact>().Where(x => x.ContactId == contactId).FirstOrDefaultAsync();
        }

        public async Task<List<Contacts.CoreBusiness.Contact>> GetContactsAsync(string filterText)
        {
            if (string.IsNullOrWhiteSpace(filterText))
            {
                return await this.database.Table<Contact>().ToListAsync();
            }

            var contacts = await this.database.Table<Contact>().Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToListAsync();

            if (contacts == null || contacts.Count <= 0)
                contacts = await this.database.Table<Contact>().Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToListAsync();
            else
                return contacts;

            if (contacts == null || contacts.Count <= 0)
                contacts = await this.database.Table<Contact>().Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToListAsync();
            else
                return contacts;

            if (contacts == null || contacts.Count <= 0)
                contacts = await this.database.Table<Contact>().Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToListAsync();
            else
                return contacts;

            return contacts;
        }

        public async Task UpdateContactAsync(int contactId, Contacts.CoreBusiness.Contact contact)
        {
            if (contactId == contact.ContactId)
                await this.database.UpdateAsync(contact);
        }
    }
}