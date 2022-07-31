using AgreementDemo.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AgreementDemo.Data
{
    public class AgreementOpr
    {
        public static Agreement AddAgreements(Agreement agreement)
        {
            AgreementDbContext context;
            try
            {
                context = new AgreementDbContext(); 
                agreement.InsertionDate = DateTime.Now;
                agreement.UpdateDate = DateTime.Now;
                agreement.Status = 1;
                agreement = context.Agreements.Add(agreement);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return agreement;
        }

        public static Agreement GetAgreement(int AgreementId)
        {
            AgreementDbContext context;
            Agreement agreement = null;
            try
            {
                context = new AgreementDbContext();
                agreement = context.Agreements.SingleOrDefault(x => x.Status == 1 && x.AgreementID == AgreementId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return agreement;
        }

        public static List<Agreement> GetAgreements()
        {
            AgreementDbContext context;
            List<Agreement> agreements = null;
            try
            {
                context = new AgreementDbContext();
                agreements = context.Agreements.Where(x => x.Status == 1).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return agreements;
        }

        public static Agreement UpdateAgreements(Agreement agreement)
        {
            AgreementDbContext context;
            try
            {
                context = new AgreementDbContext();
                agreement.UpdateDate = DateTime.Now;
                context.Entry(agreement).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return agreement;
        }

        public static Agreement SaveAgreements(Agreement agreement)
        {
            Agreement tempAgreement = null;
            try
            {
                if(agreement.AgreementID == 0)
                {
                    AddAgreements(agreement);
                }
                else
                {
                    tempAgreement = GetAgreement(agreement.AgreementID);
                    tempAgreement.RecordNumber = agreement.RecordNumber;
                    tempAgreement.IdentityNumber = agreement.IdentityNumber;
                    tempAgreement.Name = agreement.Name;
                    tempAgreement.StratDate = agreement.StratDate;
                    tempAgreement.EndDate = agreement.EndDate;
                    tempAgreement.ProcessStatus = agreement.ProcessStatus;
                    tempAgreement.AgreementType = agreement.AgreementType;
                    tempAgreement.Description = agreement.Description;
                    tempAgreement.RequestNumber = agreement.RequestNumber;
                    tempAgreement.IngoingDocumentDate = agreement.IngoingDocumentDate;
                    tempAgreement.IngoingDocumentNumber = agreement.IngoingDocumentNumber;
                    tempAgreement.HappensDateTime = agreement.HappensDateTime;
                    tempAgreement.HappensCount = agreement.HappensCount;
                    tempAgreement.FileUrl = agreement.FileUrl;
                    UpdateAgreements(tempAgreement);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            return agreement;
        }
    }
}