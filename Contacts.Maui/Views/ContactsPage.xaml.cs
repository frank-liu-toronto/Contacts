using Contacts.Maui.Models;
using Contacts.UseCases.Interfaces;
using System.Collections.ObjectModel;
using Contact = Contacts.CoreBusiness.Contact;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
    private readonly IViewContactsUseCase viewContactsUseCase;
    private readonly IDeleteContactUseCase deleteContactUseCase;

    public ContactsPage(IViewContactsUseCase viewContactsUseCase,
        IDeleteContactUseCase deleteContactUseCase)
	{
		InitializeComponent();
        this.viewContactsUseCase = viewContactsUseCase;
        this.deleteContactUseCase = deleteContactUseCase;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        SearchBar.Text = string.Empty;

        LoadContacts();
    }

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listContacts.SelectedItem != null)
		{
			//logic
			await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
        }		
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		listContacts.SelectedItem = null;
    }

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private async void Delete_Clicked(object sender, EventArgs e)
    {
        var menuItem = sender as MenuItem;
        var contact = menuItem.CommandParameter as Contact;
        //ContactRepository.DeleteContact(contact.ContactId);
        await deleteContactUseCase.ExecuteAsync(contact.ContactId);

        LoadContacts();
    }

    private async void LoadContacts()
    {
        var contacts = new ObservableCollection<Contact>(await this.viewContactsUseCase.ExecuteAsync(string.Empty));        
        listContacts.ItemsSource = contacts;
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        //var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        var contacts = new ObservableCollection<Contact>(await this.viewContactsUseCase.ExecuteAsync(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }

    private void btnTest_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(TestPage1));
    }
}
