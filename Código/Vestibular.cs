using System;
using System.IO;
using System.Collections.Generic;
using System.CodeDom;

public class Vestibular
{
    private ListaCursos cursos;
    private Candidato[] candidatos;
    private int qtdCursos;
    private int qtdCandidatos;

    public Vestibular(ListaCursos cursos, Candidato[] candidatos, int qtdCursos, int qtdCandidatos)
    {
        this.cursos = new ListaCursos();
        this.candidatos = candidatos;
        this.qtdCursos = qtdCursos;
        this.qtdCandidatos = qtdCandidatos;
    }

    public void LerEntrada(string nomeArq)
    {
        using (StreamReader arqLeit = new StreamReader(nomeArq))
        {
            string linha = arqLeit.ReadLine();
            string[] cursoAluno = linha.Split(';');
            qtdCursos = int.Parse(cursoAluno[0]);
            qtdCandidatos = int.Parse(cursoAluno[1]);

            for (int i = 0; i < qtdCursos; i++)
            {
                linha = arqLeit.ReadLine();
                string[] dadosCurso = linha.Split(';');

                int codigoCurso = int.Parse(dadosCurso[0]);
                string nomeCurso = dadosCurso[1];
                int vagasCurso = int.Parse(dadosCurso[2]);

                if (vagasCurso <= 0)
                {
                    throw new Exception("Verifique a quantidade de vagas!");
                }

                Curso curso = new Curso(codigoCurso, nomeCurso, vagasCurso);
                cursos.InserirFim(curso);
            }

            this.candidatos = new Candidato[qtdCandidatos];

            for (int i = 0; i < qtdCandidatos; i++)
            {
                linha = arqLeit.ReadLine();
                string[] dadosCandidato = linha.Split(';');

                string nomeCandidato = dadosCandidato[0];
                double notaRed = double.Parse(dadosCandidato[1]);
                    
                
                double notaMat = double.Parse(dadosCandidato[2]);
                double notaLing = double.Parse(dadosCandidato[3]);

                if (notaLing < 0 || notaMat < 0 || notaRed < 0)
                {
                    throw new Exception(" A nota não pode ser negativa");
                }
                int opcao1 = int.Parse(dadosCandidato[4]);
                int opcao2 = int.Parse(dadosCandidato[5]);

                Candidato candidato = new Candidato(nomeCandidato, notaRed, notaMat, notaLing, opcao1, opcao2);
                candidatos[i] = candidato;
            }
        }
    }


    public void CalcularClassificacao()
    {
        OrdenarCandidatos();

        foreach (var candidato in candidatos)
        {
            Curso cursoOpcao1 = cursos.Pesquisar(candidato.GetOp1());
            Curso cursoOpcao2 = cursos.Pesquisar(candidato.GetOp2());

            bool selecionadoOpcao1 = cursoOpcao1 != null && cursoOpcao1.InserirListaSelecionados(candidato);
            if (!selecionadoOpcao1)
            {
                cursoOpcao1?.InserirFilaEspera(candidato);
            }

            
            if (!selecionadoOpcao1 && cursoOpcao1 != cursoOpcao2)
            {
                bool selecionadoOpcao2 = cursoOpcao2 != null && cursoOpcao2.InserirListaSelecionados(candidato);
                if (!selecionadoOpcao2)
                {
                    cursoOpcao2?.InserirFilaEspera(candidato);
                }
            }
        }
    }



    private void OrdenarCandidatos()
    {
        Mergesort(candidatos, 0, candidatos.Length - 1);
    }

    private void Mergesort(Candidato[] array, int esq, int dir)
    {
        if (esq < dir)
        {
            int meio = (esq + dir) / 2;
            Mergesort(array, esq, meio);
            Mergesort(array, meio + 1, dir);
            Intercalar(array, esq, meio, dir);
        }
    }

    private void Intercalar(Candidato[] array, int esq, int meio, int dir)
    {
        int nEsq = meio - esq + 1;
        int nDir = dir - meio;

        Candidato[] arrayEsq = new Candidato[nEsq];
        Candidato[] arrayDir = new Candidato[nDir];

        Array.Copy(array, esq, arrayEsq, 0, nEsq);
        Array.Copy(array, meio + 1, arrayDir, 0, nDir);

        int iEsq = 0, iDir = 0, i = esq;

        while (iEsq < nEsq && iDir < nDir)
        {
            if (arrayEsq[iEsq].GetMedia() > arrayDir[iDir].GetMedia() ||
                (arrayEsq[iEsq].GetMedia() == arrayDir[iDir].GetMedia() && arrayEsq[iEsq].GetNotaRed() >= arrayDir[iDir].GetNotaRed()))
            {
                array[i] = arrayEsq[iEsq++];
            }
            else
            {
                array[i] = arrayDir[iDir++];
            }
            i++;
        }

        while (iEsq < nEsq)
        {
            array[i++] = arrayEsq[iEsq++];
        }

        while (iDir < nDir)
        {
            array[i++] = arrayDir[iDir++];
        }
    }


    public void EscreverSaida(string nomeArq)
    {
        using (StreamWriter arqEscrita = new StreamWriter(nomeArq, false, System.Text.Encoding.UTF8))
        {
            arqEscrita.WriteLine(cursos.Mostrar());
        }
    }
}

