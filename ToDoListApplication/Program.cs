namespace TO_DO_LIST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");

            List<String> toDoList = new List<String>();

            bool exitApplication = false;
            while (exitApplication != true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("[S]ee all TODOs");
                Console.WriteLine("[A]dd a TODO");
                Console.WriteLine("[R]emove a TODO");
                Console.WriteLine("[E]xit");

                var UserInput = Console.ReadLine();
                if (EqualsCaseSensitive(UserInput, "S"))
                {
                    seeAllToDo();

                }
                else if (EqualsCaseSensitive(UserInput, "A"))
                {
                    addToDo();
                }
                else if (EqualsCaseSensitive(UserInput, "R"))
                {
                    removeToDo();
                }
                else if (EqualsCaseSensitive(UserInput, "E"))
                {
                    exitApplication = true;
                }
            }

            bool EqualsCaseSensitive(string left, string right)
            {
                return left.ToUpper() == right.ToUpper();
            }

            void addToDo()
            {
                bool validdescription = false;
                while (!validdescription)
                {
                    Console.WriteLine("Enter TODO description");
                    string description = Console.ReadLine();
                    if (description == "")
                    {
                        Console.WriteLine("The decription cannot be empty");
                    }
                    else if (toDoList.Contains(description))
                    {
                        Console.WriteLine("The decription cannot be the same");
                    }
                    else
                    {
                        toDoList.Add(description);
                        validdescription = true;
                    }
                }

            }

            void seeAllToDo()
            {
                if (toDoList.Count == 0)
                {
                    Console.WriteLine("No TODOs have been added yet.");
                }
                else
                {
                    int i = 0;
                    foreach (var item in toDoList)
                    {
                        i++;
                        Console.WriteLine($"{i}. {item}");
                    }
                }
            }

            void removeToDo()
            {
                if (toDoList.Count == 0)
                {
                    Console.WriteLine("No todos have been added");
                    return;
                }
                bool indexValid = false;
                while (!indexValid)
                {
                    Console.WriteLine("Select the index of the TODO you want to remove");
                    seeAllToDo();
                    var userInput = Console.ReadLine();
                    if (userInput == "")
                    {
                        Console.WriteLine("Selected index cannot be empty");
                    }
                    if (int.TryParse(userInput, out int index) && index >= 1 && index <= toDoList.Count)
                    {
                        var todoToBeRemoved = toDoList[index - 1];
                        toDoList.RemoveAt(index - 1);
                        indexValid = true;
                        Console.WriteLine("TODO removed " + todoToBeRemoved);
                    }
                    else
                    {
                        Console.WriteLine("The index is not valid");
                    }
                }
            }
        }
    }
}