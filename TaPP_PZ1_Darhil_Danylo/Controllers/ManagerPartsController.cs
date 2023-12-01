﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPP_PZ1_Darhil_Danylo.DAL.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.PortableExecutable;
using TPP_PZ1_Darhil_Danylo.DAL.DAO.DAOImp;
using TPP_PZ1_Darhil_Danylo.DAL.ViewModels;

namespace TPP_PZ1_Darhil_Danylo.Controllers
{
    public class ManagerPartsController : Controller
    {
        AutoPartDAO AutoPartDAO = new AutoPartDAO();
        public ActionResult GetAutoParts()
        {
            List<AutoPart> autoparts = AutoPartDAO.GetAll();
            return View("ManagerParts",autoparts);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            AutoPartDAO.Delete(id);
            return RedirectToAction(controllerName: "ManagerParts", actionName: "GetAutoParts");
        }
        public ActionResult SearchAutoParts(string searchcriteria)
        {
            List<AutoPart> autoparts = AutoPartDAO.SearchByCriteria(searchcriteria);
            return View("ManagerParts", autoparts);
        }

    }
}
