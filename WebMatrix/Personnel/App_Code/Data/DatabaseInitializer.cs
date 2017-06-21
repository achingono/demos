using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using NLipsum.Core;

namespace ProSoft.Personnel.Data
{
    /// <summary>
    /// Summary description for Initializer
    /// </summary>
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<Entities>
    {
        /// <summary>
        /// List of all the countries in the world
        /// https://gist.github.com/901679
        /// http://en.wikipedia.org/wiki/Country_dial_codes#Complete_listing
        /// </summary>
        private static string[] countries = { 
            "Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra",
            "Angola", "Anguilla", "Antarctica", "Antigua And Barbuda", "Argentina",
            "Armenia", "Aruba", "Australia", "Austria", "Azerbaijan",
            "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus",
            "Belgium", "Belize", "Benin", "Bermuda", "Bhutan",
            "Bolivia", "Bosnia Hercegovina", "Botswana", "Bouvet Island", "Brazil",
            "Brunei Darussalam", "Bulgaria", "Burkina Faso", "Burundi", "Byelorussian SSR",
            "Cambodia", "Cameroon", "Canada", "Cape Verde", "Cayman Islands",
            "Central African Republic", "Chad", "Chile", "China", "Christmas Island",
            "Cocos (Keeling) Islands", "Colombia", "Comoros", "Congo", "Cook Islands",
            "Costa Rica", "Cote D'Ivoire", "Croatia", "Cuba", "Cyprus",
            "Czech Republic", "Czechoslovakia", "Denmark", "Djibouti", "Dominica",
            "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador",
            "England", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia",
            "Falkland Islands", "Faroe Islands", "Fiji", "Finland", "France",
            "Gabon", "Gambia", "Georgia", "Germany", "Ghana",
            "Gibraltar", "Great Britain", "Greece", "Greenland", "Grenada",
            "Guadeloupe", "Guam", "Guatemela", "Guernsey", "Guiana",
            "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Heard Islands",
            "Honduras", "Hong Kong", "Hungary", "Iceland", "India",
            "Indonesia", "Iran", "Iraq", "Ireland", "Isle Of Man",
            "Israel", "Italy", "Jamaica", "Japan", "Jersey",
            "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea, South",
            "Korea, North", "Kuwait", "Kyrgyzstan", "Lao People's Dem. Rep.", "Latvia",
            "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein",
            "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar",
            "Malawi", "Malaysia", "Maldives", "Mali", "Malta",
            "Mariana Islands", "Marshall Islands", "Martinique", "Mauritania", "Mauritius",
            "Mayotte", "Mexico", "Micronesia", "Moldova", "Monaco",
            "Mongolia", "Montserrat", "Morocco", "Mozambique", "Myanmar",
            "Namibia", "Nauru", "Nepal", "Netherlands", "Netherlands Antilles",
            "Neutral Zone", "New Caledonia", "New Zealand", "Nicaragua", "Niger",
            "Nigeria", "Niue", "Norfolk Island", "Northern Ireland", "Norway",
            "Oman", "Pakistan", "Palau", "Panama", "Papua New Guinea",
            "Paraguay", "Peru", "Philippines", "Pitcairn", "Poland",
            "Polynesia", "Portugal", "Puerto Rico", "Qatar", "Reunion",
            "Romania", "Russian Federation", "Rwanda", "Saint Helena", "Saint Kitts",
            "Saint Lucia", "Saint Pierre", "Saint Vincent", "Samoa", "San Marino",
            "Sao Tome and Principe", "Saudi Arabia", "Scotland", "Senegal", "Seychelles",
            "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands",
            "Somalia", "South Africa", "South Georgia", "Spain", "Sri Lanka",
            "Sudan", "Suriname", "Svalbard", "Swaziland", "Sweden",
            "Switzerland", "Syrian Arab Republic", "Taiwan", "Tajikista", "Tanzania",
            "Thailand", "Togo", "Tokelau", "Tonga", "Trinidad and Tobago",
            "Tunisia", "Turkey", "Turkmenistan", "Turks and Caicos Islands", "Tuvalu",
            "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States",
            "Uruguay", "Uzbekistan", "Vanuatu", "Vatican City State", "Venezuela",
            "Vietnam", "Virgin Islands", "Wales", "Western Sahara", "Yemen",
            "Yugoslavia", "Zaire", "Zambia", "Zimbabwe" };

        private static string[] occupations = { 
            "Academic", "Accountant", "Actor", "Architect", "Artist",
            "Business Manager", "Carpenter", "Chief Executive",
            "Cinematographer", "Civil Servant", "Coach", "Composer",
            "Computer programmer", "Cook", "Counsellor", "Doctor",
            "Driver", "Economist", "Editor", "Electrician", "Engineer",
            "Executive Producer", "Fixer", "Graphic Designer", "Hairdresser",
            "Headhunter", "HR - Recruitment", "Information Officer",
            "IT Consultant", "Journalist", "Lawyer / Solicitor", "Lecturer",
            "Librarian", "Mechanic", "Model", "Musician", "Office Worker",
            "Performer", "Photographer", "Presenter", "Producer / Director",
            "Project Manager", "Researcher", "Salesman", "Social Worker",
            "Soldier", "Sportsperson", "Student", "Teacher", "Technical Crew",
            "Technical Writer", "Therapist", "Translator", "Waitress / Waiter",
            "Web designer / author", "Writer", "Other"};

        private static string[] maleNames = { "James", "John", "Robert", "Michael", "William", "David", "Richard", "Charles", "Joseph", "Thomas" };
        private static string[] femaleNames = { "Sophia", "Emily", "Chloe", "Olivia", "Tiffany", "Fiona", "Jessica", "Vivian", "Isabella", "Nicole" };
        private static string[] lastNames = { "Lee", "Smith", "Lam", "Martin", "Brown", "Roy", "Tremblay", "McGraw", "Gagnon", "Wilson", "Clark", "Johnson", "White", "Williams", "Côté", "Taylor", "Campbell", "Anderson", "Chan", "Jones" };
        private static string[] positions = { "Software Developer", "Tester", "Support Technician" };
        private static List<string> teamNames = new List<string> { "Development", "Testing", "Support" };
        private static string[] companyTypes = { "Inc", "Corp", "Ltd", "LLC", "" };
        private static string[] streetTypes = { "St", "Way", "Ave", "Cres", "Rd" };

        private static Random random = new Random();
        private static LipsumGenerator generator = new LipsumGenerator(Lipsums.LoremIpsum, false);

        /// <summary>
        /// Seed the database
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(Entities context)
        {
            base.Seed(context);

            // populate data in a separate thread
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                SeedClients(context);
                SeedTeams(context);
                SeedEmployees(context);
                SeedProjects(context);
                SeedTasks(context);
                System.Diagnostics.Debugger.Break();
            });
        }

        /// <summary>
        /// Add clients to the database
        /// </summary>
        /// <param name="context"></param>
        public static void SeedClients(Entities context)
        {
            for (int i = 0; i < 50; i++)
            {
                var companyName = string.Join(" ", generator.GenerateWords(random.Next(1, 4))).ToTitleCase();
                var companyType = companyTypes[random.Next(companyTypes.Length)];
                var country = countries[random.Next(countries.Length)];

                if (!string.IsNullOrWhiteSpace(companyType))
                    companyName = string.Format("{0} {1}", companyName, companyType);

                context.Clients.Add(new Client
                {
                    Company = companyName,
                    Rate = random.Next(3, 9) * 25,
                    Notes = generator.GenerateLipsumHtml(random.Next(1, 5)),
                    Billing = CreateContact(companyName, country),
                    Mailing = CreateContact(companyName, country),
                    Technical = CreateContact(companyName, country),
                });
            }
            context.SaveChanges();
        }

        private static Contact CreateContact(string companyName, string country)
        {
            var male = (random.Next(0, 2) == 0);
            var firstName = string.Empty;
            var lastName = lastNames[random.Next(0, lastNames.Length)];

            if (male)
                firstName = maleNames[random.Next(0, maleNames.Length)];
            else
                firstName = femaleNames[random.Next(0, femaleNames.Length)];

            return new Contact
            {
                FirstName = firstName,
                Lastname = lastName,
                Email = string.Format("{0}{1}@{2}.com", firstName.First(), lastName, companyName.Split(' ').First()).ToLowerInvariant(),
                Address = new Address
                {
                    Street = string.Format("{0} {1} {2}", random.Next(1000), generator.GenerateWords(1)[0], streetTypes[random.Next(streetTypes.Length)]).ToTitleCase(),
                    City = string.Join(" ", generator.GenerateWords(random.Next(1, 3))).ToTitleCase(),
                    State = string.Join(" ", generator.GenerateWords(random.Next(1, 3))).ToTitleCase(),
                    Country = country,
                    PostalCode = string.Format("{0:00000}", random.Next(100000)),
                },
                Fax = string.Format("1-{0:000}-{1:000}-{2:0000}", random.Next(1000), random.Next(1000), random.Next(10000)),
                Phone = string.Format("1-{0:000}-{1:000}-{2:0000}", random.Next(1000), random.Next(1000), random.Next(10000)),
            };
        }

        /// <summary>
        /// Add teams to the database
        /// </summary>
        /// <param name="context"></param>
        public static void SeedTeams(Entities context)
        {
            foreach (var team in teamNames)
            {
                context.Teams.Add(new Team
                {
                    Name = team,
                    Description = generator.GenerateSentences(1)[0],
                });
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Add employees to the database
        /// </summary>
        /// <param name="context"></param>
        public static void SeedEmployees(Entities context)
        {
            for (int i = 0; i < 20; i++)
            {
                var male = (random.Next(0, 2) == 0);
                var firstName = string.Empty;
                var lastName = lastNames[random.Next(0, lastNames.Length)];

                if (male)
                    firstName = maleNames[random.Next(0, maleNames.Length)];
                else
                    firstName = femaleNames[random.Next(0, femaleNames.Length)];

                var email = string.Format("{0}{1}@prosoftech.com", firstName.First(), lastName).ToLower();
                var teamName = teamNames[random.Next(teamNames.Count)];

                var employee = new Employee
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    HiredOn = DateTime.Today.AddDays(random.Next(1000) * -1),
                    Position = positions[teamNames.IndexOf(teamName)],
                    Teams = new List<Team>(),
                };

                var team = context.Teams.SingleOrDefault(t => t.Name == teamName);
                employee.Teams.Add(team);
                context.Employees.Add(employee);

            }

            context.SaveChanges();
        }

        /// <summary>
        /// Add projects to the database
        /// </summary>
        /// <param name="context"></param>
        public static void SeedProjects(Entities context)
        {
            foreach (var client in context.Clients)
            {
                var max = random.Next(1, 10);
                for (int i = 0; i < max; i++)
                {
                    context.Projects.Add(new Project()
                    {
                        Name = string.Join(" ", generator.GenerateWords(3)).MakeInitialCaps(),
                        Description = generator.GenerateSentences(1)[0],
                        Client = client,
                        Team = context.Teams.ToList().ElementAt(random.Next(teamNames.Count)),
                    });
                }
                context.SaveChanges();
            }

        }

        /// <summary>
        /// Add tasks to the database
        /// </summary>
        /// <param name="context"></param>
        public static void SeedTasks(Entities context)
        {
            var present = new string[] { "Create", "Discuss", "Test", "Troubleshoot", "Debug", "Resolve" };
            foreach (var project in context.Projects)
            {
                var max = random.Next(50);
                for (int i = 0; i < max; i++)
                {
                    var hours = 0.25 * random.Next(1, 100);
                    var startDate = DateTime.Today.AddDays(random.Next(1096) * -1);

                    context.Tasks.Add(new Task
                    {
                        Title = string.Format("{0} {1}", present[random.Next(present.Length)], string.Join(" ", generator.GenerateWords(random.Next(1, 10)))),
                        Description = string.Join(". ", generator.GenerateSentences(random.Next(1, 5))),
                        Project = project,
                        Estimated = new Estimation {
                            StartDate = startDate,
                            DueDate = startDate.AddHours(hours).Date,
                            Hours = hours
                        },
                        State = (State)random.Next(7),
                        CreatedOn = DateTime.Now,
                        CreatedBy = "system",
                    });
                }
                context.SaveChanges();
            }

        }
    }
}