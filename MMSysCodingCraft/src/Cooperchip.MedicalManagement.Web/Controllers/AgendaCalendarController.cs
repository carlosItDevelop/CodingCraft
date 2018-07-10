using System;
using System.Linq;
using System.Web.Mvc;
using Cooperchip.MedicalManagement.Domain.Entidade;
using Cooperchip.MedicalManagement.Infra.Data;

namespace Cooperchip.MedicalManagement.Web.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class AgendaCalendarController : Controller
    {
        // GET: AgendaCalendar
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetEvents()
        {
            using ( MedicalManagementDbContext dc = new MedicalManagementDbContext() )
            {
                var evt = dc.Events.OrderBy(x => x.StartAt).ToList();
                return new JsonResult { Data = evt, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        //Action for Save event
        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SaveEvent( Events evt )
        {
            bool status = false;
            using ( MedicalManagementDbContext dc = new MedicalManagementDbContext() )
            {
                if ( evt.EndAt != null && evt.StartAt.TimeOfDay == new TimeSpan(0, 0, 0) &&
                    evt.EndAt.TimeOfDay == new TimeSpan(0, 0, 0) )
                {
                    evt.IsFullDay = true;
                }
                else
                {
                    evt.IsFullDay = false;
                }

                if ( evt.EventId > 0 )
                {
                    var v = dc.Events.FirstOrDefault(a => a.EventId.Equals(evt.EventId));
                    if ( v != null )
                    {
                        v.Title = evt.Title;
                        v.Description = evt.Description;
                        v.StartAt = evt.StartAt;
                        v.EndAt = evt.EndAt;
                        v.IsFullDay = evt.IsFullDay;
                    }
                }
                else
                {
                    dc.Events.Add(evt);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        [HttpPost]        
        public JsonResult DeleteEvent( int eventId )
        {
            bool status = false;
            using ( MedicalManagementDbContext dc = new MedicalManagementDbContext() )
            {
                var v = dc.Events.FirstOrDefault(a => a.EventId.Equals(eventId));
                if ( v != null )
                {
                    dc.Events.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}