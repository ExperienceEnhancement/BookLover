namespace BookLover.Tests.UnitTests.TestData
{
    using System.Collections.Generic;
    using System.Linq;
    using EntityModels;

    public static class TestData
    {
        public static IList<Author> Authors = new List<Author>()
        {
            new Author()
            {
                Id = 1,
                FirstName = "Jane",
                LastName = "Austen"
            },
            new Author()
            {
                Id = 2,
                FirstName = "Harper",
                LastName = "Lee"
            },
            new Author()
            {
                Id = 3,
                FirstName = "Charlotte",
                LastName = "Bronte"
            },
            new Author()
            {
                Id = 4,
                FirstName = "William",
                LastName = "Shakespeare"
            }
        };

       public static IList<Book> Books = new List<Book>()
       {
           new Book()
           {
                Id = 1,
                Title = "Pride and Prejudice",
                Summary = "First published in 1813, Pride and Prejudice, Jane Austens witty comedy of manners - one of the most popular novels of all time - tells the story of Mr and Mrs Bennet's five unmarried daughters after the rich and eligible Mr Bingley and his status-conscious friend, Mr Darcy, have moved into their neighbourhood.",
                Author = Authors.Where(x => x.FirstName == "Jane").First()
           },
           new Book()
           {
               Id = 2,
                Title = "Sense and Sensibility",
                Summary = "Jane Austen's first published novel introduced many of the themes which would dominate Austen's future work. Austen writes about everyday events of her own time with a subtlety and sensitivity unprecedented in the English novel. This edition, first published in 2006, follows the second edition of 1813, which corrects errors of the first edition.",
                Author = Authors.Where(x => x.FirstName == "Jane").First()
           },
           new Book()
           {
                Id = 3,
                Title = "To Kill a Mockingbird",
                Summary = "The unforgettable novel of a childhood in a sleepy Southern town and the crisis of conscience that rocked it, To Kill A Mockingbird became both an instant bestseller and a critical success when it was first published in 1960. It went on to win the Pulitzer Prize in 1961 and was later made into an Academy Award-winning film, also a classic.",
                Author = Authors.Where(x => x.FirstName == "Harper").First()
           },
           new Book()
           {
                Id = 4,
                Title = "Jane Eyre",
                Summary = "Orphaned into the household of her Aunt Reed at Gateshead, subject to the cruel regime at Lowood charity school, Jane Eyre nonetheless emerges unbroken in spirit and integrity. She takes up the post of governess at Thornfield, falls in love with Mr. Rochester, and discovers the impediment to their lawful marriage in a story that transcends melodrama to portray a woman's passionate search for a wider and richer life than Victorian society traditionally allowed.",
                Author = Authors.Where(x => x.FirstName == "Charlotte").First()
           },
           new Book()
           {
                Id = 5,
                Title = "Romeo and Juliet",
                Summary = "In Romeo and Juliet, Shakespeare creates a world of violence and generational conflict in which two young people fall in love and die because of that love. The story is rather extraordinary in that the normal problems faced by young lovers are here so very large. It is not simply that the families of Romeo and Juliet disapprove of the lover's affection for each other; rather, the Montagues and the Capulets are on opposite sides in a blood feud and are trying to kill each other on the streets of Verona. Every time a member of one of the two families dies in the fight, his relatives demand the blood of his killer. Because of the feud, if Romeo is discovered with Juliet by her family, he will be killed. Once Romeo is banished, the only way that Juliet can avoid being married to someone else is to take a potion that apparently kills her, so that she is burried with the bodies of her slain relatives. In this violent, death-filled world, the movement of the story from love at first sight to the union of the lovers in death seems almost inevitable.",
                Author = Authors.Where(x => x.FirstName == "William").First()
           }
       };
    }
}
