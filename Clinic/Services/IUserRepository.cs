namespace Clinic.Services
{
    public interface IUserRepository<TUser> where TUser : class
    {
        TUser? GetById(string id);

        void Add(TUser tUser);

        void Update(TUser tUser);

        void Activate(TUser tUser);

        void Disable(TUser tUser);

        bool IsUserActive(TUser tUser);
    }
}