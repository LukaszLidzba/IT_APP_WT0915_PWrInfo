using ProjektGlowny.LoginService;
using ProjektGlowny.Models;
using System;
using System.Web.Mvc;

namespace ProjektGlowny.Controllers
{
  public class LoginController : Controller
  {
    // GET: User
    [AllowAnonymous]
    public ActionResult Login()
    {
      return View();
    }

    //
    // POST: /Account/Login

    [HttpPost]
    [AllowAnonymous]
    public ActionResult Login(UserModels model, string returnUrl)
    {
      ILoginService loginService = new LoginServiceClient();

      try
      {
        var result = loginService.Login(model.UserName.Trim(), model.Password.Trim());
      }
      catch (Exception ex)
      {
      }

      //if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password))
      //{
      //    return RedirectToLocal(returnUrl);
      //}

      //// If we got this far, something failed, redisplay form
      ModelState.AddModelError("", "The user name or password provided is incorrect.");
      return View(model);
    }

    //
    // POST: /Account/LogOff

    [HttpPost]
    public ActionResult LogOff()
    {
      // HERE CLEAN SESSION - GET RID OFF TAKEN!!!  //PZJ

      return RedirectToAction("Index", "Home");
    }

    #region Helpers

    private ActionResult RedirectToLocal(string returnUrl)
    {
      if (Url.IsLocalUrl(returnUrl))
      {
        return Redirect(returnUrl);
      }
      else
      {
        return RedirectToAction("Index", "Home");
      }
    }

    #endregion Helpers
  }
}