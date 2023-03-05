using Contacts.WebApi;
using Contacts.WebApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
    option.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseHttpsRedirection();

app.MapGet("/api/contacts", async (ApplicationDbContext db) =>
{
    var contacts = await db.Contacts.ToListAsync();

    return Results.Ok(contacts);
});

app.MapPost("/api/contacts", async (Contact contact, ApplicationDbContext db) =>
{
    db.Contacts.Add(contact);
    await db.SaveChangesAsync();
});

app.MapPut("/api/contacts/{id}", async (int id, Contact contact, ApplicationDbContext db) =>
{
    var contactToUpdate = await db.Contacts.FindAsync(id);

    if (contactToUpdate is null) return Results.NotFound();

    contactToUpdate.Name = contact.Name;
    contactToUpdate.Email = contact.Email;
    contactToUpdate.Phone = contact.Phone;
    contactToUpdate.Address = contact.Address;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();


