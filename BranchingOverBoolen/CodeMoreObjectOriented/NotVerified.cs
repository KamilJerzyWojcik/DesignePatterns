using System;
namespace CodeMoreObjectOriented
{
    public class NotVerified : IAccountState
    {
        private Action _onUnfreeze { get; set; }


        public NotVerified(Action onUnfreeze)
        {
            _onUnfreeze = onUnfreeze;
        }

        public IAccountState Close() => new Closed();

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active(_onUnfreeze);

        public IAccountState Withdraw(Action subtractFromBalance) => this;
    }
}
