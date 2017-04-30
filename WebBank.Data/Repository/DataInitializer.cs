using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBank.Data.Entities;
using WebBank.Data.Infrastructure.Enums;
using WebBank.Data.Infrastructure.Helpers;

namespace WebBank.Data.Repository
{
    public class DataInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.UserAccounts.Any())
            {
                return;
            }

            #region Clents Initialization

            var userAccountsForClients = new List<UserAccount>()
            {
                new Entities.UserAccount()
                {
                    Name = "Ivan",
                    Surname = "Gora",
                    Email = "gora@gmail.com",
                    Password = PasswordHasher.GetMd5Hash("1111"),
                    IsAdmin = false
                },
                new Entities.UserAccount()
                {
                    Name = "John",
                    Surname = "Doe",
                    Email = "doe@gmail.com",
                    Password = PasswordHasher.GetMd5Hash("1111"),
                    IsAdmin = false
                }
            };

            var clients = new List<Client>()
            {
                new Client()
                {
                    Address = "Some Address",
                    PassportNumber = "00000",
                    Phone = "380969622965",
                    UserAccount = userAccountsForClients[0],
                    CashAccount = new CashAccount()
                    {
                        Balance = 1252
                    }
                },
                new Client()
                {
                    Address = "Some Address 2/a",
                    PassportNumber = "11111",
                    Phone = "380979722977",
                    UserAccount = userAccountsForClients[1],
                    CashAccount = new CashAccount()
                    {
                        Balance = 256
                    }
                }
            };

            context.Clients.AddRange(clients);

            #endregion

            #region Transactions

            List<TransferTransaction> trnsfTransList = new List<TransferTransaction>()
            {
                new TransferTransaction()
                {
                    Amount = 100,
                    Client = clients[1],
                    Date = DateTime.Now.AddDays(-1),
                    Receiver = 1
                },

                new TransferTransaction()
                {
                    Amount = 80,
                    Client = clients[1],
                    Date = DateTime.Now.AddHours(-1),
                    Receiver = 1
                },
                new TransferTransaction()
                {
                    Amount = 54,
                    Client = clients[1],
                    Date = DateTime.Now,
                    Receiver = 1
                }
            };

            context.TransferTransactions.AddRange(trnsfTransList);

            #endregion

            context.SaveChanges();


        }
    }
}
