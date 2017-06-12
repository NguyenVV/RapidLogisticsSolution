using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AttributeRouting;
using AttributeRouting.Web.Http;
using BusinessEntities;
using BusinessServices;
using WebApi.ActionFilters;
using BusinessServices.Interfaces;

namespace WebApi.Controllers
{
    [AuthorizationRequired]
    [RoutePrefix("v1/Manifests/Manifest")]
    public class ManifestController : ApiController
    {
        //
        // GET: /Manifest/

        #region Private variable.

        private readonly IManifestServices _manifestServices;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize manifest service instance
        /// </summary>
        public ManifestController(IManifestServices manifestServices)
        {
            _manifestServices = manifestServices;
        }

        #endregion

        // GET api/manifest
        [GET("allmanifests")]
        [GET("all")]
        public HttpResponseMessage Get()
        {
            var manifests = _manifestServices.GetAllManifests();
            
            if (manifests != null && manifests.Any())
            {
                var manifestEntities = manifests as List<ManifestEntity> ?? manifests.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, manifestEntities);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Manifests not found");
        }

        // GET api/manifest/5
        [GET("manifest/{id?}")]
        [GET("particularmanifest/{id?}")]
        [GET("mymanifest/{id:range(1, 3)}")]
        public HttpResponseMessage Get(int id)
        {
            var manifest = _manifestServices.GetManifestById(id);
            if (manifest != null)
                return Request.CreateResponse(HttpStatusCode.OK, manifest);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No manifest found for this id");
        }

        //// POST api/manifest
        //[POST("Create")]
        //[POST("Register")]
        //public int Post([FromBody] ManifestEntity manifestEntity)
        //{
        //    return _manifestServices.CreateManifest(manifestEntity);
        //}

        // POST api/manifest
        [POST("pushListManifest")]
        public int Post([FromBody] List<ManifestEntity> manifestEntityList)
        {
            return _manifestServices.CreateManifest(manifestEntityList);
        }

        // PUT api/manifest/5
        [PUT("Update/manifest/{id}")]
        [PUT("Modify/manifest/{id}")]
        public bool Put(int id, [FromBody] ManifestEntity manifestEntity)
        {
            if (id > 0)
            {
                return _manifestServices.UpdateManifestEntity(id, manifestEntity);
            }
            return false;
        }

        // DELETE api/manifest/5
        [DELETE("remove/manifest/{id}")]
        [DELETE("clear/manifest/{id}")]
        [PUT("delete/manifest/{id}")]
        public bool Delete(int id)
        {
            if (id > 0)
                return _manifestServices.DeleteManifestEntity(id);
            return false;
        }

    }
}
