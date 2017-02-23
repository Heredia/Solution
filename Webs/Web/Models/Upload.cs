using System.Web;

namespace Webs.Web.Models
{
    public class Upload
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Description { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}