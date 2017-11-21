using System;

namespace GlobalXChallenge
{
    public class Person : IComparable<Person>
    {
        private string givenName;
        private string familyName;

        public Person(string givenName, string familyName)
        {
            if(givenName.Equals(null))
                throw new Exception("Errror: given name cannot be null");
            if (familyName.Equals(null))
                throw new Exception("Error: family name cannot be null");
            this.givenName = givenName;
            this.familyName = familyName;
        }
        public int CompareTo(Person p)
        {
            if (p == null)
                return 1;
            if (string.Compare(familyName, p.familyName, StringComparison.Ordinal) == 0)
                return string.Compare(givenName, p.givenName, StringComparison.Ordinal);
            return string.Compare(familyName, p.familyName, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return (givenName + " " + familyName);
        }

        //Equals, Hash code ect not implemented yet as not required for challenge.
    }
}