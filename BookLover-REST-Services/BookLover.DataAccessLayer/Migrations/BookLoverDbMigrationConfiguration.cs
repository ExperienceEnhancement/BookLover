﻿namespace BookLover.DataAccessLayer.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity.Migrations;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Contexts;
    using EntityModels;

    class BookLoverDbMigrationConfiguration: DbMigrationsConfiguration<BookLoverDbContext>
    {
        public BookLoverDbMigrationConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BookLoverDbContext context)
        {
            if (!context.Users.Any())
            {
                this.CreateUsers(context);
                this.CreateAuthors(context);
                this.CreateBooks(context);
            }
        }

        private void CreateAuthors(BookLoverDbContext context)
        {
            var janeAusten = new Author()
            {
                FirstName = "Jane",
                LastName = "Austen"
            };

            context.Authors.Add(janeAusten);

            var harperLee = new Author()
            {
                FirstName = "Harper",
                LastName = "Lee"
            };

            context.Authors.Add(harperLee);

            var charlotteBronte = new Author()
            {
                FirstName = "Charlotte",
                LastName = "Bronte"
            };

            context.Authors.Add(charlotteBronte);

            var williamShakespeare = new Author()
            {
                FirstName = "William",
                LastName = "Shakespeare"
            };

            context.Authors.Add(williamShakespeare);

            context.SaveChanges();
        }

        public void CreateBooks(BookLoverDbContext context)
        {
            var prideAndPrejudice = new Book()
            {
                Title = "Pride and Prejudice",
                Summary = "First published in 1813, Pride and Prejudice, Jane Austens witty comedy of manners - one of the most popular novels of all time - tells the story of Mr and Mrs Bennet's five unmarried daughters after the rich and eligible Mr Bingley and his status-conscious friend, Mr Darcy, have moved into their neighbourhood.",
                Author = context.Authors.Where(x => x.FirstName == "Jane").First()
            };

            context.Books.Add(prideAndPrejudice);

            var senseAndSensibility = new Book()
            {
                Title = "Sense and Sensibility",
                Summary = "Jane Austen's first published novel introduced many of the themes which would dominate Austen's future work. Austen writes about everyday events of her own time with a subtlety and sensitivity unprecedented in the English novel. This edition, first published in 2006, follows the second edition of 1813, which corrects errors of the first edition.",
                Author = context.Authors.Where(x => x.FirstName == "Jane").First()
            };

            context.Books.Add(senseAndSensibility);

            var toKillAMockingbird = new Book()
            {
                Title = "To Kill a Mockingbird",
                Summary = "The unforgettable novel of a childhood in a sleepy Southern town and the crisis of conscience that rocked it, To Kill A Mockingbird became both an instant bestseller and a critical success when it was first published in 1960. It went on to win the Pulitzer Prize in 1961 and was later made into an Academy Award-winning film, also a classic.",
                Author = context.Authors.Where(x => x.FirstName == "Harper").First()
            };

            context.Books.Add(toKillAMockingbird);

            var janeEyre = new Book()
            {
                Title = "Jane Eyre",
                Summary = "Orphaned into the household of her Aunt Reed at Gateshead, subject to the cruel regime at Lowood charity school, Jane Eyre nonetheless emerges unbroken in spirit and integrity. She takes up the post of governess at Thornfield, falls in love with Mr. Rochester, and discovers the impediment to their lawful marriage in a story that transcends melodrama to portray a woman's passionate search for a wider and richer life than Victorian society traditionally allowed.",
                Author = context.Authors.Where(x => x.FirstName == "Charlotte").First()
            };

            context.Books.Add(janeEyre);

            var romeoAndJuliet = new Book()
            {
                Title = "Romeo and Juliet",
                Summary = "In Romeo and Juliet, Shakespeare creates a world of violence and generational conflict in which two young people fall in love and die because of that love. The story is rather extraordinary in that the normal problems faced by young lovers are here so very large. It is not simply that the families of Romeo and Juliet disapprove of the lover's affection for each other; rather, the Montagues and the Capulets are on opposite sides in a blood feud and are trying to kill each other on the streets of Verona. Every time a member of one of the two families dies in the fight, his relatives demand the blood of his killer. Because of the feud, if Romeo is discovered with Juliet by her family, he will be killed. Once Romeo is banished, the only way that Juliet can avoid being married to someone else is to take a potion that apparently kills her, so that she is burried with the bodies of her slain relatives. In this violent, death-filled world, the movement of the story from love at first sight to the union of the lovers in death seems almost inevitable.",
                Author = context.Authors.Where(x => x.FirstName == "William").First()
            };

            context.Books.Add(romeoAndJuliet);

            context.SaveChanges();
        }

        private void CreateUsers(BookLoverDbContext context)
        {
            var usernames = new[]
            {
                "katherina", "m.deneva", "nikola", "georgi", "denislav", "iliana",
            };

            var users = new List<User>();
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 2,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            foreach (var username in usernames)
            {
                var user = new User
                {
                    UserName = username,
                    Email = username + "@gmail.com",
                };

                var password = "123456";
                var userCreateResult = userManager.Create(user, password);
                if (userCreateResult.Succeeded)
                {
                    users.Add(user);
                }
                else
                {
                    throw new Exception(string.Join("; ", userCreateResult.Errors));
                }
            }
        }
    }
}
