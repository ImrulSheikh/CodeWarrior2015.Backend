using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CW.Backend.DAL.CRUD.Contexts;
using CW.Backend.DAL.CRUD.Entities;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CW.Backend.DAL.CRUD.Repositories;
using CW.Backend.DAL.CRUD.Repositories.Interfaces;

namespace CW.Backend.Services.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Profiles")]
    public class ProfilesController : ApiController
    {
        private IUserRepository _repository;
        public ProfilesController(IUserRepository repository)
        {
            if (repository == null)
                repository = new UserRepository(new ProductCRUDContext());

            _repository = repository;
        }
    
        [Route("GetData")]
        public HttpResponseMessage Get()
        {
            var data = _repository.GetAll();
            var response = Request.CreateResponse(data);

            return response;

        }

        

        [HttpPost]
        [Route("AddImage")]
        public async Task<HttpResponseMessage> UploadImageAsync()
        {

            //var userId = HttpContext.Current.User.Identity.Name;
            //var context = new ProfileDbContext();
            //var profile = context.Profiles.Where(x => x.UserName == userId && x.ProfileType == "Seller").First();

            



            //var messages = new List<string>();
            //if (Request.Content.IsMimeMultipartContent())
            //{
            //    string uploadPath = HttpContext.Current.Server.MapPath("~/Content/uploads");

            //    var streamProvider = new MyStreamProvider(uploadPath);

            //    await Request.Content.ReadAsMultipartAsync(streamProvider);


            //    foreach (var file in streamProvider.FileData)
            //    {
            //        var fi = new FileInfo(file.LocalFileName);
            //        messages.Add("File uploaded as " + fi.FullName + " (" + fi.Length + " bytes)");
            //    }

            //    profile.ImagePath = uploadPath;
            //    context.SaveChanges();


            //    return Request.CreateResponse(HttpStatusCode.OK, messages);
            //}
            //messages.Add("file not added");

            return Request.CreateResponse(HttpStatusCode.OK);
        }
       
    }
}
