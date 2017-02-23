using Application.Applications.UnitOfWork;
using System.IO;
using System.Web.Mvc;
using Webs.Web.Models;

namespace Webs.Web.Controllers
{
    public class UploadServiceController : BaseController
    {
        public UploadServiceController(IApplicationUnitOfWork application) : base(application) { }

        [HttpPost]
        public void Upload(Upload upload)
        {
            if (upload.File == null || upload.File.ContentLength <= 0) return;

            var directory = Server.MapPath("~/App_Data/Files");

            Directory.CreateDirectory(directory);

            var path = Path.Combine(directory, upload.File.FileName);

            using (var fileStream = System.IO.File.Create(path))
            {
                upload.File.InputStream.CopyTo(fileStream);
            }
        }
    }
}