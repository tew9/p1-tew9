namespace PizzaBox.Domain.Abstracts
{
    public abstract class AComponents
    {
        public string Name { get; set; }
        public long Id {get; set; }

        public AComponents()
        {
            Name = "No Name Given";
        }
    }
}