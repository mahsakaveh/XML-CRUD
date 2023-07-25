using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCXML.Models;
using Microsoft.AspNetCore.Hosting;

namespace MVCXML.Controllers;

public class AdminController : Controller
{
    // GET: /Admin/
    public ActionResult Index()
    {
        List<EmployeeModels> lstEmployee = new List<EmployeeModels>();
        DataSet ds = new DataSet();
        ds.ReadXml(MapPath("~/XML/Data.xml"));
        DataView dvPrograms;
        dvPrograms = ds.Tables[0].DefaultView;
        dvPrograms.Sort = "name";

        foreach (DataRowView item in dvPrograms)
        {
            EmployeeModels empModel = new EmployeeModels();
            empModel.EmployeeName = Convert.ToString(item[0]);
            empModel.Email = Convert.ToString(item[1]);
            empModel.Phone = Convert.ToString(item[2]);
            lstEmployee.Add(empModel);
        }
        if (lstEmployee.Count > 0)
        {
            return View(lstEmployee);
        }
        return View();
    }

    private Stream? MapPath(string v)
    {
        throw new NotImplementedException();
    }
}
