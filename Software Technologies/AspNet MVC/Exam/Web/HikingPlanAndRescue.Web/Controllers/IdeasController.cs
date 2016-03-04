namespace VoiceSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Filters;
    using VoiceSystem.Services.Data.Contracts;
    using VoiceSystem.Web.Infrastructure.Mapping;
    using VoiceSystem.Web.ViewModels.Ideas;

    public class IdeasController : BaseController
    {
        private const int PageSize = 3;
        private const int CommentsPageSize = 4;
        private IIdeasService ideas;
        private ICommentsService comments;

        public IdeasController(IIdeasService ideas, ICommentsService comments)
        {
            this.ideas = ideas;
            this.comments = comments;
        }

        public ActionResult Index(string query, int id = 1)
        {
            int page = id - 1;
            if (query == "")
            {
                query = null;
            }

            var allIdeas = this.ideas.
                GetAllWithPaging(page, PageSize)
                .Where(x => query == null || x.Description.IndexOf(query) >= 0)
                .To<IdeaViewModel>();
            //var ideasCount = this.ideas.GetAll().Count();
            var ideasCount = this.ideas.GetAll().Count();
            var pageCount = (int)Math.Ceiling(ideasCount / (decimal)PageSize);

            var ideaIndexModel = new IdeaIndexViewModel()
            {
                CreateModel = new IdeaCreateViewModel(),
                Ideas = allIdeas,
                PageCount = pageCount,
                Page = id
            };

            return this.View(ideaIndexModel);
        }

        [HttpPost]
        [AjaxRequestOnly]
        public ActionResult Create(IdeaCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new
                {
                    error = "Invalid model"
                });
            }

            var idea = this.Mapper.Map<Idea>(model);
            idea.UserIp = this.UserIp;
            this.ideas.Add(idea);
            return this.Json("ok");
        }

        public ActionResult Details(int id, int page = 1)
        {
            var idea = this.ideas.GetById(id);
            var ideaModel = this.Mapper.Map<IdeaDetailsViewModel>(idea);
            //var ideaComments = this.comments.GetAllIdeaCommentsWithPaging(page - 1, CommentsPageSize, idea.Id).To<CommentViewModel>();
            var ideaComments = idea.Comments
                .OrderByDescending(x => x.CreatedOn)
                .Skip((page - 1) * CommentsPageSize)
                .Take(CommentsPageSize)
                .AsQueryable()
                .To<CommentViewModel>()
                .ToList();

            var commentsCount = idea.Comments.Count();
            var pageCount = (int)Math.Ceiling(commentsCount / (decimal)CommentsPageSize);

            var pageModel = new IdeaDetailsPageViewModel()
            {
                Comments = ideaComments,
                Idea = ideaModel,
                Page = page,
                PageCount = pageCount
            };

            return this.View(pageModel);
        }

        [HttpPost]
        [AjaxRequestOnly]
        public ActionResult AddComment(CommentCreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Json(new
                {
                    error = "Invalid model"
                });
            }

            var comment = this.Mapper.Map<Comment>(model);
            comment.UserIp = this.UserIp;
            this.comments.Add(comment);
            return this.Json("ok");
        }
    }
}