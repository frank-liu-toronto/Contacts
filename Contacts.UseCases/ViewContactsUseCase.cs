using Contacts.UseCases.Interfaces;
using Contacts.UseCases.PluginInterfaces;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.UseCases
{
    // All the code in this file is included in all platforms.
    public class ViewContactsUseCase : IViewContactsUseCase
    {
        private readonly IContactRepository contactRepository;

        public ViewContactsUseCase(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;            
        }

        public async Task<List<Contact>> ExecuteAsync(string filterText)
        {
            return await this.contactRepository.GetContactsAsync(filterText);
        }

    }
}