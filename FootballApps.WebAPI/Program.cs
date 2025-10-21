using FootballApps.BusinessLayer.Abstract;
using FootballApps.BusinessLayer.Concrete;
using FootballApps.DataAccessLayer.Abstract;
using FootballApps.DataAccessLayer.Concrete;
using FootballApps.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

#region
builder.Services.AddDbContext<FootballAppContext>();

builder.Services.AddScoped<IPlayerDal,EfPlayerDal>();
builder.Services.AddScoped<IPlayerService, PlayerManager>();

builder.Services.AddScoped<IMatchDal, EfMatchDal>();
builder.Services.AddScoped<IMatchService, MatchManager>();

builder.Services.AddScoped<ITeamDal, EfTeamDal>();
builder.Services.AddScoped<ITeamService, TeamManager>();

builder.Services.AddScoped<ILatestNewDal, EfLatestNewDal>();
builder.Services.AddScoped<ILatestNewService, LatestNewManager>();

builder.Services.AddScoped<IVideoDal, EfVideoDal>();
builder.Services.AddScoped<IVideoService, VideoManager>();

builder.Services.AddScoped<IBlogDal, EfBlogDal>();
builder.Services.AddScoped<IBlogService, BlogManager>();

builder.Services.AddScoped<IPlayerDal, EfPlayerDal>();
builder.Services.AddScoped<IPlayerService, PlayerManager>();

builder.Services.AddScoped<ICommentDal, EfCommentDal>();
builder.Services.AddScoped<ICommentService, CommentManager>();

builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddScoped<IPlayerMatchStatisticDal, EfPlayerMatchStatisticDal>();
builder.Services.AddScoped<IPlayerMatchStatisticService, PlayerMatchStatisticManager>();


builder.Services.AddScoped<IContactCommentDal, EfContactCommentDal>();
builder.Services.AddScoped<IContactCommentService, ContactCommentManager>();
#endregion

builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
