using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ZooStore;

public partial class MainWindow : Window
{
    
    public MainWindow()
    {
        InitializeComponent();

        DG.ItemsSource = DataAnimal.OtdelList.SelectMany(x => x.Animals).ToList();

        VidCB.ItemsSource = Enum.GetValues(typeof(TypeAnimal));
        StatusCB.ItemsSource = Enum.GetValues(typeof(StatusSale));

        OtdelCB.ItemsSource = DataAnimal.OtdelList.Select(x => x.OtdelName).ToList();
        AddCB.ItemsSource = DataAnimal.OtdelList.Select(x => x.OtdelName).ToList();
    }

    private void Filters()
    {
        var results = DataAnimal.OtdelList.SelectMany(x => x.Animals).ToList();
        
        if (OtdelCB.SelectionBoxItem != null)
        {
            results = DataAnimal.OtdelList.First(x => x.OtdelName == OtdelCB.Text).Animals;
        }
        
        if (!string.IsNullOrWhiteSpace(SearchPoroda.Text))
        {
           results = results.Where(x => x.Poroda.ToLower().Contains(SearchPoroda.Text, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        
        
        if (!string.IsNullOrWhiteSpace(SearchVid.Text))
        {
            results = results.Where(x => x.Vid.ToString().ToLower().Contains(SearchVid.Text.ToLower()))
                .ToList();
        }

        
        
        
        if (SortCB.SelectedIndex == 1)
        {
            results = results.OrderBy(x => x.Price).ToList();
        }
        else if (SortCB.SelectedIndex == 0)
        {
            results = results.OrderByDescending(x => x.Price).ToList();
        }

        DG.ItemsSource = results;

        if (results.ToList().Count == 0)
        {
            result.Text = "Нет животных, удовлетворяющих условиям поиска";
            return;
        }
        
        
        result.Text = $"Средняя стоимость животных: {results.Sum(x => x.Price)}\n" +
                      $"Самое дорогое животное: {results.Max(x => x.Price)}\n" +
                      $"Кошка: {results.Count(x => x.Vid == TypeAnimal.Кошка)}, " +
                      $"Собака: {results.Count(x => x.Vid == TypeAnimal.Собака)}," +
                      $" Птица: {results.Count(x => x.Vid == TypeAnimal.Птица)}," +
                      $" Рыба: {results.Count(x => x.Vid == TypeAnimal.Рыба)}, " +
                      $"Грызун: {results.Count(x => x.Vid == TypeAnimal.Грызун)}\n";

    }
    private void AddAnimal_OnClick(object? sender, RoutedEventArgs e)
    {
        AddsAnimal();
    }

    private void SearchPoroda_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        Filters();
    }

    private void SearchVid_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        Filters();
    }

    private void SelectingItemsControl_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
       Filters();
    }

    public void AddsAnimal()
    {
        var results = DataAnimal.OtdelList.SelectMany(x => x.Animals).ToList();
        
        if (AddCB.SelectedItem == null)
        {
            ResultAdd.Text = "Введите номер отдела";
            return;
        }
        if (string.IsNullOrWhiteSpace(NameAnimal.Text))
        {
            ResultAdd.Text = "Введите имя животного";
            return;
        }
        if (string.IsNullOrWhiteSpace(PorodaAnimal.Text))
        {
            ResultAdd.Text = "Введите породу животного";
            return;
        }
        if (VidCB.SelectedItem == null)
        {
            ResultAdd.Text = "Введите вид животного";
            return;
        }
        if (string.IsNullOrWhiteSpace(PriceAnimal.Text))
        {
            ResultAdd.Text = "Введите цену животного";
            return;
            
        }
        if (StatusCB.SelectedItem == null)
        {
            ResultAdd.Text = "Введите статус животного";
            return;
        }
        if (string.IsNullOrWhiteSpace(AgeAnimal.Text))
        {
            ResultAdd.Text = "Введите возраст животного";
            return;
        }
        if (string.IsNullOrWhiteSpace(WeightAnimal.Text))
        {
            ResultAdd.Text = "Введите вес животного";
            return;
        }
        if (!decimal.TryParse(PriceAnimal.Text, out decimal parsedPrice))
        {
            ResultAdd.Text = "Некорректный формат цены (нужно число)";
            return;
        }
        if (!int.TryParse(AgeAnimal.Text, out int parsedAge))
        {
            ResultAdd.Text = "Некорректный формат возраста";
            return;
        }
        if (!int.TryParse(WeightAnimal.Text, out int parsedWeight))
        {
            ResultAdd.Text = "Некорректный формат веса";
        }
        else
        {
            var otdel = DataAnimal.OtdelList.First(x => x.OtdelName == AddCB.Text);
            otdel.Animals.Add(new Animal()
            {
                Name = NameAnimal.Text,
                Poroda = PorodaAnimal.Text,
                Vid = (TypeAnimal)VidCB.SelectedItem,
                Price = parsedPrice,
                Status = (StatusSale)StatusCB.SelectedItem,
                VeterinarCard = new VeterinarCard(){Age = parsedAge, Weight = int.Parse(WeightAnimal.Text)}
            });
            DG.ItemsSource = null;
            ResultAdd.Text = "Успешное добавление";
            
            Filters();
        }
        
    }

    
}