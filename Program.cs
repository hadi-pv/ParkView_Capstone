using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParkView_Capstone.Models;
using ParkView_Capstone.Models.Bookings;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication().AddGoogle(
    googleoptions =>
    {
        googleoptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        googleoptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    });
builder.Services.AddSession();
builder.Services.AddScoped<IRoomRepo,RoomDbRepo>();
builder.Services.AddScoped<IServiceRepo,ServiceDbRepo>();
builder.Services.AddScoped<BookingCart>(sp => BookingCart.GetCart(sp));
builder.Services.AddDbContext<ParkViewDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ParkViewDbContext>();


var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapDefaultControllerRoute();
app.UseAuthentication(); ;

app.Run();
