using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyDimashAngular.Data;
using PropertyDimashAngular.Models;

namespace PropertyDimashAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyImageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PropertyImageController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<List<byte[]>> DocumentUpload(IFormFile imageFile)
        {
            //List<byte[]> propertyImages = new List<byte[]>();
            byte[] propertyImage;
            //if(imageFiles == null)
            //{
            //    return Ok(new { message = "ImageFiles" });
            //}
            //foreach(var file in imageFiles) {
                using (var stream = new MemoryStream())
                {
                    imageFile.CopyTo(stream);
                    propertyImage = stream.ToArray();
                    //propertyImages.Append(propertyImage);
                    //propertyImage.DocumentName = "dddd";
                    //propertyImage.ContentType = "dddd";
                    //_context.PropertyImages.Add(propertyImage);
                    //int NoOfRowsInserted = _context.SaveChanges();
                    //if(NoOfRowsInserted > 0)
                    //{
                    //    return Ok(new { message = "Documents Saved Successfully" });
                    //}
                    //else
                    //{
                    //    return Ok(new { message = "Something went wrong. Please try again." });
                    //}//_context.SaveChanges();
                }
            //}
            return Ok(new { message = propertyImage });
            //try
            //{
            //    List<PropertyImage> DocList = GetDocList(DocumentInputModel.DocumentList);
            //    _context.PropertyImages.AddRange(DocList);
            //    
            //}
            //catch(Exception ex)
            //{
            //    return Ok(new { message = ex.Message });
            //}
        }

        private List<PropertyImage> GetDocList(PropertyImage[] lstDocVM)
        {
            List<PropertyImage> DBDocList = new List<PropertyImage>();
            foreach(var Doc in lstDocVM)
            {
                //Doc.DocumentContent = Doc.DocumentContent.Substring(Doc.DocumentContent.IndexOf(",") + 1);
                DBDocList.Add(new PropertyImage
                {
                    //DocumentName = Doc.DocumentName,
                    //DocumentContent = Convert.FromBase64String(Doc.DocumentContent),
                    //ContentType = Doc.ContentType
                });
            }
            return DBDocList;
        }

        [HttpGet("DownloadDocument/{DocumentId}")]
        public IActionResult DownloadDocument(string DocumentId)
        {
            try
            {
                return null;
                //PropertyImage doc = _context.PropertyImages.FirstOrDefault(d => d.DocumentId == DocumentId);
                //return File(doc.DocumentContent, doc.ContentType, doc.DocumentName);
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
    }
}
