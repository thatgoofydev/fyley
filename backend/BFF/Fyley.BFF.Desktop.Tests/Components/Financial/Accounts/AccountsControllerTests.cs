﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Fyley.BFF.Desktop.Components.Financial.Accounts;
using Fyley.BFF.Desktop.Components.Financial.Accounts.Models.List;
using Fyley.BFF.Desktop.Components.Financial.Accounts.Models.Submit;
using Fyley.Core.Asp.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace Fyley.BFF.Desktop.Tests.Components.Financial.Accounts
{
    [TestFixture]
    public class AccountsControllerTests
    {
        private IAccountViewModelFactory _viewModelFactory;
        private IAccountServiceClient _serviceClient;
        private AccountsController _controller;

        [SetUp]
        public void SetUp()
        {
            _viewModelFactory = Substitute.For<IAccountViewModelFactory>();
            _serviceClient = Substitute.For<IAccountServiceClient>();
            _controller = new AccountsController(_viewModelFactory, _serviceClient);
        }

        public class SubmitFormShould : AccountsControllerTests
        {
            private const string Name = "Savings";
            private const string Description = "Just saving some money";
            private const string AccountNumber = "BE18456141662665";
            private const SubmitAccountRequest.AccountNumberTypes AccountNumberType = SubmitAccountRequest.AccountNumberTypes.Iban;
            
            [Test]
            public async Task CallServiceClientAndReturn_WhenNewAccount()
            {
                // Arrange
                const string id = "new";
                var request = new SubmitAccountRequest
                {
                    Name = Name,
                    Description = Description,
                    AccountNumber = AccountNumber,
                    AccountNumberType = AccountNumberType
                };
                var returnId = SetupServiceClientMock_DefineAccount(request);
                
                // Act
                var result = await _controller.SubmitForm(id, request);
                
                // Assert
                var objResult = result as ObjectResult;
                var response = objResult?.Value as ApiResponse<SubmitAccountResponse>;
                
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Ok, Is.True);
                Assert.That(response.Data.Id, Is.EqualTo(returnId));
                await AssertServiceClientMockCalled_DefineAccount(request);
            }

            private Guid SetupServiceClientMock_DefineAccount(SubmitAccountRequest request)
            {
                var guid = Guid.NewGuid();
                _serviceClient
                    .DefineAccount(Arg.Is<SubmitAccountRequest>(req => 
                        req.Name.Equals(request.Name)
                        && req.Description.Equals(request.Description)
                        && req.AccountNumber.Equals(request.AccountNumber)
                        && req.AccountNumberType.Equals(request.AccountNumberType)))
                    .Returns(new SubmitAccountResponse(guid));

                return guid;
            }

            private async Task AssertServiceClientMockCalled_DefineAccount(SubmitAccountRequest request)
            {
                await _serviceClient
                    .Received(1)
                    .DefineAccount(Arg.Is<SubmitAccountRequest>(req =>
                        req.Name.Equals(request.Name)
                        && req.Description.Equals(request.Description)
                        && req.AccountNumber.Equals(request.AccountNumber)
                        && req.AccountNumberType.Equals(request.AccountNumberType)));
            }
            
            [Test]
            public async Task ReturnEmptyGuid_WhenExistingAccount()
            {
                // Arrange
                const string id = "B9A44D4F-816C-41F3-B0F1-F990351AA635";
                var request = new SubmitAccountRequest
                {
                    Name = Name,
                    Description = Description,
                    AccountNumber = AccountNumber,
                    AccountNumberType = AccountNumberType
                };
                
                // Act
                var result = await _controller.SubmitForm(id, request);
                
                // Assert
                var objResult = result as ObjectResult;
                var response = objResult?.Value as ApiResponse<SubmitAccountResponse>;
                
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Ok, Is.True);
                Assert.That(response.Data.Id, Is.EqualTo(Guid.Empty));
            }
        }

        public class ListShould : AccountsControllerTests
        {
            private static readonly Guid AccountId = Guid.NewGuid();
            private const string Name = "Savings";
            private const string Description = "Just saving some money";
            private const string AccountNumber = "BE18456141662665";
            private const ListResponse.AccountNumberType AccountNumberType = ListResponse.AccountNumberType.Iban;
            
            [Test]
            public async Task CallViewModelFactoryList()
            {
                var viewModelFactoryResponse = new ListResponse(new []
                {
                    new ListResponse.AccountViewModel
                    {
                        AccountId = AccountId,
                        Name = Name,
                        Description = Description,
                        AccountNumber = AccountNumber,
                        AccountNumberType = AccountNumberType
                    }
                });
                
                _viewModelFactory
                    .List()
                    .Returns(viewModelFactoryResponse);
                
                // Act
                var result = await _controller.List();
                
                // Arrange
                var objResult = result as ObjectResult;
                var response = objResult?.Value as ApiResponse<ListResponse>;
                
                Assert.That(response, Is.Not.Null);
                Assert.That(response.Data.Accounts, Has.Length.EqualTo(1));
                var single = response.Data.Accounts[0];
                
                Assert.That(single.AccountId, Is.EqualTo(AccountId));
                Assert.That(single.Name, Is.EqualTo(Name));
                Assert.That(single.Description, Is.EqualTo(Description));
                Assert.That(single.AccountNumber, Is.EqualTo(AccountNumber));
                Assert.That(single.AccountNumberType, Is.EqualTo(AccountNumberType));
                
                await _viewModelFactory
                    .Received(1)
                    .List();
            }
        }
    }
}