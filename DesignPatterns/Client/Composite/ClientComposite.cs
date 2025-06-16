using DesignPatterns.Composite.ex1;
using Task = System.Threading.Tasks.Task;

namespace DesignPatterns.Client.Composite;

public class ClientComposite
{
    public void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        // Создаем корневую группу задач
        TaskGroup rootProject = new TaskGroup("Проект Редизайн сайта", 
            "Обновление дизайна и функциональности корпоративного сайта", 10, 
            DateTime.Now.AddMonths(3));
        
        // Создаем подгруппы для разных этапов проекта
        TaskGroup planningPhase = new TaskGroup("Планирование", 
            "Этап планирования и подготовки проекта", 5, 
            DateTime.Now.AddDays(14));
            
        TaskGroup designPhase = new TaskGroup("Дизайн", 
            "Разработка нового дизайна сайта", 8, 
            DateTime.Now.AddDays(45));
            
        TaskGroup developmentPhase = new TaskGroup("Разработка", 
            "Этап программирования и интеграции", 15, 
            DateTime.Now.AddMonths(2));
            
        TaskGroup testingPhase = new TaskGroup("Тестирование", 
            "Проверка работоспособности и исправление ошибок", 5, 
            DateTime.Now.AddMonths(2).AddDays(15));
        
        // Добавляем группы в корневой проект
        rootProject.Add(planningPhase);
        rootProject.Add(designPhase);
        rootProject.Add(developmentPhase);
        rootProject.Add(testingPhase);
        rootProject.Add(new SingleTask("Запуск сайта", "Финальное развертывание на боевом сервере", 
            4, "High", DateTime.Now.AddMonths(3)));
        
        // Наполняем фазу планирования задачами
        planningPhase.Add(new SingleTask("Анализ требований", "Сбор и анализ требований от заказчика", 
            16, "High", DateTime.Now.AddDays(5)));
        planningPhase.Add(new SingleTask("Составление ТЗ", "Разработка технического задания", 
            24, "High", DateTime.Now.AddDays(12)));
        planningPhase.Add(new SingleTask("Оценка ресурсов", "Определение необходимых ресурсов и бюджета", 
            8, "Medium", DateTime.Now.AddDays(10)));
        
        // Наполняем фазу дизайна
        designPhase.Add(new SingleTask("Прототипирование", "Создание прототипов интерфейса", 
            20, "Medium", DateTime.Now.AddDays(25)));
            
        TaskGroup uiDesign = new TaskGroup("UI/UX Дизайн", 
            "Разработка пользовательского интерфейса", 4, DateTime.Now.AddDays(40));
        uiDesign.Add(new SingleTask("Главная страница", "Дизайн главной страницы сайта", 
            16, "High", DateTime.Now.AddDays(30)));
        uiDesign.Add(new SingleTask("Внутренние страницы", "Дизайн внутренних разделов и страниц", 
            24, "Medium", DateTime.Now.AddDays(38)));
        uiDesign.Add(new SingleTask("Мобильная версия", "Адаптивный дизайн для мобильных устройств", 
            20, "Medium", DateTime.Now.AddDays(40)));
        designPhase.Add(uiDesign);
        
        // Наполняем фазу разработки
        TaskGroup frontendDev = new TaskGroup("Фронтенд", "Разработка клиентской части", 
            5, DateTime.Now.AddDays(65));
        frontendDev.Add(new SingleTask("Верстка", "HTML/CSS верстка дизайн-макетов", 
            40, "Medium", DateTime.Now.AddDays(55)));
        frontendDev.Add(new SingleTask("JavaScript", "Реализация клиентской логики", 
            30, "Medium", DateTime.Now.AddDays(65)));
        developmentPhase.Add(frontendDev);
        
        TaskGroup backendDev = new TaskGroup("Бэкенд", "Разработка серверной части", 
            5, DateTime.Now.AddDays(70));
        backendDev.Add(new SingleTask("API", "Разработка REST API", 
            35, "High", DateTime.Now.AddDays(60)));
        backendDev.Add(new SingleTask("База данных", "Проектирование и реализация БД", 
            25, "High", DateTime.Now.AddDays(50)));
        backendDev.Add(new SingleTask("Интеграции", "Интеграция с внешними системами", 
            20, "Medium", DateTime.Now.AddDays(70)));
        developmentPhase.Add(backendDev);
        
        developmentPhase.Add(new SingleTask("Документация", "Написание документации для разработчиков", 
            15, "Low", DateTime.Now.AddDays(75)));
        
        // Наполняем фазу тестирования
        testingPhase.Add(new SingleTask("Модульное тестирование", "Проверка отдельных компонентов", 
            20, "Medium", DateTime.Now.AddMonths(2).AddDays(5)));
        testingPhase.Add(new SingleTask("Интеграционное тестирование", "Проверка взаимодействия компонентов", 
            15, "High", DateTime.Now.AddMonths(2).AddDays(10)));
        testingPhase.Add(new SingleTask("Нагрузочное тестирование", "Тестирование производительности", 
            10, "Medium", DateTime.Now.AddMonths(2).AddDays(15)));
        
        // Устанавливаем статус выполнения для некоторых задач
        // Обратите внимание, что здесь используем SingleTask вместо Task
        ((SingleTask)planningPhase.GetChild(0)).SetCompleted(true);  // Анализ требований выполнен
        ((SingleTask)planningPhase.GetChild(1)).SetCompleted(true);  // ТЗ составлено
        ((SingleTask)planningPhase.GetChild(2)).SetCompleted(true);  // Оценка ресурсов выполнена
        ((SingleTask)designPhase.GetChild(0)).SetCompleted(true);    // Прототипирование выполнено
        ((SingleTask)uiDesign.GetChild(0)).SetCompleted(true);       // Главная страница дизайн готов
        ((SingleTask)uiDesign.GetChild(1)).SetCompleted(true);       // Внутренние страницы дизайн готов
        
        // Выводим структуру проекта
        Console.WriteLine("=== СТРУКТУРА ПРОЕКТА ===");
        rootProject.Display();
        
        // Выводим общую информацию о проекте
        Console.WriteLine("\n=== ОБЩАЯ ИНФОРМАЦИЯ ===");
        Console.WriteLine($"Общее время проекта: {rootProject.GetEstimatedHours()} часов");
        Console.WriteLine($"Прогресс выполнения: {rootProject.GetCompletionPercentage()}%");
        Console.WriteLine($"Статус проекта: {(rootProject.IsCompleted() ? "Завершен" : "В процессе")}");
        
        // Поиск просроченных задач
        Console.WriteLine("\n=== ПРОСРОЧЕННЫЕ ЗАДАЧИ ===");
        var currentDate = DateTime.Now.AddDays(15); // Предположим, прошло 15 дней с начала проекта
        var overdueTasks = rootProject.FindOverdueTasks(currentDate);
        
        if (overdueTasks.Count > 0)
        {
            foreach (var task in overdueTasks)
            {
                Console.WriteLine($"- {task.Title} (должна быть выполнена до {task.DueDate.ToShortDateString()})");
            }
        }
        else
        {
            Console.WriteLine("Просроченных задач нет");
        }
        
        // Поиск задач по названию
        Console.WriteLine("\n=== ПОИСК ЗАДАЧ ПО НАЗВАНИЮ 'дизайн' ===");
        var designTasks = rootProject.FindByTitle("дизайн", false);
        foreach (var task in designTasks)
        {
            Console.WriteLine($"- {task.Title} (путь: {task.GetTaskPath()})");
        }
        
        // Фильтрация высокоприоритетных задач
        Console.WriteLine("\n=== ВЫСОКОПРИОРИТЕТНЫЕ ЗАДАЧИ ===");
        var highPriorityTasks = rootProject.FilterTasks(t => 
            t is SingleTask task && task.Priority == "High" && !task.IsCompleted());
            
        foreach (var task in highPriorityTasks)
        {
            Console.WriteLine($"- {task.Title}");
        }
        
        // Примеры работы через общий интерфейс Component
        Console.WriteLine("\n=== ДЕМОНСТРАЦИЯ ЕДИНООБРАЗНОЙ РАБОТЫ С КОМПОНЕНТАМИ ===");
        
        TodoItem[] items = {
            rootProject.GetChild(0).GetChild(0),  // Простая задача (Анализ требований)
            rootProject.GetChild(1),              // Группа задач (Дизайн)
            rootProject.GetChild(2).GetChild(1)   // Вложенная группа задач (Бэкенд)
        };
        
        foreach (var item in items)
        {
            Console.WriteLine($"\nОбработка элемента '{item.Title}':");
            Console.WriteLine($"  - Тип: {(item.IsComposite() ? "Группа задач" : "Задача")}");
            Console.WriteLine($"  - Завершен: {item.IsCompleted()}");
            Console.WriteLine($"  - Прогресс: {item.GetCompletionPercentage()}%");
            Console.WriteLine($"  - Время: {item.GetEstimatedHours()} ч.");
            Console.WriteLine($"  - Путь: {item.GetTaskPath()}");
        }
    }
}