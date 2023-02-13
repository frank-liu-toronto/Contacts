using Contacts.Maui.ViewModels;

namespace Contacts.Maui.Views_MVVM;

public partial class Contacts_MVVM_Page : ContentPage
{
    private readonly ContactsViewModel contactsViewModel;

    public Contacts_MVVM_Page(ContactsViewModel contactsViewModel)
	{
		InitializeComponent();
        this.contactsViewModel = contactsViewModel;

        this.BindingContext= contactsViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await this.contactsViewModel.LoadContactsAsync();
    }
}