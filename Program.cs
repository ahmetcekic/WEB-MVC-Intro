/*
 * Program�m�z default olarak buradan aya�a kalkmaktad�r. 
 * .NET Core ile birlikte web uygulamalar� b�t�n platformlarda yay�nlanabilir. Bu sebeple hangi ortam �zerinde �al��t�rmak istersek buradaki CreateBuilder methodu d�zenlenerek farkli web server ortamlar�nda kullanabiliriz. Default olarak bu ayar� de�i�tirmezsek IIS �zerinde uygulamay� �al���t�racakt�r. (Internet Information Server). Bu servis olmadan bir web sitesini Windows ortam�nda yay�nlayamay�z. Bunun d���nda Apache Server gibi ortamlar�n herpsinde ek ayarlar ile web sitemizi art�k .NET Core sayesinde yay�nlayabiliyoruz. 
 * 
 * .NET Core k�t�phanesi olabildi�ince minimum gereksinimlere g�re yaz�ld��� i�in sadece ya�am d�ng�s�nde kullan�lacak olan yap�lar sisteme Program.cs dosyas�nda tan�t�l�r. 
 * 
 * Program.cs dosyas� .NET Core uygulamas�n�n �al��t��� dosyad�r. Burada uygulama ile iligli t�m ayarlar yap�l�r. �rne�in uygulaman�n API veya Razor Page veya MVC olarak tan�t�lma�sn� bu class �zerinde ger�ekle�tiririz. Bunun d���nda uygulama i�erisinde kullan�lacak olan t�m ayarlarda bu dosyadan yap�labilirz. Uygulaman�n Authorization(Yetkilendirme) ve Authenticaton(Kimlik Do�rulama) ayarlar�, Database ba�lant� ayarlar�, HTTPS sertifika kullan�m ayarlar�, Route ayarlar� ve bir�ok ayar buradan y�netilir. 
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
app.UseStaticFiles(); //wwwroot klas�r�n�n i�indeki dosyalar�n okunmas�n� sa�lar.

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
