using System;
namespace CodeMoreObjectOriented
{
    public class Account
    {
        public decimal Balance { get; private set; }

        private IAccountState _state { get; set; }


        public Account(Action onUnfreeze)
        {
            _state = new NotVerified(onUnfreeze);
        }

        // #1 (Interaction): Deposit was invoked on the state
        // #2 (Behavior): Result of _state.Deposit is new _state
        // #5 (Behavior): Deposit 10, Deposit 1 - Balance == 11
        public void Deposit(decimal amount)
        {
            _state = _state.Deposit(() => Balance += amount);
        }

        // #3 (Interaction): Withdraw was invoked on the state
        // #4 (Behavior): Result of _state.Withdraw is new _state
        // #6 (Behavior): Deposit 10, Verify, Withdraw 1 - Balance == 9
        public void Withdraw(decimal amount)
        {
            _state = _state.Withdraw(() => Balance -= amount);
        }


        public void HolderVerified()
        {
            _state = _state.HolderVerified();
        }


        public void Close()
        {
            _state = _state.Close();
        }


        public void Freeze()
        {
            _state = _state.Freeze();
        }
    }
}
