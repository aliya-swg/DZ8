using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Manager;

public class Report
{
    public string content;
    public DateTime executionDate;
    public Worker executor;
    public Report(string content, Worker executor)
    {
        this.content = content;
        this.executor = executor;
        executionDate = DateTime.Today;
    }
    public override string ToString()
    {
        return $"Дата: {executionDate:G} - Исполнитель: {executor.GetName()} - Отчёт: {content}";
    }
}
