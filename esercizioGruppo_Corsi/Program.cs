using System;


// Classe astratta: Corso
public abstract class Corso
{
    // Proprietà comuni
    private string _titolo;
    private int _durataOre;

    public string Titolo
    {
        get { return _titolo; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Errore: Il titolo del corso non può essere vuoto.");

            }
            else
            {
                _titolo = value;
            }
        }
    }

    public int DurataOre
    {
        get { return _durataOre; }
        set
        {
            if (value >= 0) // Controllo: DurataOre non può essere negativa
            {
                _durataOre = value;
            }
            else
            {
                Console.WriteLine("Errore: La durata in ore non può essere negativa. Il valore non è stato impostato.");
            
            }
        }
    }

    // Costruttore della classe astratta
    public Corso(string titolo, int durataOre)
    {
        // Utilizza le proprietà per impostare i valori, così le validazioni vengono applicate
        Titolo = titolo;
        DurataOre = durataOre;
    }

    public Corso(){}

    // Metodo astratto: ErogCorso()
    public abstract Corso ErogaCorso();

    // Metodo astratto: StampaDettagli()
    public abstract void StampaDettagli();
}

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

    public CorsoInPresenza() {}

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

    public override CorsoInPresenza ErogaCorso() // Override del metodo per erogare il corso in presenza
    {
        Console.WriteLine("Avvia il corso in presenza.");
        Console.WriteLine("Dettagli del corso:");
        Console.WriteLine("Inserisci il titolo del corso:");
        string titolo = Console.ReadLine();
        Console.WriteLine("Inserisci la durata del corso in ore:");
        int durataOre;
        while (!int.TryParse(Console.ReadLine(), out durataOre) || durataOre <= 0) // Se la conversione ha successo, il valore convertito viene assegnato alla variabile durataOre tramite il parametro out. Se fallisce, durataOre non viene modificato e il ciclo continua.
        {
            Console.WriteLine("La durata deve essere un numero positivo. Riprova:");
        }

        Console.WriteLine("Inserisci l'aula del corso:");
        string aula = Console.ReadLine();
        Console.WriteLine("Inserisci il numero di posti disponibili:");
        int numeroPosti;
        while (!int.TryParse(Console.ReadLine(), out numeroPosti) || numeroPosti <= 1)
        {
            Console.WriteLine("Il numero di posti deve essere maggiore di 1. Riprova:");
        }
        CorsoInPresenza corso = new
        CorsoInPresenza(titolo, durataOre, aula, numeroPosti);
        return corso; // Restituisce un'istanza di CorsoInPresenza con i dettagli inseriti
        Console.WriteLine("Il corso è stato creato con successo!");

    }

    public override void StampaDettagli() // Override del metodo per stampare i dettagli del corso in presenza
    {
        Console.WriteLine($"Corso in Presenza: {Titolo}, Durata: {DurataOre} ore, Aula: {Aula}, Numero Posti: {NumeroPosti}");
    }
}

public class CorsoOnline : Corso
{
    private string _piattaforma;

    private string _linkAccesso;

    public CorsoOnline(string titolo, int durataOre, string piattaforma, string link) : base(titolo, durataOre)
    {
        Piattaforma = piattaforma;
        LinkAccesso = link;
    }

    public CorsoOnline() {}
    

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

    public override CorsoOnline ErogaCorso()
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
        return corsoOnline;
        Console.WriteLine("Il corso è stato creato con successo!");
    }

    public override void StampaDettagli()
    {
        Console.WriteLine($"Corso: {Titolo}, durata ore: {DurataOre}, piattaforma: {Piattaforma}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Corso> corsi = new List<Corso>();

        bool x = true;

        // ciclo principale del menù
        do
        {
            Console.WriteLine("\n-- Menù --");
            Console.WriteLine("0. Esci");
            Console.WriteLine("1. Aggiungi un corso in presenza");
            Console.WriteLine("2. Aggiungi un corso online");
            Console.WriteLine("3. Stampa informazioni sui corsi");
            Console.Write("Scelta: ");
            int sceltamenu = int.Parse(Console.ReadLine());

            switch (sceltamenu)
            {
                case 0:
                    Console.WriteLine("Uscita dal programma.");
                    x = false; // Imposta x a false per uscire dal ciclo
                    break;

                case 1:
                    CorsoInPresenza cPres = new CorsoInPresenza();
                    cPres = cPres.ErogaCorso();
                    corsi.Add(cPres);
                    break;

                case 2:
                    CorsoOnline cOnline = new CorsoOnline();
                    cOnline = cOnline.ErogaCorso();
                    corsi.Add(cOnline);
                    break;

                case 3:
                    foreach (Corso c in corsi)
                    {
                        c.StampaDettagli();
                    }
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        }
        while (x);
    }
}




