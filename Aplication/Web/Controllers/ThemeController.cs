using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class ThemeController : Controller
    {

        public void SetSideBar(String color)
        {
            Session["colorSideBar"] = color;
        }
        public void SetLogo(String color)
        {
            Session["colorLogo"] = color;
        }
        public void SetHeader(String color)
        {
            Session["colorHeader"] = color;
        }

        public void LoadTheme()
        {

            if (Session["colorSideBar"] == null)
            {
                Session["colorSideBar"] = "dark";
            }
            if (Session["colorLogo"] == null)
            {
                Session["colorLogo"] = "blue";
            }
            if (Session["colorHeader"] == null)
            {
                Session["colorHeader"] = "white";
            }
        }


        public ActionResult GetSideBar()
        {
            String color = "";

            try
            {
                color = (String)Session["colorSideBar"];

            }
            catch (Exception ex)
            {
                
            }
            
            return Content(color);
        }
        public ActionResult GetLogo()
        {
            String color = "";

            try
            {
                color = (String)Session["colorLogo"];
            }
            catch (Exception ex)
            {

            }            

            return Content(color);
        }
        public ActionResult GetHeader()
        {
            String color = "";

            try
            {
                color = (String)Session["colorHeader"];
            }
            catch (Exception ex)
            {
             
            }            

            return Content(color);
        }
    }
}