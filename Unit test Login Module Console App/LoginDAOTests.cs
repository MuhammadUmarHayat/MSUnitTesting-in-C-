using Microsoft.VisualStudio.TestTools.UnitTesting;
using EcommeraceApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommeraceApplication.Tests
{
    [TestClass()]
    public class LoginDAOTests
    {
        LoginDAO dao=new LoginDAO();
        [TestMethod()]
        public void signupTest()
        {
            try
            {
                //arrange
                string email = "hari123@gmail.com";
                string name = "haris";
                string fathername = "haji";
                string address = "lahore";
                string sec_question = "who am i";
                string sec_answer = "haris";
                string password = "haris";
                string user_type = "customer";
                string status = "active";
                string mobile_no = "033";
                //act
               // dao.signup(email, name, fathername, address, sec_question, sec_answer, password, user_type, status, mobile_no);
                return;
            }
            catch (Exception ex)
            {
                //
                //assert
                // Assert
                StringAssert.Contains(ex.Message, "User exists");
                return;
            }


        }
        [TestMethod()]
        public void loginTest()
        {
            try
            {
                //arrange
                string email = "hari123@gmail.com";
                string password = "haris";

                //act
                dao.isValid(email,password);

                return;


            }
            catch(Exception exp)
            {
                StringAssert.Contains(exp.Message, "User email or password is incorract");
                return;

            }

        }
    }
}