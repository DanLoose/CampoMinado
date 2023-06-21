enum EstadoCelula
{
    Fechada,
    Aberta,
    Marcada
}

class Celula
{
    public EstadoCelula Estado { get; private set; }
    public bool TemMina { get; private set; }

    public Celula()
    {
        Estado = EstadoCelula.Fechada;
        TemMina = false;
    }

    public void Abrir()
    {
        Estado = EstadoCelula.Aberta;
    }

    public void DefinirMina()
    {
        TemMina = true;
    }

    public void Marcar()
    {
        if (Estado == EstadoCelula.Fechada)
        {
            Estado = EstadoCelula.Marcada;
        }
    }
}