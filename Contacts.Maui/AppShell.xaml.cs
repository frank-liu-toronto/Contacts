using Contacts.Maui.Views;
using Contacts.Maui.Views_MVVM;

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
		Routing.RegisterRoute(nameof(Contacts_MVVM_Page), typeof(Contacts_MVVM_Page));
        Routing.RegisterRoute(nameof(EditContactPage_MVVM), typeof(EditContactPage_MVVM));
        Routing.RegisterRoute(nameof(AddContactPage_MVVM), typeof(AddContactPage_MVVM));
    }  
}
