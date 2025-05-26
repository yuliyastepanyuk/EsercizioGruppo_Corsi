using System;
using System.ComponentModel;

// Classe astratta: Corso
// Classe astratta: Corso


class CorsoOnline : Corso
{
    private string _piattaforma;

    private string _linkAccesso;

    public CorsoOnline(string titolo, int durataOre, string piattaforma, string link) : base(titolo, durataOre)
    {
        Piattaforma = piattaforma;
        LinkAccesso = link;
    }

    public string Piattaforma
    {
        get { return _piattaforma; }
        set { _piattaforma = value; }
    }

    public string LinkAccesso
    {
        get { return _linkAccesso; }
        set { _linkAccesso = value; }
    }

    public override void ErogaCorso()
    {
        Console.WriteLine("Avvia il corso da remoto.");
        Console.WriteLine("Dettagli del corso:");
        Console.WriteLine("Inserisci il titolo del corso:");
        string titolo = Console.ReadLine();
        Console.WriteLine("Inserisci la durata del corso in ore:");
        int durataOre;
        while (!int.TryParse(Console.ReadLine(), out durataOre) || durataOre <= 0)
        {
            Console.WriteLine("La durata deve essere un numero positivo. Riprova:");
        }

        Console.WriteLine("Inserisci la piattaforma del corso:");
        string p = Console.ReadLine();
        Console.WriteLine("Inserisci il link di accesso del corso:");
        string l = Console.ReadLine();

        CorsoOnline corsoOnline = new CorsoOnline(titolo, durataOre, p, l);
        Console.WriteLine("Il corso è stato creato con successo!");
    }

    public override void StampaDettagli()
    {
        Console.WriteLine($"Corso: {Titolo}, durata ore: {DurataOre}, piattaforma: {Piattaforma}");
    }
}

