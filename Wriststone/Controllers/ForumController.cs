using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Wriststone.Models.DAO;
using Wriststone.Models.Table;
using Wriststone.Models.ViewModel;

namespace Wriststone.Controllers
{
    public class ForumController : Controller
    {
        readonly ForumCategoryDAO ForumCategoryDAO = new ForumCategoryDAO();
        readonly ForumSearchDAO ForumSearchDAO = new ForumSearchDAO();
        readonly CategoryThreadsDAO CategoryThreadsDAO = new CategoryThreadsDAO();
        readonly AccountDAO AccountDAO = new AccountDAO();
        readonly AccountPostDAO AccountPostDAO = new AccountPostDAO();
        readonly ThreadDAO ThreadDAO = new ThreadDAO();
        readonly PostDAO PostDAO = new PostDAO();
        readonly ThreadStatusDAO ThreadStatusDAO = new ThreadStatusDAO();
        readonly PostStatusDAO PostStatusDAO = new PostStatusDAO();
        public ActionResult Forum()
        {
            return View(ForumCategoryDAO.SelectItemsByCategory(null));
        }

        public ActionResult Search(string search, long page = 0)
        {
            if (search == null) search = "";
            ViewData["Search"] = search;
            return View(ForumSearchDAO.SelectByPage(search, page));
        }

        [HttpGet]
        public ActionResult Category(long? id, long page = 0)
        {
            if (id == null) return View("NotFound");
            return View(CategoryThreadsDAO.SelectByPage(id, page));
        }

        [HttpGet]
        public ActionResult Create(long? id)
        {
            if (id == null) return View("NotFound");
            return View(ForumCategoryDAO.Select(id));
        }

        [HttpPost]
        public ActionResult Create(long category, string subject, string context)
        {
            var account = AccountDAO.SelectItemByLogin(User.Identity.Name).Id;
            ThreadDAO.Insert(new Thread
            {
                Subject = subject,
                Category = category,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Account = account,
                Status = ThreadStatusDAO.SelectByName("Idle"),
                Views = 0
            }) ;
            var thread = ThreadDAO.SelectBySubject(subject).Id;
            PostDAO.Insert(new Post
            {
                Context = context,
                Account = account,
                Created = DateTime.Now,
                Thread = thread,
                Status = PostStatusDAO.SelectByName("Idle"),
                ThreadOrder = 1
            }) ;
            return RedirectToAction("Thread", new { id = thread, page = (PostDAO.SelectLastPostByThread(thread.Value) - 1) / 15 });
        }

        [HttpGet]
        public ActionResult Thread(long? id, long page = 0, int capacity = 15)
        {
            if (id == null) return View("NotFound");
            ThreadPostsModel posts = new ThreadPostsModel
            {
                Thread = ThreadDAO.Select(id)
            };
            posts.Creator = AccountDAO.Select(posts.Thread.Account);
            posts.Post = PostDAO.SelectFirstPostByThread(posts.Creator.Id.Value, posts.Thread.Id.Value);
            var post = AccountPostDAO.SelectItemsByThread(id.Value).AsEnumerable();
            posts.Posts = post.Skip(capacity * (int)page).Take(capacity);
            posts.Pages = (post.Count() - 1) / capacity;
            posts.Page = page;
            ThreadDAO.ViewsCount(id.Value);
            return View(posts);
        }

        [HttpPost]
        public ActionResult Post(long thread, string context)
        {
            var account = AccountDAO.SelectItemByLogin(User.Identity.Name).Id;
            PostDAO.Insert(new Post 
            { 
                Context = context, 
                Account = account, 
                Created = DateTime.Now, 
                Thread = thread,
                Status = PostStatusDAO.SelectByName("Idle"),
                ThreadOrder = PostDAO.SelectLastPostByThread(thread) + 1
            });
            ThreadDAO.UpdateById(thread, new Thread { Updated = DateTime.Now });
            return RedirectToAction("Thread", new { id = thread });
        }

        [HttpGet]
        public ActionResult Edit(long threadid, long postid)
        {
            CreatorThreadModel creatorThread = new CreatorThreadModel
            {
                Thread = ThreadDAO.Select(threadid),
                Post = PostDAO.Select(postid)
            };
            return View(creatorThread);
        }

        [HttpPost]
        public ActionResult Edit(long threadid, long postid, string subject, string context)
        {
            ThreadDAO.UpdateById(threadid, new Thread { Subject = subject, Updated = DateTime.Now });
            PostDAO.UpdateById(postid, new Post { Context = context });
            return RedirectToAction("Thread", new { id = threadid });
        }
    }
}
