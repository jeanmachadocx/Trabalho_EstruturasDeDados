public class CelulaCurso
{
    public Curso Elemento { get; set; }
    public CelulaCurso Prox { get; set; }

    public CelulaCurso()
    {
        Elemento = null;
        Prox = null;
    }

    public CelulaCurso(Curso elemento)
    {
        Elemento = elemento;
        Prox = null;
    }
}
