1. Installer les bibliothèques NI pour C#
Avant de commencer, assure-toi d’avoir les drivers et SDK nécessaires :

Ouvre NI Package Manager

Va dans l’onglet Parcourir et cherche NI-DAQmx

Installe NI-DAQmx .NET Support (cela ajoute les DLL pour C#)

Si tu ne trouves pas NI-DAQmx .NET, tu peux aussi installer Measurement Studio (optionnel mais pratique).

2. Créer un projet C# sous Visual Studio
Ouvre Visual Studio

Crée un nouveau projet Console (.NET Framework)

Ajoute la référence NI-DAQmx :

Clic droit sur ton projet → "Ajouter une référence"

Va dans "Assemblies -> Extensions"

Sélectionne NationalInstruments.DAQmx
