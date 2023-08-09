using Microsoft.AspNetCore.Mvc;

namespace UploadToBlobStorage.Models
{
    public class FileUploadRequest: FileUploadBaseRequest
    {
        public Sample Sample { get; set; }
        public IFormFile[] files { get; set; }
    }

    public class FileUploadBaseRequest
    {
        public string UploaderName { get; set; }
        public string UploaderAddress { get; set; }
    }
    [ModelBinder(BinderType = typeof(JsonModelBinder2))]
    public class Sample
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
