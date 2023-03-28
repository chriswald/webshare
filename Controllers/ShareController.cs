
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace WebShare.Controllers
{
    [Route("")]
    [ApiController]
    public class ShareController : ControllerBase
    {
        [HttpGet]
        [Route($"{nameof(Await)}")]
        public ContentResult Await()
        {
            Guid guid = Guid.NewGuid();
            QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
            QRCodeData qRCodeData = qRCodeGenerator.CreateQrCode(guid.ToString(), QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qRCodeData);
            byte[] bytes = qrCode.GetGraphic(20);
            return new ContentResult
            {
                Content = $"<html><img src='data:image/bmp;base64,{Convert.ToBase64String(bytes)}'></img></html>",
                ContentType = "text/html" ,
            };
        }

        [HttpGet]
        [Route($"{nameof(Share)}")]
        public string Share([FromQuery] string id, [FromQuery] string url)
        {
            return $"id: {id} url: {url}";
        }
    }
}
