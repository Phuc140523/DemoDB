﻿using DemoDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoDB.Controllers
{
    public class LoginUserController : Controller
    {
        DBSportStoreEntities database = new DBSportStoreEntities();
        // GET: LoginUser
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(AdminUser _user)
        {
            if(ModelState.IsValid)
            {
                var check_ID = database.AdminUsers.Where(s => s.ID == _user.ID).FirstOrDefault();
                if(check_ID==null)
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.AdminUsers.Add(_user);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorRegister = "this ID is exixst";
                    return View();
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult LoginAccount(AdminUser _user)
        {
            var check = database.AdminUsers.Where(s => s.NameUser== _user.NameUser && s.PasswordUser == _user.PasswordUser).FirstOrDefault();

            if (check == null)
            {
                ViewBag.ErrorInfo = "SaiInfo";
                return View("Index");
            }
            else
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["NameUser"] = _user.NameUser;
                Session["PasswordUser"] = _user.PasswordUser;
                return RedirectToAction("Index", "Product");
            }
                
                
        }
        public ActionResult LogOutUser()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LoginUser");
        }
    }
}