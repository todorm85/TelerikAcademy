namespace VoiceSystem.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models.Comments;
    using Services.Data.Contracts;
    using Web.Controllers;

    public class CommentsController : BaseController
    {
        private ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Tracks_Read([DataSourceRequest]DataSourceRequest request)
        {
            var tracks = this.comments.GetAll().To<CommentListItemViewModel>();
            var result = tracks.ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tracks_Create([DataSourceRequest]DataSourceRequest request, CommentListItemViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.Mapper.Map<Comment>(model);
                this.comments.Add(entity);
                var responseModel = this.Mapper.Map<CommentListItemViewModel>(entity);
                return this.Json(new[] { responseModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tracks_Update([DataSourceRequest]DataSourceRequest request, CommentListItemViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var trackEntity = this.comments.GetById(model.Id);
                this.Mapper.Map(model, trackEntity);
                this.comments.Save();
                var responseModel = this.Mapper.Map<CommentListItemViewModel>(trackEntity);
                return this.Json(new[] { responseModel }.ToDataSourceResult(request, this.ModelState));
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Tracks_Destroy([DataSourceRequest]DataSourceRequest request, CommentListItemViewModel model)
        {
            this.comments.Delete(model.Id);
            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.comments.Dispose();
            base.Dispose(disposing);
        }
    }
}