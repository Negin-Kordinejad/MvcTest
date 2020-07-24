using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace MvcTest
{
    public class DataAccess
    {
        public List<Models.Movie> GetMovies()
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConVal("TestDB")))
            {
                var M = connection.Query<Models.Movie>("dbo.Moveie_Get_All").ToList();
                return M;
            }
        }

        public int AddNewMovie(string MovieName)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConVal("TestDB")))
            {
                var P = new DynamicParameters();
                P.Add("@MovieName", MovieName);
                int RecordAfected = connection.Execute("dbo.Move_InsertNewMovide", P, commandType: CommandType.StoredProcedure);
                return RecordAfected;
            }
        }
        public List<ViewModels.FullCustomerDataModel> GetCusomers()
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConVal("TestDB")))
            {
                var C = connection.Query<ViewModels.FullCustomerDataModel>("[dbo].[Customers_Get_All]").ToList();
                return C;
            }
        }
        public List<ViewModels.FullCustomerDataModel> GetCustomerById(int Id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConVal("TestDB")))
            {
                var C = connection.Query<ViewModels.FullCustomerDataModel>("dbo.Customers_GetById @Id", new { Id = Id }).ToList();

                return C;
            }
        }
        public void UpdateCustomer(Models.Custumer customer)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConVal("TestDB")))
            {
                var P = new DynamicParameters(customer);
                //P.Add("@Id",customer.id );
                //P.Add("@Name", );
                //P.Add("@IsSubscribedToNewsletter", );
                //P.Add("@MembershipTypeId", );
                //P.Add("@BirthDate", );
                connection.Execute("dbo.Customer_Update", P, commandType: CommandType.StoredProcedure);
                //  return RecordAfected;
            }
        }
        public void AddNewCustomer(Models.Custumer customer)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConVal("TestDB")))
            {
                var P = new DynamicParameters();
                P.Add("@Name", customer.Name);
                P.Add("@IsSubscribedToNewsletter",customer.IsSubscribedToNewsletter );
                P.Add("@MembershipTypeId",customer.MembershipTypeId );
                P.Add("@BirthDate",customer.BirthDate );

                connection.Execute("dbo.Customer_AddNewcustomer", P, commandType: CommandType.StoredProcedure);
                //  return RecordAfected;
            }
        }
        public List<Models.MembershipType> GetmemberShipId(int? Id)
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConVal("TestDB")))
            {
                var C = connection.Query<Models.MembershipType>("dbo.MembershipType_GetById @Id", new { Id = Id }).ToList();
                return C;
            }
        }

        public List<Models.MembershipType> GetAllMemberShip()
        {
            using (IDbConnection connection = new SqlConnection(Helper.ConVal("TestDB")))
            {
                var C = connection.Query<Models.MembershipType>("dbo.MembershipType_GetAll").ToList();
                return C;
            }
        }
    }
}