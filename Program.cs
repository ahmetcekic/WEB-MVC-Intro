/*
 * Programýmýz default olarak buradan ayaða kalkmaktadýr. 
 * .NET Core ile birlikte web uygulamalarý bütün platformlarda yayýnlanabilir. Bu sebeple hangi ortam üzerinde çalýþtýrmak istersek buradaki CreateBuilder methodu düzenlenerek farkli web server ortamlarýnda kullanabiliriz. Default olarak bu ayarý deðiþtirmezsek IIS üzerinde uygulamayý çalýþýtýracaktýr. (Internet Information Server). Bu servis olmadan bir web sitesini Windows ortamýnda yayýnlayamayýz. Bunun dýþýnda Apache Server gibi ortamlarýn herpsinde ek ayarlar ile web sitemizi artýk .NET Core sayesinde yayýnlayabiliyoruz. 
 * 
 * .NET Core kütüphanesi olabildiðince minimum gereksinimlere göre yazýldýðý için sadece yaþam döngüsünde kullanýlacak olan yapýlar sisteme Program.cs dosyasýnda tanýtýlýr. 
 * 
 * Program.cs dosyasý .NET Core uygulamasýnýn çalýþtýðý dosyadýr. Burada uygulama ile iligli tüm ayarlar yapýlýr. Örneðin uygulamanýn API veya Razor Page veya MVC olarak tanýtýlmaýsný bu class üzerinde gerçekleþtiririz. Bunun dýþýnda uygulama içerisinde kullanýlacak olan tüm ayarlarda bu dosyadan yapýlabilirz. Uygulamanýn Authorization(Yetkilendirme) ve Authenticaton(Kimlik Doðrulama) ayarlarý, Database baðlantý ayarlarý, HTTPS sertifika kullaným ayarlarý, Route ayarlarý ve birçok ayar buradan yönetilir. 
 */

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); //wwwroot klasörünün içindeki dosyalarýn okunmasýný saðlar.

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
