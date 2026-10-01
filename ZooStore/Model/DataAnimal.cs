using System.Collections.Generic;

namespace ZooStore;

public class DataAnimal
{
    public static List<Otdel> OtdelList = new List<Otdel>()
    {
        new Otdel()
        {
            OtdelName = "Отдел1", Animals = new List<Animal>()
            {
                new() {Name = "Тузик", Poroda = "Овчарка", Vid = TypeAnimal.Собака, Price = 2000, Status = StatusSale.Забронирован, VeterinarCard = new VeterinarCard(){Age = 20, Weight = 120}},
                new() {Name = "Шарик", Poroda = "Сиамская", Vid = TypeAnimal.Кошка, Price = 1000, Status = StatusSale.В_продаже, VeterinarCard = new VeterinarCard(){Age = 15, Weight = 170}},
                new() {Name = "Хохол", Poroda = "Ворон", Vid = TypeAnimal.Птица, Price = 2000, Status = StatusSale.Продан, VeterinarCard = new VeterinarCard(){Age = 10, Weight = 190}}
            
            }
        },
        
        new Otdel()
        {
            OtdelName = "Отдел2", Animals = new List<Animal>()
            {
                new() {Name = "Еврей", Poroda = "Треска", Vid = TypeAnimal.Рыба, Price = 2000, Status = StatusSale.Забронирован, VeterinarCard = new VeterinarCard(){Age = 40, Weight = 120}},
                new() {Name = "Барон", Poroda = "Немецкая овчарка", Vid = TypeAnimal.Собака, Price = 3500, Status = StatusSale.В_продаже, VeterinarCard = new VeterinarCard(){Age = 24, Weight = 340}},
                new() {Name = "Буся", Poroda = "Лабрадор", Vid = TypeAnimal.Грызун, Price = 4000, Status = StatusSale.Продан, VeterinarCard = new VeterinarCard(){Age = 36, Weight = 280}},
            }
        },
        
        
        new Otdel()
        {
            OtdelName = "Отдел3", Animals = new List<Animal>()
            {
                new() {Name = "Мурка", Poroda = "Персидская", Vid = TypeAnimal.Кошка, Price = 1500, Status = StatusSale.В_продаже, VeterinarCard = new VeterinarCard(){Age = 18, Weight = 45}},
                new() {Name = "Снежок", Poroda = "Мейн-кун", Vid = TypeAnimal.Кошка, Price = 5000, Status = StatusSale.Забронирован, VeterinarCard = new VeterinarCard(){Age = 12, Weight = 60}},
                
            }
        },
        
    };
}
