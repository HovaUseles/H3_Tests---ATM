using H3_Tests___Application.Exceptions;
using H3_Tests___Application.Models;
using H3_Tests___Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Tests___Application.Managers
{
    public class AccountManager
    {
        private readonly IGenericRepository<Account> accountRepo;

        public AccountManager(IGenericRepository<Account> accountRepository)
        {
            this.accountRepo = accountRepository;
        }

        public async Task<Account> Create(Account account)
        {
            return await accountRepo.Add(account);
        }

        public async Task<Account> Withdraw(CreditCard card, double amount)
        {
            if(card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            Account[] accounts = await accountRepo.GetAll();
            Account activeAccount = accounts.FirstOrDefault(a => a.Number == card.AccountNumber);

            if (activeAccount == null)
            {
                throw new ArgumentException($"Account with number: {card.AccountNumber} does not exist", nameof(card));
            }

            if(card.IsOverchangeAble == false & activeAccount.Balance - amount < 0)
            {
                throw new OverchargedException("The card is not overchargeable and was overcharged.", activeAccount.Balance - amount);
            }
            activeAccount.Balance -= amount;
            Account updatedAccount = await accountRepo.Update(activeAccount);
            return updatedAccount;
        }

        public async Task<Account> Deposit(CreditCard card, double amount)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            Account[] accounts = await accountRepo.GetAll();
            Account activeAccount = accounts.FirstOrDefault(a => a.Number == card.AccountNumber);

            if (activeAccount == null)
            {
                throw new ArgumentException($"Account with number: {card.AccountNumber} does not exist", nameof(card));
            }

            activeAccount.Balance += amount;
            return await accountRepo.Update(activeAccount);
        }
    }
}
