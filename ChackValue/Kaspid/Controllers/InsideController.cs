using System.Linq;
using Kaspid.Models;


namespace Kaspid.Controllers
{
    public class InsideController : MainController
    {
        #region Ctor

        public InsideController()
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