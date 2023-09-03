//1
//amount - amountToDepositInUsd
//сумма к зачислению на счет пользователя

//2
//amount - amountToWithdrawInUsd
//сумма к снятию с счета пользователя

//3
//user - userToReceiveDeposit
//пользователь который получит перевод

//4
//from - userToMakeTransfer
//пользователь который послыает перевод

//5
//to - userToReceiveTransfer
//пользователь который получает перевод

//6
//withdrawal - userLastWithdrawalDate
//дата осуществелния последнего снятия денег для конкретного пользователя

//7
//coefficient - tranferVolumeFactorForPotentialFraudCheck
//коэффициент для провекри сумма перервода при определении моженнической детяльности

//8
//interval - amongTransferMinutesIntervalForFraudCheck
//временной промежуток в минутах для проверки частоты транакзций для оценки шанса мошеннической активности 

//9
//maxTransactionCount - weeeklyTranfersNumberForPotentialFraudCheck
//количество переводов пользоватлем за неделю после которого повысится шанс на мошенническую активность 

//10
//transactionsCount - transfersMadeByUserLastWeek
//количесвто сделланных пользователем перерводов за последнюю неделю

//11
//from - oneWeekAgo
//отметка времени в 1 неделю для подсчета количества транзакицй за интервал временной

//12
//checkResult - isWithdrawalPotentiallyFraud
//результат проверки запроса на снятие денег на предемет мошеннической активности 



//Code used for task
using System;
using System.Collections.Generic;
using System.Linq;

class User
{
    public string UserName { get; set; }
    public double CheckingAccountBalance { get; set; }
    public double SavingsAccountBalance { get; set; }
    public List<DateTime> TransactionHistory { get; set; }

    public User(string userName, double initialCheckingBalance, double initialSavingsBalance)
    {
        UserName = userName;
        CheckingAccountBalance = initialCheckingBalance;
        SavingsAccountBalance = initialSavingsBalance;
        TransactionHistory = new List<DateTime>();
    }
}

class BankingSystem
{
    private List<User> users = new List<User>();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public void DepositToChecking(string userName, double amount)//(amountToDepositInUsd)
    {
        User user = FindUser(userName);//userToReceiveDeposit

        if (user == null || amount <= 0)
        {
            return;
        }

        user.CheckingAccountBalance += amount;
        user.TransactionHistory.Add(DateTime.Now);
    }

    public void WithdrawFromSavings(string userName, double amount)//(amountToWithdrawInUsd)
    {
        User user = FindUser(userName);

        if (user == null || amount <= 0 || amount > user.SavingsAccountBalance)
        {
            return;
        }

        var checkResult = IsFraudulentWithdrawal(user, amount);//isWithdrawalPotentiallyFraud
        if (!checkResult)
        {
            user.SavingsAccountBalance -= amount;
            user.TransactionHistory.Add(DateTime.Now);
        }
    }

    public void TransferFromCheckingToSavings(string senderUserName, string receiverUserName, double amount)
    {
        User from = FindUser(senderUserName);//userToMakeTransfer
        User to = FindUser(receiverUserName);//userToReceiveTransfer

        if (from == null || to == null || amount <= 0 || amount > from.CheckingAccountBalance)
        {
            return;
        }

        if (!IsFraudulentTransfer(from, amount))
        {
            from.CheckingAccountBalance -= amount;
            to.SavingsAccountBalance += amount;
            from.TransactionHistory.Add(DateTime.Now);
            to.TransactionHistory.Add(DateTime.Now);
        }
    }

    private User FindUser(string userName)
    {
        return users.Find(user => user.UserName == userName);
    }

    private bool IsFraudulentWithdrawal(User user, double amount)
    {
        var interval = 1;//amongTransferMinutesIntervalForFraudCheck
        // Check for multiple withdrawals within a short time frame
        DateTime now = DateTime.Now;
        DateTime withdrawal = user.TransactionHistory.LastOrDefault();//userLastWithdrawalDate
        if (withdrawal != null && (now - withdrawal).TotalMinutes < interval)
        {
            return true;
        }

        return false;
    }

    private bool IsFraudulentTransfer(User sender, double amount)
    {
        var coefficient = 0.5; //tranferVolumeFactorForPotentialFraudCheck
        // Check for large transfers relative to account balance
        if (amount > sender.CheckingAccountBalance * coefficient)
        {
            return true;
        }

        var maxTransactionCount = 7; //tranfersNumberForPotentialFraudCheck
        var transactionsCount = GetTransactionsInLastWeek(sender);//transfersMadeByUserLastWeek
        if (transactionsCount > maxTransactionCount)
        {
            return true;
        }

        return false;
    }

    private int GetTransactionsInLastWeek(User user)
    {
        DateTime now = DateTime.Now;
        DateTime from = now.AddDays(-7);//oneWeekAgo
        return user.TransactionHistory.Count(transactionTime => transactionTime >= from);
    }
}
