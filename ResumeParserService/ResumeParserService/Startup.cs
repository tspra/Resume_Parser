using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ResumeParserCore.Builder;
using ResumeParserCore.Extractor;
using ResumeParserCore.Mapper;
using ResumeParserCore.Parser;
using ResumeParserCore.Processor;
using ResumeParserCore.Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeParserService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IProcessor, ResumeProcessor>();
            services.AddScoped<IResumeBuilder, ResumeBuilder>();
            services.AddScoped<ISectionExtractor, SectionExtractor>();
            services.AddScoped<ISectionMapper, SectionMapper>();
            services.AddScoped<IParser, PersonalParser>();
            services.AddScoped<IParser, SkillParser>();
            services.AddScoped<IInputReaderFactory, InputReaderFactory>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
