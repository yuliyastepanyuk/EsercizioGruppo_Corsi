using System;

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

    // Metodo astratto: ErogCorso()
    // Deve essere implementato da ogni classe derivata.
    public abstract void ErogCorso();

    // Metodo astratto: StampaDettagli()
    // Deve essere implementato da ogni classe derivata.
    public abstract void StampaDettagli();
}


public class Program
{
    public static void Main(string[] args)
    {

    }
}







