using System;
using System.Collections.Generic;


namespace Task_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer("Иван");
            var teamlead = new Teamlead("Ольга");

            var project = customer.CreateProject("Разработка системы", 30, teamlead);

            var workers = new List<Worker> {
                new Worker("Алексей"),
                new Worker("Марина"),
                new Worker("Дмитрий"),
                new Worker("Елена"),
                new Worker("Сергей"),
                new Worker("Анна"),
                new Worker("Олег"),
                new Worker("Наталья"),
                new Worker("Игорь"),
                new Worker("Татьяна")
            };

            foreach (var worker in workers)
            {
                teamlead.AddWorkerToTeam(worker);
            }

            teamlead.CreateTask(project, "Собрать требования", 5, customer);
            teamlead.CreateTask(project, "Реализовать функционал", 20, customer);
            teamlead.CreateTask(project, "Собрать требования", 5, customer);
            teamlead.CreateTask(project, "Разработать архитектуру", 10, customer, true, TimeSpan.FromSeconds(5), 5);
            teamlead.CreateTask(project, "Реализовать функционал", 20, customer);
            teamlead.CreateTask(project, "Протестировать функционал", 8, customer);
            teamlead.CreateTask(project, "Подготовить документацию", 12, customer);
            teamlead.CreateTask(project, "Провести обучение пользователей", 15, customer);
            teamlead.CreateTask(project, "Оптимизировать производительность", 10, customer, true, TimeSpan.FromSeconds(10), 3);
            teamlead.CreateTask(project, "Настроить серверное окружение", 7, customer);
            teamlead.CreateTask(project, "Обновить систему безопасности", 6, customer);
            teamlead.CreateTask(project, "Сделать релиз", 3, customer);



            teamlead.StartProject(project);

            teamlead.DistributeTasks(project);

            foreach (var task in project.tasks)
            {
                if (task.performer != null)
                {
                    task.performer.TakeTask(task);

                    if (task.isPeriodic && task.reportingInterval.HasValue)
                    {
                        DateTime endDate = DateTime.Today.AddDays(task.daysToComplete);
                        int reportCounter = 0;

                        while (task.nextReportDate.HasValue && task.nextReportDate <= endDate && reportCounter < task.reportCount)
                        {
                            task.performer.SubmitPeriodicReport($"Периодический отчет по задаче '{task.description}'", task);
                            reportCounter++;

                            task.nextReportDate = task.nextReportDate.Value.Add(task.reportingInterval.Value);
                        }
                    }

                    else
                    {
                        task.performer.AddReport(task, $"Задача '{task.description}' выполнена.");
                        task.UpdateStatus(TaskStatus.Completed);
                    }
                }
                else
                {
                    Console.WriteLine($"Задача '{task.description}' не назначена исполнителю.");
                }
            }



            if (project.tasks.All(t => t.status == TaskStatus.Completed))
            {
                project.UpdateStatus(ProjectStatus.Closed);
                Console.WriteLine($"Проект '{project.description}' завершен.");
            }
        }
    }
}
