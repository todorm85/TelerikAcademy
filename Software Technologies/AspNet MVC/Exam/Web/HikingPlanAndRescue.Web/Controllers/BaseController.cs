namespace VoiceSystem.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Infrastructure.Mapping;
    using VoiceSystem.Services.Web;

    public abstract class BaseController : Controller
    {
        public BaseController()
        {
        }

        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        protected string UserIp
        {
            get
            {
                return this.Request.UserHostAddress;
            }
        }
    }
}