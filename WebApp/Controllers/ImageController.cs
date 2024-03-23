using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAppDB.Entities;

namespace WebApp.Controllers
{
    public class ImageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;
        public ImageController(UserManager<ApplicationUser> userManager, IWebHostEnvironment env)
        {
            _userManager = userManager;
            _env = env;
        }

        public async Task<FileResult> GetAvatar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.AvatarImage != null)
            {
                var result = File(user.AvatarImage, "image/...");
                return result;
            }
            else
            {
                var avatarPath = "/Images/avatar.png";
                var result = File(_env.WebRootFileProvider.GetFileInfo(avatarPath).CreateReadStream(), "image/...");
                return result;
            }
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
