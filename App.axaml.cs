using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using StudentApp.ViewModels;
using StudentApp.Views;
using StudentApp.Models;
using System.Collections.Generic;

namespace StudentApp;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            DisableAvaloniaDataAnnotationValidation();

            // Создаем экземпляр Student и передаем его в StudentViewModel
            var student = new Student(
                "Иванов", 
                "Иван", 
                DateTimeOffset.Now, // Используем DateTimeOffset
                1, 
                "Группа 101", 
                new Dictionary<int, Dictionary<string, List<int>>>()
            );

            desktop.MainWindow = new MainWindow
            {
                DataContext = new StudentViewModel(student), // Передаем DataContext через код
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}