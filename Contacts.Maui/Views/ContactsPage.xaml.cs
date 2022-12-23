namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();

		List<Contact> contacts = new List<Contact>()
		{
			new Contact { Name="John Doe", Email="JohnDoe@gmail.com"},
			new Contact { Name="Jane Doe", Email="JaneDoe@gmail.com"},
			new Contact { Name="Tom Hanks", Email="TomHanks@gmail.com"},
			new Contact { Name="Frank Liu", Email="frankliu@gmail.com"},
		};		

		listContacts.ItemsSource= contacts;

	}

	public class Contact
	{
		public string Name { get; set; }
		public string Email { get; set; }
	}

    private async void listContacts_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		if (listContacts.SelectedItem != null)
		{
			//logic
			await Shell.Current.GoToAsync(nameof(EditContactPage));
        }		
    }

    private void listContacts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
		listContacts.SelectedItem = null;
    }
}
