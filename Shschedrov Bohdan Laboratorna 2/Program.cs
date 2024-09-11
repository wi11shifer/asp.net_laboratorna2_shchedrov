var builder = WebApplication.CreateBuilder(args);

// ������� ����� CompanyService ��� ������ � ���������������� �������
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<Shschedrov_Bohdan_Laboratorna_2.Services.CompanyService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Company}/{action=Index}/{id?}");

app.Run();
