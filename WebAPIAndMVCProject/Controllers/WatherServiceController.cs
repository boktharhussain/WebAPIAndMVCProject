using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIAndMVCProject.DatataAccess;
using WebAPIAndMVCProject.Models;

namespace WebAPIAndMVCProject.Controllers
{
    public class WatherServiceController :ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private IWatherdataAccessLayer _watherService;
        // GET: WatherService
        public WatherServiceController(IWatherdataAccessLayer wather)
        {
            _watherService = wather;
        }
        [System.Web.Http.HttpGet]
        public HttpResponseMessage GetWatherInformation()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _watherService.GetWatherInfo());

            }
            catch (Exception exp)
            {

                logger.Info("Getting issue in Get Wather Information" + Environment.NewLine + DateTime.Now);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exp.ToString());
            }
        }
    }
}