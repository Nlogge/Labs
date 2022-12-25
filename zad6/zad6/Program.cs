
namespace Zad6
{
    class Program
    {
        static void Main()
        {
            Student[] studl = new Student[10];

            for (int i = 0; i < studl.Length; i++)
            {
                Student newStudent = Crstud();
                if (newStudent != null) studl[i] = newStudent;
                else break;
            }


            Console.WriteLine("\n--- Полный список студентов ---");
            All(studl);

            Console.WriteLine("\n--- Студенты только с отличными оценками ---");
            Good(studl, 5);

            Console.WriteLine("\n--- Студенты с неудовлетворительными оценками ---");
            BadStud(studl, 4);
        }

        
        private static void BadStud(Student[] studl, int bad)
        {
            foreach (Student student in studl)
            {
                if (student == null) break;

                for (int i = 0; i < student.scores.Count; i++)
                {
                    if (student.scores[i] <= bad)
                    {
                        Console.WriteLine(student);
                        break;
                    }
                }

            }
        }

        // Выводит студентов у которых все оценки выше заданного порога (minExellentScore)
        private static void Good(Student[] studl, int min)
        {
            
            foreach (Student student in studl)
            {
                if (student == null) break;

                bool onlyExellent = true;
                for (int i = 0; i < student.scores.Count; i++)
                {
                    if (student.scores[i] < min)
                    {
                        onlyExellent = false;
                        break;
                    }
                }

                if (onlyExellent)
                {
                    Console.WriteLine(student);
                }
            }
        }

        
        private static void All(Student[] studl)
        {

            foreach (Student student in studl)
            {
                if (student == null) break;

                Console.WriteLine(student);
            }
        }

        private static Student Crstud()
        {
            Console.Write("Создать нового студента? (y/n): ");
            if (Console.ReadLine() != "y")
            {
                return null;
            }

            Console.Write("ФИО: ");
            string fullName = Console.ReadLine();

            Console.Write("Оценки (через пробел): ");
           
            string[] scoresStringInput = Console.ReadLine().Trim().Split();

            
            List<int> scores = new List<int>();
            foreach (string score in scoresStringInput)
            {
                scores.Add(int.Parse(score));
            }

            Student student = new Student(fullName, scores);
            Console.WriteLine("Студент добавлен.");
            return student;
        }

    }

    public class Student
    {
        public string fullName;
        public List<int> scores;

        public Student(string fullName, List<int> scores = null)
        {
            this.fullName = fullName;

            this.scores = new List<int>();
            if (scores != null) this.scores.AddRange(scores);
        }

        public override string ToString()
        {
            return $"{fullName}: {string.Join(", ", scores)}"; //string.Join выводит элементы коллекции через заданный символ
        }
    }
}