using System.Security.Cryptography;

namespace EcommeraceApplication
{
    internal class Program
    {
        LoginDAO dao= new LoginDAO();
        public static void Main(string[] args)
        {
            Console.WriteLine("Login Module ");
            Program obj = new Program();
            string s1 = "n";
            do
            {


                Console.WriteLine(" Please choose the right option :  ");
                Console.WriteLine(" 1 for signup  ");
                Console.WriteLine(" 2 for login  ");
                Console.WriteLine(" 3 for user List  ");
                string s = Console.ReadLine();
                int choice = Convert.ToInt32(s);
                switch (choice)
                {
                    case 1:
                        obj.signup();//registertion
                        break;
                    case 2:
                        obj.login();//login
                        break;
                    case 3:
                        obj.userList();//user list
                        break;
                    default:
                        Console.WriteLine(" Please enter the right choice ");
                        break;


                }
                Console.WriteLine(" Do you want to explore more Y for yes N for no ");
                s1 = Console.ReadLine();


            } while (s1.Equals("Y") || s1.Equals("y"));
            

        }
        public void userList()
        {
            Console.WriteLine("*********** User List ************");
            dao.list();

        }
        public  void signup()
        {
            Console.WriteLine("*********** User Registration Form ************");
            Console.WriteLine("Please enter the user details");

            Console.WriteLine("Please enter the user email");
            string email = Console.ReadLine();

            Console.WriteLine("Please enter the user password : ");
            string password = Console.ReadLine();
            
            Console.WriteLine("Please enter the user  Name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Please enter the user Father Name : ");
            string fname = Console.ReadLine();
           
            Console.WriteLine("Please enter the user Address : ");
            string add = Console.ReadLine();
            
            Console.WriteLine("Please enter the user secreate question : ");
            string question = Console.ReadLine();
            Console.WriteLine("Please enter the user secrete answer : ");
            string answer = Console.ReadLine();
            Console.WriteLine("Please enter the user Mobile number : ");           
            string mob = Console.ReadLine();
            string status = "active";
            string userType = "customer";

           bool is_registered= dao.signup(email,name,fname,add,question,answer,password,userType,status,mob);
            if (is_registered)
            {
                Console.WriteLine("User has been registered");
            }
            else
            {
                Console.WriteLine("Error: somthing is wrong please try later !");
            }
            

        }
        public void login()
        {
            Console.WriteLine("*********** User Login Form ************");
            Console.WriteLine("Please enter the user email");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter the user password : ");

            string password = Console.ReadLine();
           bool is_valid= dao.isValid(email,password);
            if (is_valid)
            {
                Console.WriteLine("Welcome to my application ");
            }
            else
            {
                Console.WriteLine("Invalid email or password ");

            }



        }


    }
}
