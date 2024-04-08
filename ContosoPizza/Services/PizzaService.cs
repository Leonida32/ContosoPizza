using ContosoPizza.model;
namespace ContosoPizza.Services;

public static class PizzaService
{
    static List<Pizza> Pizzas { get; }
    static int NextId = 3;
    static PizzaService()
    {
        Pizzas = new List<Pizza>()
        {
            new Pizza() { Id = 1, Isglutenfree = true, Name = "hawaillana" },
            new Pizza() { Id = 2, Isglutenfree = false, Name = "La iluminatyy" }
        };
    }
    public static List<Pizza> GetAll() => Pizzas;
    public static Pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.Id == id );
    public static void Add(Pizza pizza)
    {
        pizza.Id = NextId++;
        Pizzas.Add(pizza);
    }
    public static void delete(int id )
    {
        var Pizza = Get(id);
        if (Pizza is null) return; Pizzas.Remove(Pizza);
    }
    public static void Update (Pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
        if (index == -1)
            return;
        Pizzas[index] = pizza;
    }

}
