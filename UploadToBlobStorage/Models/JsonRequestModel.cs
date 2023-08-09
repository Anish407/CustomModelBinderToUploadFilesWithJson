//using UploadToBlobStorage.JsonBinder;

namespace UploadToBlobStorage.Models
{
    public class JsonRequestModel
    {
        //public IList<IFormFile> Files { get; set; }
        //[FromJson]
        public Sample Model { get; set; } // <-- JSON will be deserialized to this object
    }
}
