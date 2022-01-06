﻿using Flunt.Notifications;
using Flunt.Validations;

namespace POC.Modules.Domain.ValueObjects
{
    public class EmailVo : Notifiable, IValidatable
    {
        public EmailVo(string address)
        {
            Address = address;
            Validate();
        }

        public EmailVo()
        {

        }

        public string Address { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsEmail(Address, "Email", "O e-mail é inválido"));
        }
    }
}
