using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;
using DLA.Repository;
using mvc.Models;
namespace mvc.Controllers
{
    public class VendorController : Controller
    {
               
        #region Dependence Injection Princile
        private static IVendor _vendor = null;

        public VendorController(IVendor Vendor)
        {
            _vendor = Vendor;
        }

        public VendorController()
            : this(new VendorRepository())
        { }
        #endregion
        //
        // GET: /Vendor/

        public ActionResult VendorIndex()
        {
            List<VendorObject> listvendorobj = new List<VendorObject>();

            listvendorobj = _vendor.GetAll();

            List<VendorModel> listModel = new List<VendorModel>();

            foreach (VendorObject cs in listvendorobj)
            {
                listModel.Add(new VendorModel
                {
                    MsgId = cs.MsgId,
                    DisplayNo = cs.DisplayMsg,
                    Msg_Title = cs.Msg_Title,
                    Full_Message = cs.Full_Message,
                    
                });
            }

            return View(listModel);
        }
        [HttpGet]
        public ActionResult Add()
        {
            VendorModel vendormodel1 = new VendorModel();
            return View(vendormodel1);
        }


        [HttpPost]
        public ActionResult Add(VendorModel vendormodel)
        {
            if (ModelState.IsValid)
            {
                VendorObject venobj = new VendorObject();
                venobj.DisplayMsg = vendormodel.DisplayNo;
                venobj.Msg_Title = vendormodel.Msg_Title;
                venobj.Full_Message = vendormodel.Full_Message;
                


                 _vendor.Add(venobj);

            }

            else
            {
                return View(vendormodel);
            }

            return RedirectToAction("VendorIndex", "Vendor");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
             VendorObject venobj =new VendorObject();
            VendorModel vendormodel =new VendorModel();
            VendorRepository venrep= new VendorRepository();
            venobj=venrep.GetById(Id);
            vendormodel.MsgId = venobj.MsgId;
            vendormodel.DisplayNo = venobj.DisplayMsg;
            vendormodel.Msg_Title = venobj.Msg_Title;
            vendormodel.Full_Message = venobj.Full_Message;
             
            return View(vendormodel);
        }
         [HttpPost]
        public ActionResult Edit(VendorModel vendormodel)
        {
                
                VendorObject venobj =new VendorObject();
                venobj.MsgId = vendormodel.MsgId;
                venobj.DisplayMsg=vendormodel.DisplayNo;
                venobj.Msg_Title=vendormodel.Msg_Title;
                venobj.Full_Message=vendormodel.Full_Message;
                
                
                _vendor.Update(venobj);

                return RedirectToAction ("vendorIndex","Vendor");
        }
        public ActionResult Delete(int Id)
        {
            VendorObject venobj = new VendorObject();
            VendorModel vendormodel = new VendorModel();
            VendorRepository venrep = new VendorRepository();
            venrep.Delete(Id);
            return RedirectToAction("VendorIndex", "Vendor");
        }
        public ActionResult View(int Id)
        {
            VendorObject venobj = new VendorObject();
            VendorModel vendormodel = new VendorModel();
            VendorRepository venrep = new VendorRepository();
            venobj = venrep.GetById(Id);
            vendormodel.MsgId = venobj.MsgId;
            vendormodel.DisplayNo = venobj.DisplayMsg;
            vendormodel.Msg_Title = venobj.Msg_Title;
            vendormodel.Full_Message = venobj.Full_Message;
            
            return View(vendormodel);
        }


    }
}
