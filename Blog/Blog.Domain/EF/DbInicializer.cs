using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;
using Blog.Data.Model;

namespace Blog.Data.EF
{
    public class DbInicializer : DropCreateDatabaseIfModelChanges<BlogDbContext>
    {
        protected override void Seed(BlogDbContext context)
        {
            List<ArticleTag> tags = new List<ArticleTag>() {
                new ArticleTag() { Text = "ООП" },
                new ArticleTag() { Text = ".Net" },
                new ArticleTag() { Text = "Frontend" },
                new ArticleTag() { Text = "Backend" }
            };

            var articles = new List<Article>()
            {
                new Article()
                {
                    Title = "C# Википедия",
                    PublishingDate = DateTime.Now,
                    Text = new StringBuilder().AppendFormat("{0}{1}{2}{3}",
                    "C# (произносится си шарп) — объектно-ориентированный язык программирования. Разработан в 1998—2001 годах группой инженеров под руководством Андерса Хейлсберга в компании Microsoft как язык разработки приложений для платформы Microsoft .NET Framework и впоследствии был стандартизирован как ECMA-334 и ISO/IEC 23270.\r\n",
                    "C# относится к семье языков с C-подобным синтаксисом, из них его синтаксис наиболее близок к C++ и Java. Язык имеет статическую типизацию, поддерживает полиморфизм, перегрузку операторов (в том числе операторов явного и неявного приведения типа), делегаты, атрибуты, события, свойства, обобщённые типы и методы, итераторы, анонимные функции с поддержкой замыканий, LINQ, исключения, комментарии в формате XML.\r\n",
                    "Переняв многое от своих предшественников — языков C++, Pascal, Модула, Smalltalk и, в особенности, Java — С#, опираясь на практику их использования, исключает некоторые модели, зарекомендовавшие себя как проблематичные при разработке программных систем, например, C# в отличие от C++ не поддерживает множественное наследование классов (между тем допускается множественное наследование интерфейсов).\r\n",
                    "C# разрабатывался как язык программирования прикладного уровня для CLR и, как таковой, зависит, прежде всего, от возможностей самой CLR. Это касается, прежде всего, системы типов C#, которая отражает BCL. Присутствие или отсутствие тех или иных выразительных особенностей языка диктуется тем, может ли конкретная языковая особенность быть транслирована в соответствующие конструкции CLR. Так, с развитием CLR от версии 1.1 к 2.0 значительно обогатился и сам C#; подобного взаимодействия следует ожидать и в дальнейшем (однако, эта закономерность была нарушена с выходом C# 3.0, представляющего собой расширения языка, не опирающиеся на расширения платформы .NET). CLR предоставляет C#, как и всем другим .NET-ориентированным языкам, многие возможности, которых лишены «классические» языки программирования. Например, сборка мусора не реализована в самом C#, а производится CLR для программ, написанных на C# точно так же, как это делается для программ на VB.NET, J# и др.\r\n").ToString(),
                    Tags = new List<ArticleTag>() { tags[0], tags[1], tags[3] }
                },

                new Article()
                {
                    Title = "C++ Википедия",
                    PublishingDate = DateTime.Now,
                    Text = new StringBuilder().AppendFormat("{0}{1}{2}{3}",
                    "C++ — компилируемый, статически типизированный язык программирования общего назначения.\r\n",
                    "Поддерживает такие парадигмы программирования, как процедурное программирование, объектно-ориентированное программирование, обобщённое программирование. Язык имеет богатую стандартную библиотеку, которая включает в себя распространённые контейнеры и алгоритмы, ввод-вывод, регулярные выражения, поддержку многопоточности и другие возможности. C++ сочетает свойства как высокоуровневых, так и низкоуровневых языков. В сравнении с его предшественником — языком C, — наибольшее внимание уделено поддержке объектно-ориентированного и обобщённого программирования.\r\n",
                    "C++ широко используется для разработки программного обеспечения, являясь одним из самых популярных языков программирования. Область его применения включает создание операционных систем, разнообразных прикладных программ, драйверов устройств, приложений для встраиваемых систем, высокопроизводительных серверов, а также развлекательных приложений (игр). Существует множество реализаций языка C++, как бесплатных, так и коммерческих и для различных платформ. Например, на платформе x86 это GCC, Visual C++, Intel C++ Compiler, Embarcadero (Borland) C++ Builder и другие. C++ оказал огромное влияние на другие языки программирования, в первую очередь на Java и C#.\r\n",
                    "Синтаксис C++ унаследован от языка C. Одним из принципов разработки было сохранение совместимости с C. Тем не менее, C++ не является в строгом смысле надмножеством C; множество программ, которые могут одинаково успешно транслироваться как компиляторами C, так и компиляторами C++, довольно велико, но не включает все возможные программы на C.\r\n").ToString(),
                    Tags = new List<ArticleTag>() { tags[0], tags[1], tags[3] }
                },

                new Article()
                {
                    Title = "JavaScript Википедия",
                    PublishingDate = DateTime.Now,
                    Text = new StringBuilder().AppendFormat("{0}{1}{2}{3}",
                    "JavaScript — мультипарадигменный язык программирования. Поддерживает объектно-ориентированный, императивный и функциональный стили. Является реализацией языка ECMAScript (стандарт ECMA-262).\r\n",
                    "JavaScript обычно используется как встраиваемый язык для программного доступа к объектам приложений. Наиболее широкое применение находит в браузерах как язык сценариев для придания интерактивности веб-страницам.\r\n",
                    "Основные архитектурные черты: динамическая типизация, слабая типизация, автоматическое управление памятью, прототипное программирование, функции как объекты первого класса.На JavaScript оказали влияние многие языки, при разработке была цель сделать язык похожим на Java, но при этом лёгким для использования непрограммистами. Языком JavaScript не владеет какая-либо компания или организация, что отличает его от ряда языков программирования, используемых в веб-разработке.\r\n",
                    "Название «JavaScript» является зарегистрированным товарным знаком компании Oracle Corporation.\r\n").ToString(),
                    Tags = new List<ArticleTag>() {  tags[0], tags[2] }
                },

                new Article()
                {
                    Title = "HTML Википедия",
                    PublishingDate = DateTime.Now,
                    Text = new StringBuilder().AppendFormat("{0}{1}{2}{3}{4}{5}",
                    "HTML (от англ. HyperText Markup Language — «язык гипертекстовой разметки») — стандартизированный язык разметки документов во Всемирной паутине. Большинство веб-страниц содержат описание разметки на языке HTML (или XHTML). Язык HTML интерпретируется браузерами; полученный в результате интерпретации форматированный текст отображается на экране монитора компьютера или мобильного устройства.\r\n",
                    "Язык HTML до 5-ой версии определялся как приложение SGML (стандартного обобщённого языка разметки по стандарту ISO 8879). Спецификации HTML5 формулируются в терминах DOM (объектной модели документа).\r\n",
                    "Язык XHTML является более строгим вариантом HTML, он следует синтаксису XML и является приложением языка XML в области разметки гипертекста.\r\n",
                    "Во всемирной паутине HTML-страницы, как правило, передаются браузерам от сервера по протоколам HTTP или HTTPS, в виде простого текста или с использованием шифрования.\r\n",
                    "Язык HTML был разработан британским учёным Тимом Бернерсом-Ли приблизительно в 1986—1991 годах в стенах ЦЕРНа в Женеве в Швейцарии. HTML создавался как язык для обмена научной и технической документацией, пригодный для использования людьми, не являющимися специалистами в области вёрстки. HTML успешно справлялся с проблемой сложности SGML путём определения небольшого набора структурных и семантических элементов — дескрипторов. Дескрипторы также часто называют «тегами». С помощью HTML можно легко создать относительно простой, но красиво оформленный документ. Помимо упрощения структуры документа, в HTML внесена поддержка гипертекста. Мультимедийные возможности были добавлены позже.\r\n",
                    "Изначально язык HTML был задуман и создан как средство структурирования и форматирования документов без их привязки к средствам воспроизведения (отображения). В идеале, текст с разметкой HTML должен был без стилистических и структурных искажений воспроизводиться на оборудовании с различной технической оснащённостью (цветной экран современного компьютера, монохромный экран органайзера, ограниченный по размерам экран мобильного телефона или устройства и программы голосового воспроизведения текстов). Однако современное применение HTML очень далеко от его изначальной задачи. Например, тег <table> предназначен для создания в документах таблиц, но часто используется и для оформления размещения элементов на странице. С течением времени основная идея платформонезависимости языка HTML была принесена в жертву современным потребностям в мультимедийном и графическом оформлении..\r\n").ToString(),
                    Tags = new List<ArticleTag>() { tags[2] }
                },
            };

            articles.ForEach(x => context.Articles.Add(new Article() { Title = x.Title, Text = x.Text, PublishingDate = x.PublishingDate, Tags = x.Tags}));
            context.SaveChanges();

            var reviews = new List<Review>()
            {
                new Review()
                {
                    Author = "Джон Сноу",
                    Text = "Зима близко!!!",
                    PublishingDate = DateTime.Now
                },
                new Review()
                {
                    Author = "Михаил Поплавский",
                    Text = "Кропива ти моя, кропива,\r\nЗнай, що вдячний тобі я повік\r\nОх, трава ти моя, трин-трава,\r\nНе косив я тебе цілий рік.",
                    PublishingDate = DateTime.Now
                },
                new Review()
                {
                    Author = "Виталий Кличко",
                    Text = "А сегодня в завтрашний день не все могут смотреть.\r\nВернее смотреть могут не только лишь все, мало кто может это делать",
                    PublishingDate = DateTime.Now
                }
            };

            reviews.ForEach(x => context.Reviews.Add(new Review() { Author = x.Author, Text = x.Text, PublishingDate = x.PublishingDate }));
            context.SaveChanges();

            var questionnaire = new Questionnaire() { Title = "Тест №1" };

            Question question = new Question() { Text = "Укажите свой пол.", IsFewAnswers = false };
            question.Answers.Add(new Answer() { Text = "Мужской" });
            question.Answers.Add(new Answer() { Text = "Женский" });
            question.Answers.Add(new Answer() { Text = "Я не определился)" });
            questionnaire.Questions.Add(question);

            question = new Question() { Text = "Сколько вам лет?", IsFewAnswers = false };
            question.Answers.Add(new Answer() { Text = "< 18" });
            question.Answers.Add(new Answer() { Text = "18 < и < 30" });
            question.Answers.Add(new Answer() { Text = "30 < и < 45 " });
            question.Answers.Add(new Answer() { Text = "> 45" });
            questionnaire.Questions.Add(question);

            question = new Question() { Text = "С какими языками программирования вы работали?", IsFewAnswers = true };
            question.Answers.Add(new Answer() { Text = "C#" });
            question.Answers.Add(new Answer() { Text = "C/C++" });
            question.Answers.Add(new Answer() { Text = "Java" });
            question.Answers.Add(new Answer() { Text = "JavaScript" });
            question.Answers.Add(new Answer() { Text = "Python" });
            questionnaire.Questions.Add(question);

            question = new Question() { Text = "Какими операционными системами вы пользуетесь?", IsFewAnswers = true };
            question.Answers.Add(new Answer() { Text = "Microsoft Windows" });
            question.Answers.Add(new Answer() { Text = "Linux" });
            question.Answers.Add(new Answer() { Text = "OS X" });
            question.Answers.Add(new Answer() { Text = "DOS" });
            questionnaire.Questions.Add(question);

            question = new Question() { Text = "Верите ли вы в бога?", IsFewAnswers = false };
            question.Answers.Add(new Answer() { Text = "Да" });
            question.Answers.Add(new Answer() { Text = "Нет" });
            questionnaire.Questions.Add(question);

            context.Questionnaires.Add(questionnaire);
            context.SaveChanges();

            Voting voting = new Voting() { Text = "Котики или собачки?" };
            voting.Options.Add(new VotingOption() { Text = "Котики" });
            voting.Options.Add(new VotingOption() { Text = "Собачки"});
            context.Votings.Add(voting);

            voting = new Voting() { Text = "Самый сильный ситх во вселенной Star Wars?" };
            voting.Options.Add(new VotingOption() { Text = "Дарт Сидиус" });
            voting.Options.Add(new VotingOption() { Text = "Дарт Вейдер" });
            voting.Options.Add(new VotingOption() { Text = "Дарт Мол" });
            voting.Options.Add(new VotingOption() { Text = "Граф Дуку" });
            voting.Options.Add(new VotingOption() { Text = "Кайло Рен" });
            voting.Options.Add(new VotingOption() { Text = "Сноук" });
            voting.Options.Add(new VotingOption() { Text = "Джа-Джа Бинкс" });
            context.Votings.Add(voting);

            voting = new Voting() { Text = "Саб-Зиро или Скорпион?" };
            voting.Options.Add(new VotingOption() { Text = "Саб-Зиро" });
            voting.Options.Add(new VotingOption() { Text = "Скорпион" });
            context.Votings.Add(voting);

            var userRoleId = Guid.NewGuid().ToString();
            var userRole = new IdentityRole()
            {
                Id = userRoleId,
                Name = "User"
            };

            var administratorRoleId = Guid.NewGuid().ToString();
            var adminRole = new IdentityRole()
            {
                Id = administratorRoleId,
                Name = "Administrator"
            };
            context.Roles.Add(userRole);
            context.Roles.Add(adminRole);

            var administrator = new User()
            {
                Id = "296e0f2d-d54e-4186-9ac3-8809a52d588c",
                UserName = "Admin",
                Email = "FirstAdmin@gmail.com",
                PasswordHash = "AAlFyLXgfAvNXRbRCWCyR2l1ALhs23nicgMeM8S45Ou5T4+eJl1TiEnNvXJTMe/gIA==",
                SecurityStamp = "fc84bf20-9a02-459a-9270-660137bcd907"
            };

            administrator.Roles.Add(new IdentityUserRole()
            {
                UserId = "296e0f2d-d54e-4186-9ac3-8809a52d588c",
                RoleId = administratorRoleId
            });

            administrator.Roles.Add(new IdentityUserRole()
            {
                UserId = "296e0f2d-d54e-4186-9ac3-8809a52d588c",
                RoleId = userRoleId
            });
            context.Users.Add(administrator);

            context.SaveChanges();
        }
    }
}
