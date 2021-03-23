using System.Collections.Generic;
using System.Linq;
using System;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> people;

        public Finder(List<Person> listOfPeople)
        {
            people = listOfPeople;
        }

        public PairOfPeople Find(FinderFlag flag)
        {
            var listOfPairs = new List<PairOfPeople>();
            AddAllPairs(listOfPairs);


            PairOfPeople answer = new PairOfPeople();

            if (listOfPairs.Count < 1)
            {
                return answer;
            }

            listOfPairs = listOfPairs.OrderBy(p => p.AgeDifference).ToList();

            var finderFlag = new Dictionary<FinderFlag, Action<IEnumerable<PairOfPeople>>>(){ {FinderFlag.Closest, (x) => x.First()}, {FinderFlag.Furthest, (x) => x.Last()}}; 

            return () => finderFlag[flag];

            // switch (flag)
            // {
            //     case FinderFlag.Closest:
            //         answer = listOfPairs.First();
            //         break;

            //     case FinderFlag.Furthest:
            //         answer = listOfPairs.Last();
            //         break;
            // }

            // return answer;
        }

        private void AddAllPairs(List<PairOfPeople> listOfPairs)
        {

            for (var i = 0; i < people.Count - 1; i++)
            {
                for (var j = i + 1; j < people.Count; j++)
                {
                    var pair = new PairOfPeople();
                    if (people[i].BirthDate < people[j].BirthDate)
                    {
                        pair.Younger = people[i];
                        pair.Older = people[j];
                    }
                    else
                    {
                        pair.Younger = people[j];
                        pair.Older = people[i];
                    }
                    pair.AgeDifference = pair.Older.BirthDate - pair.Younger.BirthDate;
                    listOfPairs.Add(pair);
                }
            }
        }
    }
}