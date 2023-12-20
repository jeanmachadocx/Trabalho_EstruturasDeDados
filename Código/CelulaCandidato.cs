using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CelulaCandidato
{
    public Candidato Elemento { get; set; }
    public CelulaCandidato Prox { get; set; }

    public CelulaCandidato(Candidato elemento)
    {
        Elemento = elemento;
        Prox = null;
    }
}
