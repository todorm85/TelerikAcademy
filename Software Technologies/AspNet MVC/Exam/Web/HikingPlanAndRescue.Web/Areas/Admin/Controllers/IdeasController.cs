namespace VoiceSystem.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Ideas;
    using Services.Data.Contracts;
    using Web.Controllers;

    public class IdeasController : BaseController
    {
        private IIdeasService ideas;

        public IdeasController(IIdeasService ideas)
        {
            this.ideas = ideas;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Tracks_Read([DataSourceRequest]DataSourceRequest request)
        {
            var tracks = this.ideas.GetAll().To<IdeaViewModel>();
            var result = tracks.ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tracks_Create([DataSourceRequest]DataSourceRequest request, IdeaViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Idea>(model);
                this.ideas.Add(entity);
                var responseModel = this.Mapper.Map<IdeaViewModel>(entity);
                return this.Json(new[] { responseModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tracks_Update([DataSourceRequest]DataSourceRequest request, IdeaViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var trackEntity = this.ideas.GetById(model.Id);
                this.Mapper.Map(model, trackEntity);
                this.ideas.Save();
                var responseModel = this.Mapper.Map<IdeaViewModel>(trackEntity);
                return this.Json(new[] { responseModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tracks_Destroy([DataSourceRequest]DataSourceRequest request, IdeaViewModel model)
        {
            this.ideas.Delete(model.Id);
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.ideas.Dispose();
            base.Dispose(disposing);
        }
    }
}