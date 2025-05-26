using System;
using System.Collections.Generic;

public class CorsoInPresenza : Corso // Classe concreta derivata da Corso
{
    private string Aula; // Campo privato per l'aula
    private int NumeroPosti; // Campo privato per il numero di posti

    public CorsoInPresenza(string titolo, int durataOre, string aula, int numeroPosti)  // Costruttore che accetta titolo, durata, aula e numero di posti
        : base(titolo, durataOre)
    {
        Aula = aula;
        NumeroPosti = numeroPosti;
    }

    public int numeroPosti // Proprietà per accedere e modificare il numero di posti
    {
        get
        {
            return NumeroPosti;
        }
        set
        {
            if (value > 1) // Controllo che il numero di posti sia maggiore di 1
            {
                NumeroPosti = value;
            }
            else
            {
                Console.WriteLine("Il numero di posti deve essere maggiore di 1."); // Messaggio di errore se il numero di posti non è valido
            }
        }
    }

    public string aula
    {
        get
        {
            return Aula;
        }
        set
        {
            if (!string.IsNullOrEmpty(value)) // Controllo che l'aula non sia vuota
            {
                Aula = value;
            }
            else
            {
                Console.WriteLine("L'aula non può essere vuota.");
            }
        }
    }

    public override void ErogaCorso() // Override del metodo per erogare il corso in presenza
    {
        Console.WriteLine("Avvia il corso in presenza.");
        Console.WriteLine("Dettagli del corso:");
        Console.WriteLine("Iserisci il titolo del corso:");
        string titolo = Console.ReadLine();
        Console.WriteLine("Iserisci la durata del corso in ore:");
        int durataOre;
        while (!int.TryParse(Console.ReadLine(), out durataOre) || durataOre <= 0) // Se la conversione ha successo, il valore convertito viene assegnato alla variabile durataOre tramite il parametro out. Se fallisce, durataOre non viene modificato e il ciclo continua.
        {
            Console.WriteLine("La durata deve essere un numero positivo. Riprova:");
        }

        Console.WriteLine("Iserisci l'aula del corso:");
        string aula = Console.ReadLine();
        Console.WriteLine("Iserisci il numero di posti disponibili:");
        int numeroPosti;
        while (!int.TryParse(Console.ReadLine(), out numeroPosti) || numeroPosti <= 1)
        {
            Console.WriteLine("Il numero di posti deve essere maggiore di 1. Riprova:");
        }
        CorsoInPresenza corso = new
        CorsoInPresenza(titolo, durataOre, aula, numeroPosti);
        Console.WriteLine("Il corso è stato creato con successo!");


    }

    public override void StampaDettagli() // Override del metodo per stampare i dettagli del corso in presenza
    {
        Console.WriteLine($"Corso in Presenza: {Titolo}, Durata: {DurataOre} ore, Aula: {Aula}, Numero Posti: {NumeroPosti}");
    }
}

public class Docente // Extra
{
    private string Nome;
    private string Materia;

    public Docente(string nome, string materia)
    {
        Nome = nome;
        Materia = materia;
    }

    public string nome
    {
        get { return Nome; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                Nome = value;
            }
            else
            {
                Console.WriteLine("Il nome del docente non può essere vuoto.");
            }
        }
    }

    public string materia
    {
        get { return Materia; }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                Materia = value;
            }
            else
            {
                Console.WriteLine("La materia del docente non può essere vuota.");
            }
        }
    }

}
