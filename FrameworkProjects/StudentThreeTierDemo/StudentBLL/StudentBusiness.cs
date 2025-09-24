using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentDAL;

namespace StudentBLL
{
    public class StudentBLL
    {
        //creating object of Data Access Layer class

        StudentDAL.StudentDAL sDal = new StudentDAL.StudentDAL();

        public int SaveData(int rno, string name, string branch)
        {
            try
            {
                //Checking a condition college can take max of 600 students...

                if (rno > 600)
                    throw new Exception("Roll no can't be more than 600!!!");

                //calling method from Data Access Layer

                int result = sDal.InsertStudentData(rno, name, branch);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAllStudents()
        {
            try
            {
                DataTable dt = new DataTable(); //creating empty data table

                dt = sDal.ShowAllStudents(); //getting data from DAL

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ShowData(int rno)
        {
            if (rno > 600)
                throw new Exception($"There is no Roll Number {rno}");

            return sDal.GetStudentByRollNo(rno);
        }
        public int DeleteData(int rno)
        {
            try
            {
                if (rno > 600)
                    throw new Exception("Invalid Roll Number!");

                int result = sDal.DeleteStudentByRollNo(rno);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateData(int rno, string name, string branch)
        {
            try
            {
                if (rno > 600)
                    throw new Exception("Invalid Roll Number!");

                int result = sDal.UpdateStudentByRollNo(rno, name, branch);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
