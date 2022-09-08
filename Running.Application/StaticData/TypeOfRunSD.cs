using System;
using Running.Domain.Entities;

namespace Running.Application.StaticData;

public static class TypeOfRunSD
{
    public static string BC1 = "BC1";
    public static string BC2 = "BC2";
    public static string BC3 = "BC3";
    public static string Rythm = "Przebieżki";
    public static string Base = "Trucht";
    public static string RunningTrip = "Wycieczka biegowa!";
    public static string Meeting = "Zawody";



    public static List<TypeOfRun> TypeOfRunList = new()
    {
        new TypeOfRun
        {
            Name = BC1,
            Description = "Swobodny bieg ciągły, pozwalający na rozmowę."
        },
        new TypeOfRun
        {
            Name = BC2,
            Description = "Bieg ciągły w drugim zakresie. Wysiłek na poziomie 80-85%."
        },
        new TypeOfRun
        {
            Name = BC3,
            Description = "Bieg ciągły w trzecim zakresie. Wysiłek na poziomie 90-95%"
        },
        new TypeOfRun
        {
            Name = Rythm,
            Description = "Krótki bieg szybki. Od 100 do 200m."
        },
        new TypeOfRun
        {
            Name = Base,
            Description = "Bardzo wolny bieg, tylko rozgrzewka."
        },
        new TypeOfRun
        {
            Name = RunningTrip,
            Description = "Wycieczka biegowa. Bardzo długi bieg, może być przerywany marszem."
        },
        new TypeOfRun
        {
            Name = Meeting,
            Description = "Start w zawodach"
        },

    };

}

