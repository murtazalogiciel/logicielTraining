using BusinessLogicLayer.CRUDOperations;
using DataAccessLayer.Context;
using FizzWare.NBuilder;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Training.Controllers;
using Xunit;

namespace Training.Test
{
    public class EmployeeTesting
    {
        private EmployeesController _EmployeesController;
        private Mock<IRepositoryModel> _iRepositoryModel = new Mock<IRepositoryModel>();

        public EmployeeTesting()
        {
            _EmployeesController = new EmployeesController(_iRepositoryModel.Object);
        }
        [Fact]
        public void Index()
        {
            //Arrange

            var EmployeeSizeMock = Builder<Employee>.CreateListOfSize(3).Build();
            var actualResult = _iRepositoryModel.Setup(fs => fs.getModel<Employee>()).Returns(EmployeeSizeMock);
            //// Act
            var result =_EmployeesController.Index();

            //// Assert
            var viewResult = (ViewResult)result ;
            var model = Assert.IsAssignableFrom<IList<Employee>>(viewResult.Model);
            Assert.Equal(EmployeeSizeMock.Count, model.Count);
          
        }
        [Fact]
        public void Delete()
        {
            //Arrange

            var EmployeeSizeMock = Builder<Employee>.CreateNew().Build();
            var actualResult = _iRepositoryModel.Setup(fs => fs.getModelById<Employee>(1)).Returns(EmployeeSizeMock);
            //// Act
            var result = _EmployeesController.DeleteConfirmed(1);

            //// Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", viewResult.ActionName);
        }
    }
}
