using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class User_Random_DataBase<T>
{
    // a list of whatever information a casual user might want to store.
    //it has to be from one type though
    private List<T> storageList;
    private static Random rng = new Random();

    public User_Random_DataBase() { 
        storageList = new List<T>();
    }
    //------------------------------------ function to add an item to the List---------------------------------------
    public void AddToList (T item){

        //Preventing duplicates:
        if (storageList.Contains(item))
        {
            Console.WriteLine($"the item {item} is allready there");
        }
        else
        {
            storageList.Add(item);
        }
    }

    //------------------------------------ function to Randomize the Order of the List---------------------------------------
    public void Randomize()
    {
        // I used the Fisher-Yates algorithm
        int n = storageList.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = storageList[k];
            storageList[k] = storageList[n];
            storageList[n] = value;
        }
    }

    //------------------------------------ function to get the first element---------------------------------------
    public T GetFirst()
    {
        if (storageList.Count > 0)
            return storageList[0];
        else
            throw new InvalidOperationException("The list is empty.");
    }

    //--------------------------------- Function to print the list----------------------------------

    public void PrintList(){
        Console.WriteLine("--------------------");
       foreach (T item in storageList)
        {
            Console.WriteLine (item);
        }
        Console.WriteLine("--------------------");
    }

}

namespace Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //let's assume the user is a teacher, and he wants to store students names and them randomize them and pick one name
            //to make an election for the class president
            User_Random_DataBase < string> studentsNames = new User_Random_DataBase<string>();

            string name;
            Console.WriteLine("Enter the first student's name : ");
            name= Console.ReadLine();
            while (name.ToUpper() != "EXIT")
            {
                studentsNames.AddToList(name);

                Console.WriteLine("Enter another student's name, OR Enter (Exit) to stop adding names");
                name = Console.ReadLine();

            }

            Console.WriteLine("Let's Randomize the names of the students and pick one of them as a class president! ");
            studentsNames.Randomize();

            Console.WriteLine("List after Shuffling: ");
            studentsNames.PrintList();
            
            Console.WriteLine($"The class president is {studentsNames.GetFirst()} \n\\^_^/ Horray! Congrats {studentsNames.GetFirst()}!!!");

            Console.ReadKey();
        }
    }
}
