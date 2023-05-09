using Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SpaceGroup sg;
            using (StreamReader sr = new StreamReader("file1.txt"))
            {
                string Name = sr.ReadLine();
                sg = new SpaceGroup(sr, Name, int.Parse(sr.ReadLine()));
            }
            Console.WriteLine(sg.ToString(0));
        }
    }
}

namespace Logic
{
    public class SpaceObject
    {
        public readonly string Name; // имя

        /// <summary>
        /// Конструктор-1
        /// </summary>
        /// <param name="Name"></param>
        public SpaceObject(string Name)
        {
            this.Name = Name;
        }

        protected string MakeSpace(int lvl)
        {
            string ans = "";
            for (int i = 0; i < lvl; i++)
            {
                ans += "  ";
            }
            return ans;
        }

        public virtual string ToString(int lvl)
        {
            string Spaces = MakeSpace(lvl);
            return Spaces + Name; 
        }

        /// <summary>
        /// Свойство типа
        /// </summary>
        public virtual string ThisType => "SpaceObject";

        /// <summary>
        /// Вывод объекта в консоль
        /// </summary>
        public virtual void PrintToConsole()
        {
            Console.WriteLine("Type: " + ThisType);
            Console.WriteLine(Name);
        }

        public virtual float GetWeight { get { return 0; } }

        /// <summary>
        /// Метод возвращающий объект как строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }

    public class SpaceGroup : SpaceObject, IEnumerable
    {
        protected List<SpaceObject> SpaceObjects = new List<SpaceObject>();  // лист объектов

        /// <summary>
        /// Свойство размености космической группы
        /// </summary>
        public int Length => SpaceObjects.Count;

        /// <summary>
        /// Конструктор-1
        /// </summary>
        /// <param name="Sr"></param>
        /// <param name="Name"></param>
        /// <param name="Count"></param>
        public SpaceGroup(StreamReader Sr, string Name, int Count) : base(Name)
        {
            for (int i = 0; i < Count; i++)
            {
                SpaceObjects.Add(MakeSpaceObject(Sr));
            }
        }

        /// <summary>
        /// Метод определяет какой объект создать
        /// </summary>
        /// <param name="Sr"></param>
        /// <returns></returns>
        private SpaceObject MakeSpaceObject(StreamReader Sr)
        {
            string Name = Sr.ReadLine();
            int Value = int.Parse(Sr.ReadLine());
            if (Value == 0)
            {
                float Light = float.Parse(Sr.ReadLine());
                if (Light == 0)
                {
                    return new Planet(Name, float.Parse(Sr.ReadLine()), float.Parse(Sr.ReadLine()));
                }
                else
                {
                    return new Star(Name, float.Parse(Sr.ReadLine()), Light);
                }
            }
            // иначе верни космическую группу
            return new SpaceGroup(Sr, Name, Value);
        }

        /// <summary>
        /// Свойство типа
        /// </summary>
        public override string ThisType => "SpaceGroup";


        /// <summary>
        /// Вывод объекта в консоль
        /// </summary>
        public override void PrintToConsole()
        {
            base.PrintToConsole();
            Console.WriteLine("Размерность объекта - " + Length);
            for (int i = 0; i < Length; i++)
            {
                SpaceObjects[i].PrintToConsole();
            }
        }

        public Planet GetMaxWeightPlanet()
        {
            Planet MaxPlanet = new Planet("None", 0, 0);
            for (int i = 0; i < Length; i++)
            {
                if (SpaceObjects[i] is SpaceGroup sg)
                {
                    Planet MaxPlanetInGroup = sg.GetMaxWeightPlanet();
                    if (MaxPlanetInGroup.GetWeight > MaxPlanet.GetWeight)
                        MaxPlanet = MaxPlanetInGroup;
                }
                else if (SpaceObjects[i] is Planet planet)
                {
                    if (planet.GetWeight > MaxPlanet.GetWeight)
                        MaxPlanet = planet;
                }
            }
            return MaxPlanet;
        }

        public Star GetMaxLingthStar()
        {
            Star MaxStar = new Star("None", 0, 0);
            for (int i = 0; i < Length; i++)
            {
                if (SpaceObjects[i] is SpaceGroup sg)
                {
                    Star MaxStarInGroup = sg.GetMaxLingthStar();
                    if (MaxStarInGroup.GetLight > MaxStar.GetLight)
                        MaxStar = MaxStarInGroup;
                }
                else if (SpaceObjects[i] is Star star)
                {
                    if (star.GetLight > MaxStar.GetLight)
                        MaxStar = star;
                }
            }
            return MaxStar;
        }

        public override float GetWeight
        {
            get
            {
                float ans = 0;
                for (int i = 0; i < Length; i++)
                {
                    ans += SpaceObjects[i].GetWeight;
                }
                return ans;
            }
        }

        public override string ToString()
        {
            string ans = "";
            for (int i = 0; i < Length; i++)
            {
                ans += SpaceObjects[i].ToString();
            }
            return base.ToString() + $"\n{Length}\n{ans}";
        }

        public override string ToString(int lvl)
        {
            string ans = "";
            for (int i = 0; i < Length; i++)
            {
                ans += SpaceObjects[i].ToString(lvl + 1);
            }
            return base.ToString(lvl) + $"\n{MakeSpace(lvl)}{Length}\n{ans}";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new SpaceGroupEnumerator(SpaceObjects);
        }
    }

    public class SpaceGroupEnumerator : IEnumerator
    {
        private List<SpaceObject> spaceObjects;

        private int position = -1;

        object IEnumerator.Current
        {
            get
            {
                if (position == -1 || position >= spaceObjects.Count)
                    throw new ArgumentException();
                return spaceObjects[position];
            }
        }

        public SpaceGroupEnumerator(List<SpaceObject> spaceObjects)
        {
            this.spaceObjects = spaceObjects;
        }

        bool IEnumerator.MoveNext()
        {
            if (position < spaceObjects.Count - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }
    }

    public class SingleSpaceObject : SpaceObject
    {
        protected float Weight; //вес

        /// <summary>
        /// Свойство Веса
        /// </summary>
        public override float GetWeight => Weight;

        /// <summary>
        /// Конструктор-1
        /// </summary>
        public SingleSpaceObject(string Name, float Weight) : base(Name)
        {
            this.Weight = Weight;
        }

        /// <summary>
        /// Вывод объекта в консоль
        /// </summary>
        public override void PrintToConsole()
        {
            base.PrintToConsole();
            System.Console.WriteLine(Weight);
        }

        /// <summary>
        /// Свойство типа
        /// </summary>
        public override string ThisType => "SingleSpaceObject";

    }

    public class Star : SingleSpaceObject
    {
        protected float Ligth; //светимость

        /// <summary>
        /// Свойство Светимости
        /// </summary>
        public float GetLight => Ligth;

        /// <summary>
        /// Конструктор-1
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Weight"></param>
        /// <param name="Light"></param>
        public Star(string Name, float Weight, float Ligth) : base(Name, Weight)
        {
            this.Ligth = Ligth;
        }

        /// <summary>
        /// Вывод объекта в консоль
        /// </summary>
        public override void PrintToConsole()
        {
            base.PrintToConsole();
            System.Console.WriteLine(Ligth);
        }

        /// <summary>
        /// Свойство типа
        /// </summary>
        public override string ThisType => "Star";

        /// <summary>
        /// Метод, возвращающий объект как строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + $"\n{Ligth}\n{Weight}\n";
        }

        public override string ToString(int lvl)
        {
            return base.ToString(lvl) + $"\n{MakeSpace(lvl)}{Ligth}\n{MakeSpace(lvl)}{Weight}\n";
        }

    }

    public class Planet : SingleSpaceObject
    {
        protected float Diameter; //диаметр

        /// <summary>
        /// Свойство Диаметра
        /// </summary>
        public float GetDiameter => Diameter;

        /// <summary>
        /// Конструктор-1
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Weight"></param>
        /// <param name="Diameter"></param>
        public Planet(string Name, float Weight, float Diameter) : base(Name, Weight)
        {
            this.Diameter = Diameter;
        }

        /// <summary>
        /// Вывод объекта в консоль
        /// </summary>
        public override void PrintToConsole()
        {
            base.PrintToConsole();
            System.Console.WriteLine(Diameter);
        }

        /// <summary>
        /// Свойство типа
        /// </summary>
        public override string ThisType => "Planet";

        /// <summary>
        /// Метод, возвращающий объект как строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString() + $"\n0\n{Weight}\n{Diameter}\n";
        }

        public override string ToString(int lvl)
        {
            return base.ToString(lvl) + $"\n{MakeSpace(lvl)}0\n{MakeSpace(lvl)}{Weight}\n{MakeSpace(lvl)}{Diameter}\n";
        }
    }
}

