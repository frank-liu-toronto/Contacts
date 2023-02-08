using Contacts.Maui.Models;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class TestPage : ContentPage
{
    private Contact _contact;

    public TestPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        _contact = ContactRepository.GetContactById(1);
        this.entryName.Text = _contact.Name;
        this.entryPhone.Text = _contact.Phone;
        this.entryEmail.Text = _contact.Email;
        this.entryAddress.Text = _contact.Address;
    }

    private void btnSave_Clicked(object sender, EventArgs e)
    {
        _contact.Name = this.entryName.Text;
        _contact.Address = this.entryAddress.Text;
        _contact.Email = this.entryEmail.Text;
        _contact.Phone = this.entryPhone.Text;

        ContactRepository.UpdateContact(_contact.ContactId, _contact);
    }
}