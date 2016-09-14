﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using BeerDrinkin.DataObjects;
using BeerDrinkin.Service.Models;

namespace BeerDrinin.Service.Controllers
{
    public class ImageController : TableController<Image>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<Image>(context, Request);
        }

        // GET tables/Image
        public IQueryable<Image> GetAllImage()
        {
            return Query(); 
        }

        // GET tables/Image/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Image> GetImage(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Image/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Image> PatchImage(string id, Delta<Image> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Image
        public async Task<IHttpActionResult> PostImage(Image item)
        {
            Image current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Image/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteImage(string id)
        {
             return DeleteAsync(id);
        }
    }
}
