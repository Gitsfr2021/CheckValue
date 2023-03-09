using Kaspid.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Kaspid.Controllers
{
    public class MainController : Controller
    {
        #region Fields

        public DalEntities db = new DalEntities();

        #endregion Fields


        #region Ctor

        public MainController()
        {
            
            
        }

        #endregion Ctor

        #region Methods

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        #endregion Methods

      
    }
}