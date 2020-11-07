using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using WebAPIAndMVCProject.Models;

namespace WebAPIAndMVCProject.DatataAccess
{
    public class WatherDataAccess:IWatherdataAccessLayer
    {
        public WatherInfo GetWatherInfo()
        {
            try
            {
                WatherInfo watherinfo = new WatherInfo();

                string watherinfoUrl = ConfigurationManager.AppSettings["WatherInfoUrl"];
                //  watherinfoUrl = string.Format(watherinfoUrl, test);
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync(new Uri(watherinfoUrl)).Result;
                    if (response.IsSuccessStatusCode)
                        watherinfo = JsonConvert.DeserializeObject<WatherInfo>(response.Content.ReadAsStringAsync().Result);
                }
                return watherinfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}