using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Blog.Models.Repos;

namespace Blog.Controllers{
    // the slash means that this will be the default controller
    // Basically if the URL does not provide any additional routes 
    // this controller will be called.
    [Route("/")]
    public class HomeController : Controller{
        public IActionResult Index(){
            BlogRepo blogRepo = new BlogRepo();
            blogRepo.CreateExamplePosts();
            return View(blogRepo.Posts.Find(
            p => p.Public == true && 
            p.Created <= DateTime.Now && 
            p.Deleted == false)
        );
        }
    }

}