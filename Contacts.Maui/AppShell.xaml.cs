using Contacts.Maui.Views;

namespace Contacts.Maui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ContactsPage), typeof(ContactsPage));
		Routing.RegisterRoute(nameof(EditContactPage), typeof(EditContactPage));
		Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));
        Routing.RegisterRoute(nameof(TestPage1), typeof(TestPage1));
    }  
}
