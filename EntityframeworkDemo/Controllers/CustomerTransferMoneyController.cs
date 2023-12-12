using EntityframeworkDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseFirstLibrary;

namespace EntityframeworkDemo.Controllers
{
    public class CustomerTransferMoneyController : Controller
    {

        DatabaseFirstLibrary.SomeBankEntities db = new DatabaseFirstLibrary.SomeBankEntities();

        List<TransactionDetails> listTransactions = new List<TransactionDetails>();

        // GET: CustomerTransferMoney
        public ActionResult Index()
        {

            listTransactions = (List<TransactionDetails>)TempData["list_tran"];

            return View(listTransactions);
            
        }


        public ActionResult ShowTransactionHistoryForAccountNo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowTransactionHistoryForAccountNo(int custid)
        {


            IQueryable<DatabaseFirstLibrary.fn_ShowTransactionHistory_Result> result = db.fn_ShowTransactionHistory(custid);
            List<DatabaseFirstLibrary.fn_ShowTransactionHistory_Result> list = result.AsEnumerable<DatabaseFirstLibrary.fn_ShowTransactionHistory_Result>().ToList();

            foreach (var item in list)
            {
                TransactionDetails t = new TransactionDetails();
                t.tranid = Convert.ToInt32(item.Tranid);
                t.trandate = Convert.ToDateTime(item.tranDate);
                t.amt = Convert.ToDecimal(item.Amt);
                listTransactions.Add(t);
            }
            TempData["list_tran"] = listTransactions;
            return RedirectToAction("Index");
        }

        public ActionResult TransferMoney()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TransferMoney(CustMoneyTrans trans)
        {

            db.sp_TransferMoney(trans.CustFrom, trans.CustTo, trans.Amt);
            db.SaveChanges();
            return Content("Transferred Money successfully");

        }


    }
}