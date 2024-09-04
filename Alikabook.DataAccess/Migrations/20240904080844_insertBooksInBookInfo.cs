using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Alikabook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class insertBooksInBookInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookInfos",
                columns: new[] { "BookId", "Author", "Category", "Date", "Description", "Image", "Price", "Rating", "RatingCount", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, "Eric Matthes", "Basic Programming", new DateTime(2024, 3, 12, 14, 15, 35, 0, DateTimeKind.Unspecified), "This comprehensive guide is perfect for beginners diving into the world of programming with Python. It offers a hands-on, project-based approach, allowing readers to build a solid foundation in Python by working on practical applications and real-world projects.", "Python.jpg", 2007.53m, null, 0, 98, "Python Crash Course" },
                    { 2, "Douglas Crockford", "Basic Programming", new DateTime(2024, 3, 12, 14, 45, 50, 0, DateTimeKind.Unspecified), "Uncover the power and elegance of JavaScript with Douglas Crockford's expert guidance. This book focuses on the essential and efficient aspects of the language, providing a deep understanding of how to write clean, maintainable code in JavaScript.", "Javascript.jpg", 933.83m, null, 0, 95, "JavaScript: The Good Parts" },
                    { 3, "Kathy Sierra and Bert Bates", "Basic Programming", new DateTime(2024, 3, 12, 14, 49, 42, 0, DateTimeKind.Unspecified), "Dive into the world of Java programming with this beginner-friendly and engaging guide. Kathy Sierra and Bert Bates use a unique teaching style, combining humor and interactive exercises to make learning Java enjoyable and effective.", "Java.jpg", 2491.15m, null, 0, 99, "Head First Java" },
                    { 4, "Michael Hartl", "Basic Programming", new DateTime(2024, 3, 12, 14, 53, 45, 0, DateTimeKind.Unspecified), "Embark on a journey to master web development with Ruby on Rails. Michael Hartl's tutorial is project-oriented, guiding readers through practical exercises to create web applications and gain valuable hands-on experience.", "ruby.jpg", 2481.00m, null, 0, 99, "Ruby on Rails Tutorial: Learn Web Development with Rails" },
                    { 5, "Zed A. Shaw", "Basic Programming", new DateTime(2024, 3, 12, 14, 55, 5, 0, DateTimeKind.Unspecified), "For those who prefer a challenging yet effective learning approach, Zed A. Shaw's book offers a unique method for mastering Python. Emphasizing practice and repetition, this resource ensures a solid grasp of Python fundamentals.", "python2.jpg", 1809.00m, null, 0, 99, "Learn Python the Hard Way" },
                    { 6, "Marijn Haverbeke", "Basic Programming", new DateTime(2024, 3, 12, 14, 57, 34, 0, DateTimeKind.Unspecified), "Elevate your JavaScript skills with this comprehensive guide. Marijn Haverbeke explores JavaScript from the ground up, covering both basic concepts and advanced topics, making it an essential resource for aspiring web developers.", "Javascript2.jpg", 1245.29m, null, 0, 99, "Eloquent JavaScript" },
                    { 7, "Jon Duckett", "Basic Programming", new DateTime(2024, 3, 12, 14, 58, 58, 0, DateTimeKind.Unspecified), "Ideal for beginners in web development, Jon Duckett's book is a visually appealing guide to HTML and CSS. The book combines clear explanations with beautiful illustrations, making it easy for readers to grasp the essentials of web design.", "html&css.jpg", 961.01m, null, 0, 99, "HTML and CSS: Design and Build Websites" },
                    { 8, "Robert C. Martin", "Advance Programming", new DateTime(2024, 3, 12, 15, 8, 52, 0, DateTimeKind.Unspecified), "Dive deep into the art of writing clean, maintainable code with Robert C. Martin. This handbook provides practical advice, principles, and best practices to elevate your coding skills and create software that stands the test of time.", "cleancode.jpg", 2538.16m, null, 0, 99, "Clean Code: A Handbook of Agile Software Craftsmanship" },
                    { 9, "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides", "Advance Programming", new DateTime(2024, 3, 12, 15, 45, 43, 0, DateTimeKind.Unspecified), "Considered a classic in software development literature, this book introduces essential design patterns that contribute to building scalable and maintainable software systems. Learn how to apply proven solutions to common design challenges.", "designpatterns.jpg", 1330.80m, null, 0, 99, "Design Patterns: Elements of Reusable Object-Oriented Software" },
                    { 10, "Dave Thomas and Andy Hunt", "Advance Programming", new DateTime(2024, 3, 12, 15, 47, 21, 0, DateTimeKind.Unspecified), "A pragmatic approach to mastering the art of programming, this book offers a collection of tips, techniques, and best practices. Dave Thomas and Andy Hunt guide you through real-world scenarios, providing valuable insights for developers at any level.", "pragmatic.jpg", 2264.63m, null, 0, 99, "The Pragmatic Programmer: Your Journey to Mastery" },
                    { 11, "Thomas H. Cormen, Charles E. L", "Advance Programming", new DateTime(2024, 3, 12, 15, 50, 2, 0, DateTimeKind.Unspecified), "This comprehensive textbook is a cornerstone for understanding algorithms. It covers a wide range of algorithms and their analysis, making it an invaluable resource for computer science students, researchers, and professionals.", "algorithms.jpg", 4432.16m, null, 0, 98, "Introduction to Algorithms" },
                    { 12, "Joshua Bloch", "Advance Programming", new DateTime(2024, 3, 12, 15, 51, 26, 0, DateTimeKind.Unspecified), "A former Google engineer, shares his insights on writing effective and efficient Java code. This book is a must-read for Java developers who want to enhance their skills and create robust, high-performance applications.", "effectivejava.jpg", 2317.14m, null, 0, 99, "Effective Java" },
                    { 13, "Martin Fowler", "Advance Programming", new DateTime(2024, 3, 12, 15, 53, 8, 0, DateTimeKind.Unspecified), "Explore the art of refactoring with Martin Fowler as your guide. This book provides practical techniques for improving the structure and maintainability of existing codebases, making it an essential read for developers working on legacy projects.", "refractoring.jpg", 2655.05m, null, 0, 99, "Refactoring: Improving the Design of Existing Code" },
                    { 14, "Brian Goetz", "Advance Programming", new DateTime(2024, 3, 12, 15, 54, 27, 0, DateTimeKind.Unspecified), "Delve into the complexities of concurrent programming in Java with Brian Goetz's authoritative guide. Learn how to write safe and scalable concurrent code, addressing the challenges of multi-threaded applications.", "javaconcurrency.jpg", 2296.99m, null, 0, 95, "Concurrency in Practice" },
                    { 15, "Steve McConnell", "Advance Programming", new DateTime(2024, 3, 12, 15, 55, 47, 0, DateTimeKind.Unspecified), "Steve McConnell's comprehensive guide covers the entire software development process, from initial design to testing and maintenance. It's a valuable resource for developers aiming to enhance their skills and produce high-quality software.", "codecomplete.jpg", 2131.75m, null, 0, 98, "Code Complete: A Practical Handbook of Software Construction" },
                    { 16, "Frederick P. Brooks Jr.", "Advance Programming", new DateTime(2024, 3, 12, 15, 57, 18, 0, DateTimeKind.Unspecified), "Frederick P. Brooks Jr. shares timeless insights on software project management, addressing the challenges of large-scale development. This classic book remains relevant for understanding the complexities of team dynamics and project planning.", "mythicalman.jpg", 2000.99m, null, 0, 99, "The Mythical Man-Month: Essays on Software Engineering" },
                    { 17, "Eric Evans", "Advance Programming", new DateTime(2024, 3, 12, 15, 58, 48, 0, DateTimeKind.Unspecified), "Eric Evans introduces domain-driven design as a strategic approach to building complex software systems. This book is a valuable resource for developers and architects seeking to create software that aligns with business goals and efficiently manages complexity.", "domaindriven.jpg", 3319.25m, null, 0, 95, "Domain-Driven Design: Tackling Complexity in the Heart of Software" },
                    { 18, "Peter Thiel and Blake Masters", "Business", new DateTime(2024, 3, 12, 16, 2, 33, 0, DateTimeKind.Unspecified), "Venture into the mind of entrepreneur and investor Peter Thiel as he shares his unconventional insights on innovation, monopolies, and creating groundbreaking startups.", "zerotoone.jpg", 935.75m, null, 0, 99, "Zero to One: Notes on Startups, or How to Build the Future" },
                    { 19, "Daniel Kahneman", "Business", new DateTime(2024, 3, 12, 16, 3, 58, 0, DateTimeKind.Unspecified), "Nobel laureate Daniel Kahneman explores the two systems of thinking that influence decision-making. Gain a deeper understanding of cognitive biases and how they impact business decisions and human behavior.", "thinkingfastslow.jpg", 1019.00m, null, 0, 98, "Thinking, Fast and Slow" },
                    { 20, "Katie Delahaye Paine", "Business", new DateTime(2024, 3, 12, 16, 6, 50, 0, DateTimeKind.Unspecified), "Katie Delahaye Paine provides practical insights into measuring key metrics for business success. Understand how to leverage online tools to gain a deeper understanding of customers, social media, and overall engagement.", "measurewhat.jpg", 954.10m, null, 0, 98, "Measure What Matters: Online Tools For Understanding Customers, Social Media, Engagement, and Key Relationships" },
                    { 21, "W. Chan Kim and Renée Mauborgn", "Business", new DateTime(2024, 3, 12, 16, 9, 45, 0, DateTimeKind.Unspecified), "Explore the concept of creating uncontested market space and redefining industry boundaries. W. Chan Kim and Renée Mauborgne present a strategic framework for businesses to innovate and thrive in new market spaces.", "blueocean.jpg", 979.36m, null, 0, 99, "Blue Ocean Strategy: How to Create Uncontested Market Space and Make C" },
                    { 22, "Jake Knapp", "Business", new DateTime(2024, 3, 12, 16, 12, 45, 0, DateTimeKind.Unspecified), "Jake Knapp introduces the concept of design sprints – a time-constrained process for solving big problems and testing new ideas. This book is a practical guide for teams looking to streamline innovation.", "sprint.jpg", 881.50m, null, 0, 98, "Sprint: How to Solve Big Problems and Test New Ideas in Just Five Days" },
                    { 23, "Ben Horowitz", "Business", new DateTime(2024, 3, 12, 16, 13, 41, 0, DateTimeKind.Unspecified), "Ben Horowitz shares his experiences and insights as a successful entrepreneur and venture capitalist. This candid and practical guide addresses the challenges of building and managing a business in the face of uncertainty and adversity.", "thehardthing.jpg", 941.00m, null, 0, 96, "The Hard Thing About Hard Things: Building a Business When There Are No Easy Answers" },
                    { 24, "Tony Fadell", "Business", new DateTime(2024, 4, 24, 15, 11, 19, 0, DateTimeKind.Unspecified), "Written for anyone who wants to grow at work—from young grads navigating their first jobs to CEOs deciding whether to sell their company—Build is full of personal stories, practical advice and fascinating insights into some of the most impactful products and people of the 20th century.", "build.jpg", 1029.16m, null, 0, 96, "Build: An Unorthodox Guide to Making Things Worth Making" },
                    { 25, "Charles Duhigg", "Business", new DateTime(2024, 4, 24, 15, 13, 27, 0, DateTimeKind.Unspecified), "In The Power of Habit, award-winning business reporter Charles Duhigg takes us to the thrilling edge of scientific discoveries that explain why habits exist and how they can be changed. Distilling vast amounts of information into engrossing narratives that take us from the boardrooms of Procter & Gamble to the sidelines of the NFL to the front lines of the civil rights movement, Duhigg presents a whole new understanding of human nature and its potential. At its core, The Power of Habit contains an exhilarating argument: The key to exercising regularly, losing weight, being more productive, and achieving success is understanding how habits work. As Duhigg shows, by harnessing this new science, we can transform our businesses, our communities, and our lives.", "habit.jpg", 921.01m, null, 0, 97, "The Power of Habit: Why We Do What We Do in Life and Business" },
                    { 26, "Sima Dimitrijev and Maryann Karinch", "Business", new DateTime(2024, 5, 8, 12, 4, 29, 0, DateTimeKind.Unspecified), "Everything in nature evolves by trial, error, and success. At the fundamental level, this means that the rigid laws of physics don't rule nature. At the level of your thinking, this means that no established one-size-fits-all science should inhibit your free-will decisions to try, fail, and succeed. As a guide to success by strategic decision making, this book will support your skeptical thinking and propensity for prudent use of expert advice.", "trial.jpg", 904.31m, null, 0, 99, "Trial, Error, and Success: 10 Insights into Realistic Knowledge, Thinking, and Emotional Intelligence" },
                    { 27, "Patrick Bet-David", "Business", new DateTime(2024, 5, 8, 12, 28, 20, 0, DateTimeKind.Unspecified), "Both successful entrepreneurs and chess grandmasters have the vision to look at the pieces in front of them and anticipate their next five moves. In this book, Patrick Bet-David translates this skill into a valuable methodology that applies to high performers at all levels of business. Whether you feel like you’ve hit a wall, lost your fire, or are looking for innovative strategies to take your business to the next level, Your Next Five Moves has the answers.", "fivemoves.jpg", 1228.26m, null, 0, 99, "Your Next Five Moves: Master the Art of Business Strategy" },
                    { 28, "Josh Kaufman", "Business", new DateTime(2024, 5, 8, 12, 29, 55, 0, DateTimeKind.Unspecified), "Getting an MBA is an expensive choice-one almost impossible to justify regardless of the state of the economy. Even the elite schools like Harvard and Wharton offer outdated, assembly-line programs that teach you more about PowerPoint presentations and unnecessary financial models than what it takes to run a real business. You can get better results (and save hundreds of thousands of dollars) by skipping B-school altogether.", "personal.jpg", 1716.48m, null, 0, 99, "The Personal MBA: Master the Art of Business" },
                    { 29, "Morgan Housel", "Business", new DateTime(2024, 5, 8, 12, 31, 25, 0, DateTimeKind.Unspecified), "Money - investing, personal finance, and business decisions - is typically taught as a math-based field, where data and formulas tell us exactly what to do. But in the real world people don’t make financial decisions on a spreadsheet. They make them at the dinner table, or in a meeting room, where personal history, your own unique view of the world, ego, pride, marketing, and odd incentives are scrambled together.", "psychology.jpg", 1172.75m, null, 0, 97, "The Psychology of Money: Timeless Lessons on Wealth, Greed, and Happiness" },
                    { 30, "Robert Greene", "Business", new DateTime(2024, 5, 8, 12, 33, 6, 0, DateTimeKind.Unspecified), "Some laws teach the need for prudence (“Law 1: Never Outshine the Master”), others teach the value of confidence (“Law 28: Enter Action with Boldness”), and many recommend absolute self-preservation (“Law 15: Crush Your Enemy Totally”). Every law, though, has one thing in common: an interest in total domination. In a bold and arresting two-color package, The 48 Laws of Power is ideal whether your aim is conquest, self-defense, or simply to understand the rules of the game.", "lawsofpower.jpg", 1458.92m, null, 0, 99, "The 48 Laws of Power" },
                    { 31, "Gino Wickman", "Business", new DateTime(2024, 5, 8, 12, 48, 37, 0, DateTimeKind.Unspecified), "Do you have a grip on your business, or does your business have a grip on you?\r\n\r\nAll entrepreneurs and business leaders face similar frustrations—personnel conflict, profit woes, and inadequate growth. Decisions never seem to get made, or, once made, fail to be properly implemented. But there is a solution. It's not complicated or theoretical.The Entrepreneurial Operating System® is a practical method for achieving the business success you have always envisioned. More than 170,000 companies have discovered what EOS can do.", "traction.jpg", 779.54m, null, 0, 99, "Traction: Get a Grip on Your Business" },
                    { 32, "Allan Dib", "Business", new DateTime(2024, 5, 8, 12, 50, 4, 0, DateTimeKind.Unspecified), "To build a successful business, you need to stop doing random acts of marketing and start following a reliable plan for rapid business growth. Traditionally, creating a marketing plan has been a difficult and time-consuming process, which is why it often doesn’t get done.\r\n\r\nIn The 1-Page Marketing Plan, serial entrepreneur and rebellious marketer Allan Dib reveals a marketing implementation breakthrough that makes creating a marketing plan simple and fast. It’s literally a single page, divided up into nine squares. With it, you’ll be able to map out your own sophisticated marketing plan and go from zero to marketing hero.", "marketingplan.jpg", 1236.28m, null, 0, 99, "The 1-Page Marketing Plan: Get New Customers, Make More Money, And Stand out From The Crowd" },
                    { 33, "Hubert Joly and Caroline Lambert", "Business", new DateTime(2024, 5, 8, 12, 55, 7, 0, DateTimeKind.Unspecified), "In The Heart of Business, Joly shares the philosophy behind the resurgence of Best Buy: pursue a noble purpose, put people at the center of the business, create an environment where every employee can blossom, and treat profit as an outcome, not the goal.This approach is easy to understand, but putting it into practice is not so easy. It requires radically rethinking how we view work, how we define companies, how we motivate, and how we lead. In this book Joly shares memorable stories, lessons, and practical advice, all drawn from his own personal transformation from a hard-charging McKinsey consultant to a leader who believes in human magic.", "theheartofbusiness.jpg", 960.98m, null, 0, 99, "The Heart of Business: Leadership Principles for the Next Era of Capitalism" },
                    { 34, "Napoleon Hill", "Business", new DateTime(2024, 5, 8, 12, 59, 0, 0, DateTimeKind.Unspecified), "Think and Grow Rich has been called the “Granddaddy of All Motivational Literature.” It was the first book to boldly ask, “What makes a winner?” The man who asked and listened for the answer, Napoleon Hill, is now counted in the top ranks of the world's winners himself. The most famous of all teachers of success spent “a fortune and the better part of a lifetime of effort” to produce the “Law of Success” philosophy that forms the basis of his books and that is so powerfully summarized in this one.", "thinkandgrowrich.jpg", 566.63m, null, 0, 99, "Think and Grow Rich: The Landmark Bestseller Now Revised and Updated for the 21st Century (Think and Grow Rich Series)" },
                    { 35, "Eric Tyson and Bob Nelson", "Business", new DateTime(2024, 5, 8, 13, 2, 6, 0, DateTimeKind.Unspecified), "All the essential information in one place\r\nStarting a Business All-in-One For Dummies, 3rd Edition is a treasure trove of useful information for new and would-be business owners. With content compiled from over ten best-selling For Dummies books, this guide will help with every part of starting your own business—from legal considerations to business plans, bookkeeping, and beyond. Whether you want to open a franchise, turn your crafting hobby into a money-maker, or kick off the next megahit startup, everything you need can be found inside this easy-to-use guide. This book covers the foundations of accounting, marketing, hiring, and achieving success in the first year of business in any industry. You'll find toolkits for doing all the paperwork, plus expert tips for how to make it work, even when the going is rough.", "startingabusiness.jpg", 1373.07m, null, 0, 99, "Starting a Business All-in-One For Dummies 3rd Edition" },
                    { 36, "Ryan Daniel Moran", "Business", new DateTime(2024, 5, 8, 13, 3, 19, 0, DateTimeKind.Unspecified), "The word \"entrepreneur\" is today's favorite buzzword, and any aspiring business owner has likely encountered an overwhelming number of so-called \"easy paths to success.\" \r\n\r\nThe truth is that building a real, profitable, sustainable business requires thousands of hours of commitment, grit, and hard work. It's no wonder why more than half of new businesses close within six years of opening, and fewer than 5 percent will ever earn more than $1 million annually. 12 Months to $1 Million condenses the startup phase into one fast-paced year that has helped hundreds of new entrepreneurs hit the million-dollar level by using an exclusive and foolproof formula.", "12monthtsto1million.jpg", 1201.36m, null, 0, 99, "12 Months to $1 Million: How to Pick a Winning Product, Build a Real Business, and Become a Seven-Figure Entrepreneur" },
                    { 37, "Tycho Press", "Business", new DateTime(2024, 5, 8, 13, 5, 15, 0, DateTimeKind.Unspecified), "Owning and running a small business can be complicated. On top of developing, marketing and selling your product or service, you've got to be prepared to handle the money thats coming in, pay your employees, track expenditures, consider your stock options, and much more.\r\n\r\nAccounting for Small Business Owners covers the entire process of establishing solid accounting for your business and common financial scenarios, and will show you how to:\r\n-Set up and run your business\r\n-Manage and sell your product or service\r\n-Perform a month-end balancing of accounts\r\n", "accountingforsmallbusinessowners.jpg", 1288.93m, null, 0, 99, "Accounting for Small Business Owners" },
                    { 38, "Finance Knights Publications", "Business", new DateTime(2024, 5, 8, 13, 6, 53, 0, DateTimeKind.Unspecified), "Imagine a life where dissatisfaction with your current job and the desire for higher earnings transform into a fulfilling journey of entrepreneurship.\r\nEnvision no longer wasting your time and talent under the unappreciative eye of an employer, but instead directing those valuable assets towards building your dream business.\r\nThis is a life where your aspirations for success and autonomy become a vibrant reality.\"\r\n\r\nIf the thought of becoming your own boss, following your passions, and being in control of your life excites you, then the best thing for you is to start your own business! 💡", "dummiesguide.jpg", 1486.39m, null, 0, 99, "Dummies Guide to Starting Your Own Business: The Simplest, Step-by-Step Guide to Launch a Successful Small Business in Record Time – Begin Your Entrep" },
                    { 39, "Steven Bartlett", "Business", new DateTime(2024, 5, 8, 13, 9, 30, 0, DateTimeKind.Unspecified), "At the very heart of all the success and failure I've been exposed to - both my own entrepreneurial journey and through the thousands of interviews I’ve conducted on my chart-topping podcast - are a set of principles that ensure excellence.\r\n\r\nThese fundamental laws underpinned my meteoric rise, and they will fuel yours too, whether you want to build something great or become someone great. The laws are rooted in psychology and behavioral science, in my own experiences, and those of the world's most successful entrepreneurs, entertainers, artists, writers, and athletes, who I’ve interviewed on my podcast.\r\n\r\nThese laws will stand the test of time and will help anyone master their life and unleash their potential, no matter the field.", "thediaryofceo.jpg", 1098.34m, null, 0, 99, "The Diary of a CEO: The 33 Laws of Business and Life" },
                    { 40, "Noah Kagan and Tahl Raz", "Business", new DateTime(2024, 5, 8, 13, 10, 48, 0, DateTimeKind.Unspecified), "AN INSTANT NEW YORK TIMES BESTSELLER\r\n\r\nThe founder and CEO of AppSumo.com, Noah Kagan, knows how to launch a seven-figure business in a single weekend—and he’s done it seven times. Million Dollar Weekend will show you how.\r\n\r\nNow is the best time in history for entrepreneurship. More than ever, the world needs new businesses and it’s cheaper than ever to create them.\r\n\r\nAnd, let’s be frank: most day jobs suck. People spend too much time doing too much work for too little money—and they know it. They want out.", "milliondollarweekend.jpg", 1042.25m, null, 0, 99, "Million Dollar Weekend: The Surprisingly Simple Way to Launch a 7-Figure Business in 48 Hours" },
                    { 41, "Thomas Erikson", "Business", new DateTime(2024, 5, 8, 13, 12, 29, 0, DateTimeKind.Unspecified), "Do you ever think you’re the only one making any sense? Or tried to reason with your partner with disastrous results? Do long, rambling answers drive you crazy? Or does your colleague’s abrasive manner rub you the wrong way?\r\n\r\nYou are not alone. After a disastrous meeting with a highly successful entrepreneur, who was genuinely convinced he was ‘surrounded by idiots’, communication expert and bestselling author, Thomas Erikson dedicated himself to understanding how people function and why we often struggle to connect with certain types of people.\r\n\r\nSurrounded by Idiots is an international phenomenon, selling over 1.5 million copies worldwide. It offers a simple, yet ground-breaking method for assessing the personalities of people we communicate with – in and out of the office – based on four personality types (Red, Blue, Green and Yellow), and provides insights into how we can adjust the way we speak and share information.", "surroundedbyidiots.jpg", 951.25m, null, 0, 99, "Surrounded by Idiots: The Four Types of Human Behavior and How to Effectively Communicate with Each in Business (and in Life) (The Surrounded by Idiot" },
                    { 42, "Benjamin Graham and Jason Zweig", "Business", new DateTime(2024, 5, 8, 13, 13, 57, 0, DateTimeKind.Unspecified), "This classic text is annotated to update Graham's timeless wisdom for today's market conditions...\r\nThe greatest investment advisor of the twentieth century, Benjamin Graham, taught and inspired people worldwide. Graham's philosophy of \"value investing\" -- which shields investors from substantial error and teaches them to develop long-term strategies -- has made The Intelligent Investor the stock market bible ever since its original publication in 1949.\r\n\r\nOver the years, market developments have proven the wisdom of Graham's strategies. While preserving the integrity of Graham's original text, this revised edition includes updated commentary by noted financial journalist Jason Zweig, whose perspective incorporates the realities of today's market, draws parallels between Graham's examples and today's financial headlines, and gives readers a more thorough understanding of how to apply Graham's principles.", "theintelligentinvestor.jpg", 1029.09m, null, 0, 99, "The Intelligent Investor Rev Ed.: The Definitive Book on Value Investing" },
                    { 43, "Al Sweigart", "Basic Programming", new DateTime(2024, 5, 8, 13, 25, 10, 0, DateTimeKind.Unspecified), "You've completed a basic Python programming tutorial or finished Al Sweigart's bestseller, Automate the Boring Stuff with Python. What's the next step toward becoming a capable, confident software developer?\r\n\r\nWelcome to Beyond the Basic Stuff with Python. More than a mere collection of advanced syntax and masterful tips for writing clean code, you'll learn how to advance your Python programming skills by using the command line and other professional tools like code formatters, type checkers, linters, and version control. Sweigart takes you through best practices for setting up your development environment, naming variables, and improving readability, then tackles documentation, organization and performance measurement, as well as object-oriented design and the Big-O algorithm analysis commonly used in coding interviews. The skills you learn will boost your ability to program--not just in Python but in any language.", "beyondthebasicstuffwithpython.jpg", 1461.21m, null, 0, 99, "Beyond the Basic Stuff with Python: Best Practices for Writing Clean Code" },
                    { 44, "Jack C. Stanley Erik D. Gross and The Tech Academy", "Basic Programming", new DateTime(2024, 5, 8, 13, 27, 42, 0, DateTimeKind.Unspecified), "Newly updated for 2023! Want to learn how to code in less than a day? This book was designed for absolute beginners – you don’t need any prior experience or knowledge. Written by the Co-Founders of The Tech Academy (learncodinganywhere.com), this book serves as a perfect introduction to computer programming for anyone. This book utilizes Small Basic, a computer programming language created by Microsoft for beginners and educational purposes. Learn Coding Basics in Hours with Small Basic is easy and simple, and it can be completed fast.The Tech Academy is a technology school that specializes in coding bootcamps. You can enroll online and study their programs from anywhere in the world. For more information about The Tech Academy, their books and training programs, visit: www.learncodinganywhere.com.", "learncodingbasicsinhours.jpg", 285.60m, null, 0, 99, "Learn Coding Basics in Hours with Small Basic" },
                    { 45, "Nathan Clark", "Basic Programming", new DateTime(2024, 5, 8, 13, 28, 49, 0, DateTimeKind.Unspecified), "★ Java Made Easy – a Step-by-Step Guide for Beginners ★Learning a programming language can seem like a daunting task. You may have looked at coding in the past, and felt it was too complicated and confusing. This comprehensive beginner’s guide will take you step by step through learning one of the best programming languages out there. In a matter of no time, you will be writing code like a professional.Java is one of the most popular and widely used programming languages available. Most of the modern applications built around the world, including server side and business logic components, are made from the Java programming language. Its portability and ease of use has ensured that it is a favourite among novices and seasoned developers alike.", "javaprogrammingbasicforabsolutebeginners.jpg", 937.51m, null, 0, 99, "Java: Programming Basics for Absolute Beginners (Step-By-Step Java)" },
                    { 46, "James Foxall", "Basic Programming", new DateTime(2024, 5, 8, 13, 30, 4, 0, DateTimeKind.Unspecified), "In just 24 sessions of one hour or less, you’ll learn how to build complete, reliable, and modern Windows applications with Microsoft® Visual Basic® 2015. Using a straightforward, step-by-step approach, each lesson builds on what you’ve already learned, giving you a strong foundation for success with every aspect of VB 2015 development.\r\n\r\nNotes present interesting pieces of information.\r\n\r\nTips offer advice or teach an easier way to do something.\r\n\r\nCautions advise you about potential problems and help you steer clear of disaster.", "visualbasic2015in24hours.jpg", 1439.46m, null, 0, 99, "Visual Basic 2015 in 24 Hours, Sams Teach Yourself 1st Edition" },
                    { 47, "Jesse Liberty", "Basic Programming", new DateTime(2024, 5, 8, 13, 31, 56, 0, DateTimeKind.Unspecified), "Most Visual Basic .NET books are written for experienced object-oriented programmers, but many programmers jumping on the .NET bandwagon are coming from non-object-oriented languages, such as Visual Basic 6.0 or from script programming, such as JavaScript. These programmers, and those who are adopting VB.NET as their first programming language, have been out of luck when it comes to finding a high-quality introduction to the language that helps them get started. That's why Jesse Liberty, author of the best-selling books Programming C# and Programming ASP.NET, has written an entry-level guide to Visual Basic .NET. Written in a warm and friendly manner, this book assumes no prior programming experience, and provides an easy introduction to Microsoft's most popular .NET language.", "learningvisualbasicdotnet.jpg", 1344.45m, null, 0, 99, "Learning Visual Basic .NET: Introducing the Language, .NET Programming & Object Oriented Software Development 1st Edition" },
                    { 48, "Joseph Connor", "Basic Programming", new DateTime(2024, 5, 8, 13, 33, 28, 0, DateTimeKind.Unspecified), "Learn three of the most important programming languages: Java, SQL, and C++.\r\n\r\nWith Programming: Computer Programming for Beginners Learn the Basics of Java, SQL & C++ - Revised 2018 Edition, by Joseph Conner, you'll learn the coding skills you need to build a broad range of apps for PCs and mobile devices. This revised 2018 Edition, is fully updated with all the current information. It's not just a great place for beginners to get started, it's also a handy reference and useful tool for experienced programmers who haven't used Java, SQL, or C++ for a few years.\r\nYou get everything beginners, and pros need including:", "computerprogrammingforbeginners.jpg", 1144.13m, null, 0, 99, "Programming: Computer Programming for Beginners: Learn the Basics of Java, SQL & C++ (Coding, C Programming, Java Programming, SQL Programming, JavaSc" },
                    { 49, "Julitta Korol", "Basic Programming", new DateTime(2024, 5, 8, 13, 35, 9, 0, DateTimeKind.Unspecified), "Updated for Access 2016 and based on the bestselling editions from previous versions, Microsoft Access 2016 Programming by Example with VBA, XML and ASP is a practical how-to book on Access programming, suitable for readers already proficient with the Access user interface (UI). If you are looking to automate Access routine tasks, this book will progressively introduce you to programming concepts via numerous illustrated hands-on exercises. More advanced topics are demonstrated via custom projects. Includes a comprehensive disc with source code, supplemental files, and color screen captures (Also available from the publisher for download by writing to info@merclearning.com). With concise and straightforward explanations, you learn how to write and test your programming code with the built-in Visual Basic Editor; understand and use common VBA programming structures such as conditions, loops, arrays, and collections; code a \"message box\"; reprogram characteristics of a database; and use various techniques to query and manipulate your Access .mdb and .accdb databases. The book shows you how you can build database solutions with Data Access Objects (DAO) and ActiveX Data Objects (ADO); define database objects and manage database security with SQL; enhance and alter the way users interact with database applications with Ribbon customizations and event programming in forms and reports. You also learn how to program Microsoft Access databases for Internet access with Active Server Pages (Classic ASP), HTML, and XML.", "microsoftacess2016programming.jpg", 3004.84m, null, 0, 99, "Microsoft Access 2016 Programming By Example: with VBA, XML, and ASP Pap/Cdr Edition" },
                    { 50, "Steven Roman, Ron Petrusha and Paul Lomax", "Basic Programming", new DateTime(2024, 5, 8, 13, 38, 24, 0, DateTimeKind.Unspecified), "Visual Basic .NET is a radically new version of Microsoft Visual Basic, the world's most widely used rapid application development (RAD) package. Whether you are just beginning application development with Visual Basic .NET or are already deep in code, you will appreciate just how easy and valuable the VB.NET Language Pocket Reference is.VB.NET Language Pocket Reference contains a concise description of all language elements by category. These include language elements implemented by the Visual Basic compiler, as well as all procedures and functions implemented in the Microsoft.VisualBasic namespace. Use it anytime you want to look up those pesky details of Visual Basic syntax or usage. With concise detail and no fluff, you'll want to take this book everywhere.", "vbnetlanguagepocketreference.jpg", 514.54m, null, 0, 99, "VB.NET Language Pocket Reference: Syntax and Descriptions of the Visual Basic .NET Language 1st Edition" },
                    { 51, "Mark Clifferland", "Basic Programming", new DateTime(2024, 5, 8, 13, 40, 45, 0, DateTimeKind.Unspecified), "Get started on your dream software development or data science career with Python Programming for Beginners—Simplified, real-world Python Programming insights, exercises, examples, and more! Master Python in just 7 days!", "pythonprogrammingforbegginers2024.jpg", 795.57m, null, 0, 99, "Python Programming for Beginners: A Complete Step-by-Step Guide with Practical Exercises, Coding Tips, and Career-Boosting Strategies — Master Python " },
                    { 52, "Philip Conrod and Lou Tylee", "Basic Programming", new DateTime(2024, 5, 8, 13, 44, 35, 0, DateTimeKind.Unspecified), "LEARN VISUAL BASIC is a comprehensive step-by-step programming tutorial covering object-oriented programming, the Visual Basic integrated development environment, building and distributing Windows applications using the Windows Installer, exception handling, sequential file access, graphics, multimedia, advanced topics such as web access, printing, and HTML help system authoring. The tutorial also introduces database applications (using ADO .NET) and web applications (using ASP.NET). This curriculum has been used in college and universities for over two decades. It is also used as a college prep advanced placement course for high school students.", "learnvisualbasic2019edition.jpg", 4862.11m, null, 0, 99, "Learn Visual Basic 2019 Edition: A Step-By-Step Programming Tutorial 16th 2019 ed. Edition" },
                    { 53, "Jay Thompson", "Basic Programming", new DateTime(2024, 5, 8, 13, 46, 11, 0, DateTimeKind.Unspecified), "Enter the dynamic world of Swift, Apple's innovative programming language that has taken the coding community by storm. Swift is renowned for its speed, clarity, and versatility, making it the perfect choice for anyone eager to dive into the exciting realm of app development.\r\n\r\nUnlock your potential as a Swift developer with our step-by-step guide tailored for beginners. From understanding variables and loops to mastering functions and classes, this book is your passport to becoming a proficient Swift programmer. Experience the thrill of crafting your code and witness your app ideas come to life.", "swiftprogrammingforbeginners.jpg", 571.78m, null, 0, 99, "SWIFT PROGRAMMING FOR BEGINNERS: A Step-By-Step Guide To Learning The Basics Of Swift, From Variables And Loops To Functions And Classes" },
                    { 54, "Geir Olsen, Damon Allison and James Speer", "Basic Programming", new DateTime(2024, 5, 8, 13, 47, 40, 0, DateTimeKind.Unspecified), "Since the announcement of Visual Basic .NET, a lot has been made of its powerful object-oriented features. However, very little discussion has been devoted to the practice of object-oriented programming at its most fundamental level―that is, building classes. The truth is, whatever code you write in Visual Basic .NET, you are writing classes that fall within the class hierarchy of the .NET Framework. Visual Basic .NET Class Design Handbook was conceived as a guide to help you design these classes effectively, by looking at what control you have over your classes and how Visual Basic .NET turns your class definitions into executable code.", "visualbasicdotnetclassdesignhandbook.jpg", 1824.65m, null, 0, 99, "Visual Basic .NET Class Design Handbook: Coding Effective Classes" },
                    { 55, "Philip Conrod and Lou Tylee", "Basic Programming", new DateTime(2024, 5, 8, 13, 51, 25, 0, DateTimeKind.Unspecified), "VISUAL BASIC AND DATABASES is a step-by-step database programming tutorial that provides a detailed introduction to using Visual Basic for accessing and maintaining databases for desktop applications. Topics covered include: database structure, database design, Visual Basic project building, ADO .NET data objects (connection, data adapter, command, data table), data bound controls, proper interface design, structured query language (SQL), creating databases using Access, SQL Server and ADOX, and database reports. Actual projects developed include a books tracking system, a sales invoicing program, a home inventory system and a daily weather monitor.\r\n\r\nVISUAL BASIC AND DATABASES is presented using a combination of over 850 pages of self-study notes and actual Visual Basic examples. No previous experience working with databases is presumed. It is assumed, however, that users of the product are familiar with the Visual Basic environment and the steps involved in building a Visual Basic application (such training can be gained from our LEARN VISUAL BASIC course).", "visualbasicanddatabases2019.jpg", 4862.11m, null, 0, 99, "Visual Basic and Databases 2019 Edition: A Step-By-Step Database Programming Tutorial 16th 2019 ed. Edition" },
                    { 56, "Terry Felke-Morris", "Basic Programming", new DateTime(2024, 5, 8, 13, 52, 47, 0, DateTimeKind.Unspecified), "For introductory courses in Web Design\n\nProvide a strong foundation for web design and web development\n\nBasics of Web Design: HTML5, is a foundational introduction to beginning web design and web development. The text provides a balance of “hard” skills such as HTML 5, CSS, and “soft” skills such as web design and publishing to the Web, giving students a well-rounded foundation as they pursue careers as web professionals. Students will leave an introductory design course with the tools they need to build their skills in the fields of web design, web graphics, and web development.\n\nThe 5th Edition features a major change from previous edition. Although classic page layout methods using CSS float are still introduced, there is a new emphasis on Responsive Page Layout utilizing the new CSS Flexible Box Layout (Flexbox) and CSS Grid Layout techniques. Therefore, the new 5th Edition features new content, updated topics, hands-on practice exercises, and case studies.", "basicofwebdesignhtmlandcss.jpg", 7630.57m, null, 0, 99, "Basics of Web Design: HTML5 & CSS 5th Edition" },
                    { 57, "Corinne Hoisington", "Basic Programming", new DateTime(2024, 5, 8, 13, 54, 33, 0, DateTimeKind.Unspecified), "Prepare for the number one job in today's tech sector -- app development -- as you learn the essentials of Microsoft Visual Basic. The step-by-step, visual approach and professional programming opportunities in MICROSOFT VISUAL BASIC 2017 FOR WINDOWS APPLICATIONS: INTRODUCTORY lay the initial groundwork for a successful degree in IT programming. You gain a fundamental understanding of Windows programming for 2017. This edition's innovative approach blends visual demonstrations of professional-quality programs with in-depth discussions of today's most effective programming concepts and techniques. You practice what you've learned with numerous real programming assignments in each chapter that equip you to program independently at your best.", "microsoftvisualbasic2017forwindows.jpg", 1635.20m, null, 0, 99, "Microsoft Visual Basic 2017 for Windows, Web, and Database Applications: Comprehensive (Shelly Cashman) 1st Edition" },
                    { 58, "David Schneider", "Basic Programming", new DateTime(2024, 5, 8, 13, 55, 40, 0, DateTimeKind.Unspecified), "From the Beginning: A Comprehensive Introduction to Visual Basic Programming\n\nSchneider’s Introduction to Programming Using Visual Basic, Tenth Edition brings continued refinement to a textbook praised in the industry since 1991. A favorite for both instructors and students, Visual Basic 2015 is designed for readers with no prior computer programming experience. Schneider introduces a problem-solving strategy early in the book and revisits it throughout allowing you to fully develop logic and reasoning. A broad range of real-world examples, section-ending exercises, case studies and programming projects gives you a more hands-on experience than any other Visual Basic book on the market.", "introductiontoprogrammingusingvisualbasic.jpg", 5527.18m, null, 0, 99, "Introduction to Programming Using Visual Basic 10th Edition" },
                    { 59, "Nathan Clark", "Basic Programming", new DateTime(2024, 5, 8, 13, 56, 54, 0, DateTimeKind.Unspecified), "Every Conceivable Topic a Complete Novice Needs To Know ★\n\nIf you are a newcomer to programming it’s easy to get lost in the technical jargon, before even getting to the language you want to learn.\nWhat are statements, operators, and functions?\nHow to structure, build and deploy a program?\nWhat is functional programming and object oriented programming?\nHow to store, manage and exchange data?\n\nThese are topics many programming guides don’t cover, as they are assumed to be general knowledge to most developers. That is why this guide has been created. It is the ultimate primer to all programming languages.", "fundamentalsofprogrammingtermsandconcepts.jpg", 1144.13m, null, 0, 99, "Computer Programming for Beginners: Fundamentals of Programming Terms and Concepts" },
                    { 60, "Nathan Clark", "Basic Programming", new DateTime(2024, 5, 8, 13, 58, 28, 0, DateTimeKind.Unspecified), "★ JavaScript Made Easy – a Step-by-Step Guide for Beginners ★\n\nLearning a programming language can seem like a daunting task. You may have looked at coding in the past, and felt it was too complicated and confusing. This comprehensive beginner’s guide will take you step by step through learning one of the best programming languages out there. In a matter of no time, you will be writing code like a professional.\n\nJavaScript is a popular client-side scripting language that is used to develop products and applications to run in a web browser. Almost all applications that you see on the web will have JavaScript running in some form or another. There is no limit to the extent of functionality that can be created using JavaScript.", "javascriptprogrammingbasicforabsoulutebegin.jpg", 937.51m, null, 0, 99, "JavaScript: Programming Basics for Absolute Beginners (Step-By-Step JavaScript)" },
                    { 61, "W. Richard Stevens and Stephen A. Rago", "Advance Programming", new DateTime(2024, 5, 8, 14, 29, 2, 0, DateTimeKind.Unspecified), "Practical, in-depth knowledge of the system programming interfaces that drive the UNIX and Linux kernels.", "1.jpg", 2010.47m, null, 0, 150, "Advanced Programming in the UNIX Environment" },
                    { 62, "Randal E. Bryant and David R. O'Hallaron", "Advance Programming", new DateTime(2024, 5, 8, 14, 30, 48, 0, DateTimeKind.Unspecified), "This book explains the important and enduring concepts underlying all computer systems, and shows the concrete ways that these ideas affect the correctness, performance, and utility of application programs. The book's concrete and hands-on approach will help readers understand what is going on 'under the hood' of a computer system.", "2.jpg", 1436.05m, null, 0, 150, "Computer Systems: A Programmer's Perspective" },
                    { 63, "Andrew W. Appel and Jens Palsberg", "Advance Programming", new DateTime(2024, 5, 8, 14, 31, 41, 0, DateTimeKind.Unspecified), "This new, expanded textbook describes all phases of a modern compiler: lexical analysis, parsing, abstract syntax, semantic actions, intermediate representations, instruction selection via tree matching, dataflow analysis, graph-coloring register allocation, and runtime systems.", "3.JPG", 2929.54m, null, 0, 150, "Modern Compiler Implementation in C" },
                    { 64, "Benjamin C. Pierce", "Advance Programming", new DateTime(2024, 5, 8, 14, 32, 53, 0, DateTimeKind.Unspecified), "A thorough and accessible introduction to a range of key ideas in type systems for programming languages. The study of type systems for programming languages now touches many areas of computer science, from language design and implementation to software engineering, network security, databases, and analysis of concurrent and distributed systems. This book offers accessible introductions to key ideas in the field, with contributions by experts on each topic.", "4.PNG", 3399.00m, null, 0, 148, "Advanced Topics in Types and Programming Languages" },
                    { 65, "Donald E. Knuth", "Advance Programming", new DateTime(2024, 5, 8, 14, 34, 48, 0, DateTimeKind.Unspecified), "The Art of Computer Programming is Knuth's multivolume analysis of algorithms. With the addition of this new volume, it continues to be the definitive description of classical computer science.", "5.png", 3159.31m, null, 0, 150, "The Art of Computer Programming" },
                    { 66, "Richard Bird", "Advance Programming", new DateTime(2024, 5, 8, 14, 38, 11, 0, DateTimeKind.Unspecified), "This book is unusual amongst books on functional programming in that it is primarily directed towards the concepts of functional programming, rather than their realization in a specific programming language.", "6.PNG", 2986.00m, null, 0, 150, "Introduction to Functional Programming" },
                    { 67, "John F. Hughes, Andries van Dam, Morgan McGuire, D", "Advance Programming", new DateTime(2024, 5, 8, 14, 39, 31, 0, DateTimeKind.Unspecified), "A guide to the concepts and applications of computer graphics covers such topics as interaction techniques, dialogue design, and user interface software.", "7.PNG", 1895.59m, null, 0, 149, "Computer Graphics: Principles and Practice" },
                    { 68, "Raghu Ramakrishnan and Johannes Gehrke", "Advance Programming", new DateTime(2024, 5, 8, 14, 40, 26, 0, DateTimeKind.Unspecified), "Database Management Systems provides comprehensive and up-to-date coverage of the fundamentals of database systems. Coherent explanations and practical examples have made this one of the leading texts in the field. The third edition continues in this tradition, enhancing it with more practical material.", "8.PNG", 2470.01m, null, 0, 148, "Database Management Systems" },
                    { 69, "Anany Levitin", "Advance Programming", new DateTime(2024, 5, 8, 14, 41, 12, 0, DateTimeKind.Unspecified), "Introduction to the Design and Analysis of Algorithms presents the subject in a coherent and innovative manner. Written in a student-friendly style, the book emphasizes the understanding of ideas over excessively formal treatment while thoroughly covering the material.", "9.PNG", 1550.93m, null, 0, 150, "Introduction to the Design and Analysis of Algorithms" },
                    { 70, "Brendan Gregg", "Advance Programming", new DateTime(2024, 5, 8, 14, 41, 55, 0, DateTimeKind.Unspecified), "Systems performance analysis and tuning lead to a better end-user experience and lower costs, especially for cloud computing environments that charge by the OS instance. Systems Performance, 2nd Edition covers concepts, strategy, tools, and tuning for operating systems and applications, using Linux-based operating systems as the primary example.", "10.PNG", 2355.12m, null, 0, 149, "Systems Performance: Enterprise and the Cloud" },
                    { 71, "Peter Brass", "Advance Programming", new DateTime(2024, 5, 8, 14, 43, 4, 0, DateTimeKind.Unspecified), "This text closely examines ideas, analysis, and implementation details of data structures as a specialised topic in applied algorithms. It looks at efficient ways to realise query and update operations on sets of numbers, intervals, or strings by various data structures, including: search trees; structures for sets of intervals or piece-wise constant functions; orthogonal range search structures; heaps; union-find structures; dynamization and persistence of structures; structures for strings; and hash tables. Instead of relegating data structures to trivial material used to illustrate object-oriented programming methodology, this is the first volume to show data structures as a crucial algorithmic topic. Numerous code examples in C and more than 500 references make Advanced Data Structures an indispensable text.", "11.PNG", 2297.00m, null, 0, 150, "Advanced Data Structures" },
                    { 72, "Peter van der Linden", "Advance Programming", new DateTime(2024, 5, 8, 14, 44, 7, 0, DateTimeKind.Unspecified), "This book is for the knowledgeable C programmer, this is a second book that gives the C programmers advanced tips and tricks. This book will help the C programmer reach new heights as a professional. Organized to make it easy for the reader to scan to sections that are relevant to their immediate needs.", "12.PNG", 919.07m, null, 0, 146, "Expert C Programming: Deep C Secrets" },
                    { 73, "Tomas Akenine-Möller, Eric Haines, and Naty Hoffma", "Advance Programming", new DateTime(2024, 5, 8, 14, 45, 4, 0, DateTimeKind.Unspecified), "Real-Time Rendering combines fundamental principles with guidance on the latest techniques to provide a complete reference on three-dimensional interactive computer graphics.", "13.PNG", 1436.05m, null, 0, 149, "Real-Time Rendering" },
                    { 74, "Niels Ferguson, Bruce Schneier, and Tadayoshi Kohn", "Advance Programming", new DateTime(2024, 5, 8, 14, 46, 30, 0, DateTimeKind.Unspecified), "The ultimate guide to cryptography, updated from an author team of the world's top cryptography experts. Cryptography is vital to keeping information safe, in an era when the formula to do so becomes more and more challenging. Written by a team of world-renowned cryptography experts, this essential guide is the definitive introduction to all major areas of cryptography: message security, key negotiation, and key management. You'll learn how to think like a cryptographer. You'll discover techniques for building cryptography into products from the start and you'll examine the many technical changes in the field.", "14.PNG", 2125.35m, null, 0, 150, "Cryptography Engineering: Design Principles and Practical Applications" },
                    { 75, "Olivier Bonaventure", "Business", new DateTime(2024, 5, 8, 14, 51, 50, 0, DateTimeKind.Unspecified), "This open textbook aims to fill the gap between the open-source implementations and the open-source network specifications by providing a detailed but pedagogical description of the key principles that guide the operation of the Internet. 1 Preface 2 Introduction 3 The application Layer 4 The transport layer 5 The network layer 6 The datalink layer and the Local Area Networks 7 Glossary 8 Bibliography", "15.PNG", 2010.48m, null, 0, 149, "Computer Networking: Principles, Protocols and Practice" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "BookInfos",
                keyColumn: "BookId",
                keyValue: 75);
        }
    }
}
