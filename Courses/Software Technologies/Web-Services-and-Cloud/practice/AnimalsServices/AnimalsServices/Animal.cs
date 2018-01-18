using System.Runtime.Serialization;

namespace AnimalsServices
{
    [DataContract]
    public class Animal
    {
        [DataMember(Name = "animalName")]
        public string Name { get; set; }
    }
}