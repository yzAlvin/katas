using System;

namespace Algorithm
{
    public class PairOfPeople
    {
        public Person Younger { get; set; }
        public Person Older { get; set; }
        public TimeSpan AgeDifference { get; set; }

        public PairOfPeople(Person younger, Person older)
        {
            Younger = younger;
            Older = older;
            AgeDifference = older.BirthDate - Younger.BirthDate;
        }

        public PairOfPeople()
        {

        }

        public override string ToString()
        {
            return $"{Younger}, {Older}, {AgeDifference}";
        }
    }
}