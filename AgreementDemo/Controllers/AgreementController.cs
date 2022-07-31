using AgreementDemo.Data;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static Domain.Constant.Constants;

namespace AgreementDemo.Controllers
{
    public class AgreementController : Controller
    {

        public ActionResult List()
        {
            List<Agreement> agreements = null;
            try
            {
                agreements = AgreementOpr.GetAgreements();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return View(agreements);
        }

        [HttpGet]
        public ActionResult Save(int Id = 0)
        {
            this.BindValues(Id);
            return View();
        }

        [HttpPost]
        public ActionResult Save(Agreement agreement)
        {
            try
            {
                agreement = AgreementOpr.SaveAgreements(agreement);
                this.BindValues(agreement.AgreementID, MessageTypes.Success);
            }
            catch (Exception ex)
            {
                this.BindValues(agreement.AgreementID, MessageTypes.Success);
                Console.WriteLine(ex.Message);
                throw;
            }
            return View();
        }

        private void BindValues(int Id, MessageTypes messageTypes = MessageTypes.Nothing)
        {
            Agreement agreement = null;
            try
            {
                if (Id == 0)
                {
                    ViewBag.Action = Actions.Create;
                }
                else
                {
                    ViewBag.Action = Actions.Update;
                    agreement = AgreementOpr.GetAgreement(Id);
                    ViewBag.Model = agreement;

                }
                this.SetViewBagSelectLists();
                this.SetResultMessage(messageTypes, Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        private void SetResultMessage(MessageTypes messageTypes, int Id)
        {
            @ViewBag.MessageType = messageTypes;
            if (messageTypes == MessageTypes.Error)
            {
                ViewBag.Message = "İşlem başarısız.";
            }
            else if (messageTypes == MessageTypes.Success)
            {
                ViewBag.Message = "İşlem başarılı.";
            }
        }

        private void SetViewBagSelectLists()
        {
            try
            {
                IEnumerable<SelectListItem> procesStatuses = Enum.GetValues(typeof(ProcessStatuses)).Cast<ProcessStatuses>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
                SelectList tProcesStatuses = new SelectList(procesStatuses, "Value", "Text");
                IEnumerable<SelectListItem> agreementTypesList = Enum.GetValues(typeof(AgreementTypes)).Cast<AgreementTypes>().Select(x => new SelectListItem { Text = x.ToString(), Value = ((int)x).ToString() }).ToList();
                SelectList tAgreementTypesList = new SelectList(agreementTypesList, "Value", "Text");
                ViewBag.ProcessStatusList = tProcesStatuses;
                ViewBag.AgreementTypesList = tAgreementTypesList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}