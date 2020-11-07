using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPIAndMVCProject.Models;

namespace WebAPIAndMVCProject.DatataAccess
{

    public interface IWatherdataAccessLayer
    {
        WatherInfo GetWatherInfo();

    }
}