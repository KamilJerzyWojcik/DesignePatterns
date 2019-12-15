using System;
namespace CodeMoreObjectOriented
{
    public class Active : IAccountState
    {
        private Action _onUnFreeze { get; set; }


        public Active(Action onUnfreeze)
        {
            _onUnFreeze = onUnfreeze;
        }


        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }


        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }


        public IAccountState Freeze() => new Frozen(_onUnFreeze);


        public IAccountState HolderVerified() => this;

        public IAccountState Close() => new Closed();
    }
}
