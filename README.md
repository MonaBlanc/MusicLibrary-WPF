
# Music Library (Bibliothèque Musicale)

Le projet **Bibliothèque Musicale** est une application WPF qui permet aux utilisateurs de gérer une collection d'albums de musique et de leurs pistes. Elle offre des fonctionnalités pour ajouter, supprimer et modifier des albums et des pistes, ainsi que la possibilité d'ouvrir une nouvelle fenêtre pour afficher des informations détaillées sur un album sélectionné.

## Prérequis
- .NET Framework (version 6.0 ou supérieure)
- Visual Studio 2022

## Dépendances

Le projet utilise la bibliothèque *MahApps.Metro.IconPacks* pour fournir un ensemble d'icônes. Assurez-vous d'installer la dépendance avant d'exécuter le projet.

##Pour commencer
Pour commencer avec le projet **Bibliothèque Musicale**, suivez ces étapes :

1. Récupérez l'archive fournie.
2. Ouvrez la solution dans Visual Studio.
3. Restaurez les packages NuGet si nécessaire.
4. Compilez la solution.
5. Exécutez l'application.

## Structure du projet
Le projet se compose des composants suivants :

***View*** (namespace : *MusicLibrary.View*) : Vous devez créer les vues correspondantes aux modèles de vue pour définir l'interface utilisateur.

***ViewModel*** (namespace  : *MusicLibrary.ViewModel*) : Contient les classes de vue modèle responsables de la logique et de la liaison de données dans l'application.

***Model*** (namespace : *MusicLibrary.Model*) : Définit les modèles de données utilisés dans l'application, tels que Album et Track.

***Helper*** (namespace : *MusicLibrary.Helper*) : Contient des classes d'aide, y compris la classe CommandHandler utilisée pour implémenter les commandes.

## Utilisation
La classe principale de vue modèle est ***VmMusicAlbum***, qui représente la logique et les données de la vue principale de l'application. Elle offre les fonctionnalités suivantes :

- **AddNewAlbum** : Ajoute un nouvel album à la collection.
- **DeleteAlbum** : Supprime l'album actuellement sélectionné de la collection.
- **AddNewTrack** : Ajoute une nouvelle piste à l'album actuellement sélectionné.
- **DeleteTrack** : Supprime la piste actuellement sélectionnée de l'album actuellement sélectionné.
- **OpenNewWindow** : Ouvre une nouvelle fenêtre pour afficher des informations détaillées sur l'album sélectionné.

Le modèle de vue interagit avec la vue via l'interface ***IMainView***, qui définit les méthodes permettant d'afficher des erreurs et d'ouvrir de nouvelles fenêtres.

L'application suit le modèle architectural MVVM (Modèle-Vue-Modèle de vue), qui sépare donc le projet en deux modules.
## Auteurs

- [@Kimberley Jacquemot](https://github.com/MonaBlanc)
- [@Ayoub Ech Chamali](https://github.com/Draxx023)

