
using System;

namespace Api.Domain.Models.User
{
    public class UserModel
    {
        private Guid _Id;
        public Guid Id
        {
            get { return _Id; }
            set { this._Id = value; }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
                   
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        
        private DateTime _CreateAt;
        public DateTime CreateAt
        {
            get { return _CreateAt; }
            set { _CreateAt = value == null ? DateTime.UtcNow : value; }
        }
        
        private DateTime _UpdateAt;
        public DateTime UpdateAt
        {
            get { return _UpdateAt; }
            set { _UpdateAt = value; }
        }
        
        private string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        
    }
}