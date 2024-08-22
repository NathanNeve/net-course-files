using Bank;

namespace BankTest
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void Constructor_Balance0_Returns0()
        {
            // Arrange
            Account account = new Account();
            // Act
            Double balance = account.Balance;
            // Assert
            Assert.AreEqual(balance, 0);
        }

        [TestMethod]
        public void Credit_999OnBalance0_Returns999()
        {
            //
            Account account = new Account();

            //
            account.Credit(999);

            //
            Assert.AreEqual(account.Balance, 999);
        }

        [TestMethod]
        public void Debit_500FromBalance500_Returns0()
        {
            //
            Account account = new Account();

            //
            account.Credit(500);
            account.Debit(500);

            //
            Assert.AreEqual(0, account.Balance);
        }

        [TestMethod]
        public void Credit_Negative500_ReturnsException()
        {
            Account account = new Account();
            
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => account.Credit(-200)
            );
        }

        [TestMethod]
        public void Debit_AmountBiggerThanBalance_ThrowsBalanceInsufficientException()
        {
            Account account = new Account();
            Assert.ThrowsException<BalanceInsufficientException>(
                () => account.Debit(100)
            );
        }
    }
}