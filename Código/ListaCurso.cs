using System;
using System.Collections.Generic;
using System.Text;

public class ListaCursos
{
    private Dictionary<int, Curso> cursos;

    public ListaCursos()
    {
        cursos = new Dictionary<int, Curso>();
    }

    public void InserirFim(Curso c)
    {
        cursos[c.Cod] = c;
    }

    public string Mostrar()
    {
        string resultado = "Processo seletivo da Universidade Stark\n\n";

        foreach (var curso in cursos.Values)
        {
            resultado += $"{curso.Nome} {curso.CalcularMenorNotaSelecionados():0.00}\n";
            resultado += "Selecionados:\n";
            foreach (var candidato in curso.ListaSelecionados)
            {
                resultado += $"{candidato.Nome} {candidato.GetMedia():0.00}\n";
            }
            resultado += "Fila de Espera:\n";
            foreach (var candidato in curso.ObterFilaEspera())
            {
                resultado += $"{candidato.Nome} {candidato.GetMedia():0.00}\n";
            }
            resultado += "\n";
        }

        return resultado;
    }
    public Curso Pesquisar(int codCurso)
    {
        if (cursos.TryGetValue(codCurso, out var curso))
        {
            return curso;
        }

        return null;
    }
}
