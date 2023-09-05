using Autofac.Extras.Moq;
using H3_Tests___Application;
using H3_Tests___Application.Exceptions;
using H3_Tests___Application.Managers;
using H3_Tests___Application.Models;
using H3_Tests___Application.Repositories;
using Moq;
using static MongoDB.Driver.WriteConcern;

namespace H3_Tests___Test_Project
{
    public class AccountManagerTest
    {
        #region Withdraw Tests
        [Fact]
        public async void Withdraw_CardIsNullShouldFail()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IGenericRepository<Account>>()
                    .Setup(repo => repo.GetAll())
                    .ReturnsAsync(GetSampleAccounts());

                var manager = mock.Create<AccountManager>();

                await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.Withdraw(null, 20));
            }
        }

        [Theory]
        [InlineData(50)]
        [InlineData(80)]
        [InlineData(100)]
        public async void Withdraw_ShouldWithdrawValues(double amount)
        {
            using (var mock = AutoMock.GetLoose())
            {
                Account[] sampleAccounts = GetSampleAccounts();
                Account sampleAccount = sampleAccounts[0];

                mock.Mock<IGenericRepository<Account>>()
                    .Setup(repo => repo.GetAll())
                    .ReturnsAsync(GetSampleAccounts());

                mock.Mock<IGenericRepository<Account>>()
                    .Setup(repo => repo.Update(It.IsAny<Account>()))
                    .ReturnsAsync((Account account) => account);

                var manager = mock.Create<AccountManager>();

                CreditCard[] sampleCards = GetSampleCards();
                CreditCard sampleCard = sampleCards[0];
                Account updatedAccount = await manager.Withdraw(sampleCard, amount);
                Assert.True(updatedAccount.Balance == sampleAccount.Balance - amount);
            }
        }

        [Fact]
        public async void Withdraw_ShouldThrowOvercharged()
        {
            using (var mock = AutoMock.GetLoose())
            {
                CreditCard[] sampleCards = GetSampleCards();
                CreditCard sampleCard = sampleCards[0];
                Account[] sampleAccounts = GetSampleAccounts();
                Account sampleAccount = sampleAccounts[0];

                mock.Mock<IGenericRepository<Account>>()
                    .Setup(repo => repo.GetAll())
                    .ReturnsAsync(GetSampleAccounts());

                mock.Mock<IGenericRepository<Account>>()
                    .Setup(repo => repo.Update(It.IsAny<Account>()))
                    .ReturnsAsync((Account account) => account);

                var manager = mock.Create<AccountManager>();

                double amount = sampleAccount.Balance + 1;
                await Assert.ThrowsAsync<OverchargedException>(async () =>
                {
                    await manager.Withdraw(sampleCard, amount);
                });
            }
        }
        #endregion

        #region Deposit Tests
        [Fact]
        public async void Deposit_CardIsNullShouldFail()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IGenericRepository<Account>>()
                    .Setup(repo => repo.GetAll())
                    .ReturnsAsync(GetSampleAccounts());

                var manager = mock.Create<AccountManager>();

                await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.Deposit(null, 20));
            }
        }

        [Theory]
        [InlineData(50)]
        [InlineData(80)]
        [InlineData(100)]
        public async void Deposit_ShouldDepositValues(double amount)
        {
            using (var mock = AutoMock.GetLoose())
            {
                Account[] sampleAccounts = GetSampleAccounts();
                Account sampleAccount = sampleAccounts[0];

                mock.Mock<IGenericRepository<Account>>()
                    .Setup(repo => repo.GetAll())
                    .ReturnsAsync(GetSampleAccounts());

                mock.Mock<IGenericRepository<Account>>()
                    .Setup(repo => repo.Update(It.IsAny<Account>()))
                    .ReturnsAsync((Account account) => account);

                var manager = mock.Create<AccountManager>();

                CreditCard[] sampleCards = GetSampleCards();
                CreditCard sampleCard = sampleCards[0];
                Account updatedAccount = await manager.Deposit(sampleCard, amount);
                Assert.True(updatedAccount.Balance == sampleAccount.Balance + amount);
            }
        }
        #endregion

        private Account[] GetSampleAccounts()
        {
            return new Account[] {
                new Account("1234567890")
                {
                    Balance = 100,
                },
                new Account("0987654321")
                {
                    Balance = 1120,
                },
                new Account("6789054321")
                {
                    Balance = 960,
                }
            };
        }

        private CreditCard[] GetSampleCards()
        {
            Random random = new Random();
            Account[] sampleAccounts = GetSampleAccounts();
            List<CreditCard> creditCards = new List<CreditCard>();
            foreach (Account sampleAccount in sampleAccounts)
            {
                string randomNumber = "";
                for (int i = 0; i < 10; i++)
                {
                    randomNumber += random.Next(0, 10);
                }
                creditCards.Add(new CreditCard(
                    randomNumber,
                    "Tester Testesen" + randomNumber[0] + randomNumber[1],
                    sampleAccount.Number,
                    false)
                );
            }
            return creditCards.ToArray();
        }
    }
}