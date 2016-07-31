using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using DAL;
using System.Data;

using System.Windows.Forms;
namespace BO
{
    public class Account_BO
    {
        Account_DAL account_DAL = new Account_DAL();

        //Member And Admin Panel
        public bool setMember(Member member)
        {
            return account_DAL.setMember(member);
        }
        public Member getMember(string name)
        {
            return account_DAL.getMember(name);
        }
        public DataSet getAllMember()
        {
            return account_DAL.getAllMember();
        }
        public bool updateMember(Member member)
        {
            return account_DAL.updateMember(member);
        }
        public bool deleteMember(string userName)
        {
            return account_DAL.deleteMember(userName);
        }
        public bool setMemberAttendence(Member member)
        {
            return account_DAL.setMemberAttendence(member);
        }
        public DataSet getMemberAttendenceOfTheCurrentMonth(Member member, string date2)
        {
            return account_DAL.getMemberAttendenceOfTheCurrentMonth(member, date2);
        }
        public bool setMemberAdvance(Advance advance)
        {
            return account_DAL.setMemberAdvance(advance);
        }
        public DataSet getProfitForsalary(string date1, string date2, string memberUsername)
        {
            return account_DAL.getProfitForsalary(date1, date2, memberUsername);
        }
        public DataSet getMemberAdvanceOfTheCurrentMonth(Member member, string date2)
        {
            return account_DAL.getMemberAdvanceOfTheCurrentMonth(member, date2);
        }
        public bool setSalaryHistory(SalaryHistory salaryHistory)
        {
            return account_DAL.setSalaryHistory(salaryHistory);
        }
        public DataSet getSalaryHistory(string year1, string year2, string memberUsername)
        {
            return account_DAL.getSalaryHistory(year1, year2, memberUsername);
        }
        //Note
        public bool setNote(Note note)
        {
            return account_DAL.setNote(note);
        }
        public DataSet getNote(Note note)
        {
            return account_DAL.getNote(note);
        }
        public bool DeleteNote(Note note)
        {
            return account_DAL.DeleteNote(note);
        }
        //Client
        public bool setClient(Client client)
        {
            return account_DAL.setClient(client);
        }
        public Client getClient(string cardNo)
        {
            return account_DAL.getClient(cardNo);
        }
        public DataSet getAllClient()
        {
            return account_DAL.getAllClient();
        }
        public bool deleteClient(Client client)
        {
            return account_DAL.deleteClient(client);
        }
        public bool updateClient(Client client)
        {
            return account_DAL.updateClient(client);
        }
        //Product Panel
        public bool setProduct(Product product)
        {
            return account_DAL.setProduct(product);
        }
        public bool updateProduct(Product product)
        {
            return account_DAL.updateProduct(product);
        }
       
        public bool setTempProduct(Product product)
        {
            return account_DAL.setTempProduct(product);
        }
        public bool setSoldProduct(Product product,string discount,string MRP)
        {
            return account_DAL.setSoldProduct(product,discount,MRP);
        }
        public DataSet getTempClientProduct()
        {
            return account_DAL.getTempClientProduct();
        }
        public DataSet getProduct(Product product)
        {
            return account_DAL.getProduct(product);
        }
        public DataSet getSoldProduct(string barcode,string invoiceNo)
        {
            return account_DAL.getSoldProduct(barcode,invoiceNo);
        }
        public DataSet getSoldProductByAllsearch(Product product)
        {
            return account_DAL.getSoldProductByAllsearch(product);
        }
        public DataSet getAllSoldProduct(string date1, string date2)
        {
            return account_DAL.getAllSoldProduct(date1,date2);
        }
        public DataSet getAllSoldProductForSalary(string date1, string date2,string userName)
        {
            return account_DAL.getAllSoldProductForSalary(date1, date2,userName);
        }
      
        public Product getTempProductBySerialNoforReentry(string serialNo)
        {
            return account_DAL.getTempProductBySerialNoforReentry(serialNo);
        }
       //rerturnCompanyProdut
        public bool setReturnCompanyProduct(Product product, string reference, string cause, string date)
        {
            return account_DAL.setReturnCompanyProduct(product, reference, cause, date);
        }
        public DataSet getReturnCompanyProduct(string barcode, string date)
        {
            return account_DAL.getReturnCompanyProduct(barcode, date);
        }
        public bool deleteReturnCompanyProduct(string barcode)
        {
            return account_DAL.deleteReturnCompanyProduct(barcode);
        }
        //returnClientProduct
        public bool setReturnClientProduct(Product product, string reference, string cause, string discount ,string date)
        {
            return account_DAL.setReturnClientProduct(product, reference, cause, discount, date);
        }
        public DataSet getReturnClientProduct(string barcode, string invoiceNo)
        {
            return account_DAL.getReturnClientProduct(barcode, invoiceNo);
        }
        public bool deleteReturnClientProduct(string barcode)
        {
            return account_DAL.deleteReturnClientProduct(barcode);
        }

        public bool deleteProduct(string serialNo)
        {
            return account_DAL.deleteProduct(serialNo);
        }
        public bool deleteTempProduct(string serialNo)
        {
            return account_DAL.deleteTempProduct(serialNo);
        }
        public bool deleteSoldProduct(string serialNo)
        {
            return account_DAL.deleteSoldProduct(serialNo);
        }
        public bool deleteAllTempProduct()
        {
            return account_DAL.deleteAllTempProduct();
        }
       
        
       
        //Expenditure
        public bool setExpenditure(Expenditure expenditure)
        {
            return account_DAL.setExpenditure(expenditure);
        }
        public DataSet getExpenditure(string date1, string date2)
        {
            return account_DAL.getExpenditure(date1, date2);
        } 

        //Invoice
        public bool updateInvoice(string newInvoiceNo, string oldInvoiceNo)
        {
            return account_DAL.updateInvoice(newInvoiceNo, oldInvoiceNo);
        }
        public string getInvoice()
        {
            return account_DAL.getInvoice();
        }
       
    }
}
