
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace EmployeeManagementSystem;
class Employees
{
    public  int NoofEmployees;
    List<string> EmployeeId = new List<string>();
    List<string> EmployeeName = new List<string>();
    List<DateTime> EmployeeDateOfBirth = new List<DateTime>();
    List<DateTime> EmployeeDateOfJoining = new List<DateTime>();
    List<string> EmployeeEmailId = new List<string>();
    List<string> EmployeePhoneNumber = new List<string>();
    
    //IdValidation
    public void IdValidation(List<string> EmployeeId, int IdValidate)
    {
        string Id = @"^(ACE){1}[1-9]{1}[0-9]{3}$";
        Regex CheckId = new Regex(Id);
        if (CheckId.IsMatch(EmployeeId[IdValidate]))
        {

        }
        else
        {
            Console.WriteLine("Id should start with A,C,E letters followed by four digit numbers.");
            EmployeeId[IdValidate] = Console.ReadLine();
            IdValidation(EmployeeId, IdValidate);

        }
    }
    //NameValidation
    public void NameValidation(List<string> EmployeeName, int NameValidate)
    {
        int NameValid = 0;
        string Name = @"^[A-Z]{1}[A-Za-z\s]{2,}$";
        Regex CheckName = new Regex(Name);
        if (CheckName.IsMatch(EmployeeName[NameValidate]))
        {

            for (int i = 0; i < EmployeeName[NameValidate].Length - 1; i++)//AAA
            {
                if (EmployeeName[NameValidate][i] == EmployeeName[NameValidate][i + 1])
                {

                    NameValid = 1;

                }
                else
                {
                    NameValid = 0;


                }
            }
            if (NameValid == 0)
            {

            }
            else
            {
                Console.WriteLine("Repeated Characters are not Allowed.");
                EmployeeName[NameValidate] = Console.ReadLine();
                NameValidation(EmployeeName, NameValidate);
            }
        }

        else
        {
            Console.WriteLine("Name should start with Uppercase and it should be Proper name.");
            EmployeeName[NameValidate] = Console.ReadLine();
            NameValidation(EmployeeName, NameValidate);
        }

    }
          
    //DateofBirthValidation
    public void DateofBirthValidation(List<DateTime> EmployeeDateOfBirth, int DateofBirthValidate)
    {
                  
        int Age;
        Age = DateTime.Now.Subtract(EmployeeDateOfBirth[DateofBirthValidate]).Days;
        Age = Age / 365;
        if(Age > 18 && Age < 60)
        {
            
        }
        else
        {
            Console.WriteLine("Give the DateOfBirth as above 18 and below 60 ");
            EmployeeDateOfBirth[DateofBirthValidate] = Convert.ToDateTime(Console.ReadLine());
            DateofBirthValidation(EmployeeDateOfBirth, DateofBirthValidate);
        }


    }
    //DateofJoiningValidation
    public void DateofJoiningValidation(List<DateTime> EmployeeDateOfJoining, int DateofJoiningValidate)
    {
        
        if(EmployeeDateOfJoining[DateofJoiningValidate] < DateTime.Now)
        {

        }
        else
        {
            Console.WriteLine("Should not Enter Future Date.");
            EmployeeDateOfJoining[DateofJoiningValidate]=Convert.ToDateTime(Console.ReadLine());
            DateofJoiningValidation(EmployeeDateOfJoining, DateofJoiningValidate);
        }

    }
    //EmailIdValidation
    public void EmailIdValidation(List<string> EmployeeEmailId, int EmailidValidate)
    {
        string EmailId = "^[A-Za-z0-9]+@((gmail)|(yahoo)|(hotmail))[.]((com)|(in))$";
        Regex CheckEmailId = new Regex(EmailId);
        if (CheckEmailId.IsMatch(this.EmployeeEmailId[EmailidValidate]))
        {

        }
        else
        {
            Console.WriteLine("Email should be letters and proper domain name.Special characters are not allowed.");
            this.EmployeeEmailId[EmailidValidate] = Console.ReadLine();
            EmailIdValidation(EmployeeEmailId, EmailidValidate);
        }
    }
    //PhoneNumberValidation
    public void PhoneNumberValidation(List<string> EmployeePhoneNumber, int PhoneNumberValidate)
    {
        string PhoneNumber = "^[6-9]{1}[0-9]{9}$";
        Regex CheckPhoneNumber = new Regex(PhoneNumber);
        if (CheckPhoneNumber.IsMatch(EmployeePhoneNumber[PhoneNumberValidate]))
        {

        }
        else
        {
            Console.WriteLine("Phone Number should begin with 6 7 8 or 9.It should be exactly 10 digits.");
            EmployeePhoneNumber[PhoneNumberValidate] = Console.ReadLine();
            PhoneNumberValidation(EmployeePhoneNumber, PhoneNumberValidate);
        }
    }
    
    public void AddEmployee()
    {
        Console.WriteLine("How many Employees do you want?");
        NoofEmployees = Convert.ToInt32(Console.ReadLine());
         
        for (int add =EmployeeId.Count ; add < NoofEmployees; add++)
        {
            Console.Write("Employee Id :");
            EmployeeId.Add(Console.ReadLine());
            IdValidation(EmployeeId, add);
            Console.Write("Employee Name :");
            EmployeeName.Add(Console.ReadLine());
            NameValidation(EmployeeName, add);
            Console.Write("Employee DateofBirth (dd/mm/yyy) :");
            EmployeeDateOfBirth.Add(Convert.ToDateTime(Console.ReadLine()));
            DateofBirthValidation(EmployeeDateOfBirth, add);
            Console.Write("Employee DateofJoining (dd/mm/yyy) :");
            EmployeeDateOfJoining.Add(Convert.ToDateTime(Console.ReadLine()));
            DateofJoiningValidation(EmployeeDateOfJoining, add);
            Console.Write("Employee EmailId :");
            EmployeeEmailId.Add(Console.ReadLine());
            EmailIdValidation(EmployeeEmailId, add);
            Console.Write("Employee PhoneNumber :");
            EmployeePhoneNumber.Add(Console.ReadLine());
            PhoneNumberValidation(EmployeePhoneNumber, add);

        }
        Console.WriteLine("Details are Successfully added.");
    }
    public void ReadEmployee()
    {
        string ReadId;
        int CheckReadEmployee = 0;
        Console.Write("Enter Id which you want to read th" +
            "e details :");
        ReadId = Console.ReadLine();
        for(int Read=0;Read<NoofEmployees;Read++)
        {
            if(EmployeeId[Read] == ReadId)
            {
                
                CheckReadEmployee = 1;
                Console.WriteLine("Employee Id :" + EmployeeId[Read]);
                Console.WriteLine("Employee Name :" + EmployeeName[Read]);
                Console.WriteLine("Employee DateofBirth:" + EmployeeDateOfBirth[Read]);
                Console.WriteLine("Employee DateOfJoining :" + EmployeeDateOfJoining[Read]);
                Console.WriteLine("Employee EmailId :" + EmployeeEmailId[Read]);
                Console.WriteLine("Employee PhoneNumber :" + EmployeePhoneNumber[Read]);
                break;
            }
            else
            {
                CheckReadEmployee = 0;
            }
        }
        if(CheckReadEmployee==0)
        {
            Console.WriteLine("Please Check your Id and read it.");
            ReadEmployee();
        }
    }
    public void UpdateEmployee()
    {
        string UpdateId;
        int CheckUpdateEmployee=1;
        Console.Write("Enter Id which you want to update the details : ");
        UpdateId=Console.ReadLine();
        for(int Update=0;Update < NoofEmployees;Update++) 
        {
            if (EmployeeId[Update] == UpdateId)
            {
                CheckUpdateEmployee = 1;
                Console.WriteLine("Please enter the update choice" +
                    "\n 1.Update your Name" +
                    "\n 2.Update your DateOfBirth" +
                    "\n 3.Update your DateOfJoining" +
                    "\n 4.Update your EmailId" +
                    "\n 5.Update your PhoneNumber");
                int UpdateChoice = Convert.ToInt32(Console.ReadLine());
                switch (UpdateChoice)
                {
                    case 1:Console.WriteLine("Update your Name");
                           EmployeeName[Update] = Console.ReadLine();
                           NameValidation(EmployeeName, Update);
                           break;
                    case 2:
                        Console.WriteLine("Update your DateOfBirth");
                        EmployeeDateOfBirth[Update] = (Convert.ToDateTime(Console.ReadLine())); 
                        DateofBirthValidation(EmployeeDateOfBirth, Update);
                        break;
                    case 3:
                        Console.WriteLine("Update your DateOfJoining");
                        EmployeeDateOfJoining[Update] = (Convert.ToDateTime(Console.ReadLine())); 
                        DateofJoiningValidation(EmployeeDateOfJoining, Update);
                        break;
                    case 4:
                        Console.WriteLine("Update your EmailId");
                        EmployeeEmailId[Update] = Console.ReadLine();
                        EmailIdValidation(EmployeeEmailId, Update);
                        break;
                    case 5:
                        Console.WriteLine("Update your PhoneNumber");
                        EmployeePhoneNumber[Update] = Console.ReadLine();
                        PhoneNumberValidation(EmployeePhoneNumber, Update);
                        break;
                    default:
                        Console.WriteLine("Please enter the Update choice 1 to 5");
                        break;
                }
                break;
            }
            else
            {

                CheckUpdateEmployee = 0;
            }
        }
        if(CheckUpdateEmployee==0)
        {
            Console.WriteLine("Please Check your Id and Update it");
            UpdateEmployee();
        }


    }
    
    public void DisplayEmployee()
    {
        for (int Display = 0; Display<EmployeeId.Count; Display++)
        {
            
            
                Console.WriteLine("Employee Id :" + EmployeeId[Display]);
                Console.WriteLine("Employee Name :" + EmployeeName[Display]);
                Console.WriteLine("Employee DateOfBirth:" + EmployeeDateOfBirth[Display]);
                Console.WriteLine("Employee DateOfJoining :" + EmployeeDateOfJoining[Display]);
                Console.WriteLine("Employee EmailId :" + EmployeeEmailId[Display]);
                Console.WriteLine("Employee PhoneNumber :" + EmployeePhoneNumber[Display]);
                
        }

    }
    
    public void DeleteEmployee()
    {
        string DeleteId;
        int CheckDeleteEmployee = 0;
        Console.WriteLine("Enter id which you want to delete");
        DeleteId = Console.ReadLine();
        for(int Delete=0;Delete<NoofEmployees;Delete++)
        {
            if(EmployeeId[Delete]==DeleteId)
            {
                CheckDeleteEmployee = 1;
                EmployeeId.RemoveAt(Delete);
                EmployeeName.RemoveAt(Delete);
                EmployeeDateOfBirth.RemoveAt(Delete);
                EmployeeDateOfJoining.RemoveAt(Delete);
                EmployeeEmailId.RemoveAt(Delete);
                EmployeePhoneNumber.RemoveAt(Delete);
                Console.WriteLine("Deleted Successfully");
                break;

            }
            else
            {
                CheckDeleteEmployee = 0;
            }

        }
        if(CheckDeleteEmployee==0)
        {
            Console.WriteLine("Please check your id and Delete it");
            DeleteEmployee(); 
        }
    }
    public void Exit()
    {
        Console.WriteLine("Application closed successfully");
    }
    public void PrintChoice()
    {

        Console.WriteLine("1.Enter/Add Employee Details"
                           + "\n2.Read a Specific Employee"
                           + "\n3.Update Employee Details"
                           + "\n4.Display Employee Details"
                           + "\n5.Delete Employee Details"
                           + "\n6.Exit");
        Console.Write("Please enter a choice :");
        int Choice = Convert.ToInt32(Console.ReadLine());
        GetChoice(Choice);

    }
    public void GetChoice(int Choice)
    {
        switch (Choice)
        {
            case 1:AddEmployee();
                   PrintChoice();
                   break;
            case 2:ReadEmployee();
                   PrintChoice();
                    break;
           case 3: UpdateEmployee();
                   PrintChoice();
                   break;
            case 4:DisplayEmployee();
                   PrintChoice();
                   break;
            case 5:DeleteEmployee();
                   PrintChoice();
                   break;
            case 6:Exit();
                   break;
            default:Console.WriteLine("Please enter a  choice 1 to 6");
                PrintChoice();
                break;
                   


        }
    }
    public void Print()

    {
        Console.WriteLine("Welcome To Employee Management System");
    }
}

    class Employee
{
    public static void Main(string[] args)
    {
        Employees employee = new Employees();
        employee.Print();
        employee.PrintChoice();
        
    }
}
