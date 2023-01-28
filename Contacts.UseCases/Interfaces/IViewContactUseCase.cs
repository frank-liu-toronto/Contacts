namespace Contacts.UseCases.Interfaces
{
    public interface IViewContactUseCase
    {
        Task<CoreBusiness.Contact> ExecuteAsync(int contactId);
    }
}