using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Villa.Business.Abstract;
using Villa.Business.Concrete;
using Villa.DataAccess.Abstract;
using Villa.DataAccess.Context;
using Villa.DataAccess.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Registration
builder.Services.AddScoped<IBannerDal, EfBannerDal>();
builder.Services.AddScoped<IBannerService, BannerManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<ICounterDal, EfCounterDal>();
builder.Services.AddScoped<ICounterService, CounterManager>();
builder.Services.AddScoped<IDealDal, EfDealDal>();
builder.Services.AddScoped<IDealService, DealManager>();
builder.Services.AddScoped<IFeatureDal, EfFeatureDal>();
builder.Services.AddScoped<IFeatureService, FeatureManager>();
builder.Services.AddScoped<IMessageDal, EfMessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IQuestDal, EfQuestDal>();
builder.Services.AddScoped<IQuestService, QuestManager>();
builder.Services.AddScoped<IVideoDal, EfVideoDal>();
builder.Services.AddScoped<IVideoService, VideoManager>();
#endregion

var mongoDatabase = new MongoClient(builder.Configuration.GetConnectionString("MongoConnection"))
    .GetDatabase(builder.Configuration.GetSection("DatabaseName").Value);

builder.Services.AddDbContext<VillaContext>(option =>
{
    option.UseMongoDB(mongoDatabase.Client, mongoDatabase.DatabaseNamespace.DatabaseName);
});

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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
