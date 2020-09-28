//using AutoFixture.Xunit2;
//using LeaseManagement.BusinessEntities.ViewModels;
//using LeaseManagement.DataEntities.Models;
//using LeaseManagement.Repository;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace LeaseManagement.Tests.Repositories
//{
//    public class UserPersonalRepositoryUnitTest
//    {
//        [Theory, AutoMoqData]
//        public async Task AddUserPersonalData(
//            [Frozen] Mock<Repository<UserPersonalVM>> context,
//            UserPersonalVM moqResponse,
//            UserPersonalVM request,
//            [Greedy] UserPersonalRepository sut,
//            string SP_ADD_USER_PERSONAL_DATA
//            )
//        {
//            // Arrange 
//            var parameters = new List<SqlParameter>()
//            {
//                new SqlParameter("@userId", request.UserId),
//                new SqlParameter("@firstname",request.Firstname),
//                new SqlParameter("@lastname",request.Lastname),
//                new SqlParameter("@gender",request.Gender),
//                new SqlParameter("@contact",request.Contact),
//                new SqlParameter("@dob",request.Dob),
//                new SqlParameter("@houseNo", request.HouseNo),
//                new SqlParameter("@street",request.Street),
//                new SqlParameter("@city",request.City),
//                new SqlParameter("@state",request.State),
//                new SqlParameter("@country",request.Country),
//                new SqlParameter("@pincode", request.Pincode)
//            };
//            //context.Setup(x => x.ExecuteSqlQueryWithParameters(SP_ADD_USER_PERSONAL_DATA, parameters)).ReturnsAsync(moqResponse);

//            //Act
//            var result = await sut.AddUserPersonalData(request);

//            //Assert
//            Assert.NotNull(result);
//        }
//    }
//}
