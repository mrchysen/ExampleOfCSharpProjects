using System.Xml.Linq;

namespace LogicOfApplication
{
    // Базовый класс человека \\
    public class Human
    {
        // Поля \\
        protected string Name;
        protected string Code;
        protected double Salary;
        protected string JobTitle;
        
        // Св-ва \\
        public string GetName { get { return Name; } }
        public string GetCode { get { return Code; } }
        public string GetJobTitle { get { return JobTitle; } }

        // Конструторы \\
        public Human(string name, string code, string jobTitle)
        {
            Name = name;
            Code = code;
            JobTitle = jobTitle;
        }

        // Методы \\
        public virtual double GetSalary() { return 0; }
        public override string ToString() { return $"{Name} {Code}"; }
    }

    // Управленец \\
    public class Manager : Human
    {
        // Поля для подсчёта зарплаты \\
        protected float D;
        protected float U;
        protected float P;
        protected float Dollar = 70;

        // Св-ва \\
        public float SetDollar { set { Dollar = value; } }

        // Конструторы \\
        public Manager(string name, string code, string stringWithSalaryData, string jobTitle) : base(name, code, jobTitle)
        {
            // Парсинг строки с информацией о зарплате
            string[] arrWithData = stringWithSalaryData.Split();
            D = int.Parse(arrWithData[0]);
            U = int.Parse(arrWithData[1]);
            P = float.Parse(jobTitle[1].ToString());
        }

        // Поля \\
        public override double GetSalary() { return D + U * P * Dollar; }
        public override string ToString() { return $"{base.ToString()} {GetJobTitle} {GetSalary()}"; }
    }

    // Преподаватель \\
    public class Teacher : Human
    {
        // Поля для подсчёта зарплаты \\
        protected float A;
        protected float B;
        protected float C;

        // Конструторы \\
        public Teacher(string name, string code, string stringWithSalaryData, string jobTitle) : base(name, code, jobTitle)
        {
            // Парсинг строки с информацией о зарплате
            string[] arrWithData = stringWithSalaryData.Split();
            A = int.Parse(arrWithData[0]);
            B = int.Parse(arrWithData[1]);
            C = int.Parse(arrWithData[2]);
        }

        // Поля \\
        public override double GetSalary() { return A * B * C * 1.6f; }
        public override string ToString() { return $"{base.ToString()} {GetJobTitle} {GetSalary()}"; }
    }

    // Вспомогательный работник \\
    public class Worker : Human
    {
        // Поля для подсчёта зарплаты \\
        protected float E;
        protected float G;

        // Конструторы \\
        public Worker(string name, string code, string stringWithSalaryData, string jobTitle) : base(name, code, jobTitle)
        {
            // Парсинг строки с информацией о зарплате
            string[] arrWithData = stringWithSalaryData.Split();
            E = int.Parse(arrWithData[0]);
            G = int.Parse(arrWithData[1]);
        }

        // Поля \\
        public override double GetSalary() { return E + G; }
        public override string ToString() { return $"{base.ToString()} {GetJobTitle} {GetSalary()}"; }
    }

    // Контейнерный класс \\
    public class PeopleHandler
    {
        // Поля \\
        protected List<Human> Humans = new List<Human>();

        // Св-ва и индексатор \\
        public int Length { get { return Humans.Count; } }
        public Human this[int i] 
        { 
            get
            {
                if(i < Length || 0 <= i)
                {
                    return Humans[i];
                }
                throw new IndexOutOfRangeException();
            } 
        }
        public string GetAllPeopleInString
        {
            get
            {
                string ans = "";

                for (int i = 0; i < Length; i++)
                { 
                    var h = Humans[i];
                    ans += $"{i+1}) {h.GetCode} {h.GetName} {h.GetJobTitle} {h.GetSalary()}\n";
                }
                
                return ans;
            }
        }

        // Конструктор \\ 
        public PeopleHandler() { }
        public PeopleHandler(List<Human> humans) { Humans = humans; }

        // Методы \\ 
        /// <summary>
        /// Считывание из файла по пути path
        /// </summary>
        public void LoadFromFile(string path)
        {
            if(File.Exists(path)) 
            { 
                using(StreamReader sr = new StreamReader(path)) 
                { 
                    string? line;
                    while((line = sr.ReadLine()) != null)
                    {
                        string? type = line;
                        string? code = sr.ReadLine();
                        string? name = sr.ReadLine();
                        string? jobType = sr.ReadLine();
                        string? stringWithDataSalary = sr.ReadLine();

                        Human? h = null;

                        if (type == "Преподаватель")
                        {
                            if(code != null && name != null && jobType != null && stringWithDataSalary != null)
                                h = new Teacher(name, code, stringWithDataSalary, jobType);
                        }
                        else if (type == "Управленец")
                        {
                            if (code != null && name != null && jobType != null && stringWithDataSalary != null)
                                h = new Manager(name, code, stringWithDataSalary, jobType);
                        }
                        else if (type == "Работник")
                        {
                            if (code != null && name != null && jobType != null && stringWithDataSalary != null)
                                h = new Worker(name, code, stringWithDataSalary, jobType);
                        }

                        if(h != null)
                            Humans.Add(h);

                        sr.ReadLine();
                    }
                }
            }
        }
        /// <summary>
        /// Сортировка по возрастанию идентификационного номера
        /// </summary>
        public void SortByCode() 
        { 
            //Сортировка с помощью анонимного метода, который сравнивает два объекта
            Humans.Sort((Human a, Human b) => 
            { 
                return a.GetCode.CompareTo(b.GetCode); 
            } ); 
        }
        /// <summary>
        /// Выводит людей в соотвествии с заданной категорией и курсом доллара
        /// </summary>
        /// <returns></returns>
        public string GetPeopleByCategory(string category, float valueOfOneDollar)
        {
            // Пояснение: ValueOfOneDollar стоимость одного доллара в рублях
            string ans = "";
            int num = 0;
            for (int i = 0; i < Length; i++)
            {
                if (Humans[i].GetJobTitle.Contains(category))
                {
                    num++;
                    var h = Humans[i];

                    // Пояснение: только у управленца премия в долларах, поэтому ему нужно задавать курс доллара
                    if(h is Manager t) t.SetDollar = valueOfOneDollar;

                    ans += $"{num}) {h.GetCode} {h.GetName} {h.GetJobTitle} {h.GetSalary()}\n" ;
                }
            }
            return ans;
        }
    }
}
