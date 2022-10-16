namespace Contracts
{
    public interface IMembershipService
    {
        void CreateAccount(string userName, string email, string password);
    }
}