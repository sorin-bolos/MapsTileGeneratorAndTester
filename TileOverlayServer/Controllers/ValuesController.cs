using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TileOverlayServer.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public HttpResponseMessage Get(int zoom, int x, int y)
        {
            var bitmap = new Bitmap(@"D:\CodeExamples\TileOverlayServer\TileOverlayServer\bin\0.bmp");
            var rectangle = new RectangleF(10, 50, 256, 128);
            var graphics = Graphics.FromImage(bitmap);

            graphics.DrawString($"Zoom:{zoom}\nx:{x}\ny:{y}", new Font("Tahoma", 24), Brushes.Black, rectangle);
            graphics.Flush();

            var ms = new MemoryStream();
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            ms.Position = 0;

            HttpResponseMessage r = Request.CreateResponse();
            r.Content = new StreamContent(ms);
            r.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
            return r;

        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
