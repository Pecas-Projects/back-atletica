using Back_Atletica.Business;
using Back_Atletica.Business.Implementação;
using Back_Atletica.Data;
using Back_Atletica.Repository;
using Back_Atletica.Repository.Implementação;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Back_Atletica
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            AtleticaContext context = new AtleticaContext();

            context.Start();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddControllers();

            services.Configure<KestrelServerOptions>(
            Configuration.GetSection("Kestrel"));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.SetIsOriginAllowed(origin => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .Build());
            });

            services.AddDbContext<AtleticaContext>();
            services.AddControllers().AddNewtonsoftJson(options =>
                 options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

          /*  services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = Env.Issuer,
                      ValidAudience = Env.Issuer,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Env.Secret))
                  };
              }); */

  
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Olympos Api"
                });

            }
           );

            services.AddHttpContextAccessor();

            services.AddScoped<IPublicacaoBusiness, PublicacaoBusinessImpl>();
            services.AddScoped<IPublicacaoRepository, PublicacaoRepositoryImpl>();
            services.AddScoped<ICursoBusiness, CursoBusinessImpl>();
            services.AddScoped<ICursoRepository, CursoRepositoryImpl>();
            services.AddScoped<IProdutoBusiness, ProdutoBusinessImpl>();
            services.AddScoped<IProdutoRepository, ProdutoRepositoryImpl>();
            services.AddScoped<IAtleticaBusiness, AtleticaBusinessImpl>();
            services.AddScoped<IAtleticaRepository, AtleticaRepositoryImpl>();
            services.AddScoped<IAutenticacaoBusiness, AutenticacaoBusinessImpl>();
            services.AddScoped<IAutenticacaoRepository, AutenticacaoRepositoryImpl>();
            services.AddScoped<IMembroBusiness, MembroBusinessImpl>();
            services.AddScoped<IMembroRepository, MembroRepositoryImpl>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            //app.UseHttpsRedirection();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Olympos Api V1");
                c.RoutePrefix = string.Empty;
            }
            );

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
