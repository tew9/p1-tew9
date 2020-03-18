using System.Collections.Generic;

namespace PizzaBox.ORMData.Interfaces
{
    //because each of them will be implemented differently by each class who implements them
    //To have an abstract class that implement them will require the db context to exist as generic

    //Generic type because operations will operate on different types of data and objects
    public interface IOperations<T>
    {
        List<T> Get();
        bool Post(T t);   

    }
}