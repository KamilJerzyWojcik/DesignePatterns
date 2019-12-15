using System;
namespace CodeMoreObjectOriented
{
    public class Frozen : IAccountState
    {
        private Action _onUnfreeze { get; set; }


        public Frozen(Action onUnfreeze)
        {
            _onUnfreeze = onUnfreeze;
        }


        public IAccountState Deposit(Action AddToBalance)
        {
            _onUnfreeze();
            AddToBalance();
            return new Active(_onUnfreeze);
        }


        public IAccountState Freeze() => this;


        public IAccountState Withdraw(Action subtractFromBalance)
        {
            _onUnfreeze();
            subtractFromBalance();
            return new Active(_onUnfreeze);
        }

        public IAccountState HolderVerified() => this;

        public IAccountState Close() => new Closed();
    }
}
