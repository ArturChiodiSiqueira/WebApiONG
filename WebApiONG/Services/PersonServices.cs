using MongoDB.Driver;
using System.Collections.Generic;
using WebApiONG.Models;
using WebApiONG.Utils;

namespace WebApiONG.Services
{
    public class PersonServices
    {
        private readonly IMongoCollection<Person> _people;

        public PersonServices(IDatabaseSettings settings)
        {
            var person = new MongoClient(settings.ConnectionString);
            var database = person.GetDatabase(settings.DatabaseName);
            _people = database.GetCollection<Person>(settings.PersonCollectionName);
        }

        public Person Create(Person person)
        {
            _people.InsertOne(person);
            return person;
        }

        public List<Person> Get() => _people.Find<Person>(person => true).ToList();

        public Person Get(string cpf) => _people.Find<Person>(person => person.Cpf == cpf).FirstOrDefault();

        public void Update(string cpf, Person personIn)
        {
            _people.ReplaceOne(person => person.Cpf == cpf, personIn);
        }

        public void Remove(Person personIn) => _people.DeleteOne(person => person.Cpf == personIn.Cpf);
    }
}
