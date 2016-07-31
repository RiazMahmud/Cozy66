using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITY;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Configuration;

namespace DAL
{
    public class Account_DAL
    {

        string connString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\DB\Cozy66.MDF;Integrated Security=True"; 
        //string connString = @"Data Source=DESKTOP-9KNRBC7,49172;Network Library=DBMSSOCN;Initial Catalog=H:\APPSTICK_PROJECT\ATK COMPUTER LTD\ATK COMPUTER LTD\DATABASE.MDF;Integrated Security=True";

        //MmberMaintainance
        public bool setMember(Member member)
        {     
            try
            {
                
                byte[] img = null;
                FileStream fs = new FileStream(member.imagePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
               
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SetMember", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = member.firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = member.lastName;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 15).Value = member.gender;
                cmd.Parameters.Add("@DOB", SqlDbType.NVarChar, 30).Value = member.DOB;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = member.email;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = member.userName;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = member.password;
                cmd.Parameters.Add("@Image", SqlDbType.Image).Value = img;
                cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 5).Value = "M";
                cmd.Parameters.Add("@PhoneNo", SqlDbType.NVarChar, 30).Value = member.phoneNo;
                cmd.Parameters.Add("@Salary", SqlDbType.NVarChar, 50).Value = member.salary;
                cmd.Parameters.Add("@Reference", SqlDbType.NVarChar).Value = member.reference;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
              
                return false;
            }
        }
        public Member getMember(string name)
        {
           
            try
            {
              SqlConnection conn = new SqlConnection(connString);
              SqlCommand cmd = new SqlCommand("GetAdminOrMember", conn);
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = name;
              conn.Open();
              SqlDataReader reader = cmd.ExecuteReader();
              reader.Read();
              Member member = new Member();
              member.firstName = (string)reader["FirstName"];
              member.lastName = (string)reader["LastName"];
              member.gender = (string)reader["Gender"];
              member.DOB = (string)reader["DOB"];
              member.email = (string)reader["Email"];
              member.phoneNo = (string)reader["PhoneNo"];
              member.userName = (string)reader["UserName"];
              member.password = (string)reader["Password"];
              member.type = (string)reader["Type"];
              member.image = (byte[])reader["Image"];
              member.salary = (string)reader["Salary"];
              reader.Close();
              conn.Close();
              return member;
            }
            catch (Exception ex)
            {          
                return null;
            }
        }
        public DataSet getAllMember()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("GetAllMember", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
        public bool updateMember(Member member)
        {
            try
            {
                byte[] img =member.image;
                if (member.imagePath != "")
                {
                    FileStream fs = new FileStream(member.imagePath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                }
              
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("UpdateMember", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100).Value = member.firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 100).Value = member.lastName;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 15).Value = member.gender;
                cmd.Parameters.Add("@DOB", SqlDbType.NVarChar, 30).Value = member.DOB;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = member.email;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = member.userName;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 100).Value = member.password;
                cmd.Parameters.Add("@Image", SqlDbType.Image).Value = img;
                cmd.Parameters.Add("@PhoneNo", SqlDbType.NVarChar, 30).Value = member.phoneNo;
                cmd.Parameters.Add("@Salary", SqlDbType.NVarChar, 50).Value = member.salary;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool deleteMember(string userName)
        {
            try
            {

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("DeleteMember", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = userName;  
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool setMemberAttendence(Member member)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SetMemberAttendence", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 10).Value = member.attendenceDate;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = member.userName;
                cmd.Parameters.Add("@Attendence", SqlDbType.NVarChar, 1).Value = member.attendenceStatus;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DataSet getMemberAttendenceOfTheCurrentMonth(Member member, string date2)
        {
            try
            {
                
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("GetMemberAttendenceOfTheCurrentMonth", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date1", SqlDbType.NVarChar, 10).Value = member.attendenceDate;
                cmd.Parameters.Add("@Date2", SqlDbType.NVarChar, 10).Value = date2;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = member.userName;
                
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                return ds;

            }
            catch
            {
                
                return null;
            }
        }
        public bool setMemberAdvance(Advance advance)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SetAdvance", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 10).Value = advance.date;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = advance.userName;
                cmd.Parameters.Add("@Amount", SqlDbType.NVarChar, 20).Value = advance.amount;
                cmd.Parameters.Add("@Cause", SqlDbType.NVarChar, 500).Value = advance.cause;
                cmd.Parameters.Add("@Reference", SqlDbType.NVarChar, 100).Value = advance.reference;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DataSet getMemberAdvanceOfTheCurrentMonth(Member member, string date2)
        {
            try
            {

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("GetMemberAdvanceOfTheCurrentMonth", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date1", SqlDbType.NVarChar, 10).Value = member.attendenceDate;
                cmd.Parameters.Add("@Date2", SqlDbType.NVarChar, 10).Value = date2;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = member.userName;

                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                return ds;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public bool setSalaryHistory(SalaryHistory salaryHistory)
        {
            try
            {

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SetSalaryHistory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 50).Value = salaryHistory.year;
                cmd.Parameters.Add("@Month", SqlDbType.NVarChar, 50).Value = salaryHistory.month;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = salaryHistory.UserName;
                cmd.Parameters.Add("@TotalAttendence", SqlDbType.NVarChar, 50).Value = salaryHistory.totalAttendence;
                cmd.Parameters.Add("@BasicSalary", SqlDbType.NVarChar, 50).Value = salaryHistory.basicSalary;
                cmd.Parameters.Add("@RecieveAdvance", SqlDbType.NVarChar, 50).Value = salaryHistory.recieveAdvance;
                //cmd.Parameters.Add("@ServicingAmount", SqlDbType.NVarChar, 50).Value = salaryHistory.servicingAmount;
                cmd.Parameters.Add("@ProductSellProfitAmount", SqlDbType.NVarChar, 50).Value = salaryHistory.prouctSellProfitAmount;
                //cmd.Parameters.Add("@ServicingBonus", SqlDbType.NVarChar, 50).Value = salaryHistory.servicingBonus;
                cmd.Parameters.Add("@FestivalBonus", SqlDbType.NVarChar, 50).Value = salaryHistory.festivalBonus;
                cmd.Parameters.Add("@SellBonus", SqlDbType.NVarChar, 50).Value = salaryHistory.sellBonus;
                cmd.Parameters.Add("@TotalSalary", SqlDbType.NVarChar, 50).Value = salaryHistory.totalsalary;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 50).Value = salaryHistory.date;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch 
            {
               
                return false;
            }
        }
        public DataSet getSalaryHistory(string year1,string year2,string memberUsername)
        {
            try
            {

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("GetSalaryHistory", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Year1", SqlDbType.NVarChar, 5).Value = year1;
                cmd.Parameters.Add("@Year2", SqlDbType.NVarChar, 5).Value = year2;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = memberUsername;
              
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public DataSet getProfitForsalary(string date1, string date2, string memberUsername)
        {
            try
            {

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select Profit from SoldProduct where SoldBy='"+memberUsername+"' and  SoldDate between '"+date1+"' and '"+date2+"' ", conn);
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                conn.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        //Note
        public bool setNote(Note note)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SetNote", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 10).Value = note.date;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = note.note;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = note.userName;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataSet getNote(Note note)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("GetNote", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 10).Value = note.date;           
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = note.userName;
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool DeleteNote(Note note)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("DeleteNote", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 10).Value = note.date;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = note.userName;
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = note.note;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        //Client
        public bool setClient(Client client)
        {
            try
            {
                byte[] img = null;
                FileStream fs = new FileStream(client.customerImagePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SetClient", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = client.customerFirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = client.customerLastName;
                cmd.Parameters.Add("@fatherName", SqlDbType.NVarChar, 50).Value = client.customerFatherName;
                cmd.Parameters.Add("@MotherName", SqlDbType.NVarChar, 50).Value = client.customerMothername;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 10).Value = client.customerGender;
                cmd.Parameters.Add("@DOB", SqlDbType.NVarChar, 20).Value = client.customerDOB;
                cmd.Parameters.Add("@Age", SqlDbType.NVarChar, 10).Value = client.customerAge;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = client.customerAddress;
                cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar, 15).Value = client.customerMobileNo;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = client.customerEmail;
                cmd.Parameters.Add("@NID", SqlDbType.NVarChar, 50).Value = client.customerNIDNo;
                cmd.Parameters.Add("@Qualification", SqlDbType.NVarChar, 100).Value = client.customerQualification;
                cmd.Parameters.Add("@Cardno", SqlDbType.NVarChar, 50).Value = client.customerLifeStyleCardNo;
                cmd.Parameters.Add("@IssueDate", SqlDbType.NVarChar, 10).Value = client.customerLifeStyleCardIssuedate;
                cmd.Parameters.Add("@ExpairyDate", SqlDbType.NVarChar, 10).Value = client.customerlifeStyleCardExpiaryDate;
                cmd.Parameters.Add("@Image", SqlDbType.Image).Value = img;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Client getClient(string cardNo)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("GetClient", conn);
                cmd.CommandType = CommandType.StoredProcedure;    
                cmd.Parameters.Add("@Cardno", SqlDbType.NVarChar, 50).Value =cardNo;           
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Client client2 = new Client();
                client2.customerFirstName = (string)reader["FirstName"];
                client2.customerLastName = (string)reader["LastName"];
                client2.customerFatherName = (string)reader["FatherName"];
                client2.customerMothername = (string)reader["MotherName"];
                client2.customerGender = (string)reader["Gender"];
                client2.customerDOB = (string)reader["DOB"];
                client2.customerAge = (string)reader["Age"];
                client2.customerAddress = (string)reader["Address"];
                client2.customerMobileNo = (string)reader["MobileNo"];
                client2.customerEmail = (string)reader["Email"];
                client2.customerNIDNo = (string)reader["NID"];
                client2.customerQualification = (string)reader["Qualification"];
                client2.customerLifeStyleCardNo = (string)reader["CardNo"];
                client2.customerLifeStyleCardIssuedate = (string)reader["IssueDate"];
                client2.customerlifeStyleCardExpiaryDate = (string)reader["ExpairyDate"];
                client2.customerGender = (string)reader["Gender"];
                client2.customerImage = (byte[])reader["Image"]; 
               
                reader.Close();
                conn.Close();
                return client2;      
               
            }
            catch 
            {
                return null;
            }
        }
        public DataSet getAllClient()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("GetAllClient", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
        public bool deleteClient(Client client)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("DeleteClient", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Cardno", SqlDbType.NVarChar, 50).Value = client.customerLifeStyleCardNo;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateClient(Client client)
        {
            try
            {
                byte[] img = client.customerImage;
                if (client.customerImagePath != null)
                {
                    FileStream fs = new FileStream(client.customerImagePath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    img = br.ReadBytes((int)fs.Length);
                }
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("UpdateClient", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = client.customerFirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = client.customerLastName;
                cmd.Parameters.Add("@fatherName", SqlDbType.NVarChar, 50).Value = client.customerFatherName;
                cmd.Parameters.Add("@MotherName", SqlDbType.NVarChar, 50).Value = client.customerMothername;
                cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 10).Value = client.customerGender;
                cmd.Parameters.Add("@DOB", SqlDbType.NVarChar, 20).Value = client.customerDOB;
                cmd.Parameters.Add("@Age", SqlDbType.NVarChar, 10).Value = client.customerAge;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = client.customerAddress;
                cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar, 15).Value = client.customerMobileNo;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = client.customerEmail;
                cmd.Parameters.Add("@NID", SqlDbType.NVarChar, 50).Value = client.customerNIDNo;
                cmd.Parameters.Add("@Qualification", SqlDbType.NVarChar, 100).Value = client.customerQualification;
                cmd.Parameters.Add("@Cardno", SqlDbType.NVarChar, 50).Value = client.customerLifeStyleCardNo;
                cmd.Parameters.Add("@IssueDate", SqlDbType.NVarChar, 10).Value = client.customerLifeStyleCardIssuedate;
                cmd.Parameters.Add("@ExpairyDate", SqlDbType.NVarChar, 10).Value = client.customerlifeStyleCardExpiaryDate;
                cmd.Parameters.Add("@Image", SqlDbType.Image).Value = img;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


        //Product Method Panel

        public bool setProduct(Product product)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SetProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

            
                cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = product.productName;
                cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = product.productBrand;
                cmd.Parameters.Add("@ImporterInvoiceNo", SqlDbType.NVarChar, 100).Value = product.importerInvoiceNo;
                cmd.Parameters.Add("@ImporterName", SqlDbType.NVarChar, 100).Value = product.importerName;
                cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 500).Value = product.productShortDescription;
                cmd.Parameters.Add("@EntryDate", SqlDbType.NVarChar, 20).Value = product.productEntryDate;
                cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = product.productBarcode;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = product.productEntrier;
                cmd.Parameters.Add("@Unitprice", SqlDbType.NVarChar, 50).Value = product.productUnitPrice;
                cmd.Parameters.Add("@MRP", SqlDbType.NVarChar, 50).Value = product.soldPrice;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                
                return false;
            }
        }
        public bool deleteProduct(string serialNo)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("DeleteProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductSerial", SqlDbType.NVarChar, 100).Value = serialNo;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool updateProduct(Product product)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("UpdateProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = product.productName;
                cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = product.productBrand;
                cmd.Parameters.Add("@ImporterInvoiceNo", SqlDbType.NVarChar, 100).Value = product.importerInvoiceNo;
                cmd.Parameters.Add("@ImporterName", SqlDbType.NVarChar, 100).Value = product.importerName;
                cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 500).Value = product.productShortDescription;
                cmd.Parameters.Add("@EntryDate", SqlDbType.NVarChar, 20).Value = product.productEntryDate;
                cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = product.productBarcode;     
                cmd.Parameters.Add("@Unitprice", SqlDbType.NVarChar, 50).Value = product.productUnitPrice;
                cmd.Parameters.Add("@MRP", SqlDbType.NVarChar, 50).Value = product.soldPrice;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DataSet getProduct(Product product)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SELECT * from Product WHERE ('" + product.productBarcode + "' is null or Barcode like '%" + product.productBarcode + "%') and  ('" + product.productName + "' is null or ProductName like '%" + product.productName + "%') and ('" + product.productBrand + "' is null or Brand like '%" + product.productBrand + "%') and ('" + product.importerInvoiceNo + "' is null or ImporterInvoiceNo like '%" + product.importerInvoiceNo + "%')  and ('" + product.importerName + "' is null or ImporterName like '%" + product.importerName + "%') and ('" + product.productShortDescription + "' is null or ShortDescription like '%" + product.productShortDescription + "%')  and ('" + product.productEntryDate + "' is null or EntryDate like '%" + product.productEntryDate + "%') and ('" + product.productEntrier + "' is null or UserName like '%" + product.productEntrier + "%') and ('" + product.productUnitPrice + "' is null or UnitPrice like '%" + product.productUnitPrice + "%') and ('" + product.soldPrice + "' is null or MRP like '%" + product.soldPrice + "%')", conn);

                //cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = product.productName;
                //cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = product.productBrand;
                //cmd.Parameters.Add("@ImporterInvoiceNo", SqlDbType.NVarChar, 100).Value = product.importerInvoiceNo;
                //cmd.Parameters.Add("@ImporterName", SqlDbType.NVarChar, 100).Value = product.importerName;
                //cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 500).Value = product.productShortDescription;
                //cmd.Parameters.Add("@EntryDate", SqlDbType.NVarChar, 20).Value = product.productEntryDate;
                //cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = product.productBarcode;
                //cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = product.productEntrier;
                //cmd.Parameters.Add("@Unitprice", SqlDbType.NVarChar, 50).Value = product.productUnitPrice;
                //cmd.Parameters.Add("@MRP", SqlDbType.NVarChar, 50).Value = product.soldPrice;

                conn.Open();
                //cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                return ds;
            }
            catch
            {
                
                return null;
            }
        }

       //SetTempProduct
        public bool setTempProduct(Product product)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SetTempProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = product.productName;
                cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = product.productBrand;
                cmd.Parameters.Add("@ImporterInvoiceNo", SqlDbType.NVarChar, 100).Value = product.importerInvoiceNo;
                cmd.Parameters.Add("@ImporterName", SqlDbType.NVarChar, 100).Value = product.importerName;
                cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 500).Value = product.productShortDescription;
                cmd.Parameters.Add("@EntryDate", SqlDbType.NVarChar, 20).Value = product.productEntryDate;
                cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = product.productBarcode;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = product.productEntrier;
                cmd.Parameters.Add("@Unitprice", SqlDbType.NVarChar, 50).Value = product.productUnitPrice;
                cmd.Parameters.Add("@MRP", SqlDbType.NVarChar, 50).Value = product.soldPrice;
               
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
              
                return false;
            }
        }
        public DataSet getTempClientProduct()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("GetTempClientProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool deleteTempProduct(string serialNo)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("DeleteTempProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductSerial", SqlDbType.NVarChar, 100).Value = serialNo;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool deleteAllTempProduct()
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("DeleteAllTempProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Product getTempProductBySerialNoforReentry(string serialNo)
        {

            try
            {
                Product product = new Product();
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("GetTempProductBySerialNo", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@SerialNo", SqlDbType.NVarChar, 100).Value = serialNo;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                product.productName = (string)reader["ProductName"];
                product.productBrand = (string)reader["Brand"];
                product.importerInvoiceNo = (string)reader["ImporterInvoiceNo"];
                product.importerName = (string)reader["ImporterName"];
                product.productShortDescription = (string)reader["ShortDescription"];

                product.productEntryDate = (string)reader["EntryDate"];
                product.productBarcode = (string)reader["Barcode"];
                product.productEntrier = (string)reader["UserName"];
                product.productUnitPrice = (string)reader["UnitPrice"];
                product.soldPrice = (string)reader["MRP"];
                reader.Close();
                conn.Close();
                return product;
            }
            catch 
            {
               
                return null;
            }
        }


        //SoldProductPanel
        public bool setSoldProduct(Product product,string discount,string MRP)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SetSoldProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = product.productName;
                cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = product.productBrand;
                cmd.Parameters.Add("@ImporterInvoiceNo", SqlDbType.NVarChar, 100).Value = product.importerInvoiceNo;
                cmd.Parameters.Add("@ImporterName", SqlDbType.NVarChar, 100).Value = product.importerName;
                cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 500).Value = product.productShortDescription;
                cmd.Parameters.Add("@EntryDate", SqlDbType.NVarChar, 20).Value = product.productEntryDate;
                cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = product.productBarcode;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = product.productEntrier;
                cmd.Parameters.Add("@Unitprice", SqlDbType.NVarChar, 50).Value = product.productUnitPrice;
                cmd.Parameters.Add("@MRP", SqlDbType.NVarChar, 50).Value = MRP;
                cmd.Parameters.Add("@Profit", SqlDbType.NVarChar, 50).Value = product.profit;
                cmd.Parameters.Add("@SoldDate", SqlDbType.NVarChar, 10).Value = product.soldDate;
                cmd.Parameters.Add("@Discount", SqlDbType.NVarChar, 10).Value = discount;
                cmd.Parameters.Add("@SoldPrice", SqlDbType.NVarChar, 50).Value = product.soldPrice;
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar, 50).Value = product.importerID;
                cmd.Parameters.Add("@SoldBy", SqlDbType.NVarChar, 50).Value = product.refrence;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public bool deleteSoldProduct(string serialNo)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("DeleteSoldProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ProductSerial", SqlDbType.NVarChar, 100).Value = serialNo;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public DataSet getAllSoldProduct(string date1, string date2)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select * from SoldProduct where SoldDate between '"+date1+"' and '"+date2+"'", conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@Date1", SqlDbType.NVarChar, 10).Value = date1;
                //cmd.Parameters.Add("@Date2", SqlDbType.NVarChar, 10).Value = date2;
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                return ds;
            }
            catch 
            {
                return null;
            }
        }
        public DataSet getSoldProduct(string barcode,string invoiceNo)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select * from SoldProduct where ('" + barcode + "' is null or Barcode like '%" + barcode + "%') and ('" + invoiceNo + "' is null or InvoiceNo like '%" + invoiceNo + "%')", conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@Date1", SqlDbType.NVarChar, 10).Value = date1;
                //cmd.Parameters.Add("@Date2", SqlDbType.NVarChar, 10).Value = date2;
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                return ds;
            }
            catch 
            {
                return null;
            }
        }
        public DataSet getSoldProductByAllsearch(Product product)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SELECT * from SoldProduct WHERE ('" + product.productBarcode + "' is null or Barcode like '%" + product.productBarcode + "%') and  ('" + product.productName + "' is null or ProductName like '%" + product.productName + "%') and ('" + product.productBrand + "' is null or Brand like '%" + product.productBrand + "%') and ('" + product.importerInvoiceNo + "' is null or ImporterInvoiceNo like '%" + product.importerInvoiceNo + "%')  and ('" + product.importerName + "' is null or ImporterName like '%" + product.importerName + "%') and ('" + product.productShortDescription + "' is null or ShortDescription like '%" + product.productShortDescription + "%')  and ('" + product.productEntryDate + "' is null or EntryDate like '%" + product.productEntryDate + "%') and ('" + product.productEntrier + "' is null or UserName like '%" + product.productEntrier + "%') and ('" + product.productUnitPrice + "' is null or UnitPrice like '%" + product.productUnitPrice + "%') and ('" + product.soldPrice + "' is null or MRP like '%" + product.soldPrice + "%')", conn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@Date1", SqlDbType.NVarChar, 10).Value = date1;
                //cmd.Parameters.Add("@Date2", SqlDbType.NVarChar, 10).Value = date2;
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }





        //returnCompanyProduct 
        public bool setReturnCompanyProduct(Product product, string reference,string cause,string date)
        {
            
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SetReturnCompanyProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = product.productName;
                cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = product.productBrand;
                cmd.Parameters.Add("@ImporterInvoiceNo", SqlDbType.NVarChar, 100).Value = product.importerInvoiceNo;
                cmd.Parameters.Add("@ImporterName", SqlDbType.NVarChar, 100).Value = product.importerName;
                cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 500).Value = product.productShortDescription;
                cmd.Parameters.Add("@EntryDate", SqlDbType.NVarChar, 20).Value = product.productEntryDate;
                cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = product.productBarcode;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = product.productEntrier;
                cmd.Parameters.Add("@Unitprice", SqlDbType.NVarChar, 50).Value = product.productUnitPrice;
                cmd.Parameters.Add("@MRP", SqlDbType.NVarChar, 50).Value = product.soldPrice;            
                cmd.Parameters.Add("@Reference", SqlDbType.NVarChar, 50).Value = reference;
                cmd.Parameters.Add("@Cause", SqlDbType.NVarChar, 500).Value = cause;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 10).Value = date;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public DataSet getReturnCompanyProduct(string barcode, string date)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select * from ReturnCompany where ('" + barcode + "' is null or Barcode like '%" + barcode + "%') and ('" + date + "' is null or Date like '%" + date + "%')", conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = product.productName;
                //cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = product.productBrand;
                //cmd.Parameters.Add("@ImporterInvoiceNo", SqlDbType.NVarChar, 100).Value = product.importerInvoiceNo;
                //cmd.Parameters.Add("@ImporterName", SqlDbType.NVarChar, 100).Value = product.importerName;
                //cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 500).Value = product.productShortDescription;
                //cmd.Parameters.Add("@EntryDate", SqlDbType.NVarChar, 20).Value = product.productEntryDate;
                //cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = product.productBarcode;
                //cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = product.productEntrier;
                //cmd.Parameters.Add("@Unitprice", SqlDbType.NVarChar, 50).Value = product.productUnitPrice;
                //cmd.Parameters.Add("@MRP", SqlDbType.NVarChar, 50).Value = product.soldPrice;
                //cmd.Parameters.Add("@Reference", SqlDbType.NVarChar, 50).Value = reference;
                //cmd.Parameters.Add("@Cause", SqlDbType.NVarChar, 500).Value = cause;
                //cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar, 50).Value = invoiceNo;
                //cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 10).Value = date;
                conn.Open();
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();

                return ds;
            }
            catch
            {

                return null;
            }
        }
        public bool deleteReturnCompanyProduct(string barcode)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Delete from ReturnCompany where Barcode = '" + barcode + "'", conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = product.productName;
                //cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = product.productBrand;
                //cmd.Parameters.Add("@ImporterInvoiceNo", SqlDbType.NVarChar, 100).Value = product.importerInvoiceNo;
                //cmd.Parameters.Add("@ImporterName", SqlDbType.NVarChar, 100).Value = product.importerName;
                //cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 500).Value = product.productShortDescription;
                //cmd.Parameters.Add("@EntryDate", SqlDbType.NVarChar, 20).Value = product.productEntryDate;
                //cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = product.productBarcode;
                //cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = product.productEntrier;
                //cmd.Parameters.Add("@Unitprice", SqlDbType.NVarChar, 50).Value = product.productUnitPrice;
                //cmd.Parameters.Add("@MRP", SqlDbType.NVarChar, 50).Value = product.soldPrice;
                //cmd.Parameters.Add("@Reference", SqlDbType.NVarChar, 50).Value = reference;
                //cmd.Parameters.Add("@Cause", SqlDbType.NVarChar, 500).Value = cause;
                //cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar, 50).Value = invoiceNo;
                //cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 10).Value = date;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;

            }
            catch
            {

                return false;
            }
        }
        //returnClientProduct
        public bool setReturnClientProduct(Product product, string reference, string cause, string discount ,string date)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SetReturnClientProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = product.productName;
                cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = product.productBrand;
                cmd.Parameters.Add("@ImporterInvoiceNo", SqlDbType.NVarChar, 100).Value = product.importerInvoiceNo;
                cmd.Parameters.Add("@ImporterName", SqlDbType.NVarChar, 100).Value = product.importerName;
                cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 500).Value = product.productShortDescription;
                cmd.Parameters.Add("@EntryDate", SqlDbType.NVarChar, 20).Value = product.productEntryDate;
                cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = product.productBarcode;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = product.productEntrier;
                cmd.Parameters.Add("@Unitprice", SqlDbType.NVarChar, 50).Value = product.productUnitPrice;
                cmd.Parameters.Add("@MRP", SqlDbType.NVarChar, 50).Value = product.soldPrice;
                cmd.Parameters.Add("@Profit", SqlDbType.NVarChar, 50).Value = product.profit;
                cmd.Parameters.Add("@SoldDate", SqlDbType.NVarChar, 10).Value = product.soldDate;
                cmd.Parameters.Add("@Discount", SqlDbType.NVarChar, 10).Value = discount;
                cmd.Parameters.Add("@SoldPrice", SqlDbType.NVarChar, 50).Value = product.soldPrice;
                cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar, 50).Value = product.importerID;
                cmd.Parameters.Add("@Reference", SqlDbType.NVarChar, 50).Value = reference;
                cmd.Parameters.Add("@Cause", SqlDbType.NVarChar, 50).Value = cause;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 10).Value = date;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch 
            {
                
                return false;
            }
        }
        public DataSet getReturnClientProduct(string barcode, string invoiceNo)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select * from ReturnClient where ('" + barcode + "' is null or Barcode like '%" + barcode + "%') and ('" + invoiceNo + "' is null or InvoiceNo like '%" + invoiceNo + "%')", conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = product.productName;
                //cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = product.productBrand;
                //cmd.Parameters.Add("@ImporterInvoiceNo", SqlDbType.NVarChar, 100).Value = product.importerInvoiceNo;
                //cmd.Parameters.Add("@ImporterName", SqlDbType.NVarChar, 100).Value = product.importerName;
                //cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 500).Value = product.productShortDescription;
                //cmd.Parameters.Add("@EntryDate", SqlDbType.NVarChar, 20).Value = product.productEntryDate;
                //cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = product.productBarcode;
                //cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = product.productEntrier;
                //cmd.Parameters.Add("@Unitprice", SqlDbType.NVarChar, 50).Value = product.productUnitPrice;
                //cmd.Parameters.Add("@MRP", SqlDbType.NVarChar, 50).Value = product.soldPrice;
                //cmd.Parameters.Add("@Reference", SqlDbType.NVarChar, 50).Value = reference;
                //cmd.Parameters.Add("@Cause", SqlDbType.NVarChar, 500).Value = cause;
                //cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar, 50).Value = invoiceNo;
                //cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 10).Value = date;
                conn.Open();
                cmd.ExecuteNonQuery();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
               
                return ds;
            }
            catch
            {
               
                return null;
            }
        }
        public bool deleteReturnClientProduct(string barcode)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Delete from ReturnClient where Barcode = '"+barcode+"'", conn);
                //cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar, 100).Value = product.productName;
                //cmd.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = product.productBrand;
                //cmd.Parameters.Add("@ImporterInvoiceNo", SqlDbType.NVarChar, 100).Value = product.importerInvoiceNo;
                //cmd.Parameters.Add("@ImporterName", SqlDbType.NVarChar, 100).Value = product.importerName;
                //cmd.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 500).Value = product.productShortDescription;
                //cmd.Parameters.Add("@EntryDate", SqlDbType.NVarChar, 20).Value = product.productEntryDate;
                //cmd.Parameters.Add("@Barcode", SqlDbType.NVarChar, 100).Value = product.productBarcode;
                //cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = product.productEntrier;
                //cmd.Parameters.Add("@Unitprice", SqlDbType.NVarChar, 50).Value = product.productUnitPrice;
                //cmd.Parameters.Add("@MRP", SqlDbType.NVarChar, 50).Value = product.soldPrice;
                //cmd.Parameters.Add("@Reference", SqlDbType.NVarChar, 50).Value = reference;
                //cmd.Parameters.Add("@Cause", SqlDbType.NVarChar, 500).Value = cause;
                //cmd.Parameters.Add("@InvoiceNo", SqlDbType.NVarChar, 50).Value = invoiceNo;
                //cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 10).Value = date;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;

            }
            catch 
            {

                return false;
            }
        }
        public DataSet getAllSoldProductForSalary(string date1, string date2,string userName)
        {

            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("GetSoldProductForSalary", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date1", SqlDbType.NVarChar, 10).Value = date1;
                cmd.Parameters.Add("@Date2", SqlDbType.NVarChar, 10).Value = date2;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 100).Value = userName;
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                return ds;
            }
            catch
            {
                return null;
            }
        }
       
       //expenditure
        public bool setExpenditure(Expenditure expenditure)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("SetExpenditure", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 10).Value = expenditure.date;
                cmd.Parameters.Add("@Amount", SqlDbType.NVarChar, 30).Value = expenditure.amount;
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = expenditure.description;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataSet getExpenditure(string date1,string date2)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("GetExpenditure", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Date1", SqlDbType.NVarChar, 10).Value = date1;
                cmd.Parameters.Add("@Date2", SqlDbType.NVarChar, 10).Value = date2;
                conn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter sdp = new SqlDataAdapter();
                sdp.SelectCommand = cmd;
                sdp.Fill(ds);
                conn.Close();
                return ds;
            }
            catch 
            {
                return null;
            }
        }

        //invoice
        public bool updateInvoice(string newInvoiceNo,string oldInvoiceNo)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Update Invoice Set InvoiceNo ='"+newInvoiceNo+"' where InvoiceNo='"+oldInvoiceNo+"'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string getInvoice()
        {
            try
            {
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("Select * from Invoice", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string invoice = (string)reader["InvoiceNo"];
                reader.Close();
                conn.Close();
                return invoice;
               
            }
            catch
            {
                return null;
            }
        }
       
       
    }
}
