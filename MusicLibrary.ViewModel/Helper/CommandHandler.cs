﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicLibrary.Helper
{
    public class CommandHandler : ICommand
    {
            private readonly Action _execute; // Réprésente une méthode void()

            public CommandHandler(Action execute, Func<bool> value)
            {
                _execute = execute;
            }

            public event EventHandler? CanExecuteChanged
            {
                add // Méthode exécutée lors de l'abonnement à l'évènement
                {
                    // VIDE car aucune liste d'abonnés en mémoire
                }
                remove // Méthode exécutée lors du désabonnement
                {
                    // VIDE car aucune liste d'abonnés en mémoire
                }
            }

            // Détermine si l'opération est disponible (bouton grisé ou non)
            public bool CanExecute(object? parameter)
            {
                return true;
            }

            public void Execute(object? parameter)
            {
                _execute();
            }
        
    }
}
