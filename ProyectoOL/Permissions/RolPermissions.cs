using ProyectoOL.Dto;
using System.Web;
using System.Web.Mvc;

namespace ProyectoOL.Permissions
{
    public class RolPermissions : ActionFilterAttribute
    {
        private bool Admin, Client, Librarian;
        
        public RolPermissions(bool rAdmin, bool rClient, bool rLibrarian)
        {
            this.Admin = rAdmin;
            this.Client = rClient;
            this.Librarian = rLibrarian;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            if(HttpContext.Current.Session["User"] != null)
            {
                UserDto user = HttpContext.Current.Session["User"] as UserDto;

                if (user.Tipo_Usuario == 1 && this.Admin == false)
                {
                    filterContext.Result = new RedirectResult("~/Views/Error/PageNotFound.cshtml");
                }
                if(user.Tipo_Usuario == 2 && this.Client == false)
                {
                    filterContext.Result = new RedirectResult("~/Views/Error/PageNotFound.cshtml");
                }
                if (user.Tipo_Usuario == 3 && this.Librarian == false)
                {
                    filterContext.Result = new RedirectResult("~/Views/Error/PageNotFound.cshtml");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}