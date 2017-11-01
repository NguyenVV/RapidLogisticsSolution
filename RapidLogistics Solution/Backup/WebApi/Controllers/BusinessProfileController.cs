using AttributeRouting;
using AttributeRouting.Web.Http;
using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.ActionFilters;

namespace WebApi.Controllers
{
    [AuthorizationRequired]
    [RoutePrefix("v1/BusinessProfiles/BusinessProfile")]
    public class BusinessProfileController : ApiController
    {
        #region Private variable.

        private readonly IBusinessProfileServices _businessProfileServices;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize businessProfile service instance
        /// </summary>
        public BusinessProfileController(IBusinessProfileServices businessProfileServices)
        {
            _businessProfileServices = businessProfileServices;
        }

        #endregion

        // GET api/businessProfile
        [GET("allbusinessProfiles")]
        [GET("all")]
        public HttpResponseMessage Get()
        {
            var businessProfiles = _businessProfileServices.GetAllBusinessProfileEntitys();

            if (businessProfiles != null && businessProfiles.Any())
            {
                var businessProfileEntities = businessProfiles as List<BusinessProfileEntity> ?? businessProfiles.ToList();
                return Request.CreateResponse(HttpStatusCode.OK, businessProfileEntities);
            }
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "BusinessProfiles not found");
        }

        // GET api/businessProfile/5
        [GET("businessProfile/{id?}")]
        [GET("particularbusinessProfile/{id?}")]
        [GET("myBusinessProfile/{id:range(1, 3)}")]
        public HttpResponseMessage Get(int id)
        {
            var businessProfile = _businessProfileServices.GetBusinessProfileEntityById(id);
            if (businessProfile != null)
                return Request.CreateResponse(HttpStatusCode.OK, businessProfile);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No businessProfile found for this id");
        }

        // POST api/businessProfile
        [POST("Create")]
        [POST("Register")]
        public int Post([FromBody] BusinessProfileEntity businessProfileEntity)
        {
            return _businessProfileServices.CreateBusinessProfileEntity(businessProfileEntity);
        }

        // PUT api/businessProfile/5
        [PUT("Update/businessProfile/{id}")]
        [PUT("Modify/businessProfile/{id}")]
        public bool Put(int id, [FromBody] BusinessProfileEntity businessProfileEntity)
        {
            if (id > 0)
            {
                return _businessProfileServices.UpdateBusinessProfileEntity(id, businessProfileEntity);
            }
            return false;
        }

        // DELETE api/businessProfile/5
        [DELETE("remove/businessProfile/{id}")]
        [DELETE("clear/businessProfile/{id}")]
        [PUT("delete/businessProfile/{id}")]
        public bool Delete(int id)
        {
            if (id > 0)
                return _businessProfileServices.DeleteBusinessProfileEntity(id);
            return false;
        }
    }
}
