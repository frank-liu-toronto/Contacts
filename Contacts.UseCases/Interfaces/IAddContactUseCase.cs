namespace Contacts.UseCases.Interfaces
{
    public interface IAddContactUseCase
    {
        Task ExecuteAsync(CoreBusiness.Contact contact);
    }
}