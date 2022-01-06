using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using POC.Modules.Domain.ValueObjects;

namespace POC.Modules.Domain.Entities
{
    public class Customer : Notifiable, IEntity, IValidatable
    {      
        private readonly IList<Address> _addresses = new List<Address>();
        public Customer(NameVo name, CpfVo cpf, EmailVo email, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cpf = cpf;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();

            Validate();
        }

        public Customer()
        {

        }
        public NameVo Name { get; private set; }
        public CpfVo Cpf { get; private set; }
        public EmailVo Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses { 
            get
            {
                return _addresses.ToArray();
            } 
        }

        public Guid Id { get;  set; }

        public void AddAddress(Address address)
        {
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }

        public void Validate()
        {
            AddNotifications(new Contract().Requires());

            AddNotifications(
                new Contract()
                .IsTrue(Name.Valid, "Name", "Nome inválido")
                .IsTrue(Cpf.Valid, "Name", "Cpf inválido")
                .IsTrue(Email.Valid, "Email", "Email inválido")
                );
        }
    }
}
