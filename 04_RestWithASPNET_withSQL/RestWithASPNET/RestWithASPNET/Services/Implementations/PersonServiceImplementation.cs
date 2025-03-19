using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System.Collections.Generic;


namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context;

        public PersonServiceImplementation(MySQLContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
            return person;
        }
        public void Delete(long id)
        {
            var person = _context.Persons.Find(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
                _context.SaveChanges(); 
            }
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = 1,
                FirstName = "Mat",
                LastName = "Vieira",
                Address = "Rio de Janeiro - Rj - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            _context.Persons.Update(person);
            _context.SaveChanges(); 
            return person;
        }
    }
}
