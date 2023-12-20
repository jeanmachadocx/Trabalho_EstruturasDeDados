using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Curso
{
    public int Cod { get; set; }
    public string Nome { get; set; }
    public int QuantVagas { get; set; }
    public List<Candidato> ListaSelecionados { get; set; }

    private CelulaCandidato filaEsperaInicio;
    private CelulaCandidato filaEsperaFim;

    public Curso(int cod, string nome, int quantVagas)
    {
        Cod = cod;
        Nome = nome;
        QuantVagas = quantVagas;
        ListaSelecionados = new List<Candidato>();
        filaEsperaInicio = null;
        filaEsperaFim = null;
    }

    public void InserirFilaEspera(Candidato cand)
    {
        CelulaCandidato novaCelula = new CelulaCandidato(cand);

        if (filaEsperaInicio == null)
        {
            filaEsperaInicio = filaEsperaFim = novaCelula;
        }
        else
        {
            filaEsperaFim.Prox = novaCelula;
            filaEsperaFim = novaCelula;
        }
    }

   
    
    public bool InserirListaSelecionados(Candidato cand)
    {
        if (ListaSelecionados.Count < QuantVagas)
        {
            ListaSelecionados.Add(cand);
            return true;
        }
        else if (cand.GetMedia() > CalcularMenorNotaSelecionados())
        {
            ListaSelecionados.RemoveAt(ListaSelecionados.Count - 1);
            ListaSelecionados.Add(cand);
            return true;
        }
        return false;
    }


    public double CalcularMenorNotaSelecionados()
    {
        if (ListaSelecionados.Count == 0)
        {
            return 0; 
        }
        else
        {
            return ListaSelecionados.Min(c => c.GetMedia()); 
        }
    }

    public override string ToString()
    {
        string resultado = $"{Nome} {CalcularMenorNotaSelecionados():0.00}\n";
        resultado += "Selecionados\n";
        foreach (var candidato in ListaSelecionados)
        {
            resultado += $"{candidato.Nome} {candidato.GetMedia():0.00}\n";
        }

        resultado += "Fila de Espera\n";
        foreach (var candidato in ObterFilaEspera())
        {
            resultado += $"{candidato.Nome} {candidato.GetMedia():0.00}\n";
        }

        return resultado;
    }

    public List<Candidato> ObterFilaEspera()
    {
        List<Candidato> fila = new List<Candidato>();
        CelulaCandidato atual = filaEsperaInicio;
        while (atual != null)
        {
            fila.Add(atual.Elemento);
            atual = atual.Prox;
        }
        return fila;
    }
}

