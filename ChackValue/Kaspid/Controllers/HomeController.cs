using Kaspid.Models;
using Kaspid.Models.Utility;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMarkupMin.AspNet4.Mvc;


namespace Kaspid.Controllers
{
    public class HomeController : InsideController
    {
        // GET: RangeValue
        public ActionResult Index(string S_Num)
        {
            if (S_Num != null)
                ViewBag.S_Num = S_Num;

           var lst  = db.RangeValues.Select(p => new
            {
                Id = p.Id,
                Conditions = (p.Min == null ? "∞ " : p.Min.ToString()) + (p.Oprate1 ? "<= " : "< ") + "C1 " + (p.Oprate2 ? "<= " : "< ") + (p.Max == null ? "∞" : p.Max.ToString()),
                Min = p.Min,
                Max = p.Max,
                Oprate1= p.Oprate1,
                Oprate2= p.Oprate2,
                Result = p.Result,
            }).OrderBy(p => p.Min).Take(4).ToList(); 

            ViewBag.Range = lst;
            if (S_Num != null)
            {
                int num = Convert.ToInt32(S_Num);
                int count = 0;
                foreach (var item in lst)
                {
                    if ((item.Min==null || (item.Oprate1 ? item.Min <= num : item.Min < num)) &&
                        (item.Max==null || (item.Oprate2 ? item.Max >= num : item.Max > num)))
                    {
                        ViewBag.Messge ="Result is "+ item.Result;
                        count++;
                        return View();
                    }
                }
                if(count==0)
                {
                    ViewBag.Messge = "Not found";
                    return View();
                }
            }
            return View();
        }

        #region Create

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RangeValue rangeValue)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                try
                {
                    var list = db.RangeValues.OrderBy(p => p.Min).ToList();

                    if (rangeValue.Min != null && rangeValue.Max != null && rangeValue.Max <= rangeValue.Min)
                    {
                        ViewBag.Messge = "Max value is grater than Min value";
                        return View();
                    }
                    if ((rangeValue.Min == null && rangeValue.Max != null && rangeValue.Max < list.Max(p => p.Max))
                        ||(rangeValue.Min != null && rangeValue.Max == null && rangeValue.Min > list.Min(p => p.Min)))
                    {
                        ViewBag.Messge = "wrong data";
                        return View();
                    }
                    if (rangeValue.Min != null && rangeValue.Max != null 
                        && rangeValue.Min > list.Min(p => p.Min) && rangeValue.Max < list.Max(p => p.Max))
                    {
                        ViewBag.Messge = "wrong data";
                        return View();
                    }
                    if (list.Select(p => Convert.ToInt64(p.Min)).ToList().Contains(Convert.ToInt64(rangeValue.Min)) ||
                        (list.Select(p => Convert.ToInt64(p.Max)).ToList().Contains(Convert.ToInt64(rangeValue.Max))))
                    {
                        ViewBag.Messge = "wrong data";
                        return View();
                    }
                    foreach (var item in list)
                    {
                        if ((item.Oprate1 ? item.Min <= rangeValue.Min : item.Min < rangeValue.Min) &&
                            (item.Oprate2 ?  item.Max >= rangeValue.Max : item.Max > rangeValue.Max))
                        {
                            ViewBag.Messge = "wrong data";
                            return View();
                        }
                        if(rangeValue.Min==item.Max && rangeValue.Oprate1==item.Oprate2)
                        {
                            ViewBag.Messge = "wrong data";
                            return View();
                        }
                    }

                    db.RangeValues.Add(rangeValue);
                    db.Entry(rangeValue).State = EntityState.Added;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View();
                }
            }
        }


        #endregion
        #region Delete

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return Redirect("/404");
            }
            RangeValue RangeValue = db.RangeValues.Find(id);
            if (RangeValue == null)
            {
                return Redirect("/404");
            }
            else
            {
                db.Entry(RangeValue).State = EntityState.Deleted;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion
    }
}